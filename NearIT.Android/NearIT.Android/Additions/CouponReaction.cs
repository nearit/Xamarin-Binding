namespace IT.Near.Sdk.Reactions.Couponplugin
{
    public partial class CouponReaction 
    {
		protected override void NormalizeElement(global::Java.Lang.Object element)
		{
            NormalizeElement(element as Couponplugin.Model.Coupon);
		}
        protected override void InjectRecipeExtras(global::Java.Lang.Object element, IT.Near.Sdk.Trackings.TrackingInfo trackingInfo)
		{
            InjectRecipeExtras(element as IT.Near.Sdk.Reactions.Couponplugin.Model.Coupon, trackingInfo);
		}
    }
}