namespace Quiz_2.Models
{
    public class IdentityCard
    {
        public int IdentityCardId{ get; set; }
        public DateTime ExpiryDate { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
}
