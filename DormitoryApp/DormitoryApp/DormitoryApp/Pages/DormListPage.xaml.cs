using DormitoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DormitoryApp.Models;
using DormitoryApp.Pages;

namespace DormitoryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DormListPage : ContentPage
    {
        DormsViewModel viewModel;

        public DormListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DormsViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //async void OnDormSelected(object sender, SelectedDormChangedEventArgs args)
        //{
        //    var Dorm = args.SelectedDorm as Dorm;
        //    if (Dorm == null)
        //        return;

        //    await Navigation.PushAsync(new DormDetailPage(new DormDetailViewModel(Dorm)));

        //    // Manually deselect Dorm.
        //    DormsListView.SelectedDorm = null;
        //}

        async void OnDormSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (((ListView)sender).SelectedItem != null)
            {
                ((ListView)sender).SelectedItem = null;
                await Navigation.PushModalAsync(new NavigationPage(new RoomListPage()));
            }
        }

        async void AddDorm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewDormPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Dorms.Count == 0)
                viewModel.LoadDormsCommand.Execute(null);
        }
    }
}