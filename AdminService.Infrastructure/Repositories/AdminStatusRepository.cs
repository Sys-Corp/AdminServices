using AdminService.Domain.Entities;
using AdminService.Domain.Interface;
using AdminService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Infrastructure.Repositories
{
    public class AdminStatusRepository : IAdminStatusRepository
    {
        private readonly ApplicationDBContext _db;

        public AdminStatusRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<AdminStatus> CreateAdminStatus(AdminStatus model)
        {
            bool isExists = await _db.AdminStatuses.AnyAsync(a => a.description == model.description);

            if (isExists)
                return null;

            _db.AdminStatuses.Add(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteAdminStatus(int id)
        {
            AdminStatus? adminStatus = await _db.AdminStatuses.FirstOrDefaultAsync(_ => _.id == id);

            if (adminStatus == null) return false;

            _db.AdminStatuses.Remove(adminStatus);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<AdminStatus>> GetAdminStatusAll()
        {
            return await _db.AdminStatuses.ToListAsync();
        }

        public async Task<List<AdminStatus>> GetAdminStatusByFilter(int? id, string? description, DateTime? createAt, DateTime? updateAt)
        {
            return await _db.AdminStatuses
                .Where(a=>(a.id == id || id == null) &&
                (a.description == description || description == null) &&
                (a.created_at == createAt || createAt == null) &&
                (a.updated_at == updateAt || updateAt == null))
                .ToListAsync();
        }

        public async Task<AdminStatus> GetAdminStatusById(int id)
        {
            return await _db.AdminStatuses.FirstOrDefaultAsync(a => a.id == id);
        }

        public async Task<AdminStatus> UpdateAdminStatus(AdminStatus model)
        {
            AdminStatus? adminStatus = await _db.AdminStatuses.FirstOrDefaultAsync(a=>a.id == model.id);

            if (adminStatus == null)
                throw new KeyNotFoundException($"Id:{model.id} not found.");

            bool isExists = await _db.AdminStatuses.AnyAsync(a => a.description == model.description);

            if (isExists)
                throw new InvalidOperationException($"Description:{model.description} is already exists");

            adminStatus.description = model.description;
            adminStatus.updated_at = model.updated_at;

            await _db.SaveChangesAsync();

            return adminStatus;
        }

        public Task<AdminStatus> UpdateAdminStatusPartiallyAsync(AdminStatus model)
        {
            throw new NotImplementedException();
        }
    }
}
