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
	public partial class GuestListPage : ContentPage
	{
        GuestsViewModel viewModel;

        public GuestListPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new GuestsViewModel();
        }

        //async void OnGuestSelected(object sender, SelectedGuestChangedEventArgs args)
        //{
        //    var Guest = args.SelectedGuest as Guest;
        //    if (Guest == null)
        //        return;

        //    await Navigation.PushAsync(new GuestDetailPage(new GuestDetailViewModel(Guest)));

        //    // Manually deselect Guest.
        //    GuestsListView.SelectedGuest = null;
        //}

        async void AddGuest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGuestPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Guests.Count == 0)
                viewModel.LoadGuestsCommand.Execute(null);
        }
    }
}