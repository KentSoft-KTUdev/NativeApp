using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DormitoryApp.Models;

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
                Name = "VOVOVOVO",
                //ArrivalTimeString = "2009-05-08 14:40:52"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGuest", guest);
            await Navigation.PopModalAsync();
        }
    }
}