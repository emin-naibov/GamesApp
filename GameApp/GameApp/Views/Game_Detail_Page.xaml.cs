using GameApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GameApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game_Detail_Page : ContentPage
    {
        public Game_Detail_Page()
        {
            InitializeComponent();
            BindingContext = new GameDetailsViewModel();
        }
    }
}