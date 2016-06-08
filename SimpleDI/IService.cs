using System;

namespace SimpleDI
{
	public class User{
		public string Name ;
		public string Id;
	}


	public interface IWorker{

		User ReadUserProfileById (string id) ;
		void ShowAlert (string title, string message, Action<string> action ) ;
	
	}
}

