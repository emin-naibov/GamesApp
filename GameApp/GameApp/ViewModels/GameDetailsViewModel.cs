using GameApp.Models;
using GameApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GameApp.ViewModels
{
   internal class GameDetailsViewModel:ViewModelBase
    {
        IGamesApiClient gamesApiClient;
        private Rootobject _my_game;

        public Rootobject MyGame
        {
            get { return _my_game; }
            set { Set(ref _my_game, value); }
        }
        public int SearchID { get; set; }

        public GameDetailsViewModel()
        {
            gamesApiClient = DependencyService.Get<IGamesApiClient>();
            MessagingCenter.Subscribe<SearchPageViewModel,Result>(this,"game_details",(sender, message) =>
            {
                SearchID = message.id;
            Get();
           // Get1();
            });

        }
        public async void Get()
        {
           MyGame = await gamesApiClient.getInfo(SearchID);
        }
        public async void Get1()
        {
            await App.Current.MainPage.DisplayAlert(SearchID.ToString(), "ok", "cancel");
        }
    }
}
