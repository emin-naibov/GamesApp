using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameApp.Services
{
    public class GamesStorage: IGamesStorage
    {
        private ObservableCollection<Result> TempGames = new ObservableCollection<Result>();

        public GamesStorage()
        {
           // MyTempGames = new ObservableCollection<Result>();
        }

        public void AddGame(Result result)
        {
            TempGames.Add(result);
        }
        public ObservableCollection<Result> GetAllGames()
        {
            return TempGames;
        }

    }
}
