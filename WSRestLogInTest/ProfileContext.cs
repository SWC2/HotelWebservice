namespace WSRestLogInTest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProfileContext : DbContext
    {
        public ProfileContext()
            : base("name=ProfileContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Profile>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
