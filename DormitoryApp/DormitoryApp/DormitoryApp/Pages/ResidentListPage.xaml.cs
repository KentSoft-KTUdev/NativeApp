using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DormitoryApp.ViewModels;

namespace DormitoryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResidentListPage : ContentPage
	{
        ResidentsViewModel viewModel;
		public ResidentListPage ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new ResidentsViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void AddResident_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewResidentPage()));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Residents.Count == 0)
                viewModel.LoadResidentsCommand.Execute(null);
        }
    }
}