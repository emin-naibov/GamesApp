using GameApp.Models;
using GameApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GameApp.ViewModels
{
    class SettingsViewModel:ViewModelBase
    {
        IGamesStorage gamesStorage;
        public Command Clearcache_command { get; set; }
        public SettingsViewModel()
        {
            gamesStorage = DependencyService.Get<IGamesStorage>();
            Clearcache_command = new Command(Clear);
        }
        public void Clear()
        {
            gamesStorage.ClearCache();
        }
    }
}
