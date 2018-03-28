using DormitoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DormitoryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RoomListPage : ContentPage
	{
        RoomsViewModel viewModel;
        public RoomListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new RoomsViewModel();
        }
        async void AddRoom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewRoomPage()));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Rooms.Count == 0)
                viewModel.LoadRoomsCommand.Execute(null);
        }
    }
}