using Quiz_2.Models;
using System.ComponentModel.DataAnnotations;

namespace Quiz_2.DTO
{
    public class AuthorandBookDto
    {
        [Required]
        public string AuthorName { get; set; }
        [Phone]
        public string AuthorPhone { get; set; }
        [EmailAddress]
        public string AuthorEmailAddress { get; set; }
        public List<BookDto> bookss { get; set; }
        public List<AddCreditWirhAuthorDto> CrediteCards { get; set; }
        public AddIdentityCardWithAuthorDto IdentityCard { get; set; }
    }
}
