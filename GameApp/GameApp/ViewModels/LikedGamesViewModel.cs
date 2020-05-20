using GameApp.Models;
using GameApp.Services;
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
        private ObservableCollection<Result> _myliked_games;

        public ObservableCollection<Result> MyLikedGames
        {
            get { return _myliked_games; }
            set { Set(ref _myliked_games, value);}
        }
        public LikedGamesViewModel()
        {
            gamesStorage = DependencyService.Get<IGamesStorage>();
            //if (gamesStorage != null)
            //{
            //    MyLikedGames = new ObservableCollection<Result>(gamesStorage.GetAllGames());
            //    test();
            //}
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
    }
}
