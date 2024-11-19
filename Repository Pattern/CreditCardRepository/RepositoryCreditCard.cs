using Quiz_2.DTO;
using Quiz_2.Models;

namespace Quiz_2.Repository_Pattern.CreditCardRepository
{
    public class RepositoryCreditCard:IRepositoryCreditCard
    {
        private readonly AppDbContext _context;
        public RepositoryCreditCard(AppDbContext context)
        {
            _context = context;
        }

        public void AddCreditCard(CreditCardDto dto)
        {
            var author = _context.Authors.FirstOrDefault(x=>x.AuthorId == dto.AuthorId);
            if (author == null)
            {
                throw new Exception("Author Not Found");
            }
            CrediteCard crediteCard = new CrediteCard
            {
                CardName = dto.CardName,
                CardType = dto.CardType,
                AuthorId = dto.AuthorId,
            };
            _context.CrediteCards.Add(crediteCard);
            _context.SaveChanges();
        }

        public List<CreditCardDto> GetAllCreditCard()
        {
            var res = _context.CrediteCards.Select(x => new CreditCardDto
            {
                CardType = x.CardType,
                AuthorId = x.AuthorId,
                CardName = x.CardName,
            }).ToList();
            return res;
        }
        public CreditCardDto GetCreditCardById(int CreditId)
        {
            var res = _context.CrediteCards.FirstOrDefault(x=>x.CrediteCardId == CreditId);
            if(res == null)
            {
                throw new Exception("Credit Not Found");
            }
            return new CreditCardDto
            {
                CardType = res.CardType,
                CardName= res.CardName,
                AuthorId= res.AuthorId,
            };
        }
        public void UpdateCreditCard(CreditCardDto dto , int CreditId)
        {
            var res = _context.CrediteCards.FirstOrDefault(x=>x.CrediteCardId==CreditId);
            if(res !=null)
            {
                res.CardType = dto.CardType;
                res.CardName = dto.CardName;
                res.AuthorId = dto.AuthorId;
            }
            _context.CrediteCards.Update(res);
            _context.SaveChanges();
        }
        public void DeleteCreditCard(int CreditId)
        {
            var res = _context.CrediteCards.FirstOrDefault(x => x.CrediteCardId == CreditId);
            if(res == null)
            {
                throw new Exception("Credit Card Not Found");
            }
            _context.CrediteCards.Remove(res);
            _context.SaveChanges();
        }
    }
}
