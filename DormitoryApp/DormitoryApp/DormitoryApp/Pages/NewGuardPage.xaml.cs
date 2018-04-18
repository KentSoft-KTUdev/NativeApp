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
	public partial class NewGuardPage : ContentPage
	{
        public Guard guard { get; set; }
        public NewGuardPage()
        {
            InitializeComponent();

            guard = new Guard
            {
                Name = "VP"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGuard", guard);
            await Navigation.PopModalAsync();
        }
    }
}