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
	public partial class SelectionPage : ContentPage
	{
		public SelectionPage ()
		{
			InitializeComponent ();
		}

        async void Resident_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuestListPage());
        }
        async void Admin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ResidentListPage());
        }
    }
}