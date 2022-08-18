using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record SignedPayload(
        [property: JsonPropertyName("notificationType")]
        NotificationType Type,

        [property: JsonPropertyName("subtype")]
        [property: JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        NotificationSubtype? Subtype,

        [property: JsonPropertyName("notificationUUID")]
        string UUID,

        [property: JsonPropertyName("data")]
        NotificationDataRaw Data,

        [property: JsonPropertyName("version")]
        string Version,

        [property: JsonPropertyName("signedDate")]
        long SignedDate);
}