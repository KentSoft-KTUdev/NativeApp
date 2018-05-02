using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract.Objects;
using DataContract.Data;

namespace DormitoryApp.Services
{
    public class VisitDataStore : IDataStore<Visit>
    {
        List<Visit> Visits;

        public VisitDataStore()
        {
            Visits = new List<Visit>();
            //var mockVisits = new List<Visit>
            //{
            //    new Visit { ID = "Done", VisitRegDateTime=DateTime.MaxValue, IsOver = true},
            //    new Visit { ID = "Not done", VisitRegDateTime=DateTime.MaxValue, IsOver = false},
            //    new Visit { ID = Guid.NewGuid().ToString(), VisitRegDateTime=DateTime.MaxValue, IsOver = false},
            //};

            //foreach (var Visit in mockVisits)
            //{
            //    Visits.Add(Visit);
            //}
            VisitRepository visitRepository = new VisitRepository();
            Visits = visitRepository.GetAll();
        }

        public async Task<bool> AddMemberAsync(Visit Visit)
        {
            Visits.Add(Visit);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Visit Visit)
        {
            var _Visit = Visits.Where((Visit arg) => arg.ID == Visit.ID).FirstOrDefault();
            Visits.Remove(_Visit);
            Visits.Add(Visit);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Visit Visit)
        {
            var _Visit = Visits.Where((Visit arg) => arg.ID == Visit.ID).FirstOrDefault();
            Visits.Remove(_Visit);

            return await Task.FromResult(true);
        }

        public async Task<Visit> GetMemberAsync(string id)
        {
            return await Task.FromResult(Visits.FirstOrDefault(s => s.ID == Convert.ToInt32(id)));
        }

        public async Task<IEnumerable<Visit>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Visits);
        }
    }
}
