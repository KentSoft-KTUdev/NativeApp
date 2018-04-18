using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DormitoryApp.Models;

namespace DormitoryApp.Services
{
    public class VisitDataStore : IDataStore<Visit>
    {
        List<Visit> Visits;

        public VisitDataStore()
        {
            Visits = new List<Visit>();
            var mockVisits = new List<Visit>
            {
                new Visit { Id = "Done", ArrivalTime=DateTime.MaxValue, Visited = true},
                new Visit { Id = "Not done", ArrivalTime=DateTime.MaxValue, Visited = false},
                new Visit { Id = Guid.NewGuid().ToString(), ArrivalTime=DateTime.MaxValue, Visited = false},
            };

            foreach (var Visit in mockVisits)
            {
                Visits.Add(Visit);
            }
        }

        public async Task<bool> AddMemberAsync(Visit Visit)
        {
            Visits.Add(Visit);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Visit Visit)
        {
            var _Visit = Visits.Where((Visit arg) => arg.Id == Visit.Id).FirstOrDefault();
            Visits.Remove(_Visit);
            Visits.Add(Visit);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Visit Visit)
        {
            var _Visit = Visits.Where((Visit arg) => arg.Id == Visit.Id).FirstOrDefault();
            Visits.Remove(_Visit);

            return await Task.FromResult(true);
        }

        public async Task<Visit> GetMemberAsync(string id)
        {
            return await Task.FromResult(Visits.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Visit>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Visits);
        }
    }
}
