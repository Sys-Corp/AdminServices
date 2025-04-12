using AdminService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Domain.Interface
{
    public interface IAdminStatusRepository
    {
        Task<List<AdminStatus>> GetAdminStatusAll();
        Task<AdminStatus> GetAdminStatusById(int id);
        Task<List<AdminStatus>> GetAdminStatusByFilter(int? id, string? description, DateTime? createAt, DateTime? updateAt);
        Task<AdminStatus> CreateAdminStatus(AdminStatus model);
        Task<AdminStatus> UpdateAdminStatus(AdminStatus model);
        Task<AdminStatus> UpdateAdminStatusPartiallyAsync(AdminStatus model);
        Task<bool> DeleteAdminStatus(int id);

    }
}
