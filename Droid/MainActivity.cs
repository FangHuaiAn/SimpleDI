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
			Xamarin.Insights.Initialize (global::SimpleDI.Droid.XamarinInsights.ApiKey, this);
			base.OnCreate (savedInstanceState);
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			button.Click += delegate {
				//ShowAlert( "呼叫端決定內部邏輯", (sender, e) =>{Log.Info( "SimpleDI", "這是Android");});
				ShowAlertR1( Resource.String.hello ,  (string obj)=>{Log.Info( "SimpleDI", string.Format("這是Android:{0}", obj));} );
			};

			var myClass = new MyClass ();
			myClass.VerifyPassword ("", new AndroidWorker ());


			/*
			var myClass2 = new MyClass2 (new AndroidWorker ());
			myClass2.VerifyPassword ("");
			*/
		}

		private void ShowAlert(string message, EventHandler<Android.Content.DialogClickEventArgs> positiveButtonClickHandle){

			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (message);

			alert.SetPositiveButton ("Confirm", positiveButtonClickHandle);

			RunOnUiThread (() => {
				alert.Show();
			} );

		}

		private void ShowAlertR1(string message, Action<string> action ){

			AlertDialog.Builder alert = new AlertDialog.Builder (this);

			alert.SetTitle (message);

			alert.SetPositiveButton ("Confirm", (sender, e) =>{ action("ShowAlertR1"); });

			RunOnUiThread (() => {
				alert.Show();
			} );

		}
	}
}
