using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace hotelapi.Models
{
    [Table("employees")]
    public class Employee
    {

        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("first_name")]
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("identication_number")]
        [MaxLength(20)]
        [Required]
        public string IdentificationNumber  { get; set; }

        [Column("Password")]
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

    }
}