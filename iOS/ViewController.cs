using System;
		
using UIKit;

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

			/*
			var myClass = new MyClass ();
			myClass.VerifyPassword ("", new iOSWorker ());
			*/

			var myClass2 = new MyClass2 (new iOSWorker ());
			myClass2.VerifyPassword ("");


			Button.TouchUpInside += delegate {
				//ShowAlert( "呼叫端決定內部邏輯", (e)=>{ Debug.WriteLine( "這是 iOS");});
				ShowAlertR1( "呼叫端決定內部邏輯", (string obj) => {  Debug.WriteLine( string.Format( "ShowAlertR1:{0}",obj)); }); 
			};
		}

		public override void DidReceiveMemoryWarning ()
		{		
			base.DidReceiveMemoryWarning ();		
			// Release any cached data, images, etc that aren't in use.		
		}

		public void ShowAlert(string message, Action<UIAlertAction> action){

			//Create Alert
			var confirmAlertController = UIAlertController.Create("Alert", message, UIAlertControllerStyle.Alert);

			//Add Actions
			confirmAlertController.AddAction(UIAlertAction.Create("Confirm", UIAlertActionStyle.Default, action ));

			PresentViewController (confirmAlertController, true, null);

		}
			
		public void ShowAlertR1(string message, Action<string> action){

			//Create Alert
			var confirmAlertController = UIAlertController.Create("Alert", message, UIAlertControllerStyle.Alert);

			//Add Actions
			confirmAlertController.AddAction(UIAlertAction.Create("Confirm", UIAlertActionStyle.Default, (e)=>{  
			
				action( "ShowAlertR1" );
			
			} ));

			PresentViewController (confirmAlertController, true, null);

		}
	}
}
