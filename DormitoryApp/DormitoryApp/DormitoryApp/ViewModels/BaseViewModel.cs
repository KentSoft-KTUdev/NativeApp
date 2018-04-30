using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using DormitoryApp.Services;

using DataContract.Objects;


namespace DormitoryApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Guest> GuestDataStore => DependencyService.Get<IDataStore<Guest>>() ?? new GuestDataStore();
        public IDataStore<Resident> ResidentDataStore => DependencyService.Get<IDataStore<Resident>>() ?? new ResidentDataStore();
        public IDataStore<Room> RoomDataStore => DependencyService.Get<IDataStore<Room>>() ?? new RoomDataStore();
        public IDataStore<Guard> GuardDataStore => DependencyService.Get<IDataStore<Guard>>() ?? new GuardDataStore();
        public IDataStore<Dorm> DormDataStore => DependencyService.Get<IDataStore<Dorm>>() ?? new DormDataStore();
        public IDataStore<Visit> VisitDataStore => DependencyService.Get<IDataStore<Visit>>() ?? new VisitDataStore();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
