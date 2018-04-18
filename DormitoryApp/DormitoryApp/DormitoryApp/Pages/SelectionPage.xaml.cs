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
        async void Guard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RoomListPage());
        }
        async void Guest_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GuardListPage());
        }
        async void Test1_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DormListPage());
        }
        async void Test2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VisitListPage());
        }
    }
}