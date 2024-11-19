namespace Quiz_2.Models
{
    public class CrediteCard
    {
        public int CrediteCardId { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
