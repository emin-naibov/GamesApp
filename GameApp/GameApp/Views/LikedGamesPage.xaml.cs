using GameApp.Models;
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
    public partial class LikedGamesPage : ContentPage
    {
        public LikedGamesPage()
        {
            InitializeComponent();
            //BindingContext = DependencyService.Get<LikedGamesViewModel>();
            BindingContext = new LikedGamesViewModel();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BindingContext is LikedGamesViewModel likedGamesViewModel && sender is Result result)
            {
                likedGamesViewModel.Getinfo_command.Execute(sender);
            }
        }
    }
}
