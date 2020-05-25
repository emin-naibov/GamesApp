using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GameApp.Services
{
    public interface IGamesStorage
    {
        void AddGame(Result result);
        ObservableCollection<Result> GetAllGames();
        void ClearCache();
    }
}
