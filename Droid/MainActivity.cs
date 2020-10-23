using System;
using System.Linq;
using System.Collections.Generic;

using Android.OS;
using Android.App;
using Android.Util;
using Android.Widget;

namespace SimpleDI.Droid
{
	[Activity (Label = "SimpleDI", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				//ShowAlert("Android", "呼叫端決定內部邏輯", (sender, e) =>{Log.Info( "SimpleDI", "這是Android");});
				ShowAlertR1("Android", "呼叫端決定內部邏輯" ,  (string obj)=>{Log.Info( "SimpleDI", string.Format("這是Android:{0}", obj));} );
			};


			var managerA = new BusinessManagerA ();
			managerA.VerifyPassword ("", "", new AndroidWorker (this), (msg)=>{});

			var managerB = new BusinessManagerB (new AndroidWorker (this));
			managerB.VerifyPassword ("", "", (msg)=>{});


		}

		private void ShowAlert(string title, string message, EventHandler<Android.Content.DialogClickEventArgs> positiveButtonClickHandle){

			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (title);
			alert.SetMessage (message);

			alert.SetPositiveButton ("Confirm", positiveButtonClickHandle);

			RunOnUiThread (() => {
				alert.Show();
			} );

		}

		private void ShowAlertR1(string title, string message, Action<string> action ){

			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (title);
			alert.SetMessage (message);

			alert.SetPositiveButton ("Confirm", (sender, e) =>{ action("ShowAlertR1"); });

			RunOnUiThread (() => {
				alert.Show();
			} );

		}
	}
}
