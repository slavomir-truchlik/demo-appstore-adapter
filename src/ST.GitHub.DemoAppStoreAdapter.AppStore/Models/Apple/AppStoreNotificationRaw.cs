using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record AppStoreNotificationRaw([property: JsonPropertyName("signedPayload")] string SignedPayload);
}
