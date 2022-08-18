using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record NotificationDataRaw(
        [property: JsonPropertyName("appAppleId")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? AppAppleId,

        [property: JsonPropertyName("bundleId")]
        string BundleId,

        [property: JsonPropertyName("bundleVersion")]
        string BundleVersion,

        [property: JsonPropertyName("environment")]
        string Environment,

        [property: JsonPropertyName("signedTransactionInfo")]
        string SignedTransactionInfo,

        [property: JsonPropertyName("signedRenewalInfo")]
        string SignedRenewalInfo);
}
