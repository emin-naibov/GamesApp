using GameApp.Models;
using GameApp.Services;
using GameApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GameApp.ViewModels
{
    class SearchPageViewModel:ViewModelBase
    {
		IGamesApiClient gamesApiClient;
		IGamesStorage gamesStorage;
		public Command<Result> Add_to_liked_command { get; set; }
		public Command<Result> Getinfo_command { get; set; }
		private ObservableCollection<Result> _mygame;

		public ObservableCollection<Result> Mygame
		{
			get { return _mygame; }
			set { Set(ref _mygame, value); }
		}


		private Result _selectedGame;
		public Result SelectedGame
		{
			get => _selectedGame;
			set
			{
				Set(ref _selectedGame, value);
				Add_to_liked_command.ChangeCanExecute();
			}
		}

		public SearchPageViewModel()
		{
			gamesApiClient = DependencyService.Get<IGamesApiClient>();
			gamesStorage = DependencyService.Get<IGamesStorage>();
			Mygame = new ObservableCollection<Result>();
			Load();
			Add_to_liked_command = new Command<Result>(Add_to_Liked);
			Getinfo_command = new Command<Result>(GameDetails);
		}
		public async void Add_to_Liked(Result result)
		{
			//await App.Current.MainPage.DisplayAlert("ok","yes","cancel");
			gamesStorage.AddGame(result);
			//MessagingCenter.Send(this, "game_details", SelectedGame);
		}
		private async void GameDetails(Result result)
		{
			var detailPage = (Application.Current.MainPage as MasterDetailPage).Detail;
			await detailPage.Navigation.PushAsync(new Game_Detail_Page());
			//await Navigation.PushAsync(new GameDetails());

			MessagingCenter.Send(this, "game_details", result);
		}
		private async void Load()
		{
			if (Connectivity.NetworkAccess == NetworkAccess.Internet)
			{
				try
				{
					var games = await gamesApiClient.GetGames();
					Mygame = games;


				}
				catch (Exception)
				{
				}
			}
			else
				await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection.", "Close");
		}
	}
}
