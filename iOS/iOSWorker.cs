using System;

using Foundation;

using Debug = System.Diagnostics.Debug ;

namespace SimpleDI.iOS
{
	public class iOSWorker : IWorker
	{
		public iOSWorker ()
		{
		}

		public string ReadUserProfileFromLocalStorage(){
			Debug.WriteLine ("iOS ReadUserProfileFromLocalStorage");
			return "iOS ReadUserProfileFromLocalStorage";
		}
	}
}

