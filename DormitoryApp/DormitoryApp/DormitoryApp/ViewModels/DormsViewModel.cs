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
        public ObservableCollection<Dormitory> Dorms { get; set; }
        public Command LoadDormsCommand { get; set; }

        public DormsViewModel()
        {
            Title = "Browse";
            Dorms = new ObservableCollection<Dormitory>();
            LoadDormsCommand = new Command(async () => await ExecuteLoadDormsCommand());

            MessagingCenter.Subscribe<NewDormPage, Dormitory>(this, "AddDorm", async (obj, Dormitory) =>
            {
                var _dorm = Dormitory as Dormitory;
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
                foreach (var Dormitory in dorms)
                {
                    Dorms.Add(Dormitory);
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
