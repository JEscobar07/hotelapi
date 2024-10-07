using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.DTOs
{
    public class EmployeeDTO
    {

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string IdentificationNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}