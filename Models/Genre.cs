using System.ComponentModel.DataAnnotations;

namespace Quiz_2.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
       public ICollection<Book>books { get; set; }
    }
}
