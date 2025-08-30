using LOSApplicationApi.Model;
using Master.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace LOSApplicationApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> User { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<UserRoles> UserRole { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<States> State { get; set; }
        public DbSet<Countries> Country { get; set; }
        public DbSet<Pincode> Pincode { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<OccupationType> OccupationTypes { get;set; }
        public DbSet<RejectionReason> ReajectionReasons { get; set; }

        public DbSet<Module> modules { get; set; }

        public DbSet<SubModule> subModules { get; set; }

        public DbSet<Permissions> Permissions { get; set; }

        public DbSet<RolePermissions> RolePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Navigation properties for UserRoles and Users
            modelBuilder.Entity<UserRoles>()
                .HasOne(u => u.User)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for UserRoles and Roles
            modelBuilder.Entity<UserRoles>()
                .HasOne(r => r.Role)
                .WithMany(ur => ur.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Country and States
            modelBuilder.Entity<States>()
                .HasOne(c=> c.Country)
                .WithMany(s => s.States)
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Cities and States
            modelBuilder.Entity<Cities>()
                .HasOne(s=>s.States)
                .WithMany(c=>c.City)
                .HasForeignKey(s=>s.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Pincode and Countries
            modelBuilder.Entity<Pincode>()
                .HasOne(c=> c.Country)
                .WithMany(p=>p.Pincodes)
                .HasForeignKey(c=>c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Pincode and States
            modelBuilder.Entity<Pincode>()
                .HasOne(s => s.State)
                .WithMany(p => p.Pincodes)
                .HasForeignKey(s => s.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Pincode and Cities
            modelBuilder.Entity<Pincode>()
                .HasOne(c => c.City)
                .WithMany(p => p.Pincodes)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for Bank and Branches
            modelBuilder.Entity<Branch>()
                .HasOne(c => c.Bank)
                .WithMany(p => p.Branches)
                .HasForeignKey(c => c.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            //Navigation properties for submodule
            modelBuilder.Entity<SubModule>()
                .HasOne(m => m.Module)
                .WithMany()

                .OnDelete(DeleteBehavior.Restrict);

            //navigation properties for rolepermissions
            modelBuilder.Entity<RolePermissions>()
                .HasKey(rp => rp.RolePermissionId);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RolePermissions>()
                .HasOne(rp => rp.SubModule)
                .WithMany(sm => sm.RolePermissions)
                .HasForeignKey(rp => rp.SubModuleId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
