using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataContract.Objects;

namespace DormitoryApp.Services
{
    class ResidentDataStore : IDataStore<Resident>
    {
        List<Resident> Residents;

        public ResidentDataStore()
        {
            Residents = new List<Resident>();
            var mockResidents = new List<Resident>
            {
                new Resident { PersonalCode = Guid.NewGuid().ToString(), Name = "First" },
                new Resident { PersonalCode = Guid.NewGuid().ToString(), Name = "Second" },
                new Resident { PersonalCode = Guid.NewGuid().ToString(), Name = "Third"},
            };

            foreach (var Resident in mockResidents)
            {
                Residents.Add(Resident);
            }
        }

        public async Task<bool> AddMemberAsync(Resident Resident)
        {
            Residents.Add(Resident);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Resident Resident)
        {
            var _Guest = Residents.Where((Resident arg) => arg.PersonalCode == Resident.PersonalCode).FirstOrDefault();
            Residents.Remove(_Guest);
            Residents.Add(Resident);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Resident Resident)
        {
            var _Guest = Residents.Where((Resident arg) => arg.PersonalCode == Resident.PersonalCode).FirstOrDefault();
            Residents.Remove(_Guest);

            return await Task.FromResult(true);
        }

        public async Task<Resident> GetMemberAsync(string PersonalCode)
        {
            return await Task.FromResult(Residents.FirstOrDefault(s => s.PersonalCode == PersonalCode));
        }

        public async Task<IEnumerable<Resident>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Residents);
        }
    }
}
