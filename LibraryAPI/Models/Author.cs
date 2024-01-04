using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAPI.Models
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Nationality { get; set; }
    }
}