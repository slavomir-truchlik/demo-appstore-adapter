using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record SignedTransactionInfo(
        [property: JsonPropertyName("appAccountToken")]
        string AppAccountToken,

        [property: JsonPropertyName("bundleId")]
        string BundleId,

        [property: JsonPropertyName("environment")]
        string Environment,

        [property: JsonPropertyName("expiresDate")]
        long ExpiresDate,

        [property: JsonPropertyName("inAppOwnershipType")]
        string InAppOwnershipType,

        [property: JsonPropertyName("isUpgraded")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        bool? IsUpgraded,

        [property: JsonPropertyName("offerIdentifier")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        string? OfferIdentifier,

        [property: JsonPropertyName("offerType")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? OfferType,

        [property: JsonPropertyName("originalPurchaseDate")]
        long OriginalPurchaseDate,

        [property: JsonPropertyName("originalTransactionId")]
        string OriginalTransactionId,

        [property: JsonPropertyName("productId")]
        string ProductId,

        [property: JsonPropertyName("purchaseDate")]
        long PurchaseDate,

        [property: JsonPropertyName("quantity")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? Quantity,

        [property: JsonPropertyName("revocationDate")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        long? RevocationDate,

        [property: JsonPropertyName("revocationReason")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        int? RevocationReason,

        [property: JsonPropertyName("signedDate")]
        long SignedDate,

        [property: JsonPropertyName("subscriptionGroupIdentifier")]
        string SubscriptionGroupIdentifier,

        [property: JsonPropertyName("transactionId")]
        string TransactionId,

        [property: JsonPropertyName("type")]
        string Type,

        [property: JsonPropertyName("webOrderLineItemId")]
        string? WebOrderLineItemId);   
}
