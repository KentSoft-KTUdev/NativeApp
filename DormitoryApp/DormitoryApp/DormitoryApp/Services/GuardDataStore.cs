using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataContract.Objects;
using DataContract.Data;

namespace DormitoryApp.Services
{
    public class GuardDataStore : IDataStore<Guard>
    {
        List<Guard> Guards;

        public GuardDataStore()
        {
            Guards = new List<Guard>();
            //var mockGuards = new List<Guard>
            //{
            //    new Guard { PersonalCode = Guid.NewGuid().ToString(), Name = "FirstG"},
            //    new Guard { PersonalCode = Guid.NewGuid().ToString(), Name = "SecondG"},
            //    new Guard { PersonalCode = Guid.NewGuid().ToString(), Name = "ThirdG"},
            //};

            //foreach (var Guard in mockGuards)
            //{
            //    Guards.Add(Guard);
            //}
            GuardRepository guardRepository = new GuardRepository();
            Guards = guardRepository.GetAll();
        }

        public async Task<bool> AddMemberAsync(Guard Guard)
        {
            Guards.Add(Guard);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Guard Guard)
        {
            var _Guard = Guards.Where((Guard arg) => arg.PersonalCode == Guard.PersonalCode).FirstOrDefault();
            Guards.Remove(_Guard);
            Guards.Add(Guard);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Guard Guard)
        {
            var _Guard = Guards.Where((Guard arg) => arg.PersonalCode == Guard.PersonalCode).FirstOrDefault();
            Guards.Remove(_Guard);

            return await Task.FromResult(true);
        }

        public async Task<Guard> GetMemberAsync(string PersonalCode)
        {
            return await Task.FromResult(Guards.FirstOrDefault(s => s.PersonalCode == Convert.ToInt32(PersonalCode)));
        }

        public async Task<IEnumerable<Guard>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Guards);
        }
    }
}
