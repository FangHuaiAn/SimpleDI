using System;
		
using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace SimpleDI.iOS
{
	public partial class ViewController : UIViewController
	{
		
		public ViewController (IntPtr handle) : base (handle)
		{		
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Code to start the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start ();
			#endif





			Button.TouchUpInside += delegate {
				//ShowAlert("iOS", "呼叫端決定內部邏輯", (e)=>{ Debug.WriteLine( "這是 iOS");});
				ShowAlertR1("iOS", NSBundle.MainBundle.LocalizedString("Next", null), (string obj) => {  Debug.WriteLine( string.Format( "ShowAlertR1:{0}",obj)); }); 
			};

			InvokeOnMainThread (()=>{});
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			var managerA = new BusinessManagerA ();
			managerA.VerifyPassword ("", "", new iOSWorker (this), (msg)=>{});


			//var managerB = new BusinessManagerB (new iOSWorker (this));
			//managerB.VerifyPassword ("", "", (msg)=>{});

		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		public void ShowAlert(string title, string message, Action<UIAlertAction> action){


			//Create Alert
			var confirmAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			//Add Actions
			confirmAlertController.AddAction(UIAlertAction.Create("Confirm", UIAlertActionStyle.Default, action ));

			PresentViewController (confirmAlertController, true, null);

		}
			
		public void ShowAlertR1(string title, string message, Action<string> action){

			//Create Alert
			var confirmAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			//Add Actions
			confirmAlertController.AddAction(UIAlertAction.Create("Confirm", UIAlertActionStyle.Default, (e)=>{  
			
				action( "ShowAlertR1" );
			
			} ));

			PresentViewController (confirmAlertController, true, null);

		}
	}
}
