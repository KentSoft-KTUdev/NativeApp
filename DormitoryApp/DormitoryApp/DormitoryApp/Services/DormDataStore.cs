using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DormitoryApp.Models;

namespace DormitoryApp.Services
{
    public class DormDataStore : IDataStore<Dorm>
    {
        List<Dorm> Dorms;

        public DormDataStore()
        {
            Dorms = new List<Dorm>();
            var mockDorms = new List<Dorm>
            {
                new Dorm { Id = Guid.NewGuid().ToString(), Name = "First Dorm"},
                new Dorm { Id = Guid.NewGuid().ToString(), Name = "Second Dorm"},
                new Dorm { Id = Guid.NewGuid().ToString(), Name = "Third Dorm"},
            };

            foreach (var Dorm in mockDorms)
            {
                Dorms.Add(Dorm);
            }
        }

        public async Task<bool> AddMemberAsync(Dorm Dorm)
        {
            Dorms.Add(Dorm);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Dorm Dorm)
        {
            var _Dorm = Dorms.Where((Dorm arg) => arg.Id == Dorm.Id).FirstOrDefault();
            Dorms.Remove(_Dorm);
            Dorms.Add(Dorm);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Dorm Dorm)
        {
            var _Dorm = Dorms.Where((Dorm arg) => arg.Id == Dorm.Id).FirstOrDefault();
            Dorms.Remove(_Dorm);

            return await Task.FromResult(true);
        }

        public async Task<Dorm> GetMemberAsync(string id)
        {
            return await Task.FromResult(Dorms.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Dorm>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Dorms);
        }
    }
}
