namespace WSRestHotels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelContext2 : DbContext
    {
        public HotelContext2()
            : base("name=HotelContext2")
        {
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
