﻿using GameApp.Models;
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
		IGamesStorage gamesStorage;
		public Command Add_to_liked_command { get; set; }
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
			Add_to_liked_command = new Command(Add_to_Liked);
		}
		public async void Add_to_Liked()
		{
			//await App.Current.MainPage.DisplayAlert("ok","yes","cancel");
			//gamesStorage.AddGame(SelectedGame);
			MessagingCenter.Send(this, "game_details", SelectedGame);
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
