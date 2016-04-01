using System;

using Debug = System.Diagnostics.Debug ;

namespace SimpleDI
{
	/// <summary>
	/// iOS, Android 都會呼叫到這個類別
	/// </summary>
	public class MyClass
	{
		public MyClass ()
		{
		}

		public void VerifyPassword(string password, IWorker worker){

			var profile = worker.ReadUserProfileFromLocalStorage ();

			Debug.WriteLine (string.Format(@"MyClass profile:{0}", profile));

			//return profile;
		}
	}

	public class MyClass2{

		private IWorker Worker{ get; set; }

		public MyClass2(IWorker worker){
			Worker = worker;
		}

		public void VerifyPassword(string password){
		
			var profile = Worker.ReadUserProfileFromLocalStorage ();

			Debug.WriteLine (string.Format(@"MyClass2 profile:{0}", profile));

			//return profile;
		}
	}
}

