using System.ComponentModel.DataAnnotations;

namespace Quiz_2.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required(ErrorMessage ="Title is Required")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Published Year is required")]
        public DateTime PublishedYear { get; set; }
       public ICollection<Author>Authors { get; set; }
       public ICollection<Genre>genres { get; set; }
            
    }
}
