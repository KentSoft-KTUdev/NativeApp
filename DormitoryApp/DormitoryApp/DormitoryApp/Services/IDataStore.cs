using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DormitoryApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddMemberAsync(T Member);
        Task<bool> UpdateMemberAsync(T Member);
        Task<bool> DeleteMemberAsync(T Member);
        Task<T> GetMemberAsync(string id);
        Task<IEnumerable<T>> GetMembersAsync(bool forceRefresh = false);
        //Task<bool> AddGuestAsync(T Guest);
        //Task<bool> UpdateGuestAsync(T Guest);
        //Task<bool> DeleteGuestAsync(T Guest);
        //Task<T> GetGuestAsync(string id);
        //Task<IEnumerable<T>> GetGuestsAsync(bool forceRefresh = false);
    }
}
