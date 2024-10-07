using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.DTOs
{
    public class BookingDTO
    {
        [Column("room_id")]
        [Required]
        public int RoomId { get; set; }

        [Column("guest_id")]
        [Required]
        public int GuestId { get; set; }

        [Column("employee_id")]
        [Required]
        public int EmployeeId { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

    }
}