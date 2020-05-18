using GameApp.Models;
using GameApp.Services;
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
		private ObservableCollection<Result> _mygame;

		public ObservableCollection<Result> Mygame
		{
			get { return _mygame; }
			set { Set(ref _mygame, value); }
		}
		public SearchPageViewModel()
		{
			gamesApiClient = DependencyService.Get<IGamesApiClient>();
			Mygame = new ObservableCollection<Result>();
			Load();
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
