using System.Text;
using TinyFp.Extensions;

namespace ST.GitHub.DemoAppStoreAdapter.Common
{
    public static class StringExtensions
    {
        public static string FromBase64String(this string base64Encoded)
            => base64Encoded.
                ToOption().
                Match(FromBase64StringInternal, () => base64Encoded);

        private static string FromBase64StringInternal(string base64Encoded)
            => base64Encoded
                .PadRight(base64Encoded.Length + (4 - base64Encoded.Length % 4) % 4, '=')
                .Map(_ => Convert.FromBase64String(_))
                .Map(_ => Encoding.UTF8.GetString(_));
    }
}
