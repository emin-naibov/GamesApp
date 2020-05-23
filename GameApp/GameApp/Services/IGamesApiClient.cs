using GameApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace GameApp.Services
{
    internal interface IGamesApiClient
    {
        Task<ObservableCollection<Result>>GetGames();
        Task<Rootobject> getInfo(int id);
    }
}
