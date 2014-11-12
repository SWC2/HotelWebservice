namespace HotelsWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GuestList")]
    public partial class GuestList
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(30)]
        public string HotelName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Room_No { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string GuestName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime Date_To { get; set; }
    }
}
