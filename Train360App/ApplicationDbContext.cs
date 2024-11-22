using Microsoft.EntityFrameworkCore;
using Trainee360App.Models;

namespace Trainee360App
{    
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            // DbSets represent tables in the database
            public DbSet<Role> Roles { get; set; }
            public DbSet<User> Users { get; set; } 
            public DbSet<UserAudit> userAudits { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                // Additional model configurations can be done here if needed
            }
        }
    }
