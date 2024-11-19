using System.ComponentModel.DataAnnotations;

namespace Quiz_2.DTO
{
    public class UpdateBookAndGenreDto
    {
        [Required(ErrorMessage = "Title is Required")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Published Year is required")]
        public DateTime PublishedYear { get; set; }
        public List<AddAuthorDto> Authors { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
