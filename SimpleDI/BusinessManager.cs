using System;

using Debug = System.Diagnostics.Debug ;

namespace SimpleDI
{
	/// <summary>
	/// iOS, Android 都會呼叫到這個類別
	/// </summary>
	public class BusinessManagerA
	{
		public BusinessManagerA ()
		{
		}

		public void VerifyPassword(string id, string password, IWorker worker, Action<string> action){

			var profile = worker.ReadUserProfileById (id);

			Debug.WriteLine (string.Format(@"BusinessManagerA profile:{0}", profile.Name));
		
			worker.ShowAlert ("登入", "登入成功", action);
		}
	}

	public class BusinessManagerB{

		private IWorker Worker{ get; set; }

		public BusinessManagerB(IWorker worker){
			Worker = worker;
		}

		public void VerifyPassword(string id, string password, Action<string> action){
		
			var profile = Worker.ReadUserProfileById (id);

			Debug.WriteLine (string.Format(@"BusinessManagerB profile:{0}", profile.Name));

			Worker.ShowAlert ("登入", "登入成功", action);
		}
	}
}

