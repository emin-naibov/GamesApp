using GameApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            MasterPage.MenuListView.ItemSelected += MenuListView_ItemSelected;
        }

        private void MenuListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           if(e.SelectedItem is MainMenuItem mainMenuItem)
            {
                var page = Activator.CreateInstance(mainMenuItem.PageType) as Page;
                Detail = new NavigationPage(page);
                IsPresented = false;
                MasterPage.MenuListView.SelectedItem = null;

            }
        }
    }
}
