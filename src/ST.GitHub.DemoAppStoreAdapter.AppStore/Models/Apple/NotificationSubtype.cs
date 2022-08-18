using System.Runtime.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public enum NotificationSubtype
    {
        Unsupported = -1,

        [EnumMember(Value = "INITIAL_BUY")]
        InitialBuy,

        [EnumMember(Value = "RESUBSCRIBE")]
        Resubscribe,

        [EnumMember(Value = "DOWNGRADE")]
        Downgrade,

        [EnumMember(Value = "UPGRADE")]
        Upgrade,

        [EnumMember(Value = "AUTO_RENEW_ENABLED")]
        AutorenewEnabled,

        [EnumMember(Value = "AUTO_RENEW_DISABLED")]
        AutorenewDisabled,

        [EnumMember(Value = "VOLUNTARY")]
        Voluntary,

        [EnumMember(Value = "BILLING_RETRY")]
        BillingRetry,

        [EnumMember(Value = "PRICE_INCREASE")]
        PriceIncrease,

        [EnumMember(Value = "GRACE_PERIOD")]
        GracePeriod,

        [EnumMember(Value = "BILLING_RECOVERY")]
        BillingRecovery,

        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "ACCEPTED")]
        Accepted
    }
}
