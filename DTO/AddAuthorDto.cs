using System.ComponentModel.DataAnnotations;

namespace Quiz_2.DTO
{
    public class AddAuthorDto
    {
        [Required]
        public string AuthorName { get; set; }
        [Phone]
        public string AuthorPhone { get; set; }
        [EmailAddress]
        public string AuthorEmailAddress { get; set; }
    }
}
