using SpooneritisMobile.Services;
using SpooneritisMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SpooneritisMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var settingsProvider = new SettingsProvider();
            var baseApiAccessor = new BaseApiAccessor();

            MainPage = new NavigationPage(new HomePage(settingsProvider, baseApiAccessor));
        }

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
