using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string? Title { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? Genre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PublicationDate { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string? Availability { get; set; }

        public Author? Author { get; set; }
    }

}
