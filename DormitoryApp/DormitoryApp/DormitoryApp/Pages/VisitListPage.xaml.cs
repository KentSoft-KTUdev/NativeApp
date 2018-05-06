using DormitoryApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DataContract.Objects;
using DormitoryApp.Pages;

namespace DormitoryApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisitListPage : ContentPage
    {
        VisitsViewModel viewModel;
        Guest selectedGuest;

        public VisitListPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new VisitsViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public VisitListPage(Guest selectedGuest)
        {
            InitializeComponent();
            this.selectedGuest = selectedGuest;
            BindingContext = viewModel = new VisitsViewModel(selectedGuest);
        }

        //async void OnVisitSelected(object sender, SelectedVisitChangedEventArgs args)
        //{
        //    var Visit = args.SelectedVisit as Visit;
        //    if (Visit == null)
        //        return;

        //    await Navigation.PushAsync(new VisitDetailPage(new VisitDetailViewModel(Visit)));

        //    // Manually deselect Visit.
        //    VisitsListView.SelectedVisit = null;
        //}

        async void AddVisit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewVisitPage(selectedGuest)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Visits.Count == 0)
                viewModel.LoadVisitsCommand.Execute(null);
        }
    }
}