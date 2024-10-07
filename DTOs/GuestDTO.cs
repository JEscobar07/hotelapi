using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.DTOs
{
    public class GuestDTO
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string IdentificationNumber  { get; set; }

        [MaxLength(20)]
        [Required]
        public string PhoneNumber  { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}