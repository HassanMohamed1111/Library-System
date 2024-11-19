using System.ComponentModel.DataAnnotations;

namespace Quiz_2.DTO
{
    public class IdentityCardDto
    {
        [Required]
        public DateTime ExpiryDate { get; set; }
        public int AuthorId { get; set; }
    }
}
