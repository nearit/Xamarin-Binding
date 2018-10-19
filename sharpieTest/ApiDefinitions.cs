using System;
using CoreBluetooth;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;
using UserNotifications;

// @interface NITResource : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITResource : INSCoding
{
	// @property (nonatomic, strong) NITJSONAPIResource * _Nullable resourceObject;
	[NullAllowed, Export ("resourceObject", ArgumentSemantic.Strong)]
	NITJSONAPIResource ResourceObject { get; set; }

	// -(NSDictionary * _Nonnull)attributesMap;
	[Export ("attributesMap")]
	[Verify (MethodToProperty)]
	NSDictionary AttributesMap { get; }

	// -(NSString * _Nullable)ID;
	// -(void)setID:(NSString * _Nonnull)ID;
	[NullAllowed, Export ("ID")]
	[Verify (MethodToProperty)]
	string ID { get; set; }
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
	[Verify (MethodToProperty)]
	NSUrl Url { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const NSErrorDomain NITManagerErrorDomain;
	[Field ("NITManagerErrorDomain", "__Internal")]
	NSString NITManagerErrorDomain { get; }

	// extern const NSErrorDomain NITUserProfileErrorDomain;
	[Field ("NITUserProfileErrorDomain", "__Internal")]
	NSString NITUserProfileErrorDomain { get; }

	// extern const NSErrorDomain NITInstallationErrorDomain;
	[Field ("NITInstallationErrorDomain", "__Internal")]
	NSString NITInstallationErrorDomain { get; }

	// extern const NSErrorDomain NITReactionErrorDomain;
	[Field ("NITReactionErrorDomain", "__Internal")]
	NSString NITReactionErrorDomain { get; }

	// extern const NSErrorDomain NITRecipeErrorDomain;
	[Field ("NITRecipeErrorDomain", "__Internal")]
	NSString NITRecipeErrorDomain { get; }

	// extern const NSErrorDomain NITNotificationProcessorDomain;
	[Field ("NITNotificationProcessorDomain", "__Internal")]
	NSString NITNotificationProcessorDomain { get; }

	// extern const NSErrorDomain NITNetowkrErrorDomain;
	[Field ("NITNetowkrErrorDomain", "__Internal")]
	NSString NITNetowkrErrorDomain { get; }

	// extern const NSErrorDomain NITTrackSenderErrorDomain;
	[Field ("NITTrackSenderErrorDomain", "__Internal")]
	NSString NITTrackSenderErrorDomain { get; }

	// extern NSString *const ISO8601DateFormatMilliseconds;
	[Field ("ISO8601DateFormatMilliseconds", "__Internal")]
	NSString ISO8601DateFormatMilliseconds { get; }

	// extern NSString *const NITHttpStatusCode;
	[Field ("NITHttpStatusCode", "__Internal")]
	NSString NITHttpStatusCode { get; }

	// extern NSString *const NITNotTrack;
	[Field ("NITNotTrack", "__Internal")]
	NSString NITNotTrack { get; }
}

// @protocol NITBeaconRadarDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITBeaconRadarDelegate
{
	// @required -(void)beaconRadar:(NITBeaconBaseRadar * _Nonnull)beaconRadar didTriggerWithNode:(NITNode * _Nonnull)node event:(NITRegionEvent)event;
	[Abstract]
	[Export ("beaconRadar:didTriggerWithNode:event:")]
	void DidTriggerWithNode (NITBeaconBaseRadar beaconRadar, NITNode node, NITRegionEvent @event);
}

// @interface NITBeaconBaseRadar : NSObject
[BaseType (typeof(NSObject))]
interface NITBeaconBaseRadar
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITBeaconRadarDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITBeaconRadarDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(instancetype _Nonnull)initWithLocationManager:(CLLocationManager * _Nonnull)locationManager beaconProximityManager:(NITBeaconProximityManager * _Nonnull)beaconProximity nodesManager:(NITNodesManager2 * _Nonnull)nodesManager application:(UIApplication * _Nonnull)application;
	[Export ("initWithLocationManager:beaconProximityManager:nodesManager:application:")]
	IntPtr Constructor (CLLocationManager locationManager, NITBeaconProximityManager beaconProximity, NITNodesManager2 nodesManager, UIApplication application);

	// -(void)stop;
	[Export ("stop")]
	void Stop ();

	// -(void)startWithRootLevel:(NITTreeLevel * _Nullable)level;
	[Export ("startWithRootLevel:")]
	void StartWithRootLevel ([NullAllowed] NITTreeLevel level);

	// -(void)triggerWithEvent:(NITRegionEvent)event node:(NITNode * _Nonnull)node;
	[Export ("triggerWithEvent:node:")]
	void TriggerWithEvent (NITRegionEvent @event, NITNode node);

	// -(NITBeaconNode * _Nonnull)beaconNodeWithBeacon:(CLBeacon * _Nonnull)beacon inChildren:(NSArray<NITNode *> * _Nonnull)children;
	[Export ("beaconNodeWithBeacon:inChildren:")]
	NITBeaconNode BeaconNodeWithBeacon (CLBeacon beacon, NITNode[] children);

	// -(NITRegionEvent)regionEventFromProximity:(CLProximity)proximity;
	[Export ("regionEventFromProximity:")]
	NITRegionEvent RegionEventFromProximity (CLProximity proximity);
}

// @interface NITBeaconForegroundRadar : NITBeaconBaseRadar
[BaseType (typeof(NITBeaconBaseRadar))]
interface NITBeaconForegroundRadar
{
	// -(instancetype)initWithLocationManager:(CLLocationManager *)locationManager beaconProximityManager:(NITBeaconProximityManager *)beaconProximity nodesManager:(NITNodesManager2 *)nodesManager application:(UIApplication *)application visitManager:(NITBeaconVisitManager *)visitManager;
	[Export ("initWithLocationManager:beaconProximityManager:nodesManager:application:visitManager:")]
	IntPtr Constructor (CLLocationManager locationManager, NITBeaconProximityManager beaconProximity, NITNodesManager2 nodesManager, UIApplication application, NITBeaconVisitManager visitManager);
}

// @interface NITNode : NITResource <NSCoding>
[BaseType (typeof(NITResource))]
interface NITNode : INSCoding
{
	// @property (nonatomic, strong) NSString * _Nullable identifier;
	[NullAllowed, Export ("identifier", ArgumentSemantic.Strong)]
	string Identifier { get; set; }

	// @property (nonatomic, strong) NITNode * _Nullable parent;
	[NullAllowed, Export ("parent", ArgumentSemantic.Strong)]
	NITNode Parent { get; set; }

	// @property (nonatomic, strong) NSArray<NITNode *> * _Nullable children;
	[NullAllowed, Export ("children", ArgumentSemantic.Strong)]
	NITNode[] Children { get; set; }

	// @property (nonatomic, strong) NSArray<NSString *> * _Nullable tags;
	[NullAllowed, Export ("tags", ArgumentSemantic.Strong)]
	string[] Tags { get; set; }

	// -(CLRegion * _Nullable)createRegion;
	[NullAllowed, Export ("createRegion")]
	[Verify (MethodToProperty)]
	CLRegion CreateRegion { get; }

	// -(BOOL)isLeaf;
	[Export ("isLeaf")]
	[Verify (MethodToProperty)]
	bool IsLeaf { get; }

	// -(NSInteger)parentsCount;
	[Export ("parentsCount")]
	[Verify (MethodToProperty)]
	nint ParentsCount { get; }

	// -(NSString * _Nonnull)typeName;
	[Export ("typeName")]
	[Verify (MethodToProperty)]
	string TypeName { get; }
}

// @interface NITBeaconNode : NITNode <NSCoding>
[BaseType (typeof(NITNode))]
interface NITBeaconNode : INSCoding
{
	// @property (nonatomic, strong) NSString * _Nonnull proximityUUID;
	[Export ("proximityUUID", ArgumentSemantic.Strong)]
	string ProximityUUID { get; set; }

	// @property (nonatomic, strong) NSNumber * _Nullable major;
	[NullAllowed, Export ("major", ArgumentSemantic.Strong)]
	NSNumber Major { get; set; }

	// @property (nonatomic, strong) NSNumber * _Nullable minor;
	[NullAllowed, Export ("minor", ArgumentSemantic.Strong)]
	NSNumber Minor { get; set; }

	// -(NITBeaconNodeDepth)depth;
	[Export ("depth")]
	[Verify (MethodToProperty)]
	NITBeaconNodeDepth Depth { get; }
}

// @interface NITBeaconProximityManager : NSObject
[BaseType (typeof(NSObject))]
interface NITBeaconProximityManager
{
	// -(void)addRegionWithIdentifier:(NSString * _Nonnull)identifier;
	[Export ("addRegionWithIdentifier:")]
	void AddRegionWithIdentifier (string identifier);

	// -(void)removeRegionWithIdentifier:(NSString * _Nonnull)identifier;
	[Export ("removeRegionWithIdentifier:")]
	void RemoveRegionWithIdentifier (string identifier);

	// -(void)addProximityWithBeaconIdentifier:(NSString * _Nonnull)beaconIdentifier regionIdentifier:(NSString * _Nonnull)regionIdentifier proximity:(CLProximity)proximity;
	[Export ("addProximityWithBeaconIdentifier:regionIdentifier:proximity:")]
	void AddProximityWithBeaconIdentifier (string beaconIdentifier, string regionIdentifier, CLProximity proximity);

	// -(CLProximity)proximityWithBeaconIdentifier:(NSString * _Nonnull)beaconIdentifier regionIdentifier:(NSString * _Nonnull)regionIdentifier;
	[Export ("proximityWithBeaconIdentifier:regionIdentifier:")]
	CLProximity ProximityWithBeaconIdentifier (string beaconIdentifier, string regionIdentifier);

	// -(void)evaluateDisappearedWithBeaconIdentifiers:(NSArray<NSString *> * _Nullable)identifiers regionIdentifier:(NSString * _Nonnull)regionIdentifier;
	[Export ("evaluateDisappearedWithBeaconIdentifiers:regionIdentifier:")]
	void EvaluateDisappearedWithBeaconIdentifiers ([NullAllowed] string[] identifiers, string regionIdentifier);

	// -(NSInteger)regionProximitiesCount;
	[Export ("regionProximitiesCount")]
	[Verify (MethodToProperty)]
	nint RegionProximitiesCount { get; }

	// -(NSInteger)beaconItemsCountWithRegionIdentifier:(NSString * _Nonnull)identifier;
	[Export ("beaconItemsCountWithRegionIdentifier:")]
	nint BeaconItemsCountWithRegionIdentifier (string identifier);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

// @interface NITBeaconProximityItem : NSObject
[BaseType (typeof(NSObject))]
interface NITBeaconProximityItem
{
	// @property (nonatomic, strong) NSString * _Nonnull identifier;
	[Export ("identifier", ArgumentSemantic.Strong)]
	string Identifier { get; set; }

	// @property (nonatomic) CLProximity proximity;
	[Export ("proximity", ArgumentSemantic.Assign)]
	CLProximity Proximity { get; set; }
}

// @interface NITBeaconRadar : NITBeaconBaseRadar
[BaseType (typeof(NITBeaconBaseRadar))]
interface NITBeaconRadar
{
}

// @protocol NITBeaconVisitManagerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITBeaconVisitManagerDelegate
{
	// @required -(void)beaconVisitManager:(NITBeaconVisitManager * _Nonnull)visitManager didVisitNewNode:(NITBeaconNode * _Nonnull)node;
	[Abstract]
	[Export ("beaconVisitManager:didVisitNewNode:")]
	void DidVisitNewNode (NITBeaconVisitManager visitManager, NITBeaconNode node);

	// @required -(void)beaconVisitManager:(NITBeaconVisitManager * _Nonnull)visitManager didLeaveNode:(NITBeaconNode * _Nonnull)node;
	[Abstract]
	[Export ("beaconVisitManager:didLeaveNode:")]
	void DidLeaveNode (NITBeaconVisitManager visitManager, NITBeaconNode node);
}

// @interface NITBeaconVisitManager : NSObject
[BaseType (typeof(NSObject))]
interface NITBeaconVisitManager
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITBeaconVisitManagerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITBeaconVisitManagerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic) NSTimeInterval timeWindow;
	[Export ("timeWindow")]
	double TimeWindow { get; set; }

	// -(instancetype _Nonnull)initWithDateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithDateManager:")]
	IntPtr Constructor (NITDateManager dateManager);

	// -(void)visitWithBeaconNode:(NITBeaconNode * _Nonnull)beaconNode;
	[Export ("visitWithBeaconNode:")]
	void VisitWithBeaconNode (NITBeaconNode beaconNode);

	// -(void)checkIn;
	[Export ("checkIn")]
	void CheckIn ();

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

// @protocol NITCacheManagerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITCacheManagerDelegate
{
	// @required -(void)cacheManager:(NITCacheManager * _Nonnull)cacheManager didSaveKey:(NSString * _Nonnull)key;
	[Abstract]
	[Export ("cacheManager:didSaveKey:")]
	void DidSaveKey (NITCacheManager cacheManager, string key);
}

// @interface NITCacheManager : NSObject
[BaseType (typeof(NSObject))]
interface NITCacheManager
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITCacheManagerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITCacheManagerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// +(instancetype _Nonnull)sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	NITCacheManager SharedInstance ();

	// -(instancetype _Nonnull)initWithAppId:(NSString * _Nonnull)appId;
	[Export ("initWithAppId:")]
	IntPtr Constructor (string appId);

	// -(void)setAppId:(NSString * _Nonnull)appId;
	[Export ("setAppId:")]
	void SetAppId (string appId);

	// -(NSString * _Nonnull)appDirectory;
	[Export ("appDirectory")]
	[Verify (MethodToProperty)]
	string AppDirectory { get; }

	// -(void)saveWithArray:(NSArray * _Nonnull)array forKey:(NSString * _Nonnull)key;
	[Export ("saveWithArray:forKey:")]
	[Verify (StronglyTypedNSArray)]
	void SaveWithArray (NSObject[] array, string key);

	// -(void)saveWithObject:(id<NSCoding> _Nonnull)object forKey:(NSString * _Nonnull)key;
	[Export ("saveWithObject:forKey:")]
	void SaveWithObject (NSCoding @object, string key);

	// -(NSArray * _Nullable)loadArrayForKey:(NSString * _Nonnull)key;
	[Export ("loadArrayForKey:")]
	[Verify (StronglyTypedNSArray)]
	[return: NullAllowed]
	NSObject[] LoadArrayForKey (string key);

	// -(NSDictionary * _Nullable)loadDictionaryForKey:(NSString * _Nonnull)key;
	[Export ("loadDictionaryForKey:")]
	[return: NullAllowed]
	NSDictionary LoadDictionaryForKey (string key);

	// -(id _Nullable)loadObjectForKey:(NSString * _Nonnull)key;
	[Export ("loadObjectForKey:")]
	[return: NullAllowed]
	NSObject LoadObjectForKey (string key);

	// -(NSString * _Nullable)loadStringForKey:(NSString * _Nonnull)key;
	[Export ("loadStringForKey:")]
	[return: NullAllowed]
	string LoadStringForKey (string key);

	// -(NSNumber * _Nullable)loadNumberForKey:(NSString * _Nonnull)key;
	[Export ("loadNumberForKey:")]
	[return: NullAllowed]
	NSNumber LoadNumberForKey (string key);

	// -(BOOL)removeKey:(NSString * _Nonnull)key;
	[Export ("removeKey:")]
	bool RemoveKey (string key);

	// -(BOOL)existsItemForKey:(NSString * _Nonnull)key;
	[Export ("existsItemForKey:")]
	bool ExistsItemForKey (string key);

	// -(void)removeAllItemsWithCompletionHandler:(void (^ _Nullable)(void))handler;
	[Export ("removeAllItemsWithCompletionHandler:")]
	void RemoveAllItemsWithCompletionHandler ([NullAllowed] Action handler);

	// -(NSInteger)numberOfStoredKeys;
	[Export ("numberOfStoredKeys")]
	[Verify (MethodToProperty)]
	nint NumberOfStoredKeys { get; }
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

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const NSTimeInterval NITConfigurationDefaultSchedulePeriod;
	[Field ("NITConfigurationDefaultSchedulePeriod", "__Internal")]
	double NITConfigurationDefaultSchedulePeriod { get; }
}

// @protocol NITConfigurationDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITConfigurationDelegate
{
	// @required -(void)configurationDidOptOut:(NITConfiguration * _Nonnull)configuration;
	[Abstract]
	[Export ("configurationDidOptOut:")]
	void ConfigurationDidOptOut (NITConfiguration configuration);
}

// @interface NITConfiguration : NSObject
[BaseType (typeof(NSObject))]
interface NITConfiguration
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITConfigurationDelegate Delegate { get; set; }

	// @property (nonatomic, strong) id<NITConfigurationDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Strong)]
	NSObject WeakDelegate { get; set; }

	// +(NITConfiguration * _Nonnull)defaultConfiguration;
	[Static]
	[Export ("defaultConfiguration")]
	[Verify (MethodToProperty)]
	NITConfiguration DefaultConfiguration { get; }

	// -(instancetype _Nonnull)initWithUserDefaults:(NSUserDefaults * _Nonnull)userDefaults;
	[Export ("initWithUserDefaults:")]
	IntPtr Constructor (NSUserDefaults userDefaults);

	// -(NSString * _Nonnull)paramKeyWithKey:(NSString * _Nonnull)key;
	[Export ("paramKeyWithKey:")]
	string ParamKeyWithKey (string key);

	// -(NSString * _Nullable)apiKey;
	// -(void)setApiKey:(NSString * _Nonnull)apiKey;
	[NullAllowed, Export ("apiKey")]
	[Verify (MethodToProperty)]
	string ApiKey { get; set; }

	// -(NSString * _Nullable)appId;
	// -(void)setAppId:(NSString * _Nonnull)appId;
	[NullAllowed, Export ("appId")]
	[Verify (MethodToProperty)]
	string AppId { get; set; }

	// -(NSString * _Nullable)profileId;
	// -(void)setProfileId:(NSString * _Nullable)profileId;
	[NullAllowed, Export ("profileId")]
	[Verify (MethodToProperty)]
	string ProfileId { get; set; }

	// -(NSString * _Nullable)installationId;
	[Export ("installationId")]
	[return: NullAllowed]
	string InstallationId ();

	// -(void)setInstallationId:(NSString * _Nullable)installationId;
	[Export ("setInstallationId:")]
	void SetInstallationId ([NullAllowed] string installationId);

	// -(NSString * _Nullable)deviceToken;
	[Export ("deviceToken")]
	[return: NullAllowed]
	string DeviceToken ();

	// -(void)setDeviceToken:(NSString * _Nonnull)deviceToken;
	[Export ("setDeviceToken:")]
	void SetDeviceToken (string deviceToken);

	// -(BOOL)isOptOut;
	[Export ("isOptOut")]
	bool IsOptOut ();

	// -(void)setOptOut:(BOOL)optOut;
	[Export ("setOptOut:")]
	void SetOptOut (bool optOut);

	// -(BOOL)isProfileExplicit;
	[Export ("isProfileExplicit")]
	bool IsProfileExplicit ();

	// -(void)setProfileExplicit:(BOOL)profileExplicit;
	[Export ("setProfileExplicit:")]
	void SetProfileExplicit (bool profileExplicit);

	// -(NSTimeInterval)schedulePeriod;
	[Export ("schedulePeriod")]
	double SchedulePeriod ();

	// -(void)setSchedulePeriod:(NSTimeInterval)schedulePeriod;
	[Export ("setSchedulePeriod:")]
	void SetSchedulePeriod (double schedulePeriod);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
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

// @protocol NITNetworkManaging <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITNetworkManaging
{
	// @required -(void)makeRequestWithURLRequest:(NSURLRequest * _Nonnull)request jsonApicompletionHandler:(void (^ _Nonnull)(NITJSONAPI * _Nullable, NSError * _Nullable))completionHandler;
	[Abstract]
	[Export ("makeRequestWithURLRequest:jsonApicompletionHandler:")]
	void JsonApicompletionHandler (NSUrlRequest request, Action<NITJSONAPI, NSError> completionHandler);
}

// @interface NITReaction : NSObject
[BaseType (typeof(NSObject))]
interface NITReaction
{
	// @property (nonatomic, strong) NITCacheManager * _Nonnull cacheManager;
	[Export ("cacheManager", ArgumentSemantic.Strong)]
	NITCacheManager CacheManager { get; set; }

	// @property (nonatomic, strong) id<NITNetworkManaging> _Nonnull networkManager;
	[Export ("networkManager", ArgumentSemantic.Strong)]
	NITNetworkManaging NetworkManager { get; set; }

	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager networkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithCacheManager:networkManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITNetworkManaging networkManager);

	// -(NSString * _Nonnull)pluginName;
	[Export ("pluginName")]
	[Verify (MethodToProperty)]
	string PluginName { get; }

	// -(void)contentWithRecipe:(NITRecipe * _Nonnull)recipe completionHandler:(void (^ _Nullable)(NITReactionBundle * _Nullable, NSError * _Nullable))handler;
	[Export ("contentWithRecipe:completionHandler:")]
	void ContentWithRecipe (NITRecipe recipe, [NullAllowed] Action<NITReactionBundle, NSError> handler);

	// -(void)contentWithReactionBundleId:(NSString * _Nonnull)reactionBundleId recipeId:(NSString * _Nonnull)recipeId completionHandler:(void (^ _Nullable)(NITReactionBundle * _Nullable, NSError * _Nullable))handler;
	[Export ("contentWithReactionBundleId:recipeId:completionHandler:")]
	void ContentWithReactionBundleId (string reactionBundleId, string recipeId, [NullAllowed] Action<NITReactionBundle, NSError> handler);

	// -(NITReactionBundle * _Nullable)contentWithJsonReactionBundle:(NSDictionary<NSString *,id> * _Nonnull)jsonReactionBundle trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
	[Export ("contentWithJsonReactionBundle:trackingInfo:")]
	[return: NullAllowed]
	NITReactionBundle ContentWithJsonReactionBundle (NSDictionary<NSString, NSObject> jsonReactionBundle, NITTrackingInfo trackingInfo);

	// -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
	[Export ("refreshConfigWithCompletionHandler:")]
	void RefreshConfigWithCompletionHandler ([NullAllowed] Action<NSError> handler);

	// -(NITReactionBundle * _Nullable)localContentWithBundleID:(NSString * _Nullable)bundleID notificationText:(NSString * _Nullable)notificationText trackingInfo:(NITTrackingInfo * _Nullable)trackingInfo;
	[Export ("localContentWithBundleID:notificationText:trackingInfo:")]
	[return: NullAllowed]
	NITReactionBundle LocalContentWithBundleID ([NullAllowed] string bundleID, [NullAllowed] string notificationText, [NullAllowed] NITTrackingInfo trackingInfo);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const NITContentPluginName;
	[Field ("NITContentPluginName", "__Internal")]
	NSString NITContentPluginName { get; }
}

// @interface NITContentReaction : NITReaction
[BaseType (typeof(NITReaction))]
interface NITContentReaction
{
}

// @protocol NITValidating <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITValidating
{
	// @required -(BOOL)isValidWithRecipe:(NITRecipe *)recipe;
	[Abstract]
	[Export ("isValidWithRecipe:")]
	bool IsValidWithRecipe (NITRecipe recipe);
}

// @interface NITCooldownValidator : NSObject <NITValidating>
[BaseType (typeof(NSObject))]
interface NITCooldownValidator : INITValidating
{
	// -(instancetype _Nonnull)initWithRecipeHistory:(NITRecipeHistory * _Nonnull)recipeHistory dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithRecipeHistory:dateManager:")]
	IntPtr Constructor (NITRecipeHistory recipeHistory, NITDateManager dateManager);
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

	// @property (nonatomic, strong) NSArray<NITClaim *> * claims;
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

	// -(BOOL)hasContentToInclude;
	[Export ("hasContentToInclude")]
	[Verify (MethodToProperty)]
	bool HasContentToInclude { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITCouponPluginName;
	[Field ("NITCouponPluginName", "__Internal")]
	NSString NITCouponPluginName { get; }
}

// @interface NITCouponReaction : NITReaction
[BaseType (typeof(NITReaction))]
interface NITCouponReaction
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager configuration:(NITConfiguration * _Nonnull)configuration networkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithCacheManager:configuration:networkManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITConfiguration configuration, NITNetworkManaging networkManager);

	// -(void)couponsWithCompletionHandler:(void (^ _Nullable)(NSArray<NITCoupon *> * _Nullable, NSError * _Nullable))handler;
	[Export ("couponsWithCompletionHandler:")]
	void CouponsWithCompletionHandler ([NullAllowed] Action<NSArray<NITCoupon>, NSError> handler);
}

// @interface NITCustomJSON : NITReactionBundle <NSCoding>
[BaseType (typeof(NITReactionBundle))]
interface NITCustomJSON : INSCoding
{
	// @property (nonatomic, strong) NSDictionary<NSString *,id> * content;
	[Export ("content", ArgumentSemantic.Strong)]
	NSDictionary<NSString, NSObject> Content { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const NITCustomJSONPluginName;
	[Field ("NITCustomJSONPluginName", "__Internal")]
	NSString NITCustomJSONPluginName { get; }
}

// @interface NITCustomJSONReaction : NITReaction
[BaseType (typeof(NITReaction))]
interface NITCustomJSONReaction
{
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const NITCustomTriggerPluginName;
	[Field ("NITCustomTriggerPluginName", "__Internal")]
	NSString NITCustomTriggerPluginName { get; }

	// extern NSString *const NITCustomTriggerAction;
	[Field ("NITCustomTriggerAction", "__Internal")]
	NSString NITCustomTriggerAction { get; }
}

// @interface NITCustomTriggerRequest : NSObject
[BaseType (typeof(NSObject))]
interface NITCustomTriggerRequest
{
	// +(NITTriggerRequest * _Nonnull)buildTriggerRequestWithKey:(NSString *)key;
	[Static]
	[Export ("buildTriggerRequestWithKey:")]
	NITTriggerRequest BuildTriggerRequestWithKey (string key);
}

// @interface NITDateManager : NSObject
[BaseType (typeof(NSObject))]
interface NITDateManager
{
	// -(NSDate *)currentDate;
	[Export ("currentDate")]
	[Verify (MethodToProperty)]
	NSDate CurrentDate { get; }

	// -(NSTimeInterval)currentTimestamp;
	[Export ("currentTimestamp")]
	[Verify (MethodToProperty)]
	double CurrentTimestamp { get; }
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

// @interface NITDefaultLogger : NSObject <NITLogger>
[BaseType (typeof(NSObject))]
interface NITDefaultLogger : INITLogger
{
}

// @interface NITEnrollDeviceViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface NITEnrollDeviceViewController
{
	// @property (nonatomic, strong) UITextField * _Nonnull deviceName __attribute__((iboutlet));
	[Export ("deviceName", ArgumentSemantic.Strong)]
	UITextField DeviceName { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull containerView __attribute__((iboutlet));
	[Export ("containerView", ArgumentSemantic.Strong)]
	UIView ContainerView { get; set; }

	// @property (nonatomic, strong) UIScrollView * _Nonnull scrollView __attribute__((iboutlet));
	[Export ("scrollView", ArgumentSemantic.Strong)]
	UIScrollView ScrollView { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull contentView __attribute__((iboutlet));
	[Export ("contentView", ArgumentSemantic.Strong)]
	UIView ContentView { get; set; }

	// @property (nonatomic, strong) NSLayoutConstraint * _Nonnull bottomContainerCnst __attribute__((iboutlet));
	[Export ("bottomContainerCnst", ArgumentSemantic.Strong)]
	NSLayoutConstraint BottomContainerCnst { get; set; }

	// @property (nonatomic, strong) NSLayoutConstraint * _Nonnull scrollHeightConstraint __attribute__((iboutlet));
	[Export ("scrollHeightConstraint", ArgumentSemantic.Strong)]
	NSLayoutConstraint ScrollHeightConstraint { get; set; }

	// @property (nonatomic, strong) UIButton * _Nonnull addButton __attribute__((iboutlet));
	[Export ("addButton", ArgumentSemantic.Strong)]
	UIButton AddButton { get; set; }

	// @property (nonatomic, strong) UIButton * _Nonnull sendButton __attribute__((iboutlet));
	[Export ("sendButton", ArgumentSemantic.Strong)]
	UIButton SendButton { get; set; }

	// @property (nonatomic, strong) UILabel * _Nonnull titleLabel __attribute__((iboutlet));
	[Export ("titleLabel", ArgumentSemantic.Strong)]
	UILabel TitleLabel { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull loadingView __attribute__((iboutlet));
	[Export ("loadingView", ArgumentSemantic.Strong)]
	UIView LoadingView { get; set; }

	// @property (nonatomic, strong) UIActivityIndicatorView * _Nonnull activityIndicator __attribute__((iboutlet));
	[Export ("activityIndicator", ArgumentSemantic.Strong)]
	UIActivityIndicatorView ActivityIndicator { get; set; }

	// -(instancetype _Nonnull)initWithInstallation:(NITInstallation * _Nonnull)installation configuration:(NITConfiguration * _Nonnull)configuration;
	[Export ("initWithInstallation:configuration:")]
	IntPtr Constructor (NITInstallation installation, NITConfiguration configuration);

	// -(void)tapEnroll:(id _Nullable)sender __attribute__((ibaction));
	[Export ("tapEnroll:")]
	void TapEnroll ([NullAllowed] NSObject sender);

	// -(void)tapSendReport:(id _Nullable)sender __attribute__((ibaction));
	[Export ("tapSendReport:")]
	void TapSendReport ([NullAllowed] NSObject sender);

	// -(void)tapClose:(id _Nullable)sender __attribute__((ibaction));
	[Export ("tapClose:")]
	void TapClose ([NullAllowed] NSObject sender);
}

// @interface NITEvaluationBodyBuilder : NSObject
[BaseType (typeof(NSObject))]
interface NITEvaluationBodyBuilder
{
	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration recipeHistory:(NITRecipeHistory * _Nonnull)recipeHistory dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithConfiguration:recipeHistory:dateManager:")]
	IntPtr Constructor (NITConfiguration configuration, NITRecipeHistory recipeHistory, NITDateManager dateManager);

	// -(NITJSONAPI * _Nonnull)buildEvaluationBody;
	[Export ("buildEvaluationBody")]
	[Verify (MethodToProperty)]
	NITJSONAPI BuildEvaluationBody { get; }

	// -(NITJSONAPI * _Nonnull)buildEvaluationBodyWithPlugin:(NSString * _Nullable)plugin action:(NSString * _Nullable)action bundle:(NSString * _Nullable)bundle;
	[Export ("buildEvaluationBodyWithPlugin:action:bundle:")]
	NITJSONAPI BuildEvaluationBodyWithPlugin ([NullAllowed] string plugin, [NullAllowed] string action, [NullAllowed] string bundle);
}

// @interface NITEvent : NSObject
[BaseType (typeof(NSObject))]
interface NITEvent
{
	// -(NSString * _Nonnull)pluginName;
	[Export ("pluginName")]
	[Verify (MethodToProperty)]
	string PluginName { get; }
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

	// -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback rating:(NSInteger)rating comment:(NSString * _Nonnull)comment;
	[Export ("initWithFeedback:rating:comment:")]
	IntPtr Constructor (NITFeedback feedback, nint rating, string comment);

	// -(NITJSONAPI * _Nullable)toJsonAPI:(NITConfiguration * _Nonnull)configuration;
	[Export ("toJsonAPI:")]
	[return: NullAllowed]
	NITJSONAPI ToJsonAPI (NITConfiguration configuration);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITFeedbackPluginName;
	[Field ("NITFeedbackPluginName", "__Internal")]
	NSString NITFeedbackPluginName { get; }
}

// @interface NITFeedbackReaction : NITReaction
[BaseType (typeof(NITReaction))]
interface NITFeedbackReaction
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager configuration:(NITConfiguration * _Nonnull)configuration networkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithCacheManager:configuration:networkManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITConfiguration configuration, NITNetworkManaging networkManager);

	// -(void)sendEventWithFeedbackEvent:(NITFeedbackEvent * _Nonnull)event completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
	[Export ("sendEventWithFeedbackEvent:completionHandler:")]
	void SendEventWithFeedbackEvent (NITFeedbackEvent @event, [NullAllowed] Action<NSError> handler);
}

// @interface NITGeofenceNode : NITNode <NSCoding>
[BaseType (typeof(NITNode))]
interface NITGeofenceNode : INSCoding
{
	// @property (nonatomic, strong) NSNumber * latitude;
	[Export ("latitude", ArgumentSemantic.Strong)]
	NSNumber Latitude { get; set; }

	// @property (nonatomic, strong) NSNumber * longitude;
	[Export ("longitude", ArgumentSemantic.Strong)]
	NSNumber Longitude { get; set; }

	// @property (nonatomic, strong) NSNumber * radius;
	[Export ("radius", ArgumentSemantic.Strong)]
	NSNumber Radius { get; set; }
}

// @protocol NITGeopolisRadarDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITGeopolisRadarDelegate
{
	// @required -(void)geopolisRadar:(NITGeopolisBaseRadar * _Nonnull)geopolisRadar didTriggerWithNode:(NITNode * _Nonnull)node event:(NITRegionEvent)event;
	[Abstract]
	[Export ("geopolisRadar:didTriggerWithNode:event:")]
	void DidTriggerWithNode (NITGeopolisBaseRadar geopolisRadar, NITNode node, NITRegionEvent @event);
}

// @interface NITGeopolisBaseRadar : NSObject
[BaseType (typeof(NSObject))]
interface NITGeopolisBaseRadar
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITGeopolisRadarDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITGeopolisRadarDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (readonly, nonatomic) BOOL isStarted;
	[Export ("isStarted")]
	bool IsStarted { get; }

	// -(instancetype _Nonnull)initWithNodesManager:(NITNodesManager2 * _Nonnull)nodesManager locationManager:(CLLocationManager * _Nonnull)locationManager beaconRadar:(NITBeaconBaseRadar * _Nonnull)beaconRadar neighborResolver:(NITNeighborResolver * _Nonnull)neighborResolver state:(NITGeopolisState * _Nonnull)state locationHistory:(NITLocationHistory * _Nonnull)locationHistory;
	[Export ("initWithNodesManager:locationManager:beaconRadar:neighborResolver:state:locationHistory:")]
	IntPtr Constructor (NITNodesManager2 nodesManager, CLLocationManager locationManager, NITBeaconBaseRadar beaconRadar, NITNeighborResolver neighborResolver, NITGeopolisState state, NITLocationHistory locationHistory);

	// -(BOOL)start;
	[Export ("start")]
	[Verify (MethodToProperty)]
	bool Start { get; }

	// -(void)stop;
	[Export ("stop")]
	void Stop ();

	// -(BOOL)sameContainerWithNode:(NITNode * _Nullable)node otherNode:(NITNode * _Nullable)otherNode;
	[Export ("sameContainerWithNode:otherNode:")]
	bool SameContainerWithNode ([NullAllowed] NITNode node, [NullAllowed] NITNode otherNode);

	// -(BOOL)hasBeaconChildren:(NITTreeLevel * _Nullable)level;
	[Export ("hasBeaconChildren:")]
	bool HasBeaconChildren ([NullAllowed] NITTreeLevel level);

	// -(void)triggerWithEvent:(NITRegionEvent)event node:(NITNode * _Nonnull)node;
	[Export ("triggerWithEvent:node:")]
	void TriggerWithEvent (NITRegionEvent @event, NITNode node);

	// -(void)clearState;
	[Export ("clearState")]
	void ClearState ();

	// -(void)startFromRootLevel;
	[Export ("startFromRootLevel")]
	void StartFromRootLevel ();
}

// @interface NITGeopolisForegroundRadar : NITGeopolisBaseRadar
[BaseType (typeof(NITGeopolisBaseRadar))]
interface NITGeopolisForegroundRadar
{
}

// @protocol NITManaging <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITManaging
{
	// @required -(void)recipesManager:(NITRecipesManager * _Nonnull)recipesManager gotRecipe:(NITRecipe * _Nonnull)recipe trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
	[Abstract]
	[Export ("recipesManager:gotRecipe:trackingInfo:")]
	void GotRecipe (NITRecipesManager recipesManager, NITRecipe recipe, NITTrackingInfo trackingInfo);
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

	// @optional -(void)manager:(NITManager * _Nonnull)manager alertWantsToShowContent:(id _Nonnull)content;
	[Export ("manager:alertWantsToShowContent:")]
	void AlertWantsToShowContent (NITManager manager, NSObject content);
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
	[Verify (MethodToProperty)]
	NITManager DefaultManager { get; }

	// +(void)setFrameworkName:(NSString * _Nonnull)frameworkName;
	[Static]
	[Export ("setFrameworkName:")]
	void SetFrameworkName (string frameworkName);

	// -(void)start;
	[Export ("start")]
	void Start ();

	// -(void)stop;
	[Export ("stop")]
	void Stop ();

	// -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler __attribute__((deprecated("")));
	[Export ("refreshConfigWithCompletionHandler:")]
	void RefreshConfigWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

	// -(void)setDeviceTokenWithData:(NSData * _Nonnull)token;
	[Export ("setDeviceTokenWithData:")]
	void SetDeviceTokenWithData (NSData token);

	// -(BOOL)processRecipeSimpleWithUserInfo:(NSDictionary<NSString *,id> * _Nullable)userInfo;
	[Export ("processRecipeSimpleWithUserInfo:")]
	bool ProcessRecipeSimpleWithUserInfo ([NullAllowed] NSDictionary<NSString, NSObject> userInfo);

	// -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
	[Export ("sendTrackingWithTrackingInfo:event:")]
	void SendTrackingWithTrackingInfo ([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler __attribute__((deprecated("Use setUserData("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
	[Export ("setUserDataWithKey:value:completionHandler:")]
	void SetUserDataWithKey (string key, [NullAllowed] string value, [NullAllowed] Action<NSError> handler);

	// -(void)setBatchUserDataWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)valuesDictiornary completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler __attribute__((deprecated("Use setUserData("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
	[Export ("setBatchUserDataWithDictionary:completionHandler:")]
	void SetBatchUserDataWithDictionary (NSDictionary<NSString, NSObject> valuesDictiornary, [NullAllowed] Action<NSError> handler);

	// -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value __attribute__((deprecated("Use setUserDataWithKey("MY_KEY", value:"MY_VALUE")"))) __attribute__((deprecated("")));
	[Export ("setDeferredUserDataWithKey:value:")]
	void SetDeferredUserDataWithKey (string key, [NullAllowed] string value);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value;
	[Export ("setUserDataWithKey:value:")]
	void SetUserDataWithKey (string key, [NullAllowed] string value);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key multiValue:(NSDictionary<NSString *,NSNumber *> * _Nullable)value;
	[Export ("setUserDataWithKey:multiValue:")]
	void SetUserDataWithKey (string key, [NullAllowed] NSDictionary<NSString, NSNumber> value);

	// -(void)sendEventWithEvent:(NITEvent * _Nonnull)event completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
	[Export ("sendEventWithEvent:completionHandler:")]
	void SendEventWithEvent (NITEvent @event, [NullAllowed] Action<NSError> handler);

	// -(void)couponsWithCompletionHandler:(void (^ _Nullable)(NSArray<NITCoupon *> * _Nullable, NSError * _Nullable))handler;
	[Export ("couponsWithCompletionHandler:")]
	void CouponsWithCompletionHandler ([NullAllowed] Action<NSArray<NITCoupon>, NSError> handler);

	// -(void)recipesWithCompletionHandler:(void (^ _Nullable)(NSArray<NITRecipe *> * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("recipesWithCompletionHandler:")]
	void RecipesWithCompletionHandler ([NullAllowed] Action<NSArray<NITRecipe>, NSError> completionHandler);

	// -(void)processRecipeWithId:(NSString * _Nonnull)recipeId;
	[Export ("processRecipeWithId:")]
	void ProcessRecipeWithId (string recipeId);

	// -(BOOL)processRecipeWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("processRecipeWithUserInfo:completion:")]
	bool ProcessRecipeWithUserInfo (NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

	// -(BOOL)processRecipeWithResponse:(UNNotificationResponse *)response completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("processRecipeWithResponse:completion:")]
	bool ProcessRecipeWithResponse (UNNotificationResponse response, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

	// -(void)resetProfile __attribute__((deprecated("Use resetProfileWithCompletionHandler"))) __attribute__((deprecated("")));
	[Export ("resetProfile")]
	void ResetProfile ();

	// -(void)resetProfileWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
	[Export ("resetProfileWithCompletionHandler:")]
	void ResetProfileWithCompletionHandler (Action<NSString, NSError> handler);

	// -(NSString * _Nullable)profileId __attribute__((deprecated("Use profileIdWithCompletionHandler"))) __attribute__((deprecated("")));
	// -(void)setProfileId:(NSString * _Nonnull)profileId;
	[NullAllowed, Export ("profileId")]
	[Verify (MethodToProperty)]
	string ProfileId { get; set; }

	// -(void)profileIdWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
	[Export ("profileIdWithCompletionHandler:")]
	void ProfileIdWithCompletionHandler (Action<NSString, NSError> handler);

	// -(void)optOutWithCompletionHandler:(void (^ _Nonnull)(BOOL))handler;
	[Export ("optOutWithCompletionHandler:")]
	void OptOutWithCompletionHandler (Action<bool> handler);

	// -(void)processCustomTriggerWithKey:(NSString * _Nonnull)key __attribute__((deprecated("Use triggerInAppEventWithKey"))) __attribute__((deprecated("")));
	[Export ("processCustomTriggerWithKey:")]
	void ProcessCustomTriggerWithKey (string key);

	// -(void)triggerInAppEventWithKey:(NSString * _Nonnull)key;
	[Export ("triggerInAppEventWithKey:")]
	void TriggerInAppEventWithKey (string key);

	// -(void)application:(UIApplication * _Nonnull)application performFetchWithCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
	[Export ("application:performFetchWithCompletionHandler:")]
	void Application (UIApplication application, Action<UIBackgroundFetchResult> completionHandler);

	// -(void)parseContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo contentDelegate:(id<NITContentDelegate> _Nonnull)contentDelegate;
	[Export ("parseContent:trackingInfo:contentDelegate:")]
	void ParseContent (NSObject content, NITTrackingInfo trackingInfo, NITContentDelegate contentDelegate);

	// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nullable)options;
	[Export ("application:openURL:options:")]
	bool Application (UIApplication application, NSUrl url, [NullAllowed] NSDictionary<NSString, NSObject> options);

	// -(void)historyWithCompletion:(void (^ _Nonnull)(NSArray<NITHistoryItem *> * _Nullable, NSError * _Nullable))completion;
	[Export ("historyWithCompletion:")]
	void HistoryWithCompletion (Action<NSArray<NITHistoryItem>, NSError> completion);
}

// @protocol NITRecipesManaging <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITRecipesManaging
{
	// @required -(void)gotTriggerRequest:(NITTriggerRequest * _Nonnull)request;
	[Abstract]
	[Export ("gotTriggerRequest:")]
	void GotTriggerRequest (NITTriggerRequest request);
}

// @interface NITRecipesManager : NSObject <NITRecipesManaging>
[BaseType (typeof(NSObject))]
interface NITRecipesManager : INITRecipesManaging
{
	// @property (nonatomic, strong) id<NITManaging> _Nullable manager;
	[NullAllowed, Export ("manager", ArgumentSemantic.Strong)]
	NITManaging Manager { get; set; }

	// -(instancetype _Nonnull)initWithRecipeValidationFilter:(NITRecipeValidationFilter * _Nonnull)recipeValidationFilter repository:(NITRecipeRepository * _Nonnull)repository trackSender:(NITRecipeTrackSender * _Nonnull)trackSender api:(NITRecipesApi * _Nonnull)api requestQueue:(NITTriggerRequestQueue * _Nonnull)requestQueue notificationHistoryManager:(NITNotificationHistoryManager * _Nonnull)notificationHistoryManager;
	[Export ("initWithRecipeValidationFilter:repository:trackSender:api:requestQueue:notificationHistoryManager:")]
	IntPtr Constructor (NITRecipeValidationFilter recipeValidationFilter, NITRecipeRepository repository, NITRecipeTrackSender trackSender, NITRecipesApi api, NITTriggerRequestQueue requestQueue, NITNotificationHistoryManager notificationHistoryManager);

	// +(NITRecipesManager * _Nonnull)obtainRecipesManagerWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager cacheManager:(NITCacheManager * _Nonnull)cacheManager configuration:(NITConfiguration * _Nonnull)configuration trackManager:(NITTrackManager * _Nonnull)trackManager notificationHistoryManager:(NITNotificationHistoryManager * _Nonnull)notificationHistoryManager history:(NITRecipeHistory * _Nonnull)history;
	[Static]
	[Export ("obtainRecipesManagerWithNetworkManager:cacheManager:configuration:trackManager:notificationHistoryManager:history:")]
	NITRecipesManager ObtainRecipesManagerWithNetworkManager (NITNetworkManaging networkManager, NITCacheManager cacheManager, NITConfiguration configuration, NITTrackManager trackManager, NITNotificationHistoryManager notificationHistoryManager, NITRecipeHistory history);

	// -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
	[Export ("refreshConfigWithCompletionHandler:")]
	void RefreshConfigWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

	// -(void)recipesWithCompletionHandler:(void (^ _Nullable)(NSArray<NITRecipe *> * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("recipesWithCompletionHandler:")]
	void RecipesWithCompletionHandler ([NullAllowed] Action<NSArray<NITRecipe>, NSError> completionHandler);

	// -(void)refreshConfigCheckTimeWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
	[Export ("refreshConfigCheckTimeWithCompletionHandler:")]
	void RefreshConfigCheckTimeWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

	// -(void)processRecipe:(NSString * _Nonnull)recipeId;
	[Export ("processRecipe:")]
	void ProcessRecipe (string recipeId);

	// -(void)processRecipe:(NSString * _Nonnull)recipeId completion:(void (^ _Nullable)(NITRecipe * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("processRecipe:completion:")]
	void ProcessRecipe (string recipeId, [NullAllowed] Action<NITRecipe, NSError> completionHandler);

	// -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
	[Export ("sendTrackingWithTrackingInfo:event:")]
	void SendTrackingWithTrackingInfo ([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);

	// -(NSInteger)recipesCount;
	[Export ("recipesCount")]
	[Verify (MethodToProperty)]
	nint RecipesCount { get; }

	// -(void)processCustomTriggerWithKey:(NSString * _Nonnull)key;
	[Export ("processCustomTriggerWithKey:")]
	void ProcessCustomTriggerWithKey (string key);
}

// @interface NITGeopolisManager : NSObject
[BaseType (typeof(NSObject))]
interface NITGeopolisManager
{
	// @property (nonatomic, weak) id<NITRecipesManaging> _Nullable recipesManager;
	[NullAllowed, Export ("recipesManager", ArgumentSemantic.Weak)]
	NITRecipesManaging RecipesManager { get; set; }

	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration trackManager:(NITTrackManager * _Nonnull)trackManager repository:(NITNodeRepository * _Nonnull)repository geopolisRadar:(NITGeopolisRadar * _Nonnull)radar geopolisForegroundRadar:(NITGeopolisForegroundRadar * _Nonnull)foregroundRadar locationManager:(CLLocationManager * _Nonnull)locationManager;
	[Export ("initWithConfiguration:trackManager:repository:geopolisRadar:geopolisForegroundRadar:locationManager:")]
	IntPtr Constructor (NITConfiguration configuration, NITTrackManager trackManager, NITNodeRepository repository, NITGeopolisRadar radar, NITGeopolisForegroundRadar foregroundRadar, CLLocationManager locationManager);

	// +(NITGeopolisManager * _Nonnull)obtainGeopolisManagerWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager cacheManager:(NITCacheManager * _Nonnull)cacheManager configuration:(NITConfiguration * _Nonnull)configuration trackManager:(NITTrackManager * _Nonnull)trackManager internetReachability:(NITReachability * _Nonnull)internetReachability locationHistory:(NITLocationHistory * _Nonnull)locationHistory;
	[Static]
	[Export ("obtainGeopolisManagerWithNetworkManager:cacheManager:configuration:trackManager:internetReachability:locationHistory:")]
	NITGeopolisManager ObtainGeopolisManagerWithNetworkManager (NITNetworkManaging networkManager, NITCacheManager cacheManager, NITConfiguration configuration, NITTrackManager trackManager, NITReachability internetReachability, NITLocationHistory locationHistory);

	// -(void)refreshConfigWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("refreshConfigWithCompletionHandler:")]
	void RefreshConfigWithCompletionHandler (Action<NSError> completionHandler);

	// -(void)refreshConfigCheckTimeWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
	[Export ("refreshConfigCheckTimeWithCompletionHandler:")]
	void RefreshConfigCheckTimeWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

	// -(void)start;
	[Export ("start")]
	void Start ();

	// -(void)syncWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("syncWithCompletionHandler:")]
	void SyncWithCompletionHandler (Action<NSError> completionHandler);

	// -(void)stop;
	[Export ("stop")]
	void Stop ();

	// -(void)restart;
	[Export ("restart")]
	void Restart ();

	// -(BOOL)hasCurrentNode;
	[Export ("hasCurrentNode")]
	[Verify (MethodToProperty)]
	bool HasCurrentNode { get; }
}

// @interface NITGeopolisRadar : NITGeopolisBaseRadar
[BaseType (typeof(NITGeopolisBaseRadar))]
interface NITGeopolisRadar
{
	// -(BOOL)restart;
	[Export ("restart")]
	[Verify (MethodToProperty)]
	bool Restart { get; }
}

// @interface NITGeopolisState : NSObject
[BaseType (typeof(NSObject))]
interface NITGeopolisState
{
	// @property (nonatomic, strong) CLLocation * _Nullable location;
	[NullAllowed, Export ("location", ArgumentSemantic.Strong)]
	CLLocation Location { get; set; }

	// @property (nonatomic, strong) NITTreeLevel * _Nullable currentTreeLevel;
	[NullAllowed, Export ("currentTreeLevel", ArgumentSemantic.Strong)]
	NITTreeLevel CurrentTreeLevel { get; set; }

	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cache;
	[Export ("initWithCacheManager:")]
	IntPtr Constructor (NITCacheManager cache);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

// @interface NITHistoryApi : NSObject
[BaseType (typeof(NSObject))]
interface NITHistoryApi
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithNetworkManager:")]
	IntPtr Constructor (NITNetworkManaging networkManager);

	// -(void)remoteHistoryNotificationsWithCompletion:(void (^ _Nonnull)(NSArray<NITRemoteItem *> * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("remoteHistoryNotificationsWithCompletion:")]
	void RemoteHistoryNotificationsWithCompletion (Action<NSArray<NITRemoteItem>, NSError> completionHandler);
}

// @interface NITHistoryEntry : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITHistoryEntry : INSCoding
{
	// @property (nonatomic, strong) NITReactionItem * _Nonnull reactionItem;
	[Export ("reactionItem", ArgumentSemantic.Strong)]
	NITReactionItem ReactionItem { get; set; }

	// @property (nonatomic, strong) NSString * notification;
	[Export ("notification", ArgumentSemantic.Strong)]
	string Notification { get; set; }

	// @property (nonatomic, strong) NITTrackingInfo * trackingInfo;
	[Export ("trackingInfo", ArgumentSemantic.Strong)]
	NITTrackingInfo TrackingInfo { get; set; }

	// @property (nonatomic) NSTimeInterval timestamp;
	[Export ("timestamp")]
	double Timestamp { get; set; }

	// @property (nonatomic) BOOL read;
	[Export ("read")]
	bool Read { get; set; }

	// -(instancetype)initWithReactionItem:(NITReactionItem * _Nonnull)reactionItem notification:(NSString * _Nonnull)notification trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo timestamp:(NSTimeInterval)timestamp read:(BOOL)read;
	[Export ("initWithReactionItem:notification:trackingInfo:timestamp:read:")]
	IntPtr Constructor (NITReactionItem reactionItem, string notification, NITTrackingInfo trackingInfo, double timestamp, bool read);
}

// @interface NITHistoryItem : NSObject
[BaseType (typeof(NSObject))]
interface NITHistoryItem
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
}

// @interface NITHistoryItemResolver : NSObject
[BaseType (typeof(NSObject))]
interface NITHistoryItemResolver
{
	// -(instancetype _Nonnull)initWithReactionsManager:(NITReactionsManager * _Nonnull)reactionsManager;
	[Export ("initWithReactionsManager:")]
	IntPtr Constructor (NITReactionsManager reactionsManager);

	// -(NITHistoryItem * _Nullable)itemFromEntry:(NITHistoryEntry * _Nullable)entry;
	[Export ("itemFromEntry:")]
	[return: NullAllowed]
	NITHistoryItem ItemFromEntry ([NullAllowed] NITHistoryEntry entry);

	// -(NITHistoryItem * _Nullable)itemFromRemote:(NITRemoteItem * _Nullable)remoteItem;
	[Export ("itemFromRemote:")]
	[return: NullAllowed]
	NITHistoryItem ItemFromRemote ([NullAllowed] NITRemoteItem remoteItem);
}

// @interface NITHistoryMerger : NSObject
[BaseType (typeof(NSObject))]
interface NITHistoryMerger
{
	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration itemResolver:(NITHistoryItemResolver *)itemResolver;
	[Export ("initWithConfiguration:itemResolver:")]
	IntPtr Constructor (NITConfiguration configuration, NITHistoryItemResolver itemResolver);

	// -(BOOL)merge:(NSArray<NITRemoteItem *> * _Nonnull)remotePushes and:(NSArray<NITHistoryEntry *> * _Nonnull)local withResults:(NSArray<NITHistoryItem *> ** _Nonnull)results withNotificationsToDelete:(NSArray<NITHistoryEntry *> ** _Nonnull)toDelete;
	[Export ("merge:and:withResults:withNotificationsToDelete:")]
	bool Merge (NITRemoteItem[] remotePushes, NITHistoryEntry[] local, out NITHistoryItem[] results, out NITHistoryEntry[] toDelete);
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
	[Verify (MethodToProperty)]
	NSUrl SmallSizeURL { get; }

	// -(NSURL * _Nullable)url;
	[NullAllowed, Export ("url")]
	[Verify (MethodToProperty)]
	NSUrl Url { get; }
}

// @interface NITInstallation : NSObject
[BaseType (typeof(NSObject))]
interface NITInstallation
{
	// @property (nonatomic) CBManagerState bluetoothState;
	[Export ("bluetoothState", ArgumentSemantic.Assign)]
	CBManagerState BluetoothState { get; set; }

	// @property (nonatomic, strong) NSString * _Nonnull frameworkName;
	[Export ("frameworkName", ArgumentSemantic.Strong)]
	string FrameworkName { get; set; }

	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration networkManager:(id<NITNetworkManaging> _Nonnull)networkManager reachability:(NITReachability * _Nonnull)reachability;
	[Export ("initWithConfiguration:networkManager:reachability:")]
	IntPtr Constructor (NITConfiguration configuration, NITNetworkManaging networkManager, NITReachability reachability);

	// -(void)registerInstallation;
	[Export ("registerInstallation")]
	void RegisterInstallation ();

	// -(void)shouldRegisterInstallation;
	[Export ("shouldRegisterInstallation")]
	void ShouldRegisterInstallation ();

	// -(BOOL)isQueued;
	[Export ("isQueued")]
	[Verify (MethodToProperty)]
	bool IsQueued { get; }

	// -(void)setNotificationCenter:(UNUserNotificationCenter * _Nonnull)notificationCenter;
	[Export ("setNotificationCenter:")]
	void SetNotificationCenter (UNUserNotificationCenter notificationCenter);

	// -(void)requestUserNotificationsSettings;
	[Export ("requestUserNotificationsSettings")]
	void RequestUserNotificationsSettings ();

	// -(void)enrollTestDeviceWithName:(NSString * _Nullable)name completionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("enrollTestDeviceWithName:completionHandler:")]
	void EnrollTestDeviceWithName ([NullAllowed] string name, Action<NSError> completionHandler);
}

// @interface NITJSONAPI : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITJSONAPI : INSCoding
{
	// @property (nonatomic) BOOL forceArrayOfResources;
	[Export ("forceArrayOfResources")]
	bool ForceArrayOfResources { get; set; }

	// -(instancetype _Nullable)initWithContentsOfFile:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)anError;
	[Export ("initWithContentsOfFile:error:")]
	IntPtr Constructor (string path, [NullAllowed] out NSError anError);

	// -(instancetype _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)json;
	[Export ("initWithDictionary:")]
	IntPtr Constructor (NSDictionary json);

	// -(void)setDataWithResourceObject:(NITJSONAPIResource * _Nonnull)resourceObject;
	[Export ("setDataWithResourceObject:")]
	void SetDataWithResourceObject (NITJSONAPIResource resourceObject);

	// -(void)setDataWithResourcesObject:(NSArray<NITJSONAPIResource *> * _Nonnull)resources;
	[Export ("setDataWithResourcesObject:")]
	void SetDataWithResourcesObject (NITJSONAPIResource[] resources);

	// -(NITJSONAPIResource * _Nullable)firstResourceObject;
	[NullAllowed, Export ("firstResourceObject")]
	[Verify (MethodToProperty)]
	NITJSONAPIResource FirstResourceObject { get; }

	// -(NSDictionary * _Nonnull)toDictionary;
	[Export ("toDictionary")]
	[Verify (MethodToProperty)]
	NSDictionary ToDictionary { get; }

	// -(void)registerClass:(Class _Nonnull)cls forType:(NSString * _Nonnull)type;
	[Export ("registerClass:forType:")]
	void RegisterClass (Class cls, string type);

	// -(NSArray * _Nonnull)parseToArrayOfObjects;
	[Export ("parseToArrayOfObjects")]
	[Verify (MethodToProperty), Verify (StronglyTypedNSArray)]
	NSObject[] ParseToArrayOfObjects { get; }

	// -(NSArray<NITJSONAPIResource *> * _Nonnull)allResources;
	[Export ("allResources")]
	[Verify (MethodToProperty)]
	NITJSONAPIResource[] AllResources { get; }

	// -(NSArray<NITJSONAPIResource *> * _Nonnull)rootResources;
	[Export ("rootResources")]
	[Verify (MethodToProperty)]
	NITJSONAPIResource[] RootResources { get; }

	// -(NSData * _Nullable)dataValue;
	[NullAllowed, Export ("dataValue")]
	[Verify (MethodToProperty)]
	NSData DataValue { get; }

	// +(NITJSONAPI * _Nonnull)jsonApiWithAttributes:(NSDictionary<NSString *,id> * _Nonnull)attributes type:(NSString * _Nonnull)type;
	[Static]
	[Export ("jsonApiWithAttributes:type:")]
	NITJSONAPI JsonApiWithAttributes (NSDictionary<NSString, NSObject> attributes, string type);

	// +(NITJSONAPI * _Nonnull)jsonApiWithArray:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)resources type:(NSString * _Nonnull)type;
	[Static]
	[Export ("jsonApiWithArray:type:")]
	NITJSONAPI JsonApiWithArray (NSDictionary<NSString, NSObject>[] resources, string type);

	// -(id _Nullable)metaForKey:(NSString * _Nonnull)key;
	[Export ("metaForKey:")]
	[return: NullAllowed]
	NSObject MetaForKey (string key);
}

// @interface NITJSONAPIResource : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITJSONAPIResource : INSCoding
{
	// @property (nonatomic, strong) id _Nullable ID;
	[NullAllowed, Export ("ID", ArgumentSemantic.Strong)]
	NSObject ID { get; set; }

	// @property (nonatomic, strong) NSString * _Nonnull type;
	[Export ("type", ArgumentSemantic.Strong)]
	string Type { get; set; }

	// -(void)addAttributeObject:(id _Nonnull)object forKey:(NSString * _Nonnull)key;
	[Export ("addAttributeObject:forKey:")]
	void AddAttributeObject (NSObject @object, string key);

	// -(NSInteger)attributesCount;
	[Export ("attributesCount")]
	[Verify (MethodToProperty)]
	nint AttributesCount { get; }

	// -(NSDictionary<NSString *,id> * _Nonnull)attributes;
	[Export ("attributes")]
	[Verify (MethodToProperty)]
	NSDictionary<NSString, NSObject> Attributes { get; }

	// -(NSDictionary<NSString *,id> * _Nonnull)relationships;
	[Export ("relationships")]
	[Verify (MethodToProperty)]
	NSDictionary<NSString, NSObject> Relationships { get; }

	// -(id _Nullable)attributeForKey:(NSString * _Nonnull)key;
	[Export ("attributeForKey:")]
	[return: NullAllowed]
	NSObject AttributeForKey (string key);

	// -(NSDictionary * _Nonnull)toDictionary;
	[Export ("toDictionary")]
	[Verify (MethodToProperty)]
	NSDictionary ToDictionary { get; }

	// -(NSDictionary * _Nullable)relationshipForKey:(NSString * _Nonnull)key;
	[Export ("relationshipForKey:")]
	[return: NullAllowed]
	NSDictionary RelationshipForKey (string key);

	// +(NITJSONAPIResource * _Nonnull)resourceObjectWithDictiornary:(NSDictionary * _Nonnull)dictionary;
	[Static]
	[Export ("resourceObjectWithDictiornary:")]
	NITJSONAPIResource ResourceObjectWithDictiornary (NSDictionary dictionary);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITNotificationHistoryCacheKey;
	[Field ("NITNotificationHistoryCacheKey", "__Internal")]
	NSString NITNotificationHistoryCacheKey { get; }
}

// @interface NITLocalHistory : NSObject
[BaseType (typeof(NSObject))]
interface NITLocalHistory
{
	// -(instancetype _Nonnull)initWithCache:(NITCacheManager * _Nonnull)cache dateManager:(NITDateManager *)dateManager;
	[Export ("initWithCache:dateManager:")]
	IntPtr Constructor (NITCacheManager cache, NITDateManager dateManager);

	// -(NSArray<NITHistoryEntry *> * _Nonnull)entries;
	[Export ("entries")]
	[Verify (MethodToProperty)]
	NITHistoryEntry[] Entries { get; }

	// -(NITHistoryEntry * _Nullable)findEntryWithRecipeID:(NSString * _Nonnull)recipeID reactionItem:(NITReactionItem * _Nonnull)reactionItem;
	[Export ("findEntryWithRecipeID:reactionItem:")]
	[return: NullAllowed]
	NITHistoryEntry FindEntryWithRecipeID (string recipeID, NITReactionItem reactionItem);

	// -(void)addEntry:(NITHistoryEntry * _Nonnull)entry;
	[Export ("addEntry:")]
	void AddEntry (NITHistoryEntry entry);

	// -(void)removeEntry:(NITHistoryEntry * _Nonnull)entry;
	[Export ("removeEntry:")]
	void RemoveEntry (NITHistoryEntry entry);

	// -(void)setRead:(BOOL)read forEntry:(NITHistoryEntry * _Nonnull)entry withNotification:(NSString * _Nonnull)notification;
	[Export ("setRead:forEntry:withNotification:")]
	void SetRead (bool read, NITHistoryEntry entry, string notification);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

// @interface NITLocalNeighborResolver : NSObject
[BaseType (typeof(NSObject))]
interface NITLocalNeighborResolver
{
	// -(instancetype _Nonnull)initWithNodesManager:(NITNodesManager2 * _Nonnull)nodesManager;
	[Export ("initWithNodesManager:")]
	IntPtr Constructor (NITNodesManager2 nodesManager);

	// -(NSArray<NITNode *> * _Nonnull)neighborsWithCoordinate:(CLLocationCoordinate2D)coordinate container:(NITNode * _Nullable)container maxChildren:(NSInteger)maxChildren;
	[Export ("neighborsWithCoordinate:container:maxChildren:")]
	NITNode[] NeighborsWithCoordinate (CLLocationCoordinate2D coordinate, [NullAllowed] NITNode container, nint maxChildren);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITLocationHistoryCacheKey;
	[Field ("NITLocationHistoryCacheKey", "__Internal")]
	NSString NITLocationHistoryCacheKey { get; }
}

// @interface NITLocationHistory : NSObject
[BaseType (typeof(NSObject))]
interface NITLocationHistory
{
	// -(instancetype _Nonnull)initWithCache:(NITCacheManager * _Nonnull)cache trackManager:(NITTrackManager * _Nonnull)trackManager;
	[Export ("initWithCache:trackManager:")]
	IntPtr Constructor (NITCacheManager cache, NITTrackManager trackManager);

	// -(void)addLocations:(NSArray<CLLocation *> * _Nonnull)locations;
	[Export ("addLocations:")]
	void AddLocations (CLLocation[] locations);

	// -(void)send;
	[Export ("send")]
	void Send ();

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
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

// @interface NITNeighborApi : NSObject
[BaseType (typeof(NSObject))]
interface NITNeighborApi
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager reachability:(NITReachability * _Nonnull)reachability;
	[Export ("initWithNetworkManager:reachability:")]
	IntPtr Constructor (NITNetworkManaging networkManager, NITReachability reachability);

	// -(void)neighborSearchWithCoordinate:(CLLocationCoordinate2D)coordinate containerId:(NSString * _Nullable)containerId maxChildren:(NSInteger)maxChildren completionHandler:(void (^ _Nonnull)(NSArray<NITNode *> * _Nullable, NSError * _Nullable, NSNumber * _Nullable, NSTimeInterval))completionHandler;
	[Export ("neighborSearchWithCoordinate:containerId:maxChildren:completionHandler:")]
	void NeighborSearchWithCoordinate (CLLocationCoordinate2D coordinate, [NullAllowed] string containerId, nint maxChildren, Action<NSArray<NITNode>, NSError, NSNumber, double> completionHandler);
}

// typedef void (^NITComputeNeighborBlock)(NSArray<NITNode *> * _Nullable);
delegate void NITComputeNeighborBlock ([NullAllowed] NITNode[] arg0);

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const NSInteger NITNeighborMaxChildren;
	[Field ("NITNeighborMaxChildren", "__Internal")]
	nint NITNeighborMaxChildren { get; }
}

// @interface NITNeighborResolver : NSObject
[BaseType (typeof(NSObject))]
interface NITNeighborResolver
{
	// -(instancetype _Nonnull)initWithApi:(NITNeighborApi * _Nonnull)api nodesManager:(NITNodesManager2 * _Nonnull)nodesManager state:(NITNeighborResolverState * _Nonnull)state dateManager:(NITDateManager * _Nonnull)dateManager localResolver:(NITLocalNeighborResolver * _Nonnull)localResolver;
	[Export ("initWithApi:nodesManager:state:dateManager:localResolver:")]
	IntPtr Constructor (NITNeighborApi api, NITNodesManager2 nodesManager, NITNeighborResolverState state, NITDateManager dateManager, NITLocalNeighborResolver localResolver);

	// -(void)computeNeighborWithCoordinate:(CLLocationCoordinate2D)coordinate container:(NITNode * _Nullable)container completionHandler:(NITComputeNeighborBlock _Nonnull)completionHandler;
	[Export ("computeNeighborWithCoordinate:container:completionHandler:")]
	void ComputeNeighborWithCoordinate (CLLocationCoordinate2D coordinate, [NullAllowed] NITNode container, NITComputeNeighborBlock completionHandler);
}

// @interface NITNeighborResolverState : NSObject
[BaseType (typeof(NSObject))]
interface NITNeighborResolverState
{
	// @property (nonatomic) CLLocationCoordinate2D coordinate;
	[Export ("coordinate", ArgumentSemantic.Assign)]
	CLLocationCoordinate2D Coordinate { get; set; }

	// @property (nonatomic, strong) NSDate * _Nullable timestamp;
	[NullAllowed, Export ("timestamp", ArgumentSemantic.Strong)]
	NSDate Timestamp { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable containerId;
	[NullAllowed, Export ("containerId", ArgumentSemantic.Strong)]
	string ContainerId { get; set; }

	// @property (nonatomic, strong) NSNumber * _Nullable minDistance;
	[NullAllowed, Export ("minDistance", ArgumentSemantic.Strong)]
	NSNumber MinDistance { get; set; }

	// @property (nonatomic, strong) NSArray<NITNode *> * _Nullable nodes;
	[NullAllowed, Export ("nodes", ArgumentSemantic.Strong)]
	NITNode[] Nodes { get; set; }

	// @property (nonatomic) NSTimeInterval maxWait;
	[Export ("maxWait")]
	double MaxWait { get; set; }

	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cache;
	[Export ("initWithCacheManager:")]
	IntPtr Constructor (NITCacheManager cache);

	// -(void)setRequestInfoWithTimestamp:(NSDate * _Nonnull)timestamp coordinate:(CLLocationCoordinate2D)coordinate containerId:(NSString * _Nonnull)containerId;
	[Export ("setRequestInfoWithTimestamp:coordinate:containerId:")]
	void SetRequestInfoWithTimestamp (NSDate timestamp, CLLocationCoordinate2D coordinate, string containerId);

	// -(void)setRequestFilterInfoWithMinDistance:(NSNumber * _Nonnull)minDistance maxWait:(NSTimeInterval)maxWait;
	[Export ("setRequestFilterInfoWithMinDistance:maxWait:")]
	void SetRequestFilterInfoWithMinDistance (NSNumber minDistance, double maxWait);

	// -(void)setRequestResponseWithNodes:(NSArray<NITNode *> * _Nullable)nodes;
	[Export ("setRequestResponseWithNodes:")]
	void SetRequestResponseWithNodes ([NullAllowed] NITNode[] nodes);
}

// @interface NITNetworkManager : NSObject <NITNetworkManaging>
[BaseType (typeof(NSObject))]
interface NITNetworkManager : INITNetworkManaging
{
	// -(instancetype _Nonnull)initWithSession:(NSURLSession * _Nonnull)session configuration:(NITConfiguration * _Nonnull)configuration;
	[Export ("initWithSession:configuration:")]
	IntPtr Constructor (NSUrlSession session, NITConfiguration configuration);

	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration;
	[Export ("initWithConfiguration:")]
	IntPtr Constructor (NITConfiguration configuration);

	// -(void)makeRequestWithURLRequest:(NSURLRequest * _Nonnull)request completionHandler:(void (^ _Nonnull)(NSData * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("makeRequestWithURLRequest:completionHandler:")]
	void MakeRequestWithURLRequest (NSUrlRequest request, Action<NSData, NSError> completionHandler);
}

// @interface NITNetworkProvider : NSObject
[BaseType (typeof(NSObject))]
interface NITNetworkProvider
{
	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration;
	[Export ("initWithConfiguration:")]
	IntPtr Constructor (NITConfiguration configuration);

	// -(void)setConfiguration:(NITConfiguration * _Nonnull)configuration;
	[Export ("setConfiguration:")]
	void SetConfiguration (NITConfiguration configuration);

	// +(NITNetworkProvider * _Nonnull)sharedInstance;
	[Static]
	[Export ("sharedInstance")]
	[Verify (MethodToProperty)]
	NITNetworkProvider SharedInstance { get; }

	// -(NSURLRequest * _Nonnull)recipesProcessListWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi;
	[Export ("recipesProcessListWithJsonApi:")]
	NSUrlRequest RecipesProcessListWithJsonApi (NITJSONAPI jsonApi);

	// -(NSURLRequest * _Nonnull)processRecipeWithId:(NSString * _Nonnull)recipeId;
	[Export ("processRecipeWithId:")]
	NSUrlRequest ProcessRecipeWithId (string recipeId);

	// -(NSURLRequest * _Nonnull)evaluateRecipeWithId:(NSString * _Nonnull)recipeId jsonApi:(NITJSONAPI * _Nonnull)jsonApi;
	[Export ("evaluateRecipeWithId:jsonApi:")]
	NSUrlRequest EvaluateRecipeWithId (string recipeId, NITJSONAPI jsonApi);

	// -(NSURLRequest * _Nonnull)onlinePulseEvaluationWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi;
	[Export ("onlinePulseEvaluationWithJsonApi:")]
	NSUrlRequest OnlinePulseEvaluationWithJsonApi (NITJSONAPI jsonApi);

	// -(NSURLRequest * _Nonnull)newProfileWithAppId:(NSString * _Nonnull)appId;
	[Export ("newProfileWithAppId:")]
	NSUrlRequest NewProfileWithAppId (string appId);

	// -(NSURLRequest * _Nonnull)geopolisNodes;
	[Export ("geopolisNodes")]
	[Verify (MethodToProperty)]
	NSUrlRequest GeopolisNodes { get; }

	// -(NSURLRequest * _Nonnull)neighborNodesWithCoordinate:(CLLocationCoordinate2D)coordinate containerId:(NSString * _Nullable)containerId limit:(NSInteger)limit;
	[Export ("neighborNodesWithCoordinate:containerId:limit:")]
	NSUrlRequest NeighborNodesWithCoordinate (CLLocationCoordinate2D coordinate, [NullAllowed] string containerId, nint limit);

	// -(NSURLRequest * _Nonnull)updateInstallationWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi installationId:(NSString * _Nonnull)installationId;
	[Export ("updateInstallationWithJsonApi:installationId:")]
	NSUrlRequest UpdateInstallationWithJsonApi (NITJSONAPI jsonApi, string installationId);

	// -(NSURLRequest * _Nonnull)contentWithBundleId:(NSString * _Nonnull)bundleId;
	[Export ("contentWithBundleId:")]
	NSUrlRequest ContentWithBundleId (string bundleId);

	// -(NSURLRequest * _Nonnull)contents;
	[Export ("contents")]
	[Verify (MethodToProperty)]
	NSUrlRequest Contents { get; }

	// -(NSURLRequest * _Nonnull)sendTrackingsWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi;
	[Export ("sendTrackingsWithJsonApi:")]
	NSUrlRequest SendTrackingsWithJsonApi (NITJSONAPI jsonApi);

	// -(NSURLRequest * _Nonnull)sendGeopolisTrackingsWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi;
	[Export ("sendGeopolisTrackingsWithJsonApi:")]
	NSUrlRequest SendGeopolisTrackingsWithJsonApi (NITJSONAPI jsonApi);

	// -(NSURLRequest * _Nonnull)couponsWithProfileId:(NSString * _Nonnull)profileId;
	[Export ("couponsWithProfileId:")]
	NSUrlRequest CouponsWithProfileId (string profileId);

	// -(NSURLRequest * _Nonnull)couponWithProfileId:(NSString * _Nonnull)profileId bundleId:(NSString * _Nonnull)bundleId;
	[Export ("couponWithProfileId:bundleId:")]
	NSUrlRequest CouponWithProfileId (string profileId, string bundleId);

	// -(NSURLRequest * _Nonnull)feedbackWithBundleId:(NSString * _Nonnull)bundleId;
	[Export ("feedbackWithBundleId:")]
	NSUrlRequest FeedbackWithBundleId (string bundleId);

	// -(NSURLRequest * _Nonnull)feedbacks;
	[Export ("feedbacks")]
	[Verify (MethodToProperty)]
	NSUrlRequest Feedbacks { get; }

	// -(NSURLRequest * _Nonnull)sendFeedbackEventWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi feedbackId:(NSString * _Nonnull)feedbackId;
	[Export ("sendFeedbackEventWithJsonApi:feedbackId:")]
	NSUrlRequest SendFeedbackEventWithJsonApi (NITJSONAPI jsonApi, string feedbackId);

	// -(NSURLRequest * _Nonnull)customJSONWithBundleId:(NSString * _Nonnull)bundleId;
	[Export ("customJSONWithBundleId:")]
	NSUrlRequest CustomJSONWithBundleId (string bundleId);

	// -(NSURLRequest * _Nonnull)customJSONs;
	[Export ("customJSONs")]
	[Verify (MethodToProperty)]
	NSUrlRequest CustomJSONs { get; }

	// -(NSURLRequest * _Nonnull)setUserDataWithJsonApi:(NITJSONAPI * _Nonnull)jsonApi profileId:(NSString * _Nonnull)profileId;
	[Export ("setUserDataWithJsonApi:profileId:")]
	NSUrlRequest SetUserDataWithJsonApi (NITJSONAPI jsonApi, string profileId);

	// -(NSURLRequest * _Nonnull)timestamps;
	[Export ("timestamps")]
	[Verify (MethodToProperty)]
	NSUrlRequest Timestamps { get; }

	// -(NSURLRequest * _Nonnull)optOut;
	[Export ("optOut")]
	[Verify (MethodToProperty)]
	NSUrlRequest OptOut { get; }

	// -(NSURLRequest * _Nonnull)sendSpotsWithLocations:(NSArray<CLLocation *> * _Nonnull)locations;
	[Export ("sendSpotsWithLocations:")]
	NSUrlRequest SendSpotsWithLocations (CLLocation[] locations);

	// -(NSURLRequest * _Nonnull)enrollTestDeviceWithInstallationId:(NSString * _Nonnull)installationId name:(NSString * _Nonnull)name;
	[Export ("enrollTestDeviceWithInstallationId:name:")]
	NSUrlRequest EnrollTestDeviceWithInstallationId (string installationId, string name);

	// -(NSURLRequest * _Nonnull)history;
	[Export ("history")]
	[Verify (MethodToProperty)]
	NSUrlRequest History { get; }
}

// @interface NITNodeApi : NSObject
[BaseType (typeof(NSObject))]
interface NITNodeApi
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithNetworkManager:")]
	IntPtr Constructor (NITNetworkManaging networkManager);

	// -(void)nodesWithCompletionHandler:(void (^ _Nonnull)(NSArray<NITNode *> * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("nodesWithCompletionHandler:")]
	void NodesWithCompletionHandler (Action<NSArray<NITNode>, NSError> completionHandler);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITNodeRepoNodesCacheKey;
	[Field ("NITNodeRepoNodesCacheKey", "__Internal")]
	NSString NITNodeRepoNodesCacheKey { get; }

	// extern NSString *const _Nonnull NITNodeRepoLastEditedTimeCacheKey;
	[Field ("NITNodeRepoLastEditedTimeCacheKey", "__Internal")]
	NSString NITNodeRepoLastEditedTimeCacheKey { get; }
}

// @interface NITNodeRepository : NSObject
[BaseType (typeof(NSObject))]
interface NITNodeRepository
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager timestampsManager:(NITTimestampsManager * _Nonnull)timestampsManager api:(NITNodeApi * _Nonnull)api dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithCacheManager:timestampsManager:api:dateManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITTimestampsManager timestampsManager, NITNodeApi api, NITDateManager dateManager);

	// -(void)syncWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable, BOOL))completionHandler;
	[Export ("syncWithCompletionHandler:")]
	void SyncWithCompletionHandler (Action<NSError, bool> completionHandler);

	// -(void)nodesWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("nodesWithCompletionHandler:")]
	void NodesWithCompletionHandler (Action<NSError> completionHandler);

	// -(NSArray<NITNode *> * _Nullable)nodes;
	[NullAllowed, Export ("nodes")]
	[Verify (MethodToProperty)]
	NITNode[] Nodes { get; }
}

// @interface NITNodesManager2 : NSObject
[BaseType (typeof(NSObject))]
interface NITNodesManager2
{
	// -(instancetype _Nonnull)initWithRepository:(NITNodeRepository * _Nonnull)repository;
	[Export ("initWithRepository:")]
	IntPtr Constructor (NITNodeRepository repository);

	// -(NITTreeLevel * _Nullable)findLevelForEnterWithNodeId:(NSString * _Nullable)ID;
	[Export ("findLevelForEnterWithNodeId:")]
	[return: NullAllowed]
	NITTreeLevel FindLevelForEnterWithNodeId ([NullAllowed] string ID);

	// -(NITTreeLevel * _Nullable)findLevelForExitWithNodeId:(NSString * _Nullable)ID;
	[Export ("findLevelForExitWithNodeId:")]
	[return: NullAllowed]
	NITTreeLevel FindLevelForExitWithNodeId ([NullAllowed] string ID);

	// -(NITTreeLevel * _Nonnull)rootLevel;
	[Export ("rootLevel")]
	[Verify (MethodToProperty)]
	NITTreeLevel RootLevel { get; }

	// -(NITNode * _Nullable)nodeWithID:(NSString * _Nonnull)ID;
	[Export ("nodeWithID:")]
	[return: NullAllowed]
	NITNode NodeWithID (string ID);

	// -(NITNode * _Nullable)nodeWithIdentifier:(NSString * _Nonnull)identifier;
	[Export ("nodeWithIdentifier:")]
	[return: NullAllowed]
	NITNode NodeWithIdentifier (string identifier);

	// -(NSArray<NITNode *> * _Nullable)roots;
	[NullAllowed, Export ("roots")]
	[Verify (MethodToProperty)]
	NITNode[] Roots { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSErrorDomain  _Nonnull const NITNotificationHistoryErrorDomain;
	[Field ("NITNotificationHistoryErrorDomain", "__Internal")]
	NSString NITNotificationHistoryErrorDomain { get; }
}

// @interface NITNotificationHistoryManager : NSObject
[BaseType (typeof(NSObject))]
interface NITNotificationHistoryManager
{
	// -(instancetype _Nonnull)initWithApi:(NITHistoryApi * _Nonnull)api itemResolver:(NITHistoryItemResolver * _Nonnull)itemResolver localHistory:(NITLocalHistory * _Nonnull)localHistory dateManager:(NITDateManager * _Nonnull)dateManager internetReachability:(NITReachability * _Nonnull)internetReachability historyMerger:(NITHistoryMerger * _Nonnull)historyMerger;
	[Export ("initWithApi:itemResolver:localHistory:dateManager:internetReachability:historyMerger:")]
	IntPtr Constructor (NITHistoryApi api, NITHistoryItemResolver itemResolver, NITLocalHistory localHistory, NITDateManager dateManager, NITReachability internetReachability, NITHistoryMerger historyMerger);

	// -(void)addItemToHistory:(NITReactionItem * _Nullable)reactionItem trackingInfo:(NITTrackingInfo * _Nullable)trackingInfo notificationBody:(NSString * _Nullable)notificationBody trackingEvent:(NSString * _Nullable)trackingEvent;
	[Export ("addItemToHistory:trackingInfo:notificationBody:trackingEvent:")]
	void AddItemToHistory ([NullAllowed] NITReactionItem reactionItem, [NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string notificationBody, [NullAllowed] string trackingEvent);

	// -(void)notificationHistoryWithCompletion:(void (^ _Nonnull)(NSArray<NITHistoryItem *> * _Nullable, NSError * _Nullable))completion;
	[Export ("notificationHistoryWithCompletion:")]
	void NotificationHistoryWithCompletion (Action<NSArray<NITHistoryItem>, NSError> completion);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();

	// +(NITNotificationHistoryManager * _Nonnull)obtainWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager reactionsManager:(NITReactionsManager * _Nonnull)reactionsManager cacheManager:(NITCacheManager * _Nonnull)cacheManager internetReachability:(NITReachability * _Nonnull)internetReachability configuration:(NITConfiguration * _Nonnull)configuration;
	[Static]
	[Export ("obtainWithNetworkManager:reactionsManager:cacheManager:internetReachability:configuration:")]
	NITNotificationHistoryManager ObtainWithNetworkManager (NITNetworkManaging networkManager, NITReactionsManager reactionsManager, NITCacheManager cacheManager, NITReachability internetReachability, NITConfiguration configuration);
}

// @interface NITNotificationProcessor : NSObject
[BaseType (typeof(NSObject))]
interface NITNotificationProcessor
{
	// -(instancetype _Nonnull)initWithRecipesManager:(NITRecipesManager * _Nonnull)recipesManager reactions:(NSDictionary<NSString *,NITReaction *> * _Nonnull)reactions;
	[Export ("initWithRecipesManager:reactions:")]
	IntPtr Constructor (NITRecipesManager recipesManager, NSDictionary<NSString, NITReaction> reactions);

	// -(BOOL)processNotificationWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NSString * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("processNotificationWithUserInfo:completion:")]
	bool ProcessNotificationWithUserInfo (NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NITReactionBundle, NSString, NSError> completionHandler);

	// -(BOOL)isRemoteNotificationWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo;
	[Export ("isRemoteNotificationWithUserInfo:")]
	bool IsRemoteNotificationWithUserInfo (NSDictionary<NSString, NSObject> userInfo);

	// -(BOOL)handleLocalUserInfo:(NSDictionary * _Nonnull)userInfo completionHandler:(void (^ _Nonnull)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("handleLocalUserInfo:completionHandler:")]
	bool HandleLocalUserInfo (NSDictionary userInfo, Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);
}

// @interface NITPulseBundle : NITResource
[BaseType (typeof(NITResource))]
interface NITPulseBundle
{
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString * kNITReachabilityChangedNotification;
	[Field ("kNITReachabilityChangedNotification", "__Internal")]
	NSString kNITReachabilityChangedNotification { get; }
}

// @interface NITReachability : NSObject
[BaseType (typeof(NSObject))]
interface NITReachability
{
	// +(instancetype)reachabilityWithHostName:(NSString *)hostName;
	[Static]
	[Export ("reachabilityWithHostName:")]
	NITReachability ReachabilityWithHostName (string hostName);

	// +(instancetype)reachabilityWithAddress:(const struct sockaddr *)hostAddress;
	[Static]
	[Export ("reachabilityWithAddress:")]
	unsafe NITReachability ReachabilityWithAddress (sockaddr* hostAddress);

	// +(instancetype)reachabilityForInternetConnection;
	[Static]
	[Export ("reachabilityForInternetConnection")]
	NITReachability ReachabilityForInternetConnection ();

	// -(BOOL)startNotifier;
	[Export ("startNotifier")]
	[Verify (MethodToProperty)]
	bool StartNotifier { get; }

	// -(void)stopNotifier;
	[Export ("stopNotifier")]
	void StopNotifier ();

	// -(NITNetworkStatus)currentReachabilityStatus;
	[Export ("currentReachabilityStatus")]
	[Verify (MethodToProperty)]
	NITNetworkStatus CurrentReachabilityStatus { get; }

	// -(BOOL)connectionRequired;
	[Export ("connectionRequired")]
	[Verify (MethodToProperty)]
	bool ConnectionRequired { get; }
}

// @interface NITReactionItem : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITReactionItem : INSCoding
{
	// @property (nonatomic, strong) NSString * pluginID;
	[Export ("pluginID", ArgumentSemantic.Strong)]
	string PluginID { get; set; }

	// @property (nonatomic, strong) NSString * action;
	[Export ("action", ArgumentSemantic.Strong)]
	string Action { get; set; }

	// @property (nonatomic, strong) NSString * bundleID;
	[Export ("bundleID", ArgumentSemantic.Strong)]
	string BundleID { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const NSTimeInterval NITReactionStateDefaultTime;
	[Field ("NITReactionStateDefaultTime", "__Internal")]
	double NITReactionStateDefaultTime { get; }

	// extern NSString *const _Nonnull NITReactionStateCacheKey;
	[Field ("NITReactionStateCacheKey", "__Internal")]
	NSString NITReactionStateCacheKey { get; }

	// extern NSString *const _Nonnull NITReactionLastEditedTimeKey;
	[Field ("NITReactionLastEditedTimeKey", "__Internal")]
	NSString NITReactionLastEditedTimeKey { get; }
}

// @interface NITReactionState : NSObject
[BaseType (typeof(NSObject))]
interface NITReactionState
{
	// @property (nonatomic) NSTimeInterval lastEditedTime;
	[Export ("lastEditedTime")]
	double LastEditedTime { get; set; }

	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager;
	[Export ("initWithCacheManager:")]
	IntPtr Constructor (NITCacheManager cacheManager);
}

// @interface NITReactionsManager : NSObject
[BaseType (typeof(NSObject))]
interface NITReactionsManager
{
	// -(instancetype _Nonnull)initWithTimestampManager:(NITTimestampsManager * _Nonnull)timestampManager dateManager:(NITDateManager * _Nonnull)dateManager state:(NITReactionState * _Nonnull)state;
	[Export ("initWithTimestampManager:dateManager:state:")]
	IntPtr Constructor (NITTimestampsManager timestampManager, NITDateManager dateManager, NITReactionState state);

	// -(void)setReaction:(NITReaction * _Nonnull)reaction forPlugin:(NSString * _Nonnull)plugin;
	[Export ("setReaction:forPlugin:")]
	void SetReaction (NITReaction reaction, string plugin);

	// -(NSDictionary<NSString *,NITReaction *> * _Nonnull)internalReactions;
	[Export ("internalReactions")]
	[Verify (MethodToProperty)]
	NSDictionary<NSString, NITReaction> InternalReactions { get; }

	// -(NITReaction * _Nullable)reactionForPlugin:(NSString * _Nonnull)plugin;
	[Export ("reactionForPlugin:")]
	[return: NullAllowed]
	NITReaction ReactionForPlugin (string plugin);

	// -(NITReactionBundle * _Nullable)localContentWithReactionItem:(NITReactionItem * _Nonnull)reactionItem notification:(NSString * _Nonnull)notification trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
	[Export ("localContentWithReactionItem:notification:trackingInfo:")]
	[return: NullAllowed]
	NITReactionBundle LocalContentWithReactionItem (NITReactionItem reactionItem, string notification, NITTrackingInfo trackingInfo);

	// -(NITReactionBundle * _Nullable)parseFromRemote:(NITRemoteItem * _Nonnull)remoteItem;
	[Export ("parseFromRemote:")]
	[return: NullAllowed]
	NITReactionBundle ParseFromRemote (NITRemoteItem remoteItem);

	// -(void)syncReactionsWithCompletionHandler:(void (^)(void))completionHandler;
	[Export ("syncReactionsWithCompletionHandler:")]
	void SyncReactionsWithCompletionHandler (Action completionHandler);

	// -(void)refreshReactionsWithCompletionHandler:(void (^)(void))completionHandler;
	[Export ("refreshReactionsWithCompletionHandler:")]
	void RefreshReactionsWithCompletionHandler (Action completionHandler);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
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
	[Verify (MethodToProperty)]
	bool IsEvaluatedOnline { get; }

	// -(BOOL)isForeground;
	[Export ("isForeground")]
	[Verify (MethodToProperty)]
	bool IsForeground { get; }

	// -(NSString * _Nullable)notificationTitle;
	[NullAllowed, Export ("notificationTitle")]
	[Verify (MethodToProperty)]
	string NotificationTitle { get; }

	// -(NSString * _Nullable)notificationBody;
	[NullAllowed, Export ("notificationBody")]
	[Verify (MethodToProperty)]
	string NotificationBody { get; }
}

// @interface NITRecipeCooler : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeCooler
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithCacheManager:dateManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITDateManager dateManager);

	// -(void)markRecipeAsShownWithId:(NSString * _Nonnull)recipeId;
	[Export ("markRecipeAsShownWithId:")]
	void MarkRecipeAsShownWithId (string recipeId);

	// -(NSArray<NITRecipe *> * _Nonnull)filterRecipeWithRecipes:(NSArray<NITRecipe *> * _Nonnull)recipes;
	[Export ("filterRecipeWithRecipes:")]
	NITRecipe[] FilterRecipeWithRecipes (NITRecipe[] recipes);

	// -(NSNumber * _Nonnull)latestLog;
	[Export ("latestLog")]
	[Verify (MethodToProperty)]
	NSNumber LatestLog { get; }

	// -(NSMutableDictionary<NSString *,NSNumber *> * _Nonnull)log;
	[Export ("log")]
	[Verify (MethodToProperty)]
	NSMutableDictionary<NSString, NSNumber> Log { get; }
}

// @interface NITRecipeForceRefresher : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeForceRefresher
{
	// -(instancetype _Nonnull)initWithRepositoryState:(NITRecipeRepositoryState * _Nonnull)state dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithRepositoryState:dateManager:")]
	IntPtr Constructor (NITRecipeRepositoryState state, NITDateManager dateManager);

	// -(BOOL)shouldRefresh;
	[Export ("shouldRefresh")]
	[Verify (MethodToProperty)]
	bool ShouldRefresh { get; }
}

// @interface NITRecipeHistory : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeHistory
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithCacheManager:dateManager:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITDateManager dateManager);

	// -(void)markRecipeAsShownWithId:(NSString * _Nonnull)recipeId;
	[Export ("markRecipeAsShownWithId:")]
	void MarkRecipeAsShownWithId (string recipeId);

	// -(NSNumber * _Nonnull)latestLog;
	[Export ("latestLog")]
	[Verify (MethodToProperty)]
	NSNumber LatestLog { get; }

	// -(NSMutableDictionary<NSString *,NSNumber *> * _Nonnull)log;
	[Export ("log")]
	[Verify (MethodToProperty)]
	NSMutableDictionary<NSString, NSNumber> Log { get; }

	// -(BOOL)isRecipeInLogWithId:(NSString * _Nonnull)recipeId;
	[Export ("isRecipeInLogWithId:")]
	bool IsRecipeInLogWithId (string recipeId);

	// -(NSNumber * _Nullable)latestLogEntryWithId:(NSString * _Nonnull)recipeId;
	[Export ("latestLogEntryWithId:")]
	[return: NullAllowed]
	NSNumber LatestLogEntryWithId (string recipeId);

	// -(void)clear;
	[Export ("clear")]
	void Clear ();
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull RecipesCacheKey;
	[Field ("RecipesCacheKey", "__Internal")]
	NSString RecipesCacheKey { get; }
}

// @interface NITRecipeRepository : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeRepository
{
	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager dateManager:(NITDateManager * _Nonnull)dateManager recipeHistory:(NITRecipeHistory * _Nonnull)recipeHistory timestampsManager:(NITTimestampsManager * _Nonnull)timestampsManager api:(NITRecipesApi * _Nonnull)api state:(NITRecipeRepositoryState * _Nonnull)state refresher:(NITRecipeForceRefresher * _Nonnull)refresher;
	[Export ("initWithCacheManager:dateManager:recipeHistory:timestampsManager:api:state:refresher:")]
	IntPtr Constructor (NITCacheManager cacheManager, NITDateManager dateManager, NITRecipeHistory recipeHistory, NITTimestampsManager timestampsManager, NITRecipesApi api, NITRecipeRepositoryState state, NITRecipeForceRefresher refresher);

	// -(NSArray<NITRecipe *> * _Nullable)recipes;
	[NullAllowed, Export ("recipes")]
	[Verify (MethodToProperty)]
	NITRecipe[] Recipes { get; }

	// -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
	[Export ("refreshConfigWithCompletionHandler:")]
	void RefreshConfigWithCompletionHandler ([NullAllowed] Action<NSError> completionHandler);

	// -(void)syncWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable, BOOL))completionHandler;
	[Export ("syncWithCompletionHandler:")]
	void SyncWithCompletionHandler ([NullAllowed] Action<NSError, bool> completionHandler);

	// -(void)recipesWithCompletionHandler:(void (^ _Nullable)(NSArray<NITRecipe *> * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("recipesWithCompletionHandler:")]
	void RecipesWithCompletionHandler ([NullAllowed] Action<NSArray<NITRecipe>, NSError> completionHandler);

	// -(NSInteger)recipesCount;
	[Export ("recipesCount")]
	[Verify (MethodToProperty)]
	nint RecipesCount { get; }

	// -(BOOL)isPulseOnlineEvaluationAvaialble;
	[Export ("isPulseOnlineEvaluationAvaialble")]
	[Verify (MethodToProperty)]
	bool IsPulseOnlineEvaluationAvaialble { get; }

	// -(void)addRecipe:(NITRecipe * _Nonnull)recipe;
	[Export ("addRecipe:")]
	void AddRecipe (NITRecipe recipe);

	// -(NSArray<NITRecipe *> * _Nonnull)matchingRecipesWithPulsePlugin:(NSString * _Nonnull)pulsePlugin pulseAction:(NSString * _Nonnull)pulseAction pulseBundle:(NSString * _Nonnull)pulseBundle;
	[Export ("matchingRecipesWithPulsePlugin:pulseAction:pulseBundle:")]
	NITRecipe[] MatchingRecipesWithPulsePlugin (string pulsePlugin, string pulseAction, string pulseBundle);

	// -(NSArray<NITRecipe *> * _Nonnull)matchingRecipesWithPulsePlugin:(NSString * _Nonnull)pulsePlugin pulseAction:(NSString * _Nonnull)pulseAction tags:(NSArray<NSString *> * _Nullable)tags;
	[Export ("matchingRecipesWithPulsePlugin:pulseAction:tags:")]
	NITRecipe[] MatchingRecipesWithPulsePlugin (string pulsePlugin, string pulseAction, [NullAllowed] string[] tags);

	// -(NITRecipe * _Nullable)recipeWithID:(NSString * _Nullable)ID;
	[Export ("recipeWithID:")]
	[return: NullAllowed]
	NITRecipe RecipeWithID ([NullAllowed] string ID);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITRecipeRepositoryLastEditedTimeKey;
	[Field ("NITRecipeRepositoryLastEditedTimeKey", "__Internal")]
	NSString NITRecipeRepositoryLastEditedTimeKey { get; }

	// extern NSString *const _Nonnull NITRecipeRepositoryPulseEvaluationOnlineKey;
	[Field ("NITRecipeRepositoryPulseEvaluationOnlineKey", "__Internal")]
	NSString NITRecipeRepositoryPulseEvaluationOnlineKey { get; }

	// extern NSString *const _Nonnull NITRecipeRepositoryMinTimeToRefreshKey;
	[Field ("NITRecipeRepositoryMinTimeToRefreshKey", "__Internal")]
	NSString NITRecipeRepositoryMinTimeToRefreshKey { get; }

	// extern const NSTimeInterval NITRecipeDefaultTime;
	[Field ("NITRecipeDefaultTime", "__Internal")]
	double NITRecipeDefaultTime { get; }

	// extern const NSTimeInterval NITRecipeDefaultMinTimeToRefresh;
	[Field ("NITRecipeDefaultMinTimeToRefresh", "__Internal")]
	double NITRecipeDefaultMinTimeToRefresh { get; }

	// extern NSString *const _Nonnull NITRecipeRepositoryStateCacheKey;
	[Field ("NITRecipeRepositoryStateCacheKey", "__Internal")]
	NSString NITRecipeRepositoryStateCacheKey { get; }
}

// @interface NITRecipeRepositoryState : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeRepositoryState
{
	// @property (nonatomic) NSTimeInterval lastEditedTime;
	[Export ("lastEditedTime")]
	double LastEditedTime { get; set; }

	// @property (nonatomic) BOOL pulseEvaluationOnline;
	[Export ("pulseEvaluationOnline")]
	bool PulseEvaluationOnline { get; set; }

	// @property (nonatomic) NSTimeInterval minTimeToRefresh;
	[Export ("minTimeToRefresh")]
	double MinTimeToRefresh { get; set; }

	// -(instancetype _Nonnull)initWithCacheManager:(NITCacheManager * _Nonnull)cacheManager;
	[Export ("initWithCacheManager:")]
	IntPtr Constructor (NITCacheManager cacheManager);
}

// @interface NITRecipeTrackSender : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeTrackSender
{
	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration history:(NITRecipeHistory * _Nonnull)history trackManager:(NITTrackManager * _Nonnull)trackManager dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithConfiguration:history:trackManager:dateManager:")]
	IntPtr Constructor (NITConfiguration configuration, NITRecipeHistory history, NITTrackManager trackManager, NITDateManager dateManager);

	// -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
	[Export ("sendTrackingWithTrackingInfo:event:")]
	void SendTrackingWithTrackingInfo ([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);
}

// @interface NITRecipeValidationFilter : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipeValidationFilter
{
	// -(instancetype _Nonnull)initWithValidators:(NSArray<id<NITValidating>> * _Nonnull)validators;
	[Export ("initWithValidators:")]
	IntPtr Constructor (NITValidating[] validators);

	// -(NSArray<NITRecipe *> * _Nonnull)filterRecipes:(NSArray<NITRecipe *> * _Nonnull)recipes;
	[Export ("filterRecipes:")]
	NITRecipe[] FilterRecipes (NITRecipe[] recipes);
}

// @interface NITRecipesApi : NSObject
[BaseType (typeof(NSObject))]
interface NITRecipesApi
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager configuration:(NITConfiguration * _Nonnull)configuration evaluationBodyBuilder:(NITEvaluationBodyBuilder * _Nonnull)evaluationBodyBuilder;
	[Export ("initWithNetworkManager:configuration:evaluationBodyBuilder:")]
	IntPtr Constructor (NITNetworkManaging networkManager, NITConfiguration configuration, NITEvaluationBodyBuilder evaluationBodyBuilder);

	// -(void)processRecipesWithCompletionHandler:(void (^ _Nonnull)(NSArray<NITRecipe *> * _Nullable, BOOL, NSNumber *, NSError * _Nullable))completionHandler;
	[Export ("processRecipesWithCompletionHandler:")]
	void ProcessRecipesWithCompletionHandler (Action<NSArray<NITRecipe>, bool, NSNumber, NSError> completionHandler);

	// -(void)fetchRecipeWithId:(NSString * _Nonnull)recipeId completionHandler:(void (^ _Nonnull)(NITRecipe * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("fetchRecipeWithId:completionHandler:")]
	void FetchRecipeWithId (string recipeId, Action<NITRecipe, NSError> completionHandler);

	// -(void)evaluateRecipeWithId:(NSString * _Nonnull)recipeId completionHandler:(void (^ _Nonnull)(NITRecipe * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("evaluateRecipeWithId:completionHandler:")]
	void EvaluateRecipeWithId (string recipeId, Action<NITRecipe, NSError> completionHandler);

	// -(void)onlinePulseEvaluationWithPlugin:(NSString * _Nonnull)plugin action:(NSString * _Nonnull)action bundle:(NSString * _Nonnull)bundle completionHandler:(void (^ _Nonnull)(NITRecipe * _Nullable, NSError * _Nullable))completionHandler;
	[Export ("onlinePulseEvaluationWithPlugin:action:bundle:completionHandler:")]
	void OnlinePulseEvaluationWithPlugin (string plugin, string action, string bundle, Action<NITRecipe, NSError> completionHandler);
}

// @interface NITRemoteItem : NITResource <NSCoding>
[BaseType (typeof(NITResource))]
interface NITRemoteItem : INSCoding
{
	// @property (nonatomic, strong) NSString * _Nullable profileId;
	[NullAllowed, Export ("profileId", ArgumentSemantic.Strong)]
	string ProfileId { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable recipeId;
	[NullAllowed, Export ("recipeId", ArgumentSemantic.Strong)]
	string RecipeId { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable pluginId;
	[NullAllowed, Export ("pluginId", ArgumentSemantic.Strong)]
	string PluginId { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable actionId;
	[NullAllowed, Export ("actionId", ArgumentSemantic.Strong)]
	string ActionId { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable bundleId;
	[NullAllowed, Export ("bundleId", ArgumentSemantic.Strong)]
	string BundleId { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable notificationText;
	[NullAllowed, Export ("notificationText", ArgumentSemantic.Strong)]
	string NotificationText { get; set; }

	// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable bundle;
	[NullAllowed, Export ("bundle", ArgumentSemantic.Strong)]
	NSDictionary<NSString, NSObject> Bundle { get; set; }

	// @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Strong)]
	NSDictionary<NSString, NSObject> Metadata { get; set; }

	// @property (nonatomic) BOOL read;
	[Export ("read")]
	bool Read { get; set; }

	// @property (nonatomic) long tracked_at;
	[Export ("tracked_at")]
	nint Tracked_at { get; set; }

	// -(NSDate * _Nonnull)date;
	[Export ("date")]
	[Verify (MethodToProperty)]
	NSDate Date { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITSchedulePeriodRefreshDateCacheKey;
	[Field ("NITSchedulePeriodRefreshDateCacheKey", "__Internal")]
	NSString NITSchedulePeriodRefreshDateCacheKey { get; }
}

// @interface NITSchedulePeriodRefresher : NSObject
[BaseType (typeof(NSObject))]
interface NITSchedulePeriodRefresher
{
	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration cacheManager:(NITCacheManager * _Nonnull)cacheManager dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithConfiguration:cacheManager:dateManager:")]
	IntPtr Constructor (NITConfiguration configuration, NITCacheManager cacheManager, NITDateManager dateManager);

	// -(BOOL)shouldRefresh;
	[Export ("shouldRefresh")]
	[Verify (MethodToProperty)]
	bool ShouldRefresh { get; }

	// -(void)updateRefreshDate;
	[Export ("updateRefreshDate")]
	void UpdateRefreshDate ();
}

// @interface NITScheduleValidator : NSObject <NITValidating>
[BaseType (typeof(NSObject))]
interface NITScheduleValidator : INITValidating
{
	// -(instancetype _Nonnull)initWithDateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithDateManager:")]
	IntPtr Constructor (NITDateManager dateManager);

	// -(void)setTimeZone:(NSTimeZone * _Nonnull)timeZone;
	[Export ("setTimeZone:")]
	void SetTimeZone (NSTimeZone timeZone);
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

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const NITSimpleNotificationPluginName;
	[Field ("NITSimpleNotificationPluginName", "__Internal")]
	NSString NITSimpleNotificationPluginName { get; }
}

// @interface NITSimpleNotificationReaction : NITReaction
[BaseType (typeof(NITReaction))]
interface NITSimpleNotificationReaction
{
}

// @interface NITTimeBandEvaluator : NSObject
[BaseType (typeof(NSObject))]
interface NITTimeBandEvaluator
{
	// -(instancetype _Nonnull)initWithDateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithDateManager:")]
	IntPtr Constructor (NITDateManager dateManager);

	// -(BOOL)isInTimeBandWithFromHour:(NSString * _Nullable)fromHour toHour:(NSString * _Nullable)toHour;
	[Export ("isInTimeBandWithFromHour:toHour:")]
	bool IsInTimeBandWithFromHour ([NullAllowed] string fromHour, [NullAllowed] string toHour);

	// -(void)setTimeZone:(NSTimeZone * _Nonnull)timeZone;
	[Export ("setTimeZone:")]
	void SetTimeZone (NSTimeZone timeZone);
}

// @interface NITTimestamp : NITResource
[BaseType (typeof(NITResource))]
interface NITTimestamp
{
	// @property (nonatomic, strong) NSString * what;
	[Export ("what", ArgumentSemantic.Strong)]
	string What { get; set; }

	// @property (nonatomic, strong) NSNumber * time;
	[Export ("time", ArgumentSemantic.Strong)]
	NSNumber Time { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const NSTimeInterval TimestampInvalidTime;
	[Field ("TimestampInvalidTime", "__Internal")]
	double TimestampInvalidTime { get; }
}

// @interface NITTimestampsManager : NSObject
[BaseType (typeof(NSObject))]
interface NITTimestampsManager
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager configuration:(NITConfiguration * _Nonnull)configuration;
	[Export ("initWithNetworkManager:configuration:")]
	IntPtr Constructor (NITNetworkManaging networkManager, NITConfiguration configuration);

	// -(void)checkTimestampWithType:(NSString * _Nonnull)type referenceTime:(NSTimeInterval)referenceTime completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
	[Export ("checkTimestampWithType:referenceTime:completionHandler:")]
	void CheckTimestampWithType (string type, double referenceTime, [NullAllowed] Action<bool> completionHandler);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull NITTrackCacheKey;
	[Field ("NITTrackCacheKey", "__Internal")]
	NSString NITTrackCacheKey { get; }
}

// @interface NITTrackManager : NSObject
[BaseType (typeof(NSObject))]
interface NITTrackManager
{
	// -(instancetype _Nonnull)initWithSender:(NITTrackSender * _Nonnull)sender cacheManager:(NITCacheManager * _Nonnull)cacheManager reachability:(NITReachability * _Nonnull)reachability dateManager:(NITDateManager * _Nonnull)dateManager;
	[Export ("initWithSender:cacheManager:reachability:dateManager:")]
	IntPtr Constructor (NITTrackSender sender, NITCacheManager cacheManager, NITReachability reachability, NITDateManager dateManager);

	// -(void)sendTrackWithRequest:(NITTrackRequest * _Nonnull)request;
	[Export ("sendTrackWithRequest:")]
	void SendTrackWithRequest (NITTrackRequest request);

	// -(void)sendTrackings;
	[Export ("sendTrackings")]
	void SendTrackings ();
}

// @interface NITTrackRequest : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITTrackRequest : INSCoding
{
	// @property (nonatomic, strong) NSURLRequest * _Nonnull request;
	[Export ("request", ArgumentSemantic.Strong)]
	NSUrlRequest Request { get; set; }

	// @property (nonatomic) BOOL sending;
	[Export ("sending")]
	bool Sending { get; set; }

	// -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nonnull)request;
	[Export ("initWithRequest:")]
	IntPtr Constructor (NSUrlRequest request);
}

// @interface NITTrackSender : NSObject
[BaseType (typeof(NSObject))]
interface NITTrackSender
{
	// -(instancetype _Nonnull)initWithNetworkManager:(id<NITNetworkManaging> _Nonnull)networkManager;
	[Export ("initWithNetworkManager:")]
	IntPtr Constructor (NITNetworkManaging networkManager);

	// -(void)sendWithRequest:(NITTrackRequest * _Nonnull)request completionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("sendWithRequest:completionHandler:")]
	void SendWithRequest (NITTrackRequest request, Action<NSError> completionHandler);
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
	[Verify (MethodToProperty)]
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

	// +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId extras:(NSDictionary<NSString *,id> *)extras;
	[Static]
	[Export ("trackingInfoFromRecipeId:extras:")]
	NITTrackingInfo TrackingInfoFromRecipeId (string recipeId, NSDictionary<NSString, NSObject> extras);
}

// @interface NITTreeLevel : NSObject <NSCoding>
[BaseType (typeof(NSObject))]
interface NITTreeLevel : INSCoding
{
	// -(instancetype _Nonnull)initWithParent:(NITNode * _Nullable)parent children:(NSArray<NITNode *> * _Nullable)children;
	[Export ("initWithParent:children:")]
	IntPtr Constructor ([NullAllowed] NITNode parent, [NullAllowed] NITNode[] children);

	// -(BOOL)containsWithId:(NSString * _Nullable)ID;
	[Export ("containsWithId:")]
	bool ContainsWithId ([NullAllowed] string ID);

	// -(BOOL)shouldConsiderEventWithId:(NSString * _Nullable)ID event:(NITTreeLevelEvent)event;
	[Export ("shouldConsiderEventWithId:event:")]
	bool ShouldConsiderEventWithId ([NullAllowed] string ID, NITTreeLevelEvent @event);

	// -(NSInteger)count;
	[Export ("count")]
	[Verify (MethodToProperty)]
	nint Count { get; }

	// -(NITNode * _Nullable)parent;
	[NullAllowed, Export ("parent")]
	[Verify (MethodToProperty)]
	NITNode Parent { get; }

	// -(NSArray<NITNode *> * _Nullable)children;
	[NullAllowed, Export ("children")]
	[Verify (MethodToProperty)]
	NITNode[] Children { get; }

	// -(BOOL)isEmpty;
	[Export ("isEmpty")]
	[Verify (MethodToProperty)]
	bool IsEmpty { get; }

	// -(BOOL)isChildrenEmpty;
	[Export ("isChildrenEmpty")]
	[Verify (MethodToProperty)]
	bool IsChildrenEmpty { get; }
}

// @interface NITTriggerRequest : NSObject
[BaseType (typeof(NSObject))]
interface NITTriggerRequest
{
	// @property (nonatomic, strong) NSString * _Nonnull pulsePlugin;
	[Export ("pulsePlugin", ArgumentSemantic.Strong)]
	string PulsePlugin { get; set; }

	// @property (nonatomic, strong) NSString * _Nonnull pulseAction;
	[Export ("pulseAction", ArgumentSemantic.Strong)]
	string PulseAction { get; set; }

	// @property (nonatomic, strong) NSString * _Nonnull pulseBundle;
	[Export ("pulseBundle", ArgumentSemantic.Strong)]
	string PulseBundle { get; set; }

	// @property (nonatomic, strong) NSString * _Nullable tagAction;
	[NullAllowed, Export ("tagAction", ArgumentSemantic.Strong)]
	string TagAction { get; set; }

	// @property (nonatomic, strong) NSArray<NSString *> * _Nullable tags;
	[NullAllowed, Export ("tags", ArgumentSemantic.Strong)]
	string[] Tags { get; set; }

	// @property (nonatomic, strong) NITTrackingInfo * _Nonnull trackingInfo;
	[Export ("trackingInfo", ArgumentSemantic.Strong)]
	NITTrackingInfo TrackingInfo { get; set; }
}

// @protocol NITTriggerRequestQueueDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITTriggerRequestQueueDelegate
{
	// @required -(void)triggerRequestQueue:(NITTriggerRequestQueue * _Nonnull)queue didFinishWithRequest:(NITTriggerRequest * _Nonnull)request;
	[Abstract]
	[Export ("triggerRequestQueue:didFinishWithRequest:")]
	void DidFinishWithRequest (NITTriggerRequestQueue queue, NITTriggerRequest request);
}

// @interface NITTriggerRequestQueue : NSObject
[BaseType (typeof(NSObject))]
interface NITTriggerRequestQueue
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITTriggerRequestQueueDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITTriggerRequestQueueDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(instancetype _Nonnull)initWithRepository:(NITRecipeRepository * _Nonnull)repository;
	[Export ("initWithRepository:")]
	IntPtr Constructor (NITRecipeRepository repository);

	// -(void)addRequest:(NITTriggerRequest * _Nonnull)request;
	[Export ("addRequest:")]
	void AddRequest (NITTriggerRequest request);
}

// @interface NITUpdateManager : NSObject
[BaseType (typeof(NSObject))]
interface NITUpdateManager
{
	// -(instancetype _Nonnull)initWithRecipesManager:(NITRecipesManager * _Nonnull)recipesManager geopolisManager:(NITGeopolisManager * _Nonnull)geopolisManager reactionsManager:(NITReactionsManager * _Nonnull)reactionsManager scheduleRefresher:(NITSchedulePeriodRefresher * _Nonnull)scheduleRefresher;
	[Export ("initWithRecipesManager:geopolisManager:reactionsManager:scheduleRefresher:")]
	IntPtr Constructor (NITRecipesManager recipesManager, NITGeopolisManager geopolisManager, NITReactionsManager reactionsManager, NITSchedulePeriodRefresher scheduleRefresher);

	// -(void)updateWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler;
	[Export ("updateWithCompletionHandler:")]
	void UpdateWithCompletionHandler (Action<NSError> completionHandler);

	// -(void)updateForBackgroundFetchWithCompletionHandler:(void (^ _Nonnull)(UIBackgroundFetchResult))completionHandler;
	[Export ("updateForBackgroundFetchWithCompletionHandler:")]
	void UpdateForBackgroundFetchWithCompletionHandler (Action<UIBackgroundFetchResult> completionHandler);
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
	[Verify (MethodToProperty)]
	NSUrl Url { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull UserDataBackoffCacheKey;
	[Field ("UserDataBackoffCacheKey", "__Internal")]
	NSString UserDataBackoffCacheKey { get; }
}

// @protocol NITUserDataBackoffDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITUserDataBackoffDelegate
{
	// @required -(void)userDataBackoffDidComplete:(NITUserDataBackoff * _Nonnull)userDataBackoff;
	[Abstract]
	[Export ("userDataBackoffDidComplete:")]
	void UserDataBackoffDidComplete (NITUserDataBackoff userDataBackoff);

	// @required -(void)userDataBackoffDidFailed:(NITUserDataBackoff * _Nonnull)userDataBackoff withError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("userDataBackoffDidFailed:withError:")]
	void UserDataBackoffDidFailed (NITUserDataBackoff userDataBackoff, NSError error);

	// @optional -(void)userDataBackoffDidSend:(NITUserDataBackoff * _Nonnull)userDataBackoff;
	[Export ("userDataBackoffDidSend:")]
	void UserDataBackoffDidSend (NITUserDataBackoff userDataBackoff);
}

// @interface NITUserDataBackoff : NSObject
[BaseType (typeof(NSObject))]
interface NITUserDataBackoff
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITUserDataBackoffDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITUserDataBackoffDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration networkManager:(id<NITNetworkManaging> _Nonnull)networkManager cacheManager:(NITCacheManager * _Nonnull)cacheManager;
	[Export ("initWithConfiguration:networkManager:cacheManager:")]
	IntPtr Constructor (NITConfiguration configuration, NITNetworkManaging networkManager, NITCacheManager cacheManager);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value;
	[Export ("setUserDataWithKey:value:")]
	void SetUserDataWithKey (string key, [NullAllowed] string value);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key multiValue:(NSDictionary<NSString *,NSNumber *> *)value;
	[Export ("setUserDataWithKey:multiValue:")]
	void SetUserDataWithKey (string key, NSDictionary<NSString, NSNumber> value);

	// -(void)shouldSendDataPoints;
	[Export ("shouldSendDataPoints")]
	void ShouldSendDataPoints ();
}

// @protocol NITUserProfileDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface NITUserProfileDelegate
{
	// @required -(void)profileUserDataBackoffDidComplete:(NITUserProfile * _Nonnull)profile;
	[Abstract]
	[Export ("profileUserDataBackoffDidComplete:")]
	void ProfileUserDataBackoffDidComplete (NITUserProfile profile);
}

// @interface NITUserProfile : NSObject
[BaseType (typeof(NSObject))]
interface NITUserProfile
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	NITUserProfileDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<NITUserProfileDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) NITInstallation * _Nonnull installation;
	[Export ("installation", ArgumentSemantic.Strong)]
	NITInstallation Installation { get; set; }

	// -(instancetype _Nonnull)initWithConfiguration:(NITConfiguration * _Nonnull)configuration networkManager:(id<NITNetworkManaging> _Nonnull)networkManager installation:(NITInstallation * _Nonnull)installation userDataBackoff:(NITUserDataBackoff * _Nonnull)userDataBackoff;
	[Export ("initWithConfiguration:networkManager:installation:userDataBackoff:")]
	IntPtr Constructor (NITConfiguration configuration, NITNetworkManaging networkManager, NITInstallation installation, NITUserDataBackoff userDataBackoff);

	// -(void)createNewProfileWithCompletionHandler:(void (^ _Nullable)(NSString * _Nullable, NSError * _Nullable))handler;
	[Export ("createNewProfileWithCompletionHandler:")]
	void CreateNewProfileWithCompletionHandler ([NullAllowed] Action<NSString, NSError> handler);

	// -(void)setUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
	[Export ("setUserDataWithKey:value:completionHandler:")]
	void SetUserDataWithKey (string key, [NullAllowed] string value, [NullAllowed] Action<NSError> handler);

	// -(void)setBatchUserDataWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)valuesDictiornary completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
	[Export ("setBatchUserDataWithDictionary:completionHandler:")]
	void SetBatchUserDataWithDictionary (NSDictionary<NSString, NSObject> valuesDictiornary, [NullAllowed] Action<NSError> handler);

	// -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nullable)value;
	[Export ("setDeferredUserDataWithKey:value:")]
	void SetDeferredUserDataWithKey (string key, [NullAllowed] string value);

	// -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key multiValue:(NSDictionary<NSString *,NSNumber *> * _Nullable)value;
	[Export ("setDeferredUserDataWithKey:multiValue:")]
	void SetDeferredUserDataWithKey (string key, [NullAllowed] NSDictionary<NSString, NSNumber> value);

	// -(void)resetProfile __attribute__((deprecated("")));
	[Export ("resetProfile")]
	void ResetProfile ();

	// -(void)resetProfileWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
	[Export ("resetProfileWithCompletionHandler:")]
	void ResetProfileWithCompletionHandler (Action<NSString, NSError> handler);

	// -(void)setProfileId:(NSString * _Nonnull)profileId;
	[Export ("setProfileId:")]
	void SetProfileId (string profileId);

	// -(void)profileIdWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))handler;
	[Export ("profileIdWithCompletionHandler:")]
	void ProfileIdWithCompletionHandler (Action<NSString, NSError> handler);

	// -(void)shouldSendUserData;
	[Export ("shouldSendUserData")]
	void ShouldSendUserData ();
}

// @interface NITUtils : NSObject
[BaseType (typeof(NSObject))]
interface NITUtils
{
	// +(NSString * _Nonnull)fetchAppIdFromApiKey:(NSString * _Nonnull)apiKey;
	[Static]
	[Export ("fetchAppIdFromApiKey:")]
	string FetchAppIdFromApiKey (string apiKey);

	// +(NSString * _Nonnull)stringFromRegionEvent:(NITRegionEvent)event;
	[Static]
	[Export ("stringFromRegionEvent:")]
	string StringFromRegionEvent (NITRegionEvent @event);

	// +(NSString * _Nonnull)stringTagFromRegionEvent:(NITRegionEvent)event;
	[Static]
	[Export ("stringTagFromRegionEvent:")]
	string StringTagFromRegionEvent (NITRegionEvent @event);

	// +(NSString * _Nonnull)stringFromBluetoothState:(CBManagerState)state;
	[Static]
	[Export ("stringFromBluetoothState:")]
	string StringFromBluetoothState (CBManagerState state);

	// +(NSString * _Nonnull)generateUUID;
	[Static]
	[Export ("generateUUID")]
	[Verify (MethodToProperty)]
	string GenerateUUID { get; }

	// +(NSString * _Nonnull)deviceModel;
	[Static]
	[Export ("deviceModel")]
	[Verify (MethodToProperty)]
	string DeviceModel { get; }
}

// @interface NITVisitedArea : NSObject
[BaseType (typeof(NSObject))]
interface NITVisitedArea
{
	// @property (nonatomic, strong) NSString * proximityUUID;
	[Export ("proximityUUID", ArgumentSemantic.Strong)]
	string ProximityUUID { get; set; }

	// @property (nonatomic, strong) NSNumber * major;
	[Export ("major", ArgumentSemantic.Strong)]
	NSNumber Major { get; set; }

	// @property (nonatomic, strong) NSDate * lastSeen;
	[Export ("lastSeen", ArgumentSemantic.Strong)]
	NSDate LastSeen { get; set; }

	// @property (nonatomic, strong) NITBeaconNode * sourceNode;
	[Export ("sourceNode", ArgumentSemantic.Strong)]
	NITBeaconNode SourceNode { get; set; }
}

// @interface NSDataZip (NSData)
[Category]
[BaseType (typeof(NSData))]
interface NSData_NSDataZip
{
	// -(NSData *)zlibInflate;
	[Export ("zlibInflate")]
	[Verify (MethodToProperty)]
	NSData ZlibInflate { get; }

	// -(NSData *)zlibDeflate;
	[Export ("zlibDeflate")]
	[Verify (MethodToProperty)]
	NSData ZlibDeflate { get; }

	// -(NSData *)gzipInflate;
	[Export ("gzipInflate")]
	[Verify (MethodToProperty)]
	NSData GzipInflate { get; }

	// -(NSData *)gzipDeflate;
	[Export ("gzipDeflate")]
	[Verify (MethodToProperty)]
	NSData GzipDeflate { get; }

	// +(NSData *)dataFromBase64String:(NSString *)aString;
	[Static]
	[Export ("dataFromBase64String:")]
	NSData DataFromBase64String (string aString);

	// +(NSString *)md5Digest:(NSString * _Nonnull)target;
	[Static]
	[Export ("md5Digest:")]
	string Md5Digest (string target);
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double NearITSDKVersionNumber;
	[Field ("NearITSDKVersionNumber", "__Internal")]
	double NearITSDKVersionNumber { get; }

	// extern const unsigned char [] NearITSDKVersionString;
	[Field ("NearITSDKVersionString", "__Internal")]
	byte[] NearITSDKVersionString { get; }
}
