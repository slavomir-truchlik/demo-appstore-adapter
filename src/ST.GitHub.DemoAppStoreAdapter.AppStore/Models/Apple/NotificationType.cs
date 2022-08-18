using System.Runtime.Serialization;

namespace ST.GitHub.DemoAppStoreAdapter.AppStore.Models.Apple
{
    public enum NotificationType
    {
        Unsupported = -1,

        [EnumMember(Value = "CONSUMPTION_REQUEST")]
        ConsumptionRequest,

        [EnumMember(Value = "DID_CHANGE_RENEWAL_PREF")]
        ChangeRenewalPref,

        [EnumMember(Value = "DID_CHANGE_RENEWAL_STATUS")]
        ChangeRenewalStatus,

        [EnumMember(Value = "DID_FAIL_TO_RENEW")]
        FailToRenew,

        [EnumMember(Value = "DID_RENEW")]
        Renew,

        [EnumMember(Value = "EXPIRED")]
        Expired,

        [EnumMember(Value = "GRACE_PERIOD_EXPIRED")]
        GracePeriodExpired,

        [EnumMember(Value = "OFFER_REDEEMED")]
        OfferRedeemed,

        [EnumMember(Value = "PRICE_INCREASE")]
        PriceIncrease,

        [EnumMember(Value = "REFUND")]
        Refund,

        [EnumMember(Value = "REFUND_DECLINED")]
        RefundDeclined,

        [EnumMember(Value = "RENEWAL_EXTENDED")]
        RenewalExtended,

        [EnumMember(Value = "REVOKE")]
        Revoke,

        [EnumMember(Value = "SUBSCRIBED")]
        Subscribed,

        [EnumMember(Value = "TEST")]
        Test
    }
}
