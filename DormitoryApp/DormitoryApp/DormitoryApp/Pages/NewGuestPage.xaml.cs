using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DataContract.Objects;

namespace DormitoryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGuestPage : ContentPage
    {
        public Guest guest { get; set; }
        public NewGuestPage()
        {
            InitializeComponent();

            guest = new Guest
            {
                Name = "",
                Surname = "",
                PersonalCode = Guid.NewGuid().GetHashCode()
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (guest.Name != "" && guest.Surname != "")
            {
                //guest.ArrivalTime += GuestTimePicker.Time;

                MessagingCenter.Send(this, "AddGuest", guest);

                guest = new Guest
                {
                    Name = "",
                    Surname = "",
                    PersonalCode = Guid.NewGuid().GetHashCode()
                };

                await Navigation.PopModalAsync();
            }
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            
            //guest.ArrivalTime = e.NewDate;
        }
    }
}