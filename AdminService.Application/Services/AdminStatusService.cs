using AdminService.Application.DTO;
using AdminService.Domain.Entities;
using AdminService.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Application.Services
{
    public class AdminStatusService
    {
        private readonly IAdminStatusRepository _repository;
        public AdminStatusService(IAdminStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AdminStatus>> GetAdminStatusAll()
        {
            return await _repository.GetAdminStatusAll();
        }

        public async Task<AdminStatus> GetAdminStatusById(int id)
        {
            return await _repository.GetAdminStatusById(id);
        }

        public async Task<List<AdminStatus>> GetAdminStatusByFilter(int? id, string? description, DateTime? createdAt, DateTime? updatedAt)
        {
            return await _repository.GetAdminStatusByFilter(id,description,createdAt,updatedAt);
        }

        public async Task<AdminStatus> CreateAdminStatus(AdminStatus model)
        {
            return await _repository.CreateAdminStatus(model);
        }

        public async Task<AdminStatus> UpdateAdminStatus(AdminStatus model)
        {
            return await _repository.UpdateAdminStatus(model);
        }

        public async Task<bool> DeleteAdminStatus(int id)
        {
            return await _repository.DeleteAdminStatus(id);
        }
    }
}
