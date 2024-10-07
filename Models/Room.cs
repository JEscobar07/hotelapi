using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.Models
{
    [Table("rooms")]
    public class Room
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("room_number")]
        [Required]
        [MaxLength(10)]
        public string RoomNumber { get; set; }

        [Column("room_type_id")]
        [Required]
        public int RoomTypeId { get; set; }

        [Column("price_per_night")]
        [Required]
        public double PricePerNight { get; set; }

        [Column("availability")]
        [Required]
        public bool Availability { get; set; }

        [Column("max_occupancy_persons")]
        [Required]
        public int MaxOccupancyPersons { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomType RoomType { get; set; }

    }
}