using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DataContract.Objects;
using DormitoryApp.Pages;

namespace DormitoryApp.ViewModels
{
    class VisitsViewModel : BaseViewModel
    {
        public ObservableCollection<Visit> Visits { get; set; }
        public Command LoadVisitsCommand { get; set; }

        public VisitsViewModel()
        {
            Title = "Browse";
            Visits = new ObservableCollection<Visit>();
            LoadVisitsCommand = new Command(async () => await ExecuteLoadVisitsCommand());

            MessagingCenter.Subscribe<NewVisitPage, Visit>(this, "AddVisit", async (obj, dorm) =>
            {
                var _dorm = dorm as Visit;
                Visits.Add(_dorm);
                await VisitDataStore.AddMemberAsync(_dorm);
            });
        }

        public VisitsViewModel(Guest selectedGuest)
        {
            Title = "Browse";
            Visits = new ObservableCollection<Visit>();
            LoadVisitsCommand = new Command(async () => await ExecuteLoadVisitsCommand(selectedGuest));

            MessagingCenter.Subscribe<NewVisitPage, Visit>(this, "AddVisit", async (obj, dorm) =>
            {
                var _dorm = dorm as Visit;
                Visits.Add(_dorm);
                await VisitDataStore.AddMemberAsync(_dorm);
            });
        }

        async Task ExecuteLoadVisitsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Visits.Clear();
                var dorms = await VisitDataStore.GetMembersAsync(true);
                foreach (var dorm in dorms)
                {
                    Visits.Add(dorm);
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

        async Task ExecuteLoadVisitsCommand(Guest selectedGuest)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Visits.Clear();
                var visits = await VisitDataStore.GetMembersAsync(true);
                foreach (var visit in visits)
                {
                    if (visit.GuestId == selectedGuest.PersonalCode)
                    {
                        Visits.Add(visit);
                    }
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
