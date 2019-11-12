using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace NearIT
{
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
	public enum NITBeaconNodeDepth : ulong
    {
		ProximityUUID = 1,
		Major = 2,
		MajorAndMinor = 3
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
		// [Verify (PlatformInvoke)]
		static extern void NITLogV (NSString tag, NSString format, IntPtr varArgs);

		// extern void NITLogD (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern void NITLogD (NSString tag, NSString format, IntPtr varArgs);

		// extern void NITLogI (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern void NITLogI (NSString tag, NSString format, IntPtr varArgs);

		// extern void NITLogW (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern void NITLogW (NSString tag, NSString format, IntPtr varArgs);

		// extern void NITLogE (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern void NITLogE (NSString tag, NSString format, IntPtr varArgs);

		// extern void * _Nonnull NewBase64Decode (const char * _Nonnull inputBuffer, size_t length, size_t * _Nonnull outputLength);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		static extern unsafe void* NewBase64Decode (sbyte* inputBuffer, nuint length, nuint* outputLength);

		// extern char * _Nullable NewBase64Encode (const void * _Nonnull inputBuffer, size_t length, _Bool separateLines, size_t * _Nonnull outputLength);
		[DllImport ("__Internal")]
		// [Verify (PlatformInvoke)]
		// [return: NullAllowed]
		static extern unsafe sbyte* NewBase64Encode (void* inputBuffer, nuint length, bool separateLines, nuint* outputLength);
	}

	[Native]
    public enum NITNetworkStatus : ulong
    {
		NotReachable = 0,
		ReachableViaWiFi,
		ReachableViaWWAN
	}

	[Native]
	public enum NITTreeLevelEvent : ulong
    {
		nter = 1,
		xit
	}
}
