namespace IT.Near.Sdk.Reactions.Feedbackplugin
{
    public partial class FeedbackReaction 
    {
		protected override void NormalizeElement(global::Java.Lang.Object element)
		{
            NormalizeElement(element as IT.Near.Sdk.Reactions.Feedbackplugin.Model.Feedback);
		}
        protected override void InjectRecipeExtras(global::Java.Lang.Object element, IT.Near.Sdk.Trackings.TrackingInfo trackingInfo)
		{
            InjectRecipeExtras(element as IT.Near.Sdk.Reactions.Feedbackplugin.Model.Feedback, trackingInfo);
		}
    }
}