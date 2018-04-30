using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataContract.Objects;

namespace DormitoryApp.Services
{
    public class DormDataStore : IDataStore<Dormitory>
    {
        List<Dormitory> Dormitorys;

        public DormDataStore()
        {
            Dormitorys = new List<Dormitory>();
            var mockDormitorys = new List<Dormitory>
            {
                new Dormitory { ID = 1, Name = "First Dormitory"},
                new Dormitory { ID = 2, Name = "Second Dormitory"},
                new Dormitory { ID = 3, Name = "Third Dormitory"},
            };

            foreach (var Dormitory in mockDormitorys)
            {
                Dormitorys.Add(Dormitory);
            }
        }

        public async Task<bool> AddMemberAsync(Dormitory Dormitory)
        {
            Dormitorys.Add(Dormitory);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateMemberAsync(Dormitory Dormitory)
        {
            var _Dormitory = Dormitorys.Where((Dormitory arg) => arg.ID == Dormitory.ID).FirstOrDefault();
            Dormitorys.Remove(_Dormitory);
            Dormitorys.Add(Dormitory);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMemberAsync(Dormitory Dormitory)
        {
            var _Dormitory = Dormitorys.Where((Dormitory arg) => arg.ID == Dormitory.ID).FirstOrDefault();
            Dormitorys.Remove(_Dormitory);

            return await Task.FromResult(true);
        }

        public async Task<Dormitory> GetMemberAsync(string ID)
        {
            return await Task.FromResult(Dormitorys.FirstOrDefault(s => s.ID == ID));
        }

        public async Task<IEnumerable<Dormitory>> GetMembersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Dormitorys);
        }
    }
}
