using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

[Native]
public enum NITLogLevel : nint
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
	[Verify (PlatformInvoke)]
	static extern void NITLogV (NSString tag, NSString format, IntPtr varArgs);

	// extern void NITLogD (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void NITLogD (NSString tag, NSString format, IntPtr varArgs);

	// extern void NITLogI (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void NITLogI (NSString tag, NSString format, IntPtr varArgs);

	// extern void NITLogW (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void NITLogW (NSString tag, NSString format, IntPtr varArgs);

	// extern void NITLogE (NSString * _Nonnull tag, NSString * _Nonnull format, ...);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void NITLogE (NSString tag, NSString format, IntPtr varArgs);
}
