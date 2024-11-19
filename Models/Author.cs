using System.ComponentModel.DataAnnotations;

namespace Quiz_2.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Phone]
        public string AuthorPhone { get; set; }
        [EmailAddress]
        public string AuthorEmailAddress { get; set; }
        public ICollection<Book> books { get; set; }
        public ICollection<CrediteCard> CrediteCards { get; set; }
        public IdentityCard IdentityCard { get; set; }
    }
}
