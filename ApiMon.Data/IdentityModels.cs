using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace ApiMon.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Database sets
        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Move> Moves { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }

        public DbSet<TypeAdvantage> TypeAdvantages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Conventions
            //    .Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            //https://stackoverflow.com/questions/5559043/entity-framework-code-first-two-foreign-keys-from-same-table
            // a = typeAdvantage ----- e = elementType
            modelBuilder
                .Entity<TypeAdvantage>()
                .HasRequired(a => a.Advantage)
                .WithMany(e => e.Advantages)
                .HasForeignKey(a => a.AdvantageId)
                .WillCascadeOnDelete(false);

            modelBuilder
                .Entity<TypeAdvantage>()
                .HasRequired(a => a.Disadvantage)
                .WithMany(e => e.Disadvantages)
                .HasForeignKey(a => a.DisadvantageId)
                .WillCascadeOnDelete(false);
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}