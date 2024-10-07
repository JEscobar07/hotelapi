using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.Models
{
    [Table("guests")]
    public class Guest
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("identification_number")]
        [MaxLength(20)]
        [Required]
        public string IdentificationNumber  { get; set; }

        [Column("phone_number")]
        [MaxLength(20)]
        [Required]
        public string PhoneNumber  { get; set; }

        [Column("birthdate")]
        public DateTime? Birthdate { get; set; }
    }
}