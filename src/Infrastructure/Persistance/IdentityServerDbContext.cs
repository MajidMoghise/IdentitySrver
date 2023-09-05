using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.ModelBuilders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Domain.Action;

namespace EFDBContext
{
    public class IdentityServerDbContext:DbContext
    {
        public static string ConnectionString;
        public IdentityServerDbContext()
        {

        }
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> option):base(option)
        {
       
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=MAJIDMOGHISE-LA\MSSQLSERVER2019;Initial Catalog=Identity;Persist Security Info=True;User ID=sa;Password=Mm123");

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.DomainBuilder();
                    }

        public DbSet<Action> Actions { get; set; }
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleClaimAction> UserRoleClaimActions { get; set; }
    }
}
