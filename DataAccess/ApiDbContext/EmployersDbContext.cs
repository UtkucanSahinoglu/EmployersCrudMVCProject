using Entity.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ApiDbContext
{
    public class EmployersDbContext : DbContext
    {
        public DbSet <Employer> Employers { get; set; }
        public EmployersDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}