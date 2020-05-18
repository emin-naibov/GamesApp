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
    public partial class SearchPage : TabbedPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = new SearchPageViewModel();
        }
    }
}