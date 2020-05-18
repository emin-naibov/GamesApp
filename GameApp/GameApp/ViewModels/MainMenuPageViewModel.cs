using GameApp.Models;
using GameApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameApp.ViewModels
{
    class MainMenuPageViewModel:ViewModelBase
    {
		private ObservableCollection<MainMenuItem> _menuItems;

		public ObservableCollection<MainMenuItem> MenuItems
		{
			get => _menuItems;
			set => Set(ref _menuItems, value);
		}

		public MainMenuPageViewModel()
		{
			MenuItems = new ObservableCollection<MainMenuItem>
			{
				new MainMenuItem{PageType=typeof(SearchPage),Title="SearchPage"},
				new MainMenuItem{PageType=typeof(LikedGamesPage),Title="LikedGames"},
				new MainMenuItem{PageType=typeof(Settings),Title="Settings"}
			};
		}
	}
}
