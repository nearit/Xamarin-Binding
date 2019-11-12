using System;
using NearIT;
using UIKit;

namespace iOSSample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NITManager.DefaultManager.Start();
            // Perform any additional setup after loading the view, typically from a nib.
            NITManager.DefaultManager.HistoryWithCompletion((history, arg2) => {
                if (history == null) return;
                foreach (NITHistoryItem item in history){
                    bool read = item.Read;
                }
            });

            NITManager.DefaultManager.CouponsWithCompletionHandler((coupons, arg2) =>
            {
                foreach (NITCoupon coupon in coupons)
                {
                    string desc = coupon.Description;
                }
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
