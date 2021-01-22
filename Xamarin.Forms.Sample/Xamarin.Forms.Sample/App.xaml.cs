using System;
using Xamarin.Forms;
using Xamarin.Forms.Sample.UI.Pages;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new PropertiesValidationPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
