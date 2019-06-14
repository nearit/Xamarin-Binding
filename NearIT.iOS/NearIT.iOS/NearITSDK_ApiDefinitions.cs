using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

namespace NearIT
{
	// @protocol NITContentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NITContentDelegate
	{
		// @required -(void)gotSimpleNotification:(NITSimpleNotification * _Nonnull)notification trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("gotSimpleNotification:trackingInfo:")]
		void GotSimpleNotification (NITSimpleNotification notification, NITTrackingInfo trackingInfo);

		// @required -(void)gotContent:(NITContent * _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("gotContent:trackingInfo:")]
		void GotContent (NITContent content, NITTrackingInfo trackingInfo);

		// @required -(void)gotCoupon:(NITCoupon * _Nonnull)coupon trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("gotCoupon:trackingInfo:")]
		void GotCoupon (NITCoupon coupon, NITTrackingInfo trackingInfo);

		// @required -(void)gotFeedback:(NITFeedback * _Nonnull)feedback trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("gotFeedback:trackingInfo:")]
		void GotFeedback (NITFeedback feedback, NITTrackingInfo trackingInfo);

		// @required -(void)gotCustomJSON:(NITCustomJSON * _Nonnull)customJson trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("gotCustomJSON:trackingInfo:")]
		void GotCustomJSON (NITCustomJSON customJson, NITTrackingInfo trackingInfo);
	}

	// @protocol NITManaging <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NITManaging
	{
		// @required -(void)recipesManager:(NITRecipesManager * _Nonnull)recipesManager gotRecipe:(NITRecipe * _Nonnull)recipe trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		//[Abstract]
		//[Export ("recipesManager:gotRecipe:trackingInfo:")]
		//void GotRecipe (NITRecipesManager recipesManager, NITRecipe recipe, NITTrackingInfo trackingInfo);
	}

	// @protocol NITManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NITManagerDelegate
	{
		// @required -(void)manager:(NITManager * _Nonnull)manager eventWithContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Abstract]
		[Export ("manager:eventWithContent:trackingInfo:")]
		void EventWithContent (NITManager manager, NSObject content, NITTrackingInfo trackingInfo);

		// @required -(void)manager:(NITManager * _Nonnull)manager eventFailureWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("manager:eventFailureWithError:")]
		void EventFailureWithError (NITManager manager, NSError error);

		// @optional -(void)manager:(NITManager * _Nonnull)manager alertWantsToShowContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
		[Export ("manager:alertWantsToShowContent:trackingInfo:")]
		void AlertWantsToShowContent (NITManager manager, NSObject content, NITTrackingInfo trackingInfo);
	}

	// @interface NITManager : NSObject
	[BaseType (typeof(NSObject))]
	interface NITManager
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		NITManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<NITManagerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakNotificationDelegate")]
		[NullAllowed]
		NITNotificationUpdateDelegate NotificationDelegate { get; set; }

		// @property (nonatomic, weak) id<NITNotificationUpdateDelegate> _Nullable notificationDelegate;
		[NullAllowed, Export ("notificationDelegate", ArgumentSemantic.Weak)]
		NSObject WeakNotificationDelegate { get; set; }

		// @property (nonatomic) BOOL showBackgroundNotification;
		[Export ("showBackgroundNotification")]
		bool ShowBackgroundNotification { get; set; }

		// @property (nonatomic) BOOL showForegroundNotification;
		[Export ("showForegroundNotification")]
		bool ShowForegroundNotification { get; set; }

		// +(void)setupWithApiKey:(NSString * _Nonnull)apiKey;
		[Static]
		[Export ("setupWithApiKey:")]
		void SetupWithApiKey (string apiKey);

		// +(NITManager * _Nonnull)defaultManager;
		[Static]
		[Export ("defaultManager")]
		// [Verify (MethodToProperty)]
		NITManager DefaultManager { get; }

		// +(void)setFrameworkName:(NSString * _Nonnull)frameworkName;
		[Static]
		[Export ("setFrameworkName:")]
		void SetFrameworkName (string frameworkName);

		// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nullable)options;
		[Export ("application:openURL:options:")]
		bool Application (UIApplication application, NSUrl url, [NullAllowed] NSDictionary<NSString, NSObject> options);

		// -(void)application:(UIApplication * _Nonnull)application performFetchWithCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
		[Export ("application:performFetchWithCompletionHandler:")]
		void Application (UIApplication application, Action<UIBackgroundFetchResult> completionHandler);

		// -(void)setDeviceTokenWithData:(NSData * _Nonnull)token;
		[Export ("setDeviceTokenWithData:")]
		void SetDeviceTokenWithData (NSData token);

		// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value;
		[Export ("setUserDataWithKey:value:")]
		void SetUserDataWithKey (string key, [NullAllowed] string value);

		// -(void)setUserDataWithKey:(NSString * _Nonnull)key multiValue:(NSDictionary<NSString *,NSNumber *> * _Nullable)value;
		[Export ("setUserDataWithKey:multiValue:")]
		void SetUserDataWithKey (string key, [NullAllowed] NSDictionary<NSString, NSNumber> value);

		// -(void)getUserDataWithCompletionHandler:(void (^ _Nonnull)(NSDictionary<NSString *,id> * _Nullable, NSError * _Nullable))handler;
		[Export ("getUserDataWithCompletionHandler:")]
		void GetUserDataWithCompletionHandler (Action<NSDictionary<NSString, NSObject>, NSError> handler);

		// -(void)profileIdWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
		[Export ("profileIdWithCompletionHandler:")]
		void ProfileIdWithCompletionHandler (Action<NSString, NSError> handler);

		// -(void)resetProfileWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
		[Export ("resetProfileWithCompletionHandler:")]
		void ResetProfileWithCompletionHandler (Action<NSString, NSError> handler);

		// -(void)optOutWithCompletionHandler:(void (^ _Nonnull)(BOOL))handler;
		[Export ("optOutWithCompletionHandler:")]
		void OptOutWithCompletionHandler (Action<bool> handler);

		// -(void)resetProfile __attribute__((deprecated("Use resetProfileWithCompletionHandler"))) __attribute__((deprecated("")));
		[Export ("resetProfile")]
		void ResetProfile ();

		// -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value __attribute__((deprecated("Use setUserDataWithKey("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
		[Export ("setDeferredUserDataWithKey:value:")]
		void SetDeferredUserDataWithKey (string key, [NullAllowed] string value);

		// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler __attribute__((deprecated("Use setUserData("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
		[Export ("setUserDataWithKey:value:completionHandler:")]
		void SetUserDataWithKey (string key, [NullAllowed] string value, [NullAllowed] Action<NSError> handler);

		// -(void)setBatchUserDataWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)valuesDictiornary completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler __attribute__((deprecated("Use setUserData("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
		[Export ("setBatchUserDataWithDictionary:completionHandler:")]
		void SetBatchUserDataWithDictionary (NSDictionary<NSString, NSObject> valuesDictiornary, [NullAllowed] Action<NSError> handler);

		// -(NSString * _Nullable)profileId __attribute__((deprecated("Use profileIdWithCompletionHandler"))) __attribute__((deprecated("")));
		// -(void)setProfileId:(NSString * _Nonnull)profileId;
		[NullAllowed, Export ("profileId")]
		// [Verify (MethodToProperty)]
		string ProfileId { get; set; }

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();

		// -(void)userNotificationCenter:(UNUserNotificationCenter * _Nonnull)center willPresent:(UNNotification * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(UNNotificationPresentationOptions))handler;
		[Export ("userNotificationCenter:willPresent:withCompletionHandler:")]
		void UserNotificationCenter (UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> handler);

		// -(BOOL)getContentFrom:(UNNotificationResponse * _Nonnull)response completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("getContentFrom:completion:")]
		bool GetContentFrom (UNNotificationResponse response, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

		// -(BOOL)processRecipeWithResponse:(UNNotificationResponse * _Nonnull)response completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler __attribute__((deprecated("Use getContentFrom"))) __attribute__((deprecated("")));
		[Export ("processRecipeWithResponse:completion:")]
		bool ProcessRecipeWithResponse (UNNotificationResponse response, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

		// -(void)couponsWithCompletionHandler:(void (^ _Nullable)(NSArray<NITCoupon *> * _Nullable, NSError * _Nullable))handler;
		[Export ("couponsWithCompletionHandler:")]
		void CouponsWithCompletionHandler ([NullAllowed] Action<NSArray<NITCoupon>, NSError> handler);

		// -(BOOL)processRecipeSimpleWithUserInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo;
		[Export ("processRecipeSimpleWithUserInfo:")]
		bool ProcessRecipeSimpleWithUserInfo ([NullAllowed] NSDictionary<NSString, NSObject> userInfo);

		// -(void)recipesWithCompletionHandler:(void (^ _Nullable)(NSArray<NITRecipe *> * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("recipesWithCompletionHandler:")]
		void RecipesWithCompletionHandler ([NullAllowed] Action<NSArray<NITRecipe>, NSError> completionHandler);

		// -(void)processRecipeWithId:(NSString * _Nonnull)recipeId;
		[Export ("processRecipeWithId:")]
		void ProcessRecipeWithId (string recipeId);

		// -(BOOL)processRecipeWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("processRecipeWithUserInfo:completion:")]
		bool ProcessRecipeWithUserInfo (NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

		// -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler __attribute__((deprecated("")));
		[Export ("refreshConfigWithCompletionHandler:")]
		void RefreshConfigWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

		// -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
		[Export ("sendTrackingWithTrackingInfo:event:")]
		void SendTrackingWithTrackingInfo ([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);

		// -(void)sendEventWithEvent:(NITEvent * _Nonnull)event completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
		[Export ("sendEventWithEvent:completionHandler:")]
		void SendEventWithEvent (NITEvent @event, [NullAllowed] Action<NSError> handler);

		// -(void)processCustomTriggerWithKey:(NSString * _Nonnull)key __attribute__((deprecated("Use triggerInAppEventWithKey"))) __attribute__((deprecated("")));
		[Export ("processCustomTriggerWithKey:")]
		void ProcessCustomTriggerWithKey (string key);

		// -(void)triggerInAppEventWithKey:(NSString * _Nonnull)key;
		[Export ("triggerInAppEventWithKey:")]
		void TriggerInAppEventWithKey (string key);

		// -(void)parseContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo contentDelegate:(id<NITContentDelegate> _Nonnull)contentDelegate;
		[Export ("parseContent:trackingInfo:contentDelegate:")]
		void ParseContent (NSObject content, NITTrackingInfo trackingInfo, NITContentDelegate contentDelegate);

		// -(void)historyWithCompletion:(void (^ _Nonnull)(NSArray<NITHistoryItem *> * _Nullable, NSError * _Nullable))completion;
		[Export ("historyWithCompletion:")]
		void HistoryWithCompletion (Action<NSArray<NITHistoryItem>, NSError> completion);

		// -(void)updateWithNotification:(UNNotification * _Nonnull)notification;
		[Export ("updateWithNotification:")]
		void UpdateWithNotification (UNNotification notification);

		// -(void)markNotificationHistoryAsOld;
		[Export ("markNotificationHistoryAsOld")]
		void MarkNotificationHistoryAsOld ();
	}

	// @interface NITResource : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface NITResource : INSCoding
	{
		// @property (nonatomic, strong) NITJSONAPIResource * _Nullable resourceObject;
		//[NullAllowed, Export ("resourceObject", ArgumentSemantic.Strong)]
		//NITJSONAPIResource ResourceObject { get; set; }

		// -(NSDictionary * _Nonnull)attributesMap;
		[Export ("attributesMap")]
		// [Verify (MethodToProperty)]
		NSDictionary AttributesMap { get; }

		// -(NSString * _Nullable)ID;
		// -(void)setID:(NSString * _Nonnull)ID;
		[NullAllowed, Export ("ID")]
		// [Verify (MethodToProperty)]
		string ID { get; set; }
	}

	// @interface NITReactionBundle : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITReactionBundle : INSCoding
	{
		// @property (nonatomic, strong) NSString * notificationMessage;
		[Export ("notificationMessage", ArgumentSemantic.Strong)]
		string NotificationMessage { get; set; }
	}

	// @interface NITContent : NITReactionBundle <NSCoding>
	[BaseType (typeof(NITReactionBundle))]
	interface NITContent : INSCoding
	{
		// @property (nonatomic, strong) NSArray<NITImage *> * _Nullable images __attribute__((deprecated("You should use 'image' attribute"))) __attribute__((deprecated("")));
		[NullAllowed, Export ("images", ArgumentSemantic.Strong)]
		NITImage[] Images { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable videoLink __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
		[NullAllowed, Export ("videoLink", ArgumentSemantic.Strong)]
		string VideoLink { get; set; }

		// @property (nonatomic, strong) NITAudio * _Nullable audio __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
		[NullAllowed, Export ("audio", ArgumentSemantic.Strong)]
		NITAudio Audio { get; set; }

		// @property (nonatomic, strong) NITUpload * _Nullable upload __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
		[NullAllowed, Export ("upload", ArgumentSemantic.Strong)]
		NITUpload Upload { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable title;
		[NullAllowed, Export ("title", ArgumentSemantic.Strong)]
		string Title { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable content;
		[NullAllowed, Export ("content", ArgumentSemantic.Strong)]
		string Content { get; set; }

		// @property (readonly, nonatomic) NITImage * _Nullable image;
		[NullAllowed, Export ("image")]
		NITImage Image { get; }

		// @property (readonly, nonatomic) NITContentLink * _Nullable link;
		[NullAllowed, Export ("link")]
		NITContentLink Link { get; }

		// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull internalLink;
		[Export ("internalLink", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> InternalLink { get; set; }
	}

	// @interface NITImage : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITImage : INSCoding
	{
		// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable image;
		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> Image { get; set; }

		// -(NSURL * _Nullable)smallSizeURL;
		[NullAllowed, Export ("smallSizeURL")]
		// [Verify (MethodToProperty)]
		NSUrl SmallSizeURL { get; }

		// -(NSURL * _Nullable)url;
		[NullAllowed, Export ("url")]
		// [Verify (MethodToProperty)]
		NSUrl Url { get; }
	}

	[Static]
	// [Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern NSString *const _Nonnull NITRecipeNotified __attribute__((deprecated("You should use 'NITRecipeReceived' constant"))) __attribute__((deprecated("")));
		[Field ("NITRecipeNotified", "__Internal")]
		NSString NITRecipeNotified { get; }

		// extern NSString *const _Nonnull NITRecipeReceived;
		[Field ("NITRecipeReceived", "__Internal")]
		NSString NITRecipeReceived { get; }

		// extern NSString *const _Nonnull NITRecipeEngaged __attribute__((deprecated("You should use 'NITRecipeOpened' constant"))) __attribute__((deprecated("")));
		[Field ("NITRecipeEngaged", "__Internal")]
		NSString NITRecipeEngaged { get; }

		// extern NSString *const _Nonnull NITRecipeOpened;
		[Field ("NITRecipeOpened", "__Internal")]
		NSString NITRecipeOpened { get; }

		// extern NSString *const _Nonnull NITRecipeCtaTapped;
		[Field ("NITRecipeCtaTapped", "__Internal")]
		NSString NITRecipeCtaTapped { get; }
	}

	// @interface NITRecipe : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITRecipe : INSCoding
	{
		// @property (nonatomic, strong) NSString * _Nullable name;
		[NullAllowed, Export ("name", ArgumentSemantic.Strong)]
		string Name { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable notification;
		[NullAllowed, Export ("notification", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> Notification { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable labels;
		[NullAllowed, Export ("labels", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> Labels { get; set; }

		// @property (nonatomic, strong) NSArray<NSDictionary<NSString *,id> *> * _Nullable scheduling;
		[NullAllowed, Export ("scheduling", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject>[] Scheduling { get; set; }

		// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable cooldown;
		[NullAllowed, Export ("cooldown", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> Cooldown { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull pulsePluginId;
		[Export ("pulsePluginId", ArgumentSemantic.Strong)]
		string PulsePluginId { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull reactionPluginId;
		[Export ("reactionPluginId", ArgumentSemantic.Strong)]
		string ReactionPluginId { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull reactionBundleId;
		[Export ("reactionBundleId", ArgumentSemantic.Strong)]
		string ReactionBundleId { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * _Nullable tags;
		[NullAllowed, Export ("tags", ArgumentSemantic.Strong)]
		string[] Tags { get; set; }

		// @property (nonatomic, strong) NITResource * _Nonnull pulseBundle;
		[Export ("pulseBundle", ArgumentSemantic.Strong)]
		NITResource PulseBundle { get; set; }

		// @property (nonatomic, strong) NITResource * _Nonnull pulseAction;
		[Export ("pulseAction", ArgumentSemantic.Strong)]
		NITResource PulseAction { get; set; }

		// @property (nonatomic, strong) NITResource * _Nonnull reactionAction;
		[Export ("reactionAction", ArgumentSemantic.Strong)]
		NITResource ReactionAction { get; set; }

		// @property (nonatomic, strong) NITResource * _Nonnull reactionBundle;
		[Export ("reactionBundle", ArgumentSemantic.Strong)]
		NITResource ReactionBundle { get; set; }

		// -(BOOL)isEvaluatedOnline;
		[Export ("isEvaluatedOnline")]
		// [Verify (MethodToProperty)]
		bool IsEvaluatedOnline { get; }

		// -(BOOL)isForeground;
		[Export ("isForeground")]
		// [Verify (MethodToProperty)]
		bool IsForeground { get; }

		// -(NSString * _Nullable)notificationTitle;
		[NullAllowed, Export ("notificationTitle")]
		// [Verify (MethodToProperty)]
		string NotificationTitle { get; }

		// -(NSString * _Nullable)notificationBody;
		[NullAllowed, Export ("notificationBody")]
		// [Verify (MethodToProperty)]
		string NotificationBody { get; }
	}

	// @interface NITCoupon : NITReactionBundle <NSCoding>
	[BaseType (typeof(NITReactionBundle))]
	interface NITCoupon : INSCoding
	{
		// @property (nonatomic, strong) NSString * couponDescription;
		[Export ("couponDescription", ArgumentSemantic.Strong)]
		string CouponDescription { get; set; }

		// @property (nonatomic, strong) NSString * value;
		[Export ("value", ArgumentSemantic.Strong)]
		string Value { get; set; }

		// @property (nonatomic, strong) NSString * expiresAt;
		[Export ("expiresAt", ArgumentSemantic.Strong)]
		string ExpiresAt { get; set; }

		// @property (nonatomic, strong) NSString * redeemableFrom;
		[Export ("redeemableFrom", ArgumentSemantic.Strong)]
		string RedeemableFrom { get; set; }

		// @property (nonatomic, strong) NSArray<NITClaim *> * claims __attribute__((deprecated("You should get claim info directly from coupon getters"))) __attribute__((deprecated("")));
		[Export ("claims", ArgumentSemantic.Strong)]
		NITClaim[] Claims { get; set; }

		// @property (nonatomic, strong) NITImage * icon;
		[Export ("icon", ArgumentSemantic.Strong)]
		NITImage Icon { get; set; }

		// @property (readonly, nonatomic) NSDate * expires;
		[Export ("expires")]
		NSDate Expires { get; }

		// @property (readonly, nonatomic) NSDate * redeemable;
		[Export ("redeemable")]
		NSDate Redeemable { get; }

		// @property (readonly, nonatomic) NSString * title;
		[Export ("title")]
		string Title { get; }

		// @property (readonly, nonatomic) NSString * serial;
		[Export ("serial")]
		string Serial { get; }

		// @property (readonly, nonatomic) NSString * claimedAt;
		[Export ("claimedAt")]
		string ClaimedAt { get; }

		// @property (readonly, nonatomic) NSDate * claimed;
		[Export ("claimed")]
		NSDate Claimed { get; }

		// @property (readonly, nonatomic) NSString * redeemedAt;
		[Export ("redeemedAt")]
		string RedeemedAt { get; }

		// @property (readonly, nonatomic) NSDate * redeemed;
		[Export ("redeemed")]
		NSDate Redeemed { get; }

		// -(BOOL)hasContentToInclude;
		[Export ("hasContentToInclude")]
		// [Verify (MethodToProperty)]
		bool HasContentToInclude { get; }
	}

	// @interface NITClaim : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITClaim : INSCoding
	{
		// @property (nonatomic, strong) NSString * _Nonnull serialNumber;
		[Export ("serialNumber", ArgumentSemantic.Strong)]
		string SerialNumber { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull claimedAt;
		[Export ("claimedAt", ArgumentSemantic.Strong)]
		string ClaimedAt { get; set; }

		// @property (nonatomic, strong) NSString * _Nullable redeemedAt;
		[NullAllowed, Export ("redeemedAt", ArgumentSemantic.Strong)]
		string RedeemedAt { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull recipeId;
		[Export ("recipeId", ArgumentSemantic.Strong)]
		string RecipeId { get; set; }

		// @property (nonatomic, strong) NITCoupon * _Nonnull coupon;
		[Export ("coupon", ArgumentSemantic.Strong)]
		NITCoupon Coupon { get; set; }

		// @property (readonly, nonatomic) NSDate * _Nonnull claimed;
		[Export ("claimed")]
		NSDate Claimed { get; }

		// @property (readonly, nonatomic) NSDate * _Nullable redeemed;
		[NullAllowed, Export ("redeemed")]
		NSDate Redeemed { get; }
	}

	// @interface NITFeedback : NITReactionBundle <NSCoding>
	[BaseType (typeof(NITReactionBundle))]
	interface NITFeedback : INSCoding
	{
		// @property (nonatomic, strong) NSString * _Nonnull question;
		[Export ("question", ArgumentSemantic.Strong)]
		string Question { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull recipeId __attribute__((deprecated("")));
		[Export ("recipeId", ArgumentSemantic.Strong)]
		string RecipeId { get; set; }

		// @property (nonatomic, strong) NITTrackingInfo * _Nonnull trackingInfo;
		[Export ("trackingInfo", ArgumentSemantic.Strong)]
		NITTrackingInfo TrackingInfo { get; set; }
	}

	// @interface NITEvent : NSObject
	[BaseType (typeof(NSObject))]
	interface NITEvent
	{
		// -(NSString * _Nonnull)pluginName;
		[Export ("pluginName")]
		// // [Verify (MethodToProperty)]
		string PluginName { get; }
	}

	// @interface NITFeedbackEvent : NITEvent
	[BaseType (typeof(NITEvent))]
	interface NITFeedbackEvent
	{
		// @property (nonatomic, strong) NSString * _Nonnull ID;
		[Export ("ID", ArgumentSemantic.Strong)]
		string ID { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull recipeId;
		[Export ("recipeId", ArgumentSemantic.Strong)]
		string RecipeId { get; set; }

		// -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback rating:(NSInteger)rating comment:(NSString * _Nullable)comment;
		[Export ("initWithFeedback:rating:comment:")]
		IntPtr Constructor (NITFeedback feedback, nint rating, [NullAllowed] string comment);

		// -(NITJSONAPI * _Nullable)toJsonAPI:(NITConfiguration * _Nonnull)configuration;
		//[Export ("toJsonAPI:")]
		//[return: NullAllowed]
		//NITJSONAPI ToJsonAPI (NITConfiguration configuration);
	}

	// @interface NITCustomJSON : NITReactionBundle <NSCoding>
	[BaseType (typeof(NITReactionBundle))]
	interface NITCustomJSON : INSCoding
	{
		// @property (nonatomic, strong) NSDictionary<NSString *,id> * content;
		[Export ("content", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> Content { get; set; }
	}

	// @interface NITSimpleNotification : NITReactionBundle <NSCoding>
	[BaseType (typeof(NITReactionBundle))]
	interface NITSimpleNotification : INSCoding
	{
		// @property (nonatomic, strong) NSString * _Nullable notificationTitle;
		[NullAllowed, Export ("notificationTitle", ArgumentSemantic.Strong)]
		string NotificationTitle { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull message;
		[Export ("message", ArgumentSemantic.Strong)]
		string Message { get; set; }
	}

	// @interface NITTrackingInfo : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface NITTrackingInfo : INSCoding
	{
		// -(BOOL)addExtraWithObject:(id<NSCoding> _Nonnull)object key:(NSString * _Nonnull)key;
		[Export ("addExtraWithObject:key:")]
		bool AddExtraWithObject (NSCoding @object, string key);

		// -(NSString * _Nullable)recipeId;
		// -(void)setRecipeId:(NSString * _Nonnull)recipeId;
		[NullAllowed, Export ("recipeId")]
		// [Verify (MethodToProperty)]
		string RecipeId { get; set; }

		// -(NSDictionary * _Nonnull)extrasDictionary;
		[Export ("extrasDictionary")]
		NSDictionary ExtrasDictionary ();

		// -(BOOL)existsExtraForKey:(NSString * _Nonnull)key;
		[Export ("existsExtraForKey:")]
		bool ExistsExtraForKey (string key);

		// -(BOOL)hasDeliveryID;
		[Export ("hasDeliveryID")]
		bool HasDeliveryID ();

		// -(NSString * _Nullable)deliveryID;
		[Export ("deliveryID")]
		[return: NullAllowed]
		string DeliveryID ();

		// +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId;
		[Static]
		[Export ("trackingInfoFromRecipeId:")]
		NITTrackingInfo TrackingInfoFromRecipeId (string recipeId);

		// +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId deliveryId:(NSString * _Nullable)deliveryId;
		[Static]
		[Export ("trackingInfoFromRecipeId:deliveryId:")]
		NITTrackingInfo TrackingInfoFromRecipeId (string recipeId, [NullAllowed] string deliveryId);

		// +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId extras:(NSDictionary<NSString *,id> * _Nonnull)extras;
		[Static]
		[Export ("trackingInfoFromRecipeId:extras:")]
		NITTrackingInfo TrackingInfoFromRecipeId (string recipeId, NSDictionary<NSString, NSObject> extras);
	}

	// @interface NITAudio : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITAudio : INSCoding
	{
		// @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull audio;
		[Export ("audio", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> Audio { get; set; }

		// -(NSURL * _Nullable)url;
		[NullAllowed, Export ("url")]
		// [Verify (MethodToProperty)]
		NSUrl Url { get; }
	}

	// @interface NITUpload : NITResource <NSCoding>
	[BaseType (typeof(NITResource))]
	interface NITUpload : INSCoding
	{
		// @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull upload;
		[Export ("upload", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSString> Upload { get; set; }

		// -(NSURL * _Nullable)url;
		[NullAllowed, Export ("url")]
		// [Verify (MethodToProperty)]
		NSUrl Url { get; }
	}

	// @protocol NITLogger <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NITLogger
	{
		// @required -(void)verboseWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("verboseWithTag:message:")]
		void VerboseWithTag (string tag, string message);

		// @required -(void)debugWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("debugWithTag:message:")]
		void DebugWithTag (string tag, string message);

		// @required -(void)infoWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("infoWithTag:message:")]
		void InfoWithTag (string tag, string message);

		// @required -(void)warningWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("warningWithTag:message:")]
		void WarningWithTag (string tag, string message);

		// @required -(void)errorWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("errorWithTag:message:")]
		void ErrorWithTag (string tag, string message);
	}

	// @interface NITLog : NSObject
	[BaseType (typeof(NSObject))]
	interface NITLog
	{
		// +(void)setLogger:(id<NITLogger> _Nonnull)logger;
		[Static]
		[Export ("setLogger:")]
		void SetLogger (NITLogger logger);

		// +(void)setLevel:(NITLogLevel)level;
		[Static]
		[Export ("setLevel:")]
		void SetLevel (NITLogLevel level);

		// +(void)setLogEnabled:(BOOL)enabled;
		[Static]
		[Export ("setLogEnabled:")]
		void SetLogEnabled (bool enabled);
	}

	// @interface NITContentLink : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface NITContentLink : INSCoding
	{
		// @property (nonatomic, strong) NSURL * url;
		[Export ("url", ArgumentSemantic.Strong)]
		NSUrl Url { get; set; }

		// @property (nonatomic, strong) NSString * label;
		[Export ("label", ArgumentSemantic.Strong)]
		string Label { get; set; }
	}

	// @interface NITHistoryItem : NSObject
	[BaseType (typeof(NSObject))]
	interface NITHistoryItem: INativeObject
	{
		// @property (nonatomic, strong) NITTrackingInfo * _Nonnull trackingInfo;
		[Export ("trackingInfo", ArgumentSemantic.Strong)]
		NITTrackingInfo TrackingInfo { get; set; }

		// @property (nonatomic, strong) NITReactionBundle * _Nonnull reactionBundle;
		[Export ("reactionBundle", ArgumentSemantic.Strong)]
		NITReactionBundle ReactionBundle { get; set; }

		// @property (readonly, nonatomic) NSDate * _Nonnull date;
		[Export ("date")]
		NSDate Date { get; }

		// @property (nonatomic) NSTimeInterval timestamp;
		[Export ("timestamp")]
		double Timestamp { get; set; }

		// @property (nonatomic) BOOL read;
		[Export ("read")]
		bool Read { get; set; }

		// @property (nonatomic) BOOL isNew;
		[Export ("isNew")]
		bool IsNew { get; set; }
	}

	// @protocol NITNotificationUpdateDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface NITNotificationUpdateDelegate
	{
		// @required -(void)historyUpdatedWithItems:(NSArray<NITHistoryItem *> * _Nullable)items;
		[Abstract]
		[Export ("historyUpdatedWithItems:")]
		void HistoryUpdatedWithItems ([NullAllowed] NITHistoryItem[] items);
	}

	//[Static]
	//[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double NearITSDKVersionNumber;
		[Field ("NearITSDKVersionNumber", "__Internal")]
		double NearITSDKVersionNumber { get; }

		// extern const unsigned char [] NearITSDKVersionString;
		//[Field ("NearITSDKVersionString", "__Internal")]
		//byte[] NearITSDKVersionString { get; }
	}
}
