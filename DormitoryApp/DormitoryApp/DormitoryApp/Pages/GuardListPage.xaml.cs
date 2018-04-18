using DormitoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DormitoryApp.Models;
using DormitoryApp.Pages;

namespace DormitoryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GuardListPage : ContentPage
	{
        GuardsViewModel viewModel;

        public GuardListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new GuardsViewModel();
        }

        //async void OnGuardSelected(object sender, SelectedGuardChangedEventArgs args)
        //{
        //    var Guard = args.SelectedGuard as Guard;
        //    if (Guard == null)
        //        return;

        //    await Navigation.PushAsync(new GuardDetailPage(new GuardDetailViewModel(Guard)));

        //    // Manually deselect Guard.
        //    GuardsListView.SelectedGuard = null;
        //}

        async void AddGuard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGuardPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Guards.Count == 0)
                viewModel.LoadGuardsCommand.Execute(null);
        }
    }
}