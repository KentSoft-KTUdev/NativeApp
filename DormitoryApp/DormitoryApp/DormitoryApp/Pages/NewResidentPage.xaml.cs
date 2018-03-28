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
	public partial class NewResidentPage : ContentPage
	{
        public Resident resident { get; set; }
		public NewResidentPage ()
		{
			InitializeComponent ();

            resident = new Resident
            {
                Name = "VP",
            };

            BindingContext = this;
        }
        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddResident", resident);
            await Navigation.PopModalAsync();
        }
    }
}