using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record SignedRenewalInfo(
        [property: JsonPropertyName("autoRenewProductId")]
        string AutoRenewProductId,

        [property: JsonPropertyName("autoRenewStatus")]
        AutoRenewStatus AutoRenewStatus,

        [property: JsonPropertyName("environment")]
        string Environment,

        [property: JsonPropertyName("expirationIntent")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? ExpirationIntent,

        [property: JsonPropertyName("gracePeriodExpiresDate")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        long? GracePeriodExpiresDate,

        [property: JsonPropertyName("isInBillingRetryPeriod")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        bool? IsInBillingRetryPeriod,

        [property: JsonPropertyName("offerIdentifier")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? OfferIdentifier,

        [property: JsonPropertyName("offerType")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? OfferType,

        [property: JsonPropertyName("originalTransactionId")]
        string OriginalTransactionId,

        [property: JsonPropertyName("priceIncreaseStatus")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? priceIncreaseStatus,

        [property: JsonPropertyName("productId")]
        string ProductId,

        [property: JsonPropertyName("recentSubscriptionStartDate")]
        long RecentSubscriptionStartDate,

        [property: JsonPropertyName("signedDate")]
        long SignedDate);
}
