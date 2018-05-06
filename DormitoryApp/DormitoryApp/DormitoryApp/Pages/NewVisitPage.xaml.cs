using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DataContract.Objects;

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
                VisitRegDateTime = DateTime.MinValue
            };

            BindingContext = this;
        }

        public NewVisitPage(Guest selectedGuest)
        {
            InitializeComponent();

            visit = new Visit
            {
                VisitRegDateTime = DateTime.MinValue,
                GuestId = selectedGuest.PersonalCode,
                IsOver = false,
                VisitEndDateTime = DateTime.MaxValue,
                ResidentId = 123,
                GuardId = 123,
                DormitoryId = 1
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            if (visit.VisitRegDateTime != DateTime.MinValue)
            {
                visit.VisitRegDateTime += VisitTimePicker.Time;
                MessagingCenter.Send(this, "AddVisit", visit);

                visit = new Visit
                {
                    VisitRegDateTime = DateTime.MinValue
                };

                await Navigation.PopModalAsync();
            }
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            visit.VisitRegDateTime = e.NewDate;
        }
    }
}