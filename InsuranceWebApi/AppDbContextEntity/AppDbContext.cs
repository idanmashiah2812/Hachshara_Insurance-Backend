using InsuranceWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceWebApi.AppDbContextEntity
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<InsurancePolicyModel> Policies { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
