using System;
using CoreBluetooth;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

namespace NearIT
{
    // @interface NITBaseViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface NITBaseViewController
    {
        // @property (nonatomic) BOOL isEnableTapToClose;
        [Export("isEnableTapToClose")]
        bool IsEnableTapToClose { get; set; }

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        void ViewDidLoad();

        // -(void)didReceiveMemoryWarning;
        [Export("didReceiveMemoryWarning")]
        void DidReceiveMemoryWarning();

        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);

    }

    // @interface NITContentViewController : NITBaseViewController
    [BaseType(typeof(NITBaseViewController))]
    interface NITContentViewController
    {
        // @property (copy, nonatomic) WKNavigationActionPolicy (^ _Nullable)(NITContentViewController * _Nonnull, NSURLRequest * _Nonnull) linkHandler;
        [NullAllowed, Export("linkHandler", ArgumentSemantic.Copy)]
        Func<NITContentViewController, Foundation.NSUrlRequest, WKNavigationActionPolicy> LinkHandler { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NITContentViewController * _Nonnull, NSURL * _Nonnull) callToActionHandler;
        [NullAllowed, Export("callToActionHandler", ArgumentSemantic.Copy)]
        Action<NITContentViewController, Foundation.NSUrl> CallToActionHandler { get; set; }

        // @property (nonatomic) BOOL drawSeparator;
        [Export("drawSeparator")]
        bool DrawSeparator { get; set; }

        // @property (nonatomic) BOOL hideCloseButton;
        [Export("hideCloseButton")]
        bool HideCloseButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified imagePlaceholder;
        [Export("imagePlaceholder", ArgumentSemantic.Strong)]
        UIImage ImagePlaceholder { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull titleFont;
        [Export("titleFont", ArgumentSemantic.Strong)]
        UIFont TitleFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull titleColor;
        [Export("titleColor", ArgumentSemantic.Strong)]
        UIColor TitleColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified callToActionButton;
        [Export("callToActionButton", ArgumentSemantic.Strong)]
        UIImage CallToActionButton { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull contentMainFont;
        [Export("contentMainFont", ArgumentSemantic.Strong)]
        UIFont ContentMainFont { get; set; }

        // -(instancetype _Nonnull)initWithContent:(NITContent * _Nonnull)content;
        [Export("initWithContent:")]
        IntPtr Constructor(NITContent content);

        [Export("initWithContent:manager:")]
        IntPtr Constructor(NITContent content, NITManager manager);

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)showFromViewController:(UIViewController * _Nullable)fromViewController configureDialog:(void (^ _Nullable)(NITDialogController * _Nonnull))configureDialog;
        [Export("showFromViewController:configureDialog:")]
        void ShowFromViewController([NullAllowed] UIViewController fromViewController, [NullAllowed] Action<NITDialogController> configureDialog);

        // -(void)showWithNavigationController:(UINavigationController * _Nonnull)navigationController;
        [Export("showWithNavigationController:")]
        void ShowWithNavigationController(UINavigationController navigationController);

        // -(void)viewDidLoad;
        [Export("viewDidLoad")]
        void ViewDidLoad();
    }

    // @interface NITCouponListViewController : NITBaseViewController <UITableViewDataSource, UITableViewDelegate>
    [BaseType(typeof(NITBaseViewController))]
    interface NITCouponListViewController : IUITableViewDataSource, IUITableViewDelegate
    {
        // @property (nonatomic) enum NITCouponListViewControllerPresentCoupon presentCoupon;
        [Export("presentCoupon", ArgumentSemantic.Assign)]
        NITCouponListViewControllerPresentCoupon PresentCoupon { get; set; }

        // @property (nonatomic) enum NITCouponListViewControllerFilterOptions filterOption;
        [Export("filterOption", ArgumentSemantic.Assign)]
        NITCouponListViewControllerFilterOptions FilterOption { get; set; }

        // @property (nonatomic) enum NITCouponListViewControllerFilterRedeemed filterRedeemed;
        [Export("filterRedeemed", ArgumentSemantic.Assign)]
        NITCouponListViewControllerFilterRedeemed FilterRedeemed { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified iconPlaceholder;
        [Export("iconPlaceholder", ArgumentSemantic.Strong)]
        UIImage IconPlaceholder { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull expiredColor;
        [Export("expiredColor", ArgumentSemantic.Strong)]
        UIColor ExpiredColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull expiredFont;
        [Export("expiredFont", ArgumentSemantic.Strong)]
        UIFont ExpiredFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull disabledColor;
        [Export("disabledColor", ArgumentSemantic.Strong)]
        UIColor DisabledColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull disabledFont;
        [Export("disabledFont", ArgumentSemantic.Strong)]
        UIFont DisabledFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull validColor;
        [Export("validColor", ArgumentSemantic.Strong)]
        UIColor ValidColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull validFont;
        [Export("validFont", ArgumentSemantic.Strong)]
        UIFont ValidFont { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull titleFont;
        [Export("titleFont", ArgumentSemantic.Strong)]
        UIFont TitleFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull titleColor;
        [Export("titleColor", ArgumentSemantic.Strong)]
        UIColor TitleColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull titleDisabledFont;
        [Export("titleDisabledFont", ArgumentSemantic.Strong)]
        UIFont TitleDisabledFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull titleDisabledColor;
        [Export("titleDisabledColor", ArgumentSemantic.Strong)]
        UIColor TitleDisabledColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull titleExpiredFont;
        [Export("titleExpiredFont", ArgumentSemantic.Strong)]
        UIFont TitleExpiredFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull titleExpiredColor;
        [Export("titleExpiredColor", ArgumentSemantic.Strong)]
        UIColor TitleExpiredColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull valueFont;
        [Export("valueFont", ArgumentSemantic.Strong)]
        UIFont ValueFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull valueColor;
        [Export("valueColor", ArgumentSemantic.Strong)]
        UIColor ValueColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull valueDisabledFont;
        [Export("valueDisabledFont", ArgumentSemantic.Strong)]
        UIFont ValueDisabledFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull valueDisabledColor;
        [Export("valueDisabledColor", ArgumentSemantic.Strong)]
        UIColor ValueDisabledColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull valueExpiredFont;
        [Export("valueExpiredFont", ArgumentSemantic.Strong)]
        UIFont ValueExpiredFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull valueExpiredColor;
        [Export("valueExpiredColor", ArgumentSemantic.Strong)]
        UIColor ValueExpiredColor { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified expiredText;
        [Export("expiredText")]
        string ExpiredText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified disabledText;
        [Export("disabledText")]
        string DisabledText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified validText;
        [Export("validText")]
        string ValidText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified noCoupons;
        [Export("noCoupons")]
        string NoCoupons { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified cellBackground;
        [Export("cellBackground", ArgumentSemantic.Strong)]
        UIImage CellBackground { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified selectedCellBackground;
        [Export("selectedCellBackground", ArgumentSemantic.Strong)]
        UIImage SelectedCellBackground { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NITCouponViewController * _Nonnull) couponViewControllerConfiguration;
        [NullAllowed, Export("couponViewControllerConfiguration", ArgumentSemantic.Copy)]
        Action<NITCouponViewController> CouponViewControllerConfiguration { get; set; }

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)showFromViewController:(UIViewController * _Nullable)fromViewController;
        [Export("showFromViewController:")]
        void ShowFromViewController([NullAllowed] UIViewController fromViewController);

        // -(void)showWithNavigationController:(UINavigationController * _Nonnull)navigationController;
        [Export("showWithNavigationController:")]
        void ShowWithNavigationController(UINavigationController navigationController);

        /*// -(NSInteger)tableView:(UITableView * _Nonnull)tableView numberOfRowsInSection:(NSInteger)section __attribute__((warn_unused_result));
        [Export("tableView:numberOfRowsInSection:")]
        nint TableView(UITableView tableView, nint section);

        // -(NSInteger)numberOfSectionsInTableView:(UITableView * _Nonnull)tableView __attribute__((warn_unused_result));
        [Export("numberOfSectionsInTableView:")]
        nint NumberOfSectionsInTableView(UITableView tableView);

        // -(UIView * _Nullable)tableView:(UITableView * _Nonnull)tableView viewForHeaderInSection:(NSInteger)section __attribute__((warn_unused_result));
        [Export("tableView:viewForHeaderInSection:")]
        [return: NullAllowed]
        UIView TableView(UITableView tableView, nint section);

        // -(UITableViewCell * _Nonnull)tableView:(UITableView * _Nonnull)tableView cellForRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath __attribute__((warn_unused_result));
        [Export("tableView:cellForRowAtIndexPath:")]
        UITableViewCell TableView(UITableView tableView, NSIndexPath indexPath);

        // -(void)tableView:(UITableView * _Nonnull)tableView didSelectRowAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("tableView:didSelectRowAtIndexPath:")]
        void TableView(UITableView tableView, NSIndexPath indexPath);*/
    }

    // @interface NITCouponViewController : NITBaseViewController
    [BaseType(typeof(NITBaseViewController))]
    interface NITCouponViewController
    {
        // @property (nonatomic) BOOL drawSeparator;
        [Export("drawSeparator")]
        bool DrawSeparator { get; set; }

        // @property (nonatomic) BOOL hideCloseButton;
        [Export("hideCloseButton")]
        bool HideCloseButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified separatorImage;
        [Export("separatorImage", ArgumentSemantic.Strong)]
        UIImage SeparatorImage { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull separatorBackgroundColor;
        [Export("separatorBackgroundColor", ArgumentSemantic.Strong)]
        UIColor SeparatorBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified iconPlaceholder;
        [Export("iconPlaceholder", ArgumentSemantic.Strong)]
        UIImage IconPlaceholder { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified expiredText;
        [Export("expiredText")]
        string ExpiredText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified disabledText;
        [Export("disabledText")]
        string DisabledText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified validText;
        [Export("validText")]
        string ValidText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified fromText;
        [Export("fromText")]
        string FromText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified toText;
        [Export("toText")]
        string ToText { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull couponValidColor;
        [Export("couponValidColor", ArgumentSemantic.Strong)]
        UIColor CouponValidColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull couponDisabledColor;
        [Export("couponDisabledColor", ArgumentSemantic.Strong)]
        UIColor CouponDisabledColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull couponExpiredColor;
        [Export("couponExpiredColor", ArgumentSemantic.Strong)]
        UIColor CouponExpiredColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull validFont;
        [Export("validFont", ArgumentSemantic.Strong)]
        UIFont ValidFont { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull fromToFont;
        [Export("fromToFont", ArgumentSemantic.Strong)]
        UIFont FromToFont { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull alternativeFont;
        [Export("alternativeFont", ArgumentSemantic.Strong)]
        UIFont AlternativeFont { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull titleFont;
        [Export("titleFont", ArgumentSemantic.Strong)]
        UIFont TitleFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull titleColor;
        [Export("titleColor", ArgumentSemantic.Strong)]
        UIColor TitleColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull descriptionFont;
        [Export("descriptionFont", ArgumentSemantic.Strong)]
        UIFont DescriptionFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull descriptionColor;
        [Export("descriptionColor", ArgumentSemantic.Strong)]
        UIColor DescriptionColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull serialFont;
        [Export("serialFont", ArgumentSemantic.Strong)]
        UIFont SerialFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull serialColor;
        [Export("serialColor", ArgumentSemantic.Strong)]
        UIColor SerialColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nonnull valueFont;
        [Export("valueFont", ArgumentSemantic.Strong)]
        UIFont ValueFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull valueColor;
        [Export("valueColor", ArgumentSemantic.Strong)]
        UIColor ValueColor { get; set; }

        // -(instancetype _Nonnull)initWithCoupon:(id)coupon;
        [Export("initWithCoupon:")]
        IntPtr Constructor(NITCoupon coupon);

        [Export("initWithCoupon:manager:")]
        IntPtr Constructor(NITCoupon coupon, NITManager manager);

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)showFromViewController:(UIViewController * _Nullable)fromViewController configureDialog:(void (^ _Nullable)(NITDialogController * _Nonnull))configureDialog;
        [Export("showFromViewController:configureDialog:")]
        void ShowFromViewController([NullAllowed] UIViewController fromViewController, [NullAllowed] Action<NITDialogController> configureDialog);

        // -(void)showWithNavigationController:(UINavigationController * _Nonnull)navigationController;
        [Export("showWithNavigationController:")]
        void ShowWithNavigationController(UINavigationController navigationController);
    }

    // @interface NITDialogController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface NITDialogController
    {
        // @property (nonatomic) enum CFAlertControllerBackgroundStyle backgroundStyle;
        [Export("backgroundStyle", ArgumentSemantic.Assign)]
        CFAlertControllerBackgroundStyle BackgroundStyle { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic) enum CFAlertControllerContentPosition contentPosition;
        [Export("contentPosition", ArgumentSemantic.Assign)]
        CFAlertControllerContentPosition ContentPosition { get; set; }

        // -(void)observeValueForKeyPath:(NSString * _Nullable)keyPath ofObject:(id _Nullable)object change:(NSDictionary<NSKeyValueChangeKey,id> * _Nullable)change context:(void * _Nullable)context;
        [Export("observeValueForKeyPath:ofObject:change:context:")]
        void ObserveValueForKeyPath([NullAllowed] string keyPath, [NullAllowed] NSObject @object, [NullAllowed] NSDictionary<NSString, NSObject> change, [NullAllowed] NSObject context);

        // -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
        [Export("initWithNibName:bundle:")]
        [DesignatedInitializer]
        IntPtr Constructor([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);
    }

    /*
    // @interface NearUIBinding_Swift_383 (NITDialogController) <UIGestureRecognizerDelegate>
    [Category]
    [BaseType(typeof(NITDialogController))]
    interface NITDialogController_NearUIBinding_Swift_383 : IUIGestureRecognizerDelegate
    {
        // -(BOOL)gestureRecognizer:(UIGestureRecognizer * _Nonnull)gestureRecognizer shouldReceiveTouch:(UITouch * _Nonnull)touch __attribute__((warn_unused_result));
        [Export("gestureRecognizer:shouldReceiveTouch:")]
        bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UITouch touch);
    }*/

    //delegate void FeedbackCallback(NITFeedbackViewController FeedbackViewController, int Integer, NSString String, Action<bool> Boolean);

    // @interface NITFeedbackViewController : NITBaseViewController
    [BaseType(typeof(NITBaseViewController))]
    interface NITFeedbackViewController
    {
        // @property (copy, nonatomic) void (^ _Nullable)(NITFeedbackViewController * _Nonnull, NSInteger, NSString * _Nullable, void (^ _Nonnull)(BOOL)) feedbackSendCallback;
        /*[NullAllowed, Export("feedbackSendCallback", ArgumentSemantic.Copy)]
        Action<FeedbackCallback> FeedbackSendCallback { get; set; }*/

        // @property (nonatomic, strong) UIImage * _Null_unspecified sendButton;
        [Export("sendButton", ArgumentSemantic.Strong)]
        UIImage SendButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified rateFullButton;
        [Export("rateFullButton", ArgumentSemantic.Strong)]
        UIImage RateFullButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified rateEmptyButton;
        [Export("rateEmptyButton", ArgumentSemantic.Strong)]
        UIImage RateEmptyButton { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable textFont;
        [NullAllowed, Export("textFont", ArgumentSemantic.Strong)]
        UIFont TextFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull errorColor;
        [Export("errorColor", ArgumentSemantic.Strong)]
        UIColor ErrorColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable errorFont;
        [NullAllowed, Export("errorFont", ArgumentSemantic.Strong)]
        UIFont ErrorFont { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified retryButton;
        [Export("retryButton", ArgumentSemantic.Strong)]
        UIImage RetryButton { get; set; }

        // @property (nonatomic) enum NITFeedbackCommentVisibility commentVisibility;
        [Export("commentVisibility", ArgumentSemantic.Assign)]
        NITFeedbackCommentVisibility CommentVisibility { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified closeText;
        [Export("closeText")]
        string CloseText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified commentDescriptionText;
        [Export("commentDescriptionText")]
        string CommentDescriptionText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified sendText;
        [Export("sendText")]
        string SendText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified errorText;
        [Export("errorText")]
        string ErrorText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified retryText;
        [Export("retryText")]
        string RetryText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified okText;
        [Export("okText")]
        string OkText { get; set; }

        // @property (nonatomic) double disappearTime;
        [Export("disappearTime")]
        double DisappearTime { get; set; }

        // -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback;
        [Export("initWithFeedback:")]
        IntPtr Constructor(NITFeedback feedback);

        // -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback feedbackSendCallback:(void (^ _Nullable)(NITFeedbackViewController * _Nonnull, NSInteger, NSString * _Nullable, void (^ _Nonnull)(BOOL)))feedbackSendCallback;
        /*[Export("initWithFeedback:feedbackSendCallback:manager:")]
        IntPtr Constructor(NITFeedback feedback, [NullAllowed] Action<FeedbackCallback> feedbackSendCallback, NITManager manager);*/

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)showFromViewController:(UIViewController * _Nullable)fromViewController configureDialog:(void (^ _Nullable)(NITDialogController * _Nonnull))configureDialog;
        [Export("showFromViewController:configureDialog:")]
        void ShowFromViewController([NullAllowed] UIViewController fromViewController, [NullAllowed] Action<NITDialogController> configureDialog);
    }

    // @protocol NITPermissionsViewControllerDelegate
    [Protocol, Model]
    interface NITPermissionsViewControllerDelegate
    {
        // @optional -(void)locationGranted:(BOOL)granted;
        [Export("locationGranted:")]
        void LocationGranted(bool granted);

        // @optional -(void)notificationsGranted:(BOOL)granted;
        [Export("notificationsGranted:")]
        void NotificationsGranted(bool granted);

        // @optional -(void)dialogClosedWithLocationGranted:(BOOL)locationGranted notificationsGranted:(BOOL)notificationsGranted;
        [Export("dialogClosedWithLocationGranted:notificationsGranted:")]
        void DialogClosedWithLocationGranted(bool locationGranted, bool notificationsGranted);
    }

    /*
    // @interface NITPermissionsView : UIView <CBPeripheralManagerDelegate, NITPermissionsViewControllerDelegate>
    [BaseType(typeof(UIView))]
    interface NITPermissionsView : ICBPeripheralManagerDelegate, NITPermissionsViewControllerDelegate, NITPermissionsManagerDelegate
    {
        // @property (copy, nonatomic) NSString * _Nullable messageText;
        [NullAllowed, Export("messageText")]
        string MessageText { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable messageColor;
        [NullAllowed, Export("messageColor", ArgumentSemantic.Strong)]
        UIColor MessageColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable messageFont;
        [NullAllowed, Export("messageFont", ArgumentSemantic.Strong)]
        UIFont MessageFont { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable buttonText;
        [NullAllowed, Export("buttonText")]
        string ButtonText { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable buttonColor;
        [NullAllowed, Export("buttonColor", ArgumentSemantic.Strong)]
        UIColor ButtonColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable buttonFont;
        [NullAllowed, Export("buttonFont", ArgumentSemantic.Strong)]
        UIFont ButtonFont { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable permissionAvailableColor;
        [NullAllowed, Export("permissionAvailableColor", ArgumentSemantic.Strong)]
        UIColor PermissionAvailableColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable permissionNotAvailableColor;
        [NullAllowed, Export("permissionNotAvailableColor", ArgumentSemantic.Strong)]
        UIColor PermissionNotAvailableColor { get; set; }

        // @property (nonatomic) BOOL animateView;
        [Export("animateView")]
        bool AnimateView { get; set; }

        // @property (nonatomic) enum NITPermissionsViewPermissions permissionsRequired;
        [Export("permissionsRequired", ArgumentSemantic.Assign)]
        NITPermissionsViewPermissions PermissionsRequired { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NITPermissionsView * _Nonnull) callbackOnPermissions;
        [NullAllowed, Export("callbackOnPermissions", ArgumentSemantic.Copy)]
        Action<NITPermissionsView> CallbackOnPermissions { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable buttonBackgroundImage;
        [NullAllowed, Export("buttonBackgroundImage", ArgumentSemantic.Strong)]
        UIImage ButtonBackgroundImage { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)peripheralManagerDidUpdateState:(CBPeripheralManager * _Nonnull)peripheral;
        [Export("peripheralManagerDidUpdateState:")]
        void PeripheralManagerDidUpdateState(CBPeripheralManager peripheral);

        // -(void)notificationsGranted:(BOOL)granted;
        [Export("notificationsGranted:")]
        void NotificationsGranted(bool granted);
    }
    */

    // @interface NITPermissionsViewController : NITBaseViewController
    [BaseType(typeof(NITBaseViewController))]
    interface NITPermissionsViewController
    {
        // @property (nonatomic) enum NITPermissionsType type;
        [Export("type", ArgumentSemantic.Assign)]
        NITPermissionsType Type { get; set; }

        // @property (nonatomic) enum NITPermissionsLocationType locationType;
        [Export("locationType", ArgumentSemantic.Assign)]
        NITPermissionsLocationType LocationType { get; set; }

        // @property (nonatomic) enum NITPermissionsAutoStartRadarType autoStartRadar;
        [Export("autoStartRadar", ArgumentSemantic.Assign)]
        NITPermissionsAutoStartRadarType AutoStartRadar { get; set; }

        // @property (nonatomic) enum NITPermissionsAutoCloseDialog autoCloseDialog;
        [Export("autoCloseDialog", ArgumentSemantic.Assign)]
        NITPermissionsAutoCloseDialog AutoCloseDialog { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified unknownButton;
        [Export("unknownButton", ArgumentSemantic.Strong)]
        UIImage UnknownButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified grantedButton;
        [Export("grantedButton", ArgumentSemantic.Strong)]
        UIImage GrantedButton { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified grantedIcon;
        [Export("grantedIcon", ArgumentSemantic.Strong)]
        UIImage GrantedIcon { get; set; }

        // @property (nonatomic, strong) UIImage * _Null_unspecified headerImage;
        [Export("headerImage", ArgumentSemantic.Strong)]
        UIImage HeaderImage { get; set; }

        // @property (nonatomic, strong) UIColor * _Null_unspecified textColor;
        [Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified locationText;
        [Export("locationText")]
        string LocationText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified notificationsText;
        [Export("notificationsText")]
        string NotificationsText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified explainText;
        [Export("explainText")]
        string ExplainText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified closeText;
        [Export("closeText")]
        string CloseText { get; set; }

        // @property (copy, nonatomic) NSString * _Null_unspecified notNowText;
        [Export("notNowText")]
        string NotNowText { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        NITPermissionsViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NITPermissionsViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // -(BOOL)checkPermissions __attribute__((warn_unused_result));
        [Export("checkPermissions")]
        bool CheckPermissions { get; }

        // -(instancetype _Nonnull)initWithLocationType:(enum NITPermissionsLocationType)locationType;
        [Export("initWithLocationType:")]
        IntPtr Constructor(NITPermissionsLocationType locationType);

        // -(instancetype _Nonnull)initWithType:(enum NITPermissionsType)type;
        [Export("initWithType:")]
        IntPtr Constructor(NITPermissionsType type);

        // -(instancetype _Nonnull)initWithType:(enum NITPermissionsType)type locationType:(enum NITPermissionsLocationType)locationType autoStartRadar:(enum NITPermissionsAutoStartRadarType)autoStartRadar autoCloseDialog:(enum NITPermissionsAutoCloseDialog)autoCloseDialog __attribute__((objc_designated_initializer));
        [Export("initWithType:locationType:autoStartRadar:autoCloseDialog:")]
        [DesignatedInitializer]
        IntPtr Constructor(NITPermissionsType type, NITPermissionsLocationType locationType, NITPermissionsAutoStartRadarType autoStartRadar, NITPermissionsAutoCloseDialog autoCloseDialog);

        // -(void)show;
        [Export("show")]
        void Show();

        // -(void)showWithConfigureDialog:(void (^ _Nullable)(NITDialogController * _Nonnull))configureDialog;
        [Export("showWithConfigureDialog:")]
        void ShowWithConfigureDialog([NullAllowed] Action<NITDialogController> configureDialog);

        // -(void)showFromViewController:(UIViewController * _Nonnull)fromViewController configureDialog:(void (^ _Nullable)(NITDialogController * _Nonnull))configureDialog;
        [Export("showFromViewController:configureDialog:")]
        void ShowFromViewController(UIViewController fromViewController, [NullAllowed] Action<NITDialogController> configureDialog);
    }
    // @interface NITManager : NSObject
    [BaseType(typeof(NSObject))]
    interface NITManager
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        NITManagerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<NITManagerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) BOOL showBackgroundNotification;
        [Export("showBackgroundNotification")]
        bool ShowBackgroundNotification { get; set; }

        // @property (nonatomic) BOOL showForegroundNotification;
        [Export("showForegroundNotification")]
        bool ShowForegroundNotification { get; set; }

        // +(void)setupWithApiKey:(NSString * _Nonnull)apiKey;
        [Static]
        [Export("setupWithApiKey:")]
        void SetupWithApiKey(string apiKey);

        // +(NITManager * _Nonnull)defaultManager;
        [Static]
        [Export("defaultManager")]
        NITManager DefaultManager { get; }

        //+ (void)setFrameworkName:(NSString* _Nonnull)frameworkName;
        [Static]
        [Export("setFrameworkName:")]
        void SetFrameworkName(string FrameworkName);

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)refreshConfigWithCompletionHandler:(void (^ _Nullable)(NSError * _Nullable))completionHandler;
        [Export("refreshConfigWithCompletionHandler:")]
        void RefreshConfigWithCompletionHandler([NullAllowed] Action<NSError> completionHandler);

        // -(void)setDeviceTokenWithData:(NSData * _Nonnull)token;
        [Export("setDeviceTokenWithData:")]
        void SetDeviceTokenWithData(NSData token);

        // -(void)sendTrackingWithTrackingInfo:(NITTrackingInfo * _Nullable)trackingInfo event:(NSString * _Nullable)event;
        [Export("sendTrackingWithTrackingInfo:event:")]
        void SendTrackingWithTrackingInfo([NullAllowed] NITTrackingInfo trackingInfo, [NullAllowed] string @event);

        // -(void)setDeferredUserDataWithKey:(NSString * _Nonnull)key value:(NSString * _Nonnull)value;
        [Export("setDeferredUserDataWithKey:value:")]
        void SetUserData(string key, string value);

        // -(void)sendEventWithEvent:(NITEvent * _Nonnull)event completionHandler:(void (^ _Nullable)(NSError * _Nullable))handler;
        [Export("sendEventWithEvent:completionHandler:")]
        void SendEventWithEvent(NITEvent @event, [NullAllowed] Action<NSError> handler);

        // -(BOOL)processRecipeWithUserInfo:(NSDictionary<NSString *,id> * _Nonnull)userInfo completion:(void (^ _Nullable)(NITReactionBundle * _Nullable, NITTrackingInfo * _Nullable, NSError * _Nullable))completionHandler;
        [Export("processRecipeWithUserInfo:completion:")]
        bool ProcessRecipeWithUserInfo(NSDictionary<NSString, NSObject> userInfo, [NullAllowed] Action<NITReactionBundle, NITTrackingInfo, NSError> completionHandler);

        // -(void)couponsWithCompletionHandler:(void (^ _Nullable)(NSArray<NITCoupon *> * _Nullable, NSError * _Nullable))handler;
        [Export("couponsWithCompletionHandler:")]
        void CouponsWithCompletionHandler([NullAllowed] Action<NSArray<NITCoupon>, NSError> handler);

        //- (void) profileIdWithCompletionHandler:(void (^_Nonnull)(NSString* _Nullable profileId, NSError* _Nullable error))handler;
        [Export("profileIdWithCompletionHandler:")]
        void ProfileIdWithCompletionHandler(Action<NSString, NSError> handler);

        //- (void)resetProfileWithCompletionHandler:(void (^_Nonnull)(NSString* _Nullable profileId, NSError* _Nullable error))handler;
        [Export("resetProfileWithCompletionHandler:")]
        void ResetProfileWithCompletionHandler(Action<NSString, NSError> handler);

        //- (void)optOutWithCompletionHandler:(void (^_Nonnull)(BOOL success))handler;
        [Export("optOutWithCompletionHandler:")]
        void OptOutWithCompletionHandler(Action<bool> handler);

        //- (void)processCustomTriggerWithKey:(NSString* _Nonnull)key;
        [Export("processCustomTriggerWithKey:")]
        void ProcessCustomTriggerWithKey(string key);

        //- (void)application:(UIApplication* _Nonnull)application performFetchWithCompletionHandler:(void (^_Nonnull)(UIBackgroundFetchResult))completionHandler;
        [Export("application:performFetchWithCompletionHandler:")]
        void PerformFetchWithCompletionHandler(UIApplication application, Action<UIBackgroundFetchResult> completionHandler);

        //- (void)setProfileId:(NSString * _Nonnull)profileId;
        [Export("setProfileId:")]
        void SetProfileId(string ProfileId);

        //- (void)parseContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo* _Nonnull)trackingInfo contentDelegate:(id<NITContentDelegate> _Nonnull)contentDelegate;
        [Export("parseContent:trackingInfo:contentDelegate:")]
        void ParseContent(NSObject Content, NITTrackingInfo TrackingInfo, NITContentDelegate ContentDelegate);
    }

    // @protocol NITManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NITManagerDelegate
    {
        // @required -(void)manager:(NITManager * _Nonnull)manager eventWithContent:(id _Nonnull)content trackingInfo:(NITTrackingInfo * _Nonnull)trackingInfo;
        [Abstract]
        [Export("manager:eventWithContent:trackingInfo:")]
        void EventWithContent(NITManager manager, NSObject content, NITTrackingInfo trackingInfo);

        // @required -(void)manager:(NITManager * _Nonnull)manager eventFailureWithError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("manager:eventFailureWithError:")]
        void EventFailureWithError(NITManager manager, NSError error);

        // @optional -(void)manager:(NITManager * _Nonnull)manager alertWantsToShowContent:(id _Nonnull)content;
        [Export("manager:alertWantsToShowContent:")]
        void AlertWantsToShowContent(NITManager manager, NSObject content);
    }

    // @interface NITContent : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITContent : INSCoding
    {
        // @property (nonatomic, strong) NSArray<NITImage *> * _Nullable images __attribute__((deprecated("You should use 'image' attribute"))) __attribute__((deprecated("")));
        [NullAllowed, Export("images", ArgumentSemantic.Strong)]
        NITImage[] Images { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable videoLink __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("videoLink", ArgumentSemantic.Strong)]
        string VideoLink { get; set; }

        // @property (nonatomic, strong) NITAudio * _Nullable audio __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("audio", ArgumentSemantic.Strong)]
        NITAudio Audio { get; set; }

        // @property (nonatomic, strong) NITUpload * _Nullable upload __attribute__((deprecated("Unused"))) __attribute__((deprecated("")));
        [NullAllowed, Export("upload", ArgumentSemantic.Strong)]
        NITUpload Upload { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable title;
        [NullAllowed, Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable content;
        [NullAllowed, Export("content", ArgumentSemantic.Strong)]
        string Content { get; set; }

        // @property (readonly, nonatomic) NITImage * _Nullable image;
        [NullAllowed, Export("image")]
        NITImage Image { get; }

        // @property (readonly, nonatomic) NITContentLink * _Nullable link;
        [NullAllowed, Export("link")]
        NITContentLink Link { get; }

        //@property(nonatomic, strong) NSDictionary<NSString*, id>* _Nonnull internalLink;
        [Export("internalLink")]
        NSDictionary<NSString, NSObject> InternalLink { get; set; }

        /*//- (void)setInternalLink:(NSDictionary<NSString *,id> *)internalLinks;
        [Export("setInternalLink:")]
        void SetInternalLink(NSDictionary<NSString, NSObject> internalLink);

        //- (void)writeSomething:(NSString *_Nonnull)value;
        [Export("writeSomething:")]
        void WriteSomething(NSString value);*/
    }

    // @interface NITImage : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITImage : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Image { get; set; }

        // -(NSURL * _Nullable)smallSizeURL;
        [NullAllowed, Export("smallSizeURL")]

        NSUrl SmallSizeURL { get; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @interface NITResource : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITResource : INSCoding
    {
        // @property (nonatomic, strong) NITJSONAPIResource * _Nullable resourceObject;
        [NullAllowed, Export("resourceObject", ArgumentSemantic.Strong)]
        NITJSONAPIResource ResourceObject { get; set; }
        // -(NSDictionary * _Nonnull)attributesMap;
        [Export("attributesMap")]

        NSDictionary AttributesMap { get; }

        // -(NSString * _Nullable)ID;
        // -(void)setID:(NSString * _Nonnull)ID;
        [NullAllowed, Export("ID")]

        string ID { get; set; }
    }

    // @interface NITAudio : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITAudio : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull audio;
        [Export("audio", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Audio { get; set; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @interface NITRecipe : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITRecipe : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable name;
        [NullAllowed, Export("name", ArgumentSemantic.Strong)]
        string Name { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable notification;
        [NullAllowed, Export("notification", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Notification { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable labels;
        [NullAllowed, Export("labels", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Labels { get; set; }

        // @property (nonatomic, strong) NSArray<NSDictionary<NSString *,id> *> * _Nullable scheduling;
        [NullAllowed, Export("scheduling", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject>[] Scheduling { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,id> * _Nullable cooldown;
        [NullAllowed, Export("cooldown", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Cooldown { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull pulsePluginId;
        [Export("pulsePluginId", ArgumentSemantic.Strong)]
        string PulsePluginId { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull reactionPluginId;
        [Export("reactionPluginId", ArgumentSemantic.Strong)]
        string ReactionPluginId { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull reactionBundleId;
        [Export("reactionBundleId", ArgumentSemantic.Strong)]
        string ReactionBundleId { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable tags;
        [NullAllowed, Export("tags", ArgumentSemantic.Strong)]
        string[] Tags { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull pulseBundle;
        [Export("pulseBundle", ArgumentSemantic.Strong)]
        NITResource PulseBundle { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull pulseAction;
        [Export("pulseAction", ArgumentSemantic.Strong)]
        NITResource PulseAction { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull reactionAction;
        [Export("reactionAction", ArgumentSemantic.Strong)]
        NITResource ReactionAction { get; set; }

        // @property (nonatomic, strong) NITResource * _Nonnull reactionBundle;
        [Export("reactionBundle", ArgumentSemantic.Strong)]
        NITResource ReactionBundle { get; set; }

        // -(BOOL)isEvaluatedOnline;
        [Export("isEvaluatedOnline")]

        bool IsEvaluatedOnline { get; }

        // -(BOOL)isForeground;
        [Export("isForeground")]

        bool IsForeground { get; }

        // -(NSString * _Nullable)notificationTitle;
        [NullAllowed, Export("notificationTitle")]

        string NotificationTitle { get; }

        // -(NSString * _Nullable)notificationBody;
        [NullAllowed, Export("notificationBody")]

        string NotificationBody { get; }
    }

    // @interface NITCoupon : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITCoupon : INSCoding
    {
        // @property (nonatomic, strong) NSString * couponDescription;
        [Export("couponDescription", ArgumentSemantic.Strong)]
        string CouponDescription { get; set; }

        // @property (nonatomic, strong) NSString * value;
        [Export("value", ArgumentSemantic.Strong)]
        string Value { get; set; }

        // @property (nonatomic, strong) NSString * expiresAt;
        [Export("expiresAt", ArgumentSemantic.Strong)]
        string ExpiresAt { get; set; }

        // @property (nonatomic, strong) NSString * redeemableFrom;
        [Export("redeemableFrom", ArgumentSemantic.Strong)]
        string RedeemableFrom { get; set; }

        // @property (nonatomic, strong) NSArray<NITClaim *> * claims;
        [Export("claims", ArgumentSemantic.Strong)]
        NITClaim[] Claims { get; set; }

        // @property (nonatomic, strong) NITImage * icon;
        [Export("icon", ArgumentSemantic.Strong)]
        NITImage Icon { get; set; }

        // @property (readonly, nonatomic) NSDate * expires;
        [Export("expires")]
        NSDate Expires { get; }

        // @property (readonly, nonatomic) NSDate * redeemable;
        [Export("redeemable")]
        NSDate Redeemable { get; }

        // @property (readonly, nonatomic) NSString * title;
        [Export("title")]
        string Title { get; }

        // -(BOOL)hasContentToInclude;
        [Export("hasContentToInclude")]

        bool HasContentToInclude { get; }
    }

    // @interface NITClaim : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITClaim : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nonnull serialNumber;
        [Export("serialNumber", ArgumentSemantic.Strong)]
        string SerialNumber { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull claimedAt;
        [Export("claimedAt", ArgumentSemantic.Strong)]
        string ClaimedAt { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable redeemedAt;
        [NullAllowed, Export("redeemedAt", ArgumentSemantic.Strong)]
        string RedeemedAt { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }

        // @property (nonatomic, strong) NITCoupon * _Nonnull coupon;
        [Export("coupon", ArgumentSemantic.Strong)]
        NITCoupon Coupon { get; set; }

        // @property (readonly, nonatomic) NSDate * _Nonnull claimed;
        [Export("claimed")]
        NSDate Claimed { get; }

        // @property (readonly, nonatomic) NSDate * _Nullable redeemed;
        [NullAllowed, Export("redeemed")]
        NSDate Redeemed { get; }
    }

    // @interface NITFeedback : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITFeedback : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nonnull question;
        [Export("question", ArgumentSemantic.Strong)]
        string Question { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Obsolete("Use TrackingInfo instead.")]
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }

        // @property(nonatomic, strong) NITTrackingInfo* _Nonnull trackingInfo;
        [Export("trackingInfo", ArgumentSemantic.Strong)]
        NITTrackingInfo TrackingInfo { get; set; }
    }

    // @interface NITFeedbackEvent : NITEvent
    [BaseType(typeof(NITEvent))]
    interface NITFeedbackEvent
    {
        // @property (nonatomic, strong) NSString * _Nonnull ID;
        [Export("ID", ArgumentSemantic.Strong)]
        string ID { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull recipeId;
        [Export("recipeId", ArgumentSemantic.Strong)]
        string RecipeId { get; set; }

        // -(instancetype _Nonnull)initWithFeedback:(NITFeedback * _Nonnull)feedback rating:(NSInteger)rating comment:(NSString * _Nonnull)comment;
        [Export("initWithFeedback:rating:comment:")]
        IntPtr Constructor(NITFeedback feedback, nint rating, string comment);

        // -(NITJSONAPI * _Nullable)toJsonAPI:(NITConfiguration * _Nonnull)configuration;
        [Export("toJsonAPI:")]
        [return: NullAllowed]
        NITJSONAPI ToJsonAPI(NITConfiguration configuration);
    }

    // @interface NITCustomJSON : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITCustomJSON : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,id> * content;
        [Export("content", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSObject> Content { get; set; }
    }

    // @interface NITSimpleNotification : NITReactionBundle <NSCoding>
    [BaseType(typeof(NITReactionBundle))]
    interface NITSimpleNotification : INSCoding
    {
        // @property (nonatomic, strong) NSString * _Nullable notificationTitle;
        [NullAllowed, Export("notificationTitle", ArgumentSemantic.Strong)]
        string NotificationTitle { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull message;
        [Export("message", ArgumentSemantic.Strong)]
        string Message { get; set; }
    }

    // @interface NITEvent : NSObject
    [BaseType(typeof(NSObject))]
    interface NITEvent
    {
        // -(NSString * _Nonnull)pluginName;
        [Export("pluginName")]

        string PluginName { get; }
    }

    // @interface NITUpload : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITUpload : INSCoding
    {
        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nonnull upload;
        [Export("upload", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Upload { get; set; }

        // -(NSURL * _Nullable)url;
        [NullAllowed, Export("url")]

        NSUrl Url { get; }
    }

    // @protocol NITLogger <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NITLogger
    {
        // @required -(void)verboseWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("verboseWithTag:message:")]
        void VerboseWithTag(string tag, string message);

        // @required -(void)debugWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("debugWithTag:message:")]
        void DebugWithTag(string tag, string message);

        // @required -(void)infoWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("infoWithTag:message:")]
        void InfoWithTag(string tag, string message);

        // @required -(void)warningWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("warningWithTag:message:")]
        void WarningWithTag(string tag, string message);

        // @required -(void)errorWithTag:(NSString * _Nonnull)tag message:(NSString * _Nonnull)message;
        [Abstract]
        [Export("errorWithTag:message:")]
        void ErrorWithTag(string tag, string message);
    }

    // @interface NITLog : NSObject
    [BaseType(typeof(NSObject))]
    interface NITLog
    {
        // +(void)setLogger:(id<NITLogger> _Nonnull)logger;
        [Static]
        [Export("setLogger:")]
        void SetLogger(NITLogger logger);

        // +(void)setLevel:(NITLogLevel)level;
        [Static]
        [Export("setLevel:")]
        void SetLevel(NITLogLevel level);

        // +(void)setLogEnabled:(BOOL)enabled;
        [Static]
        [Export("setLogEnabled:")]
        void SetLogEnabled(bool enabled);
    }

    // @interface NITReactionBundle : NITResource <NSCoding>
    [BaseType(typeof(NITResource))]
    interface NITReactionBundle : INSCoding
    {
        // @property (nonatomic, strong) NSString * notificationMessage;
        [Export("notificationMessage", ArgumentSemantic.Strong)]
        string NotificationMessage { get; set; }
    }

    // @interface NITContentLink : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITContentLink : INSCoding
    {
        // @property (nonatomic, strong) NSURL * url;
        [Export("url", ArgumentSemantic.Strong)]
        NSUrl Url { get; set; }

        // @property (nonatomic, strong) NSString * label;
        [Export("label", ArgumentSemantic.Strong)]
        string Label { get; set; }
    }

    // @interface NITTrackingInfo : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITTrackingInfo : INSCoding
    {
        // -(BOOL)addExtraWithObject:(id<NSCoding> _Nonnull)object key:(NSString * _Nonnull)key;
        [Export("addExtraWithObject:key:")]
        bool AddExtraWithObject(NSCoding @object, string key);

        // -(NSString * _Nullable)recipeId;
        // -(void)setRecipeId:(NSString * _Nonnull)recipeId;
        [NullAllowed, Export("recipeId")]
        string RecipeId { get; set; }

        //@property (nonatomic, strong) NSMutableDictionary<NSString*, id> *extras;
        [Export("extras")]
        NSDictionary<NSString, NSObject> extras { get; set; }

        // -(NSDictionary * _Nonnull)extrasDictionary;
        [Export("extrasDictionary")]
        NSDictionary ExtrasDictionary();

        // -(BOOL)existsExtraForKey:(NSString * _Nonnull)key;
        [Export("existsExtraForKey:")]
        bool ExistsExtraForKey(string key);

        // +(NITTrackingInfo * _Nonnull)trackingInfoFromRecipeId:(NSString * _Nonnull)recipeId;
        [Static]
        [Export("trackingInfoFromRecipeId:")]
        NITTrackingInfo TrackingInfoFromRecipeId(string recipeId);
    }

    // @interface NITConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface NITConfiguration
    {
        // +(NITConfiguration * _Nonnull)defaultConfiguration;
        [Static]
        [Export("defaultConfiguration")]

        NITConfiguration DefaultConfiguration { get; }

        // -(instancetype _Nonnull)initWithUserDefaults:(NSUserDefaults * _Nonnull)userDefaults;
        [Export("initWithUserDefaults:")]
        IntPtr Constructor(NSUserDefaults userDefaults);

        // -(NSString * _Nonnull)paramKeyWithKey:(NSString * _Nonnull)key;
        [Export("paramKeyWithKey:")]
        string ParamKeyWithKey(string key);

        // -(NSString * _Nullable)apiKey;
        // -(void)setApiKey:(NSString * _Nonnull)apiKey;
        [NullAllowed, Export("apiKey")]

        string ApiKey { get; set; }

        // -(NSString * _Nullable)appId;
        // -(void)setAppId:(NSString * _Nonnull)appId;
        [NullAllowed, Export("appId")]

        string AppId { get; set; }

        // -(NSString * _Nullable)profileId;
        // -(void)setProfileId:(NSString * _Nullable)profileId;
        [NullAllowed, Export("profileId")]

        string ProfileId { get; set; }

        // -(NSString * _Nullable)installationId;
        [Export("installationId")]
        [return: NullAllowed]
        string InstallationId();

        // -(void)setInstallationId:(NSString * _Nullable)installationId;
        [Export("setInstallationId:")]
        void SetInstallationId([NullAllowed] string installationId);

        // -(NSString * _Nullable)deviceToken;
        [Export("deviceToken")]
        [return: NullAllowed]
        string DeviceToken();

        // -(void)setDeviceToken:(NSString * _Nonnull)deviceToken;
        [Export("setDeviceToken:")]
        void SetDeviceToken(string deviceToken);

        // -(void)clear;
        [Export("clear")]
        void Clear();
    }

    // @interface NITJSONAPI : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITJSONAPI : INSCoding
    {
        // -(instancetype _Nullable)initWithContentsOfFile:(NSString * _Nonnull)path error:(NSError * _Nullable * _Nullable)anError;
        [Export("initWithContentsOfFile:error:")]
        IntPtr Constructor(string path, [NullAllowed] out NSError anError);

        // -(instancetype _Nonnull)initWithDictionary:(NSDictionary * _Nonnull)json;
        [Export("initWithDictionary:")]
        IntPtr Constructor(NSDictionary json);

        // -(void)setDataWithResourceObject:(NITJSONAPIResource * _Nonnull)resourceObject;
        [Export("setDataWithResourceObject:")]
        void SetDataWithResourceObject(NITJSONAPIResource resourceObject);

        // -(void)setDataWithResourcesObject:(NSArray<NITJSONAPIResource *> * _Nonnull)resources;
        [Export("setDataWithResourcesObject:")]
        void SetDataWithResourcesObject(NITJSONAPIResource[] resources);

        // -(NITJSONAPIResource * _Nullable)firstResourceObject;
        [NullAllowed, Export("firstResourceObject")]

        NITJSONAPIResource FirstResourceObject { get; }

        // -(NSDictionary * _Nonnull)toDictionary;
        [Export("toDictionary")]

        NSDictionary ToDictionary { get; }

        // -(void)registerClass:(Class _Nonnull)cls forType:(NSString * _Nonnull)type;
        [Export("registerClass:forType:")]
        void RegisterClass(Class cls, string type);

        // -(NSArray * _Nonnull)parseToArrayOfObjects;
        [Export("parseToArrayOfObjects")]
        NSObject[] ParseToArrayOfObjects { get; }

        // -(NSArray<NITJSONAPIResource *> * _Nonnull)allResources;
        [Export("allResources")]

        NITJSONAPIResource[] AllResources { get; }

        // -(NSArray<NITJSONAPIResource *> * _Nonnull)rootResources;
        [Export("rootResources")]

        NITJSONAPIResource[] RootResources { get; }

        // -(NSData * _Nullable)dataValue;
        [NullAllowed, Export("dataValue")]

        NSData DataValue { get; }

        // +(NITJSONAPI * _Nonnull)jsonApiWithAttributes:(NSDictionary<NSString *,id> * _Nonnull)attributes type:(NSString * _Nonnull)type;
        [Static]
        [Export("jsonApiWithAttributes:type:")]
        NITJSONAPI JsonApiWithAttributes(NSDictionary<NSString, NSObject> attributes, string type);

        // +(NITJSONAPI * _Nonnull)jsonApiWithArray:(NSArray<NSDictionary<NSString *,id> *> * _Nonnull)resources type:(NSString * _Nonnull)type;
        [Static]
        [Export("jsonApiWithArray:type:")]
        NITJSONAPI JsonApiWithArray(NSDictionary<NSString, NSObject>[] resources, string type);

        // -(id _Nullable)metaForKey:(NSString * _Nonnull)key;
        [Export("metaForKey:")]
        [return: NullAllowed]
        NSObject MetaForKey(string key);
    }

    // @interface NITJSONAPIResource : NSObject <NSCoding>
    [BaseType(typeof(NSObject))]
    interface NITJSONAPIResource : INSCoding
    {
        // @property (nonatomic, strong) id _Nullable ID;
        [NullAllowed, Export("ID", ArgumentSemantic.Strong)]
        NSObject ID { get; set; }

        // @property (nonatomic, strong) NSString * _Nonnull type;
        [Export("type", ArgumentSemantic.Strong)]
        string Type { get; set; }

        // -(void)addAttributeObject:(id _Nonnull)object forKey:(NSString * _Nonnull)key;
        [Export("addAttributeObject:forKey:")]
        void AddAttributeObject(NSObject @object, string key);

        // -(NSInteger)attributesCount;
        [Export("attributesCount")]

        nint AttributesCount { get; }

        // -(NSDictionary<NSString *,id> * _Nonnull)attributes;
        [Export("attributes")]

        NSDictionary<NSString, NSObject> Attributes { get; }

        // -(NSDictionary<NSString *,id> * _Nonnull)relationships;
        [Export("relationships")]

        NSDictionary<NSString, NSObject> Relationships { get; }

        // -(id _Nullable)attributeForKey:(NSString * _Nonnull)key;
        [Export("attributeForKey:")]
        [return: NullAllowed]
        NSObject AttributeForKey(string key);

        // -(NSDictionary * _Nonnull)toDictionary;
        [Export("toDictionary")]

        NSDictionary ToDictionary { get; }

        // -(NSDictionary * _Nullable)relationshipForKey:(NSString * _Nonnull)key;
        [Export("relationshipForKey:")]
        [return: NullAllowed]
        NSDictionary RelationshipForKey(string key);

        // +(NITJSONAPIResource * _Nonnull)resourceObjectWithDictiornary:(NSDictionary * _Nonnull)dictionary;
        [Static]
        [Export("resourceObjectWithDictiornary:")]
        NITJSONAPIResource ResourceObjectWithDictiornary(NSDictionary dictionary);
    }

    // @protocol NITContentDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NITContentDelegate
    {
        //- (void) gotSimpleNotification:(NITSimpleNotification* _Nonnull) notification trackingInfo:(NITTrackingInfo* _Nonnull) trackingInfo;
        [Abstract]
        [Export("gotSimpleNotification:trackingInfo:")]
        void GotSimpleNotification(NITSimpleNotification Notification, NITTrackingInfo TrackingInfo);

        //- (void) gotContent:(NITContent* _Nonnull) content trackingInfo:(NITTrackingInfo* _Nonnull) trackingInfo;
        [Abstract]
        [Export("gotContent:trackingInfo:")]
        void GotContent(NITContent Content, NITTrackingInfo TrackingInfo);

        //- (void) gotCoupon:(NITCoupon* _Nonnull) coupon trackingInfo:(NITTrackingInfo* _Nonnull) trackingInfo;
        [Abstract]
        [Export("gotCoupon:trackingInfo:")]
        void GotCoupon(NITCoupon Coupon, NITTrackingInfo TrackingInfo);

        //- (void) gotFeedback:(NITFeedback* _Nonnull) feedback trackingInfo:(NITTrackingInfo* _Nonnull) trackingInfo;
        [Abstract]
        [Export("gotFeedback:trackingInfo:")]
        void GotFeedback(NITFeedback Feedback, NITTrackingInfo TrackingInfo);

        //- (void) gotCustomJSON:(NITCustomJSON* _Nonnull) customJson trackingInfo:(NITTrackingInfo* _Nonnull) trackingInfo;
        [Abstract]
        [Export("gotCustomJSON:trackingInfo:")]
        void GotCustomJSON(NITCustomJSON CustomJSON, NITTrackingInfo TrackingInfo);

    }


    /*//@interface NITRecipeForceRefresher : NSObject
    [BaseType(typeof(NSObject))]
    interface NITRecipeForceRefresher
    {
        //- (instancetype _Nonnull)initWithRepositoryState:(NITRecipeRepositoryState* _Nonnull)state dateManager:(NITDateManager* _Nonnull)dateManager;
        [Export("initWithRepositoryState:dateManager:")]
        IntPtr Constructor(NITRecipeRepositoryState state, NITDateManager dateManager);

        //- (BOOL)shouldRefresh;
        [Export("shouldRefresh:")]
        bool ShouldRefresh { get; }
    }

    //@interface NITRecipeRepositoryState : NSObject
    [BaseType(typeof(NSObject))]
    interface NITRecipeRepositoryState
    {
        //@property(nonatomic) NSTimeInterval lastEditedTime;
        [Export("lastEditedTime")]
        NSTimeInterval LastEditedTime { get; set; }

        //@property(nonatomic) BOOL pulseEvaluationOnline;
        [Export("pulseEvaluationOnline")]
        bool PulseEvaluationOnline { get; set; }

        //@property(nonatomic) NSTimeInterval minTimeToRefresh;
        [Export("minTimeToRefresh")]
        NSTimeInterval MinTimeToRefresh { get; set; }

        //- (instancetype _Nonnull) initWithCacheManager:(NITCacheManager* _Nonnull) cacheManager;
        [Export("initWithCacheManager:")]
        IntPtr Constructor(NITCacheManager cacheManager);
    }*/
}