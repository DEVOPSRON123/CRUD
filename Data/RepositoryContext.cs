using CRUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;

namespace CRUD.Data
{
    public class RepositoryContext : IdentityDbContext<Login>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
          
        }

        public DbSet<Login> Logins { get; set; }
       
    }

}
