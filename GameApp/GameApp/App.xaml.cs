using GameApp.Services;
using GameApp.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IGamesApiClient, GamesApiClient>();
            DependencyService.Register<IGamesStorage, GamesStorage>();
           // DependencyService.Register<LikedGamesViewModel>();
            MainPage = new MainPage();
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
