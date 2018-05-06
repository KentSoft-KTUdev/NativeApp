using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataContract.Objects;
using DataContract.Data;

namespace DormitoryApp.Services
{
    public class GuestDataStore : IDataStore<Guest>
    {
        List<Guest> Guests;
        GuestRepository guestRepository = new GuestRepository();
        public GuestDataStore()
        {
            Guests = new List<Guest>();
            //var mockGuests = new List<Guest>
            //{
            //    new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "LOL"}, 
            //    new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "Vapau"},
            //    new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "OLOL"},
            //};

            //foreach (var Guest in mockGuests)
            //{
            //    Guests.Add(Guest);
            //}

            
            Guests = guestRepository.GetAll();
        }

        public async Task<bool> AddMemberAsync(Guest Guest)
        {
            Guests.Add(Guest);
            guestRepository.Create(Guest);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Guest Guest)
        {
            var _Guest = Guests.Where((Guest arg) => arg.PersonalCode == Guest.PersonalCode).FirstOrDefault();
            Guests.Remove(_Guest);
            Guests.Add(Guest);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Guest Guest)
        {
            var _Guest = Guests.Where((Guest arg) => arg.PersonalCode == Guest.PersonalCode).FirstOrDefault();
            Guests.Remove(_Guest);
            guestRepository.Delete(Guest);
            return await Task.FromResult(true);
        }

        public async Task<Guest> GetMemberAsync(string PersonalCode)
        {
            return await Task.FromResult(Guests.FirstOrDefault(s => s.PersonalCode == Convert.ToInt32(PersonalCode)));
        }

        public async Task<IEnumerable<Guest>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Guests);
        }
        //List<Guest> Guests;

        //public MockDataStore()
        //{
        //    Guests = new List<Guest>();
        //    var mockGuests = new List<Guest>
        //    {
        //        new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "LOL", ArrivalTime=DateTime.MaxValue },
        //        new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "Vapau", ArrivalTime=DateTime.MinValue },
        //        new Guest { PersonalCode = Guid.NewGuid().ToString(), Name = "OLOL", ArrivalTime=DateTime.Now},
        //    };

        //    foreach (var Guest in mockGuests)
        //    {
        //        Guests.Add(Guest);
        //    }
        //}

        //public async Task<bool> AddGuestAsync(Guest Guest)
        //{
        //    Guests.Add(Guest);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> UpdateGuestAsync(Guest Guest)
        //{
        //    var _Guest = Guests.Where((Guest arg) => arg.PersonalCode == Guest.PersonalCode).FirstOrDefault();
        //    Guests.Remove(_Guest);
        //    Guests.Add(Guest);

        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteGuestAsync(Guest Guest)
        //{
        //    var _Guest = Guests.Where((Guest arg) => arg.PersonalCode == Guest.PersonalCode).FirstOrDefault();
        //    Guests.Remove(_Guest);

        //    return await Task.FromResult(true);
        //}

        //public async Task<Guest> GetGuestAsync(string PersonalCode)
        //{
        //    return await Task.FromResult(Guests.FirstOrDefault(s => s.PersonalCode == PersonalCode));
        //}

        //public async Task<IEnumerable<Guest>> GetGuestsAsync(bool forceRefresh = false)
        //{
        //    return await Task.FromResult(Guests);
        //}
    }
}
