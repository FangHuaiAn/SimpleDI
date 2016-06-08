using System;

using Android.OS;
using Android.App;
using Android.Util;
using Android.Content;
using Android.Preferences;

namespace SimpleDI.Droid
{
	public class AndroidWorker : IWorker
	{
		private Activity Context { get; set;}

		public AndroidWorker (Activity context)
		{
			Context = context;
		}

		public User ReadUserProfileById (string id) {

			var sharedPreferences = PreferenceManager.GetDefaultSharedPreferences(Context);

			// Set
			var editor = sharedPreferences.Edit();
			editor.PutString ("UserId", id);
			editor.Commit ();

			// Get
			var idFromPreference = sharedPreferences.GetString ("UserId", "");

			return new User{Id = idFromPreference, Name = @"Android User" };
		}

	
		public void ShowAlert (string title, string message, Action<string> action ){

			AlertDialog.Builder alert = new AlertDialog.Builder (Context);

			alert.SetTitle (title);
			alert.SetMessage (message);

			alert.SetPositiveButton ("Confirm", (sender, e) =>{ action("Alert from AndroidWorker"); });

			Context.RunOnUiThread (() => {
				alert.Show();
			} );

		}
	}
}

