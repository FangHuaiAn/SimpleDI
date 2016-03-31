using System;

using Android.Util;

namespace SimpleDI.Droid
{
	public class AndroidWorker : IWorker
	{
		public AndroidWorker ()
		{
		}

		public string ReadUserProfileFromLocalStorage(){
			Log.Info ("SimpleDI","Android ReadUserProfileFromLocalStorage");
			return "Android ReadUserProfileFromLocalStorage";
		}
	}
}

