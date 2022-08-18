
using ST.GitHub.DemoAppStoreAdapter.Common;
using System.Text.Json;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Tests.Unit.SignedTransactionMocks
{
    public class AppStoreSignedTransactionFactory
    {
        private const string RootCertificatePath = "Certificates/certificate_root.cer";
        private const string IntermeadiateCertificatePath = "Certificates/certificate_intermediate.cer";
        private const string SigningCertificatePath = "Certificates/certificate_signing.cer";
        private const string SigningPrivateKeyPath = "Certificates/signing.key";

        private readonly SignedTransactionBuilder _signedTransactionBuilder;

        public AppStoreSignedTransactionFactory()
        {
            _signedTransactionBuilder = new SignedTransactionBuilder(RootCertificatePath,
                                                                     IntermeadiateCertificatePath,
                                                                     SigningCertificatePath,
                                                                     SigningPrivateKeyPath);
        }

        public async Task<string> BuildTestSignedTransactionAsync()
        {
            var signedTransactionInfoJws = await BuildSignedTransactionInfo()
                .Map(_signedTransactionBuilder.SignAsJwsAsync);

            var signedRenewalInfoJws = await BuildSignedRenewalInfo()
                .Map(_signedTransactionBuilder.SignAsJwsAsync);

            var result = await BuildSignedTransactionAsync(NotificationType.Test, signedTransactionInfoJws, signedRenewalInfoJws);

            return result;
        }

        private Task<string> BuildSignedTransactionAsync(NotificationType type, string signedTransactionInfo, string signedRenewalInfo)
            => BuildSignedTransactionAsync(type, null, signedTransactionInfo, signedRenewalInfo);

        private Task<string> BuildSignedTransactionAsync(NotificationType type, NotificationSubtype? subtype, string signedTransactionInfo, string signedRenewalInfo)
            => new SignedPayload(type, subtype, Guid.NewGuid().ToString(), BuildNotificationData(signedTransactionInfo, signedRenewalInfo), "2.0", DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            .Map(_signedTransactionBuilder.SignAsJwsAsync)
            .MapAsync(_ => new AppStoreNotificationRaw(_))
            .MapAsync(_ => JsonSerializer.Serialize(_));

        private static NotificationDataRaw BuildNotificationData(string signedTransactionInfo, string signedRenewalInfo)
            => new(null, "github.truchlik.slavomir.test", "0.0.1", "localhost", signedTransactionInfo, signedRenewalInfo);

        private static SignedTransactionInfo BuildSignedTransactionInfo()
            => new(
                Guid.NewGuid().ToString(),
                "github.truchlik.slavomir.test",
                "localhost",
                DateTimeOffset.UtcNow.AddDays(3).ToUnixTimeSeconds(),
                "PURCHASED",
                null,
                null,
                null,
                DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeSeconds(),
                "9900000084529325",
                "github.truchlik.slavomir.test.subscription",
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                null,
                null,
                null,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                "10520933",
                "9900000084522805",
                "Auto-Renewable Subscription",
                null);

        private static SignedRenewalInfo BuildSignedRenewalInfo()
                => new(
                    "github.truchlik.slavomir.test.subscription",
                    AutoRenewStatus.On,
                    "localhost",
                    null,
                    null,
                    null,
                    null,
                    null,
                    "9900000084529325",
                    null,
                    "github.truchlik.slavomir.test.subscription",
                    DateTimeOffset.UtcNow.AddMonths(-1).ToUnixTimeSeconds(),
                    DateTimeOffset.UtcNow.ToUnixTimeSeconds());

    }
}
