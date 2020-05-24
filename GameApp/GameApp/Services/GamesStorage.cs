using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GameApp.Services
{
    public class GamesStorage: IGamesStorage
    {
        private List<Result> TempGames = new List<Result>();

        public GamesStorage()
        {
           // MyTempGames = new ObservableCollection<Result>();
        }

        public void AddGame(Result result)
        {
            TempGames.Add(result);
        }
        public List<Result> GetAllGames()
        {
            TempGames = TempGames.Distinct().ToList();
            return TempGames;
        }

    }
}
