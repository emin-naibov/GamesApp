using GameApp.Models;
using GameApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GameApp.ViewModels
{
   class GameDetailsViewModel:ViewModelBase
    {
        IGamesApiClient gamesApiClient;
        IGamesStorage gamesStorage;
        private Rootobject _my_game;
        private Result _my_message;

        public Command Add_to_liked_command { get; set; }
        public Command Share_command { get; set; }
        public Command Buy_command { get; set; }

        public Rootobject MyGame
        {
            get { return _my_game; }
            set { Set(ref _my_game, value); }
        }
        public Result Message
        {
            get { return _my_message; }
            set { Set(ref _my_message, value); }
        }
        public int SearchID { get; set; }

        public GameDetailsViewModel()
        {
            gamesStorage = DependencyService.Get<IGamesStorage>();
            Add_to_liked_command = new Command(AddMethod);
            gamesApiClient = DependencyService.Get<IGamesApiClient>();
            MessagingCenter.Subscribe<SearchPageViewModel,Result>(this,"game_details",(sender, message) =>
            {
                SearchID = message.id;
                Message = message;
            Get();
            });
            MessagingCenter.Subscribe<LikedGamesViewModel, Result>(this, "game_details", (sender, message) =>
            {
                SearchID = message.id;
                Message = message;
                Get();
            });

            Share_command = new Command(ShareGame);
            Buy_command = new Command(Buy);

        }
        public void AddMethod()
        {
            gamesStorage.AddGame(Message);
        }
        public async void Get()
        {
            MyGame = await gamesApiClient.getInfo(SearchID);
        }
        public async void Buy()
        {
                await Browser.OpenAsync(new Uri(MyGame.stor[0].url), BrowserLaunchMode.SystemPreferred);
        }
        private void ShareGame()
        {
            Share.RequestAsync(new ShareTextRequest
            {
                Text = MyGame.name,
                Title = "Name of game"
            }); ;
        }
        
    }
}
