using DormitoryApp.Models;
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
	public partial class NewRoomPage : ContentPage
	{
        public Room room { get; set; }
        public NewRoomPage()
        {
            InitializeComponent();

            room = new Room
            {
                Number = "564654"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddRoom", room);
            await Navigation.PopModalAsync();
        }
    }
}