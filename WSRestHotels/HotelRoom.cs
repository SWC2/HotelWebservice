namespace WSRestHotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HotelRoom
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_No { get; set; }

        [StringLength(1)]
        public string Types { get; set; }

        public double? Price { get; set; }
    }
}
