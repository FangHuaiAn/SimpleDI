using System;

using UIKit;
using Foundation;

using Debug = System.Diagnostics.Debug ;

namespace SimpleDI.iOS
{
	public class iOSWorker : IWorker
	{
		private UIViewController ViewController { get; set;}

		public iOSWorker (UIViewController viewController)
		{
			ViewController = viewController;
		}

		public User ReadUserProfileById (string id) {

			NSUserDefaults.StandardUserDefaults.SetString (id, "UserId");
			NSUserDefaults.StandardUserDefaults.Synchronize ();


			var idFromNSUserDefaults = NSUserDefaults.StandardUserDefaults.StringForKey ("UserId");

			return new User{Id = idFromNSUserDefaults, Name = @"iOS User" };
		}

		public void ShowAlert (string title, string message, Action<string> action ) {

			//Create Alert
			var confirmAlertController = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);

			//Add Actions
			confirmAlertController.AddAction(UIAlertAction.Create("Confirm", UIAlertActionStyle.Default, (e)=>{  

				action( "ShowAlert from iOSWorker" );

			} ));

			ViewController.InvokeOnMainThread (()=>{
				ViewController.PresentViewController (confirmAlertController, true, null);
			});

		}
	}
}