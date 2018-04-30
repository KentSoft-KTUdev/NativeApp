using DataContract.Objects;
using DormitoryApp.Pages;
using DormitoryApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DormitoryApp.ViewModels
{
    class RoomsViewModel : BaseViewModel
    {
        public ObservableCollection<Room> Rooms { get; set; }
        public Command LoadRoomsCommand { get; set; }

        public RoomsViewModel()
        {
            Title = "Browse";
            Rooms = new ObservableCollection<Room>();
            LoadRoomsCommand = new Command(async () => await ExecuteLoadRoomsCommand());

            MessagingCenter.Subscribe<NewRoomPage, Room>(this, "AddRoom", async (obj, room) =>
            {
                var _room = room as Room;
                Rooms.Add(_room);
                await RoomDataStore.AddMemberAsync(_room);
            });
        }

        async Task ExecuteLoadRoomsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Rooms.Clear();
                var rooms = await RoomDataStore.GetMembersAsync(true);
                foreach (var room in rooms)
                {
                    Rooms.Add(room);
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
