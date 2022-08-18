using ST.GitHub.DemoAppStoreAdapter.Common;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Tests.Unit.SignedTransactionMocks
{
    internal class SignedTransactionBuilder
    {
        private readonly string _rootCertificatePath;
        private readonly string _intermeadiateCertificatePath;
        private readonly string _signingCertificatePath;
        private readonly string _signingPrivateKeyPath;

        public SignedTransactionBuilder(
            string rootCertificatePath,
            string intermeadiateCertificatePath,
            string signingCertificatePath,
            string signingPrivateKeyPath)
        {
            _rootCertificatePath = rootCertificatePath;
            _intermeadiateCertificatePath = intermeadiateCertificatePath;
            _signingCertificatePath = signingCertificatePath;
            _signingPrivateKeyPath = signingPrivateKeyPath;
        }

        public Task<string> SignAsJwsAsync<TPayload>(TPayload payload)
            => BuildJwsHeaderAsync(_rootCertificatePath, _intermeadiateCertificatePath, _signingCertificatePath)
                .MapAsync(_ => BuildJwsAsync(_, payload, _signingPrivateKeyPath));

        private static async Task<string> BuildJwsAsync<TObject>(
            IDictionary<string, object> header,
            TObject payload,
            string signingKeyPath)
        {
            var toSign = JsonSerializer
                .Serialize(header)
                .Map(ToRfc7515Base64)
                .Map(_ => JsonSerializer
                          .Serialize(payload)
                          .Map(ToRfc7515Base64)
                          .Map(__ => $"{_}.{__}"));

            return $"{toSign}.{await CalculateSignatureAsync(signingKeyPath, toSign)}";
        }

        private static async Task<IDictionary<string, object>> BuildJwsHeaderAsync(
            string rootCertificatePath,
            string intermeadiateCertificatePath,
            string signingCertificatePath)
        {
            var (rootCertTask,
                 intermediateCertTask,
                 signingCertTask) = (GetCertificatePemAsync(rootCertificatePath),
                                     GetCertificatePemAsync(intermeadiateCertificatePath),
                                     GetCertificatePemAsync(signingCertificatePath));

            return new Dictionary<string, object>
            {
                { "alg", "ES256"},
                { "x5c", new string[]{ await signingCertTask,
                                       await intermediateCertTask,
                                       await rootCertTask } }
            };
        }

        private static Task<string> GetCertificatePemAsync(string path)
            => File.ReadAllBytesAsync(path)
                .MapAsync(_ => PemEncoding.Write("CERTIFICATE", _).AsTask())
                .MapAsync(_ => new string(_).AsTask())
                .MapAsync(_ => _.Split('-', StringSplitOptions.RemoveEmptyEntries)[1].AsTask())
                .MapAsync(_ => _.Replace("\n", string.Empty).AsTask());

        private static async Task<string> CalculateSignatureAsync(string signingKeyPath, string @string)
        {
            using var key = ECDsa.Create();
            key.ImportFromPem(await File.ReadAllTextAsync(signingKeyPath));

            return key
            .SignData(@string.Map(Encoding.UTF8.GetBytes), HashAlgorithmName.SHA256)
            .Map(ToRfc7515Base64);
        }

        private static string ToRfc7515Base64(string @string)
            => @string
            .Map(Encoding.UTF8.GetBytes)
            .Map(ToRfc7515Base64);

        private static string ToRfc7515Base64(byte[] bytes)
            => bytes
            .Map(Convert.ToBase64String)
            .Map(_ => _.Replace("+", "-"))
            .Map(_ => _.Replace("/", "_"))
            .Map(_ => _.Replace("=", ""));
    }
}
