using Foundation;
using UIKit;
using UserNotifications;
using System;
using CoreLocation;
using ObjCRuntime;
using NearIT;

namespace iOSSample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method

            NITManager.SetupWithApiKey("YOUR-API-KEY");
            NITManager.SetFrameworkName("xamarin");
            NITManager d = NITManager.DefaultManager;

            CLLocationManager c = new CLLocationManager();
            c.RequestAlwaysAuthorization();
            application.RegisterForRemoteNotifications();

            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) => {

            });
            UNUserNotificationCenter.Current.Delegate = new UserNotificationDelegate();

            return true;
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
        }

        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return NITManager.DefaultManager.Application(app, url, null);
        }

        public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
        {
            NITManager.DefaultManager.SetDeviceTokenWithData(deviceToken);
        }
    }
}

// Create a delegate class
public class UserNotificationDelegate : UNUserNotificationCenterDelegate
{
    public UserNotificationDelegate()
    {
    }

    public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
    {
        completionHandler(UNNotificationPresentationOptions.Alert);
    }

    public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
    {
        var userInfo = response.Notification.Request.Content.UserInfo;

        NSString[] keys = new NSString[userInfo.Keys.Length];
        int i;
        for (i = 0; i < userInfo.Keys.Length; i++)
        {
            if (userInfo.Keys[i] is NSString)
                keys[i] = userInfo.Keys[i] as NSString;
            else
                i = int.MaxValue;
        }
        if (i != int.MaxValue)
        {
            NSDictionary<NSString, NSObject> notif = new NSDictionary<NSString, NSObject>(keys, userInfo.Values);
            NITManager.DefaultManager.ProcessRecipeWithUserInfo(notif, (content, trackingInfo, error) =>
            {
                if (content != null && content is NITReactionBundle)
                {
                    //call the ParseContent to manage your notification

                }
            });
        }
    }
}
