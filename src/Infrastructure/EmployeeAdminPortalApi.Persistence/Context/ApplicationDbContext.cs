using System.Data.Common;
using EmployeeAdminPortalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalApi.Persistence.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}
