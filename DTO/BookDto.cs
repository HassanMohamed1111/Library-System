using System.ComponentModel.DataAnnotations;

namespace Quiz_2.DTO
{
    public class BookDto
    {
        [Required(ErrorMessage = "Title is Required")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Published Year is required")]
        public DateTime PublishedYear { get; set; }
    }
}
