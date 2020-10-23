using System;
using System.Web.UI;

namespace SimpleDI.Web
{
    public class AspNetWorker : IWorker
    {
        private SimpleDI.Web.Index Controller { get; set; }

        public AspNetWorker(SimpleDI.Web.Index page)
        {
            Controller = page;
        }

        public User ReadUserProfileById(string id)
        {
            // read from database, but I just return a mock object here.
            return new User { Id = "A", Name = "from EF" };
        }

        public void ShowAlert(string title, string message, Action<string> action)
        {
            // trigger asp.net alert
            Controller.Alert(title, message);
        }
    }
}
