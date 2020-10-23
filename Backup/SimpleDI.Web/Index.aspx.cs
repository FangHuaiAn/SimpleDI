using System;
using System.Linq;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleDI.Web
{

	public partial class Index : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{
			var managerB = new BusinessManagerB(new AspNetWorker(this));
			managerB.VerifyPassword("a", "asp.net", (msg) => { });

		}

		public void Alert(string title, string message) {
			Response.Write($"title:{title};message:{ message };");
		}
	}


}