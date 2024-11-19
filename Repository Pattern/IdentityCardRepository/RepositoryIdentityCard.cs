using Microsoft.AspNetCore.Http.HttpResults;
using Quiz_2.DTO;
using Quiz_2.Models;

namespace Quiz_2.Repository_Pattern.IdentityCardRepository
{
    public class RepositoryIdentityCard:IRepositoryIdentityCard
    {
        private readonly AppDbContext _context;
        public RepositoryIdentityCard(AppDbContext context)
        {
            _context = context;
        }

        public void AddIdentityCard(IdentityCardDto dto)
        {
            var author = _context.Authors.FirstOrDefault(x=>x.AuthorId == dto.AuthorId);
            if (author == null)
            {
                throw new Exception("Author Not Found");
            }
            IdentityCard identityCard = new IdentityCard
            {
                ExpiryDate = dto.ExpiryDate,
                AuthorId = dto.AuthorId,
            };
            _context.IdentityCards.Add(identityCard);
            _context.SaveChanges();
        }

        public List<IdentityCardDto> GetIdentityCard()
        {
            var res = _context.IdentityCards.Select(x=> new IdentityCardDto
            {
                AuthorId = x.AuthorId,
                ExpiryDate = x.ExpiryDate,
            }).ToList();
            return res;
        }

        public IdentityCardDto GetIdentityCardById(int IdentityId)
        {
            var res = _context.IdentityCards.FirstOrDefault(x=>x.AuthorId==IdentityId);
            if(res == null)
            {
                return null;
            }
            return new IdentityCardDto
            {
                AuthorId = res.AuthorId,
                ExpiryDate = res.ExpiryDate,
            };
        }
        public void UpdateIdentityCard(IdentityCardDto dto , int IdentityId)
        {
            var res = _context.IdentityCards.FirstOrDefault(x => x.IdentityCardId == IdentityId);
            if (res != null)
            {
                res.AuthorId = dto.AuthorId;
                res.ExpiryDate = dto.ExpiryDate;
            }
            _context.IdentityCards.Update(res);
            _context.SaveChanges();
        }
        public void DeleteIdentityCard(int IdentityId)
        {
            var res = _context.IdentityCards.FirstOrDefault(x => x.IdentityCardId == IdentityId);
            if (res == null)
            {
                throw new Exception("Card Not Found");
            }
            _context.IdentityCards.Remove(res);
            _context.SaveChanges();
        }
    }
}
