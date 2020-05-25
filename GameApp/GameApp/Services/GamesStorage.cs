using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GameApp.Services
{
    public class GamesStorage : IGamesStorage
    {
        private ObservableCollection<Result> TempGames = new ObservableCollection<Result>();
        private bool canAdd;

        public GamesStorage()
        {
            // MyTempGames = new ObservableCollection<Result>();
        }

        public void AddGame(Result result)
        {
            
            if (result.is_liked)
            {
                App.Current.MainPage.DisplayAlert("ok", "yes", "cancel");
            }
            else
            {
                TempGames.Add(result);
                result.is_liked = true;
            }
        }
        public ObservableCollection<Result> GetAllGames()
        {
            return TempGames;
        }

    }
}
