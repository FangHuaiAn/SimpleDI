using System;
using System.Linq;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace SimpleDI.iOS.Test
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main (string[] args)
		{
			Xamarin.Insights.Initialize (global::SimpleDI.iOS.Test.XamarinInsights.ApiKey);
			// if you want to use a different Application Delegate class from "UnitTestAppDelegate"
			// you can specify it here.
			UIApplication.Main (args, null, "UnitTestAppDelegate");
		}
	}
}
