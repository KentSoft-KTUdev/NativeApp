using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DataContract;
using DormitoryApp.Objects;

namespace DormitoryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        private DataContract.Data.GuardRepository GuardRepository = new DataContract.Data.GuardRepository();
        private DataContract.Data.ResidentRepository ResidentRepository = new DataContract.Data.ResidentRepository();
        private DataContract.Data.AdministratorRepository AdministratorRepository = new DataContract.Data.AdministratorRepository();
        public User user { get; set; }
		public LoginPage ()
		{
			InitializeComponent ();
            user = new User
            {
                username = "",
                password = ""
            };

            BindingContext = this;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Login_Clicked(object sender, EventArgs e)
        {
            
            if (user.username != "" & user.password != "")
            {
                //MessagingCenter.Send(this, "AddGuest", guest);
                //await Navigation.PopModalAsync();
                if (AdministratorRepository.Login(user.username, DataContract.Configuration.Encryption(user.password)).IsSuccessStatusCode)
                {
                    user.PersonalCode = AdministratorRepository.ReadByUsername(user.username).PersonalCode;
                    user.status = "Admin";
                    await Navigation.PushAsync(new AdminPage());
                }
                else if (GuardRepository.Login(user.username, DataContract.Configuration.Encryption(user.password)).IsSuccessStatusCode)
                {
                    user.PersonalCode = GuardRepository.ReadByUsername(user.username).PersonalCode;
                    user.status = "Guard";
                    await Navigation.PushAsync(new GuardPage());
                }
                else if (ResidentRepository.Login(user.username, DataContract.Configuration.Encryption(user.password)).IsSuccessStatusCode)
                {
                    user.PersonalCode = ResidentRepository.ReadByUsername(user.username).PersonalCode;
                    user.status = "Resident";
                    await Navigation.PushAsync(new GuestListPage());
                }
            }
            Objects.GlobalUser.globalUser = user;
        }

        //void Username_Completed(object sender, EventArgs e)
        //{
        //    user.username = ((Entry)sender).Text; //cast sender to access the properties of the Entry
        //}

        //void Password_Completed(object sender, EventArgs e)
        //{
        //    user.password = ((Entry)sender).Text; //cast sender to access the properties of the Entry
        //}
    }
}