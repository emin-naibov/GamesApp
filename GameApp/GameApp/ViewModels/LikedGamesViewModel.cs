using GameApp.Models;
using GameApp.Services;
using GameApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace GameApp.ViewModels
{
    class LikedGamesViewModel:ViewModelBase
    {
        IGamesStorage gamesStorage;
        public Command<Result> Getinfo_command { get; set; }
        private ObservableCollection<Result> _myliked_games;


        public ObservableCollection<Result> MyLikedGames
        {
            get { return _myliked_games; }
            set { Set(ref _myliked_games, value);}
        }
        public LikedGamesViewModel()
        {
            gamesStorage = DependencyService.Get<IGamesStorage>();
            if (gamesStorage != null)
            {
                MyLikedGames = new ObservableCollection<Result>(gamesStorage.GetAllGames());
                test();
            }
            Getinfo_command = new Command<Result>(GetInfo);
            //MessagingCenter.Subscribe<SearchPageViewModel, Result>(this, "game_details", async (sender, message) =>
            //{
            //    MyLikedGames.Add(message);
            //    test();
            //});

        }
        public async void test()
        {
            await App.Current.MainPage.DisplayAlert("ok", "wait", "cancel");
        }
        public async void GetInfo(Result result)
        {
            var detailPage = (Application.Current.MainPage as MasterDetailPage).Detail;
            await detailPage.Navigation.PushAsync(new Game_Detail_Page());
            //await Navigation.PushAsync(new GameDetails());

            MessagingCenter.Send(this, "game_details", result);
        }
    }
}
