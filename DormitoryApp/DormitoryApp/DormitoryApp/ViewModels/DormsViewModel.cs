using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DataContract.Objects;
using DormitoryApp.Pages;

namespace DormitoryApp.ViewModels
{
    class DormsViewModel : BaseViewModel
    {
        public ObservableCollection<Dorm> Dorms { get; set; }
        public Command LoadDormsCommand { get; set; }

        public DormsViewModel()
        {
            Title = "Browse";
            Dorms = new ObservableCollection<Dorm>();
            LoadDormsCommand = new Command(async () => await ExecuteLoadDormsCommand());

            MessagingCenter.Subscribe<NewDormPage, Dorm>(this, "AddDorm", async (obj, dorm) =>
            {
                var _dorm = dorm as Dorm;
                Dorms.Add(_dorm);
                await DormDataStore.AddMemberAsync(_dorm);
            });
        }

        async Task ExecuteLoadDormsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Dorms.Clear();
                var dorms = await DormDataStore.GetMembersAsync(true);
                foreach (var dorm in dorms)
                {
                    Dorms.Add(dorm);
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
