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
        VisitRepository visitRepository = new VisitRepository();
        public GuestDataStore()
        {
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

            List<Visit> visitsToDelete = visitRepository.GetAll().Where((Visit visit) => visit.GuestId == _Guest.PersonalCode).ToList();
            foreach (var visit in visitsToDelete)
            {
                visitRepository.Delete(visit.ID);
            }

            Guests.Remove(_Guest);
            guestRepository.Delete(_Guest.PersonalCode);
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
    }
}
