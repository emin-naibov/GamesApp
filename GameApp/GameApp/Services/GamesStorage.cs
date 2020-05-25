using GameApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Essentials;

namespace GameApp.Services
{
    public class GamesStorage: IGamesStorage
    {
        private ObservableCollection<Result> TempGames = new ObservableCollection<Result>();
        private ObservableCollection<Result> TempGames_second = new ObservableCollection<Result>();
        private bool canAdd;
        private const string GamesFile="games.json";
        string filename = Path.Combine(FileSystem.CacheDirectory, GamesFile);

        public GamesStorage()
        {
           // MyTempGames = new ObservableCollection<Result>();
        }

        public void AddGame(Result result)
        {
            canAdd = true;
            foreach (var item in TempGames)
            {
                if (item.id == result.id)
                {
                    canAdd = false;
                    App.Current.MainPage.DisplayAlert("ok", "yes", "cancel");
                }
            }
            if (canAdd)
            {
                TempGames.Add(result);
                var jsonToWrite = JsonConvert.SerializeObject(TempGames);
                File.WriteAllText(filename, jsonToWrite);
            }
        }
        public ObservableCollection<Result> GetAllGames()
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                
                TempGames = JsonConvert.DeserializeObject<ObservableCollection<Result>>(json);
                return TempGames;
            }
            else
                return TempGames_second;
        }
        public void ClearCache()
        {
            if (File.Exists(filename))
            {
                var jsonToWrite = JsonConvert.SerializeObject(TempGames_second);
                File.WriteAllText(filename, jsonToWrite);
            }
            else App.Current.MainPage.DisplayAlert("ok", "yes", "cancel");
        }

    }
}
