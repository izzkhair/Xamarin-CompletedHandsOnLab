using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TiblerZone
{
    public class App : Application
    {
        static TiblerDatabase database;
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new Page2());
        }

        public static TiblerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TiblerDatabase();
                }
                return database;
            }
        }

        public int ResumeAtTodoId { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
