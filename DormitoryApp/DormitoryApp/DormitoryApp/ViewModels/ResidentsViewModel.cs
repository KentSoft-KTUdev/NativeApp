using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DormitoryApp.Models;
using DormitoryApp.Pages;

namespace DormitoryApp.ViewModels
{
    class ResidentsViewModel : BaseViewModel
    {
        public ObservableCollection<Resident> Residents { get; set; }
        public Command LoadResidentsCommand { get; set; }
        public ResidentsViewModel()
        {
            Title = "Browse";
            Residents = new ObservableCollection<Resident>();
            LoadResidentsCommand = new Command(async () => await ExecuteLoadResidentsCommand());

            MessagingCenter.Subscribe<NewResidentPage, Resident>(this, "AddResident", async (obj, resident) =>
            {
                var _resident = resident as Resident;
                Residents.Add(_resident);
                await ResidentDataStore.AddMemberAsync(_resident);
            });
        }
        async Task ExecuteLoadResidentsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Residents.Clear();
                var residents = await ResidentDataStore.GetMembersAsync(true);
                foreach (var resident in residents)
                {
                    Residents.Add(resident);
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
