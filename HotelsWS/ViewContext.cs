namespace HotelsWS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewContext : DbContext
    {
        public ViewContext()
            : base("name=ViewContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<GuestList> GuestLists { get; set; }
        public virtual DbSet<HotelRoom> HotelRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestList>()
                .Property(e => e.HotelName)
                .IsUnicode(false);

            modelBuilder.Entity<GuestList>()
                .Property(e => e.GuestName)
                .IsUnicode(false);

            modelBuilder.Entity<HotelRoom>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HotelRoom>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
