using System.Text.Json.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public record AppStoreNotification([property: JsonPropertyName("signedPayload")] SignedPayload SignedPayload);
}
