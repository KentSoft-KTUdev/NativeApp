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
    public partial class NewVisitPage : ContentPage
    {
        public Visit visit { get; set; }
        public NewVisitPage()
        {
            InitializeComponent();

            visit = new Visit
            {
                ArrivalTime = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            visit.ArrivalTime += VisitTimePicker.Time;
            MessagingCenter.Send(this, "AddVisit", visit);
            await Navigation.PopModalAsync();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            visit.ArrivalTime = e.NewDate;
        }
    }
}