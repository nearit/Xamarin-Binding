using System;
using ObjCRuntime;
using Foundation;
using System.Runtime.InteropServices;

namespace NearIT
{

    [Native]
    public enum NITFeedbackCommentVisibility : long
    {
        Visible = 0,
        Hidden = 1,
        OnRating = 2
    }

    [Native]
    public enum NITPermissionsAutoCloseDialog : long
    {
        ff = 0,
        n = 1
    }

    [Native]
    public enum NITPermissionsAutoStartRadarType : long
    {
        ff = 0,
        n = 1
    }

    [Native]
    public enum NITPermissionsLocationType : long
    {
        Always = 0,
        WhenInUse = 1
    }

    [Native]
    public enum NITPermissionsType : long
    {
        LocationOnly = 0,
        NotificationsOnly = 1,
        LocationAndNotifications = 2
    }

    [Native]
    public enum NITPermissionsViewPermissions : long
    {
        Location = 1,
        Notifications = 2,
        Bluetooth = 4,
        LocationAndNotifications = 3,
        NotificationAndBluetooth = 6,
        LocationAndBluetooth = 5,
        All = 7
    }

    [Native]
    public enum NITCouponListViewControllerPresentCoupon : long
    {
        Popover = 0,
        Push = 1,
        Custom = 2
    }

    [Native]
    public enum NITCouponListViewControllerFilterOptions : long
    {
        None = 0,
        Valid = 1,
        Expired = 2,
        ValidAndExpired = 3,
        Disabled = 4,
        ValidAndDisabled = 5,
        ExpiredAndDisabled = 6,
        All = 7
    }

    [Native]
    public enum NITCouponListViewControllerFilterRedeemed : long
    {
        Hide = 0,
        Show = 1
    }

    [Native]
    public enum CFAlertControllerBackgroundStyle : long
    {
        Plain = 0,
        Blur = 1
    }

    [Native]
    public enum CFAlertControllerContentPosition : long
    {
        Middle = 0,
        Full = 1
    }

    [Native]
    public enum NITLogLevel : ulong
    {
        Verbose = 0,
        Debug = 1,
        Info = 2,
        Warning = 3,
        Error = 4
    }

    static class CFunctions
    {
        // extern void NITLogV (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
        [DllImport ("__Internal")]
        static extern void NITLogV (NSString tag, NSString format, IntPtr varArgs);

        // extern void NITLogD (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
        [DllImport ("__Internal")]
        static extern void NITLogD (NSString tag, NSString format, IntPtr varArgs);

        // extern void NITLogI (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
        [DllImport ("__Internal")]
        static extern void NITLogI (NSString tag, NSString format, IntPtr varArgs);

        // extern void NITLogW (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
        [DllImport ("__Internal")]
        static extern void NITLogW (NSString tag, NSString format, IntPtr varArgs);

        // extern void NITLogE (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
        [DllImport ("__Internal")]
        static extern void NITLogE (NSString tag, NSString format, IntPtr varArgs);

        // extern void * NewBase64Decode (const char *inputBuffer, size_t length, size_t *outputLength);
        [DllImport ("__Internal")]
        static extern unsafe void* NewBase64Decode (sbyte* inputBuffer, nuint length, nuint* outputLength);

        // extern char * NewBase64Encode (const void *inputBuffer, size_t length, _Bool separateLines, size_t *outputLength);
        [DllImport ("__Internal")]
        static extern unsafe sbyte* NewBase64Encode (void* inputBuffer, nuint length, bool separateLines, nuint* outputLength);
    }

    [Native]
    public enum NITRegionEvent : ulong
    {
        EnterArea,
        LeaveArea,
        Immediate,
        Near,
        Far,
        EnterPlace,
        LeavePlace,
        Unknown
    }

    [Native]
    public enum NITNetworkStatus : ulong
    {
        NotReachable = 0,
        ReachableViaWiFi,
        ReachableViaWWAN
    }
}
