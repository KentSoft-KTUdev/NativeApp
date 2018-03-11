using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DormitoryApp.Models;
using DormitoryApp.Pages;


namespace DormitoryApp.ViewModels
{
    class GuestsViewModel : BaseViewModel
    {
        public ObservableCollection<Guest> Guests { get; set; }
        public Command LoadGuestsCommand { get; set; }

        public GuestsViewModel()
        {
            Title = "Browse";
            Guests = new ObservableCollection<Guest>();
            LoadGuestsCommand = new Command(async () => await ExecuteLoadGuestsCommand());

            //MessagingCenter.Subscribe<NewGuestPage, Guest>(this, "AddGuest", async (obj, guest) =>
            //{
            //    var _guest = guest as Guest;
            //    Guests.Add(_guest);
            //    await DataStore.AddGuestAsync(_guest);
            //});
        }

        async Task ExecuteLoadGuestsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Guests.Clear();
                var guests = await DataStore.GetGuestsAsync(true);
                foreach (var guest in guests)
                {
                    Guests.Add(guest);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
