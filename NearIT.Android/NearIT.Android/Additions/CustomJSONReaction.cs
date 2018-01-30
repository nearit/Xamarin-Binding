
namespace IT.Near.Sdk.Reactions.Customjsonplugin
{
    public partial class CustomJSONReaction 
    {
		protected override void NormalizeElement(global::Java.Lang.Object element)
		{
			NormalizeElement(element as IT.Near.Sdk.Reactions.Customjsonplugin.Model.CustomJSON);
		}
        protected override void InjectRecipeExtras(global::Java.Lang.Object element, IT.Near.Sdk.Trackings.TrackingInfo trackingInfo)
		{
            InjectRecipeExtras(element as IT.Near.Sdk.Reactions.Customjsonplugin.Model.CustomJSON, trackingInfo);
		}
    }
}