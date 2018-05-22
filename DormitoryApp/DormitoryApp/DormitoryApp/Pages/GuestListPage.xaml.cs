using DormitoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DataContract.Objects;
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

        //async void OnGuestSelected(object sender, SelectedItemChangedEventArgs args)
        //{
        //    var Guest = args.SelectedItem as Guest;
        //    if (Guest == null)
        //        return;

        //    await Navigation.PushAsync(new GuestDetailPage(new GuestDetailViewModel(Guest)));

        //    // Manually deselect Guest.
        //    GuestsListView.SelectedGuest = null;
        //}

        async void OnGuestSelected(object sender, SelectedItemChangedEventArgs args)
        {

            if (((ListView)sender).SelectedItem != null)
            {
                var Guest = args.SelectedItem as Guest;
                if (Guest == null)
                    return;

                
                await Navigation.PushModalAsync(new NavigationPage(new VisitListPage(Guest)));
                ((ListView)sender).SelectedItem = null;
            }

        }

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

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        void OnEdit(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            var guest = item.CommandParameter;
            Guest _guest = guest as Guest;
            MessagingCenter.Send(this, "DeleteGuest", _guest);
        }
    }
}