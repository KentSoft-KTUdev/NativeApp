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
    public partial class NewDormPage : ContentPage
    {
        public Dormitory dorm { get; set; }
        public NewDormPage()
        {
            InitializeComponent();

            dorm = new Dormitory
            {
                Name = "DormName"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddDorm", dorm);
            await Navigation.PopModalAsync();
        }
    }
}