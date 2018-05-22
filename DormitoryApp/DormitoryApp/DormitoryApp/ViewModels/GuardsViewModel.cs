using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DataContract.Objects;
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

            MessagingCenter.Subscribe<NewGuardPage, Guard>(this, "AddGuard", async (obj, guard) =>
            {
                var _guard = guard as Guard;
                Guards.Add(_guard);
                await GuardDataStore.AddMemberAsync(_guard);
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
                var guards = await GuardDataStore.GetMembersAsync(true);
                foreach (var guard in guards)
                {
                    Guards.Add(guard);
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
