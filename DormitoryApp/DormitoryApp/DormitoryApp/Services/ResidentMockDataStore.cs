using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DormitoryApp.Models;

namespace DormitoryApp.Services
{
    class ResidentMockDataStore : IDataStore<Resident>
    {
        List<Resident> Residents;

        public ResidentMockDataStore()
        {
            Residents = new List<Resident>();
            var mockResidents = new List<Resident>
            {
                new Resident { Id = Guid.NewGuid().ToString(), Name = "First" },
                new Resident { Id = Guid.NewGuid().ToString(), Name = "Second" },
                new Resident { Id = Guid.NewGuid().ToString(), Name = "Third"},
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
            var _Guest = Residents.Where((Resident arg) => arg.Id == Resident.Id).FirstOrDefault();
            Residents.Remove(_Guest);
            Residents.Add(Resident);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Resident Resident)
        {
            var _Guest = Residents.Where((Resident arg) => arg.Id == Resident.Id).FirstOrDefault();
            Residents.Remove(_Guest);

            return await Task.FromResult(true);
        }

        public async Task<Resident> GetMemberAsync(string id)
        {
            return await Task.FromResult(Residents.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Resident>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Residents);
        }
    }
}
