using AdminService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminService.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        #region Add Entity to DBSet
        public DbSet<AdminStatus> AdminStatuses { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Modify tablename and schema
            modelBuilder.Entity<AdminStatus>().ToTable("admin_status", "GN");
            #endregion

            #region Data seeding to table
            modelBuilder.Entity<AdminStatus>().HasData(
                new AdminStatus
                {
                    id = 1,
                    description = "Active"
                },
                new AdminStatus
                {
                    id = 2,
                    description = "In Active"
                });
            #endregion
        }
    }
}
