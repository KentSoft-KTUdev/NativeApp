using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DormitoryApp.Models;
using DormitoryApp.Pages;

namespace DormitoryApp.ViewModels
{
    class GuardsViewModel : BaseViewModel
    {
        public ObservableCollection<Guard> Guards { get; set; }
        public Command LoadGuardsCommand { get; set; }

        public GuardsViewModel()
        {
            Title = "Browse";
            Guards = new ObservableCollection<Guard>();
            LoadGuardsCommand = new Command(async () => await ExecuteLoadGuardsCommand());

            MessagingCenter.Subscribe<NewGuardPage, Guard>(this, "AddGuard", async (obj, guest) =>
            {
                var _guest = guest as Guard;
                Guards.Add(_guest);
                await GuardDataStore.AddMemberAsync(_guest);
            });
        }

        async Task ExecuteLoadGuardsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Guards.Clear();
                var guests = await GuardDataStore.GetMembersAsync(true);
                foreach (var guest in guests)
                {
                    Guards.Add(guest);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
