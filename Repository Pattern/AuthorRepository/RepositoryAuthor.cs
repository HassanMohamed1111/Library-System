using Microsoft.EntityFrameworkCore;
using Quiz_2.DTO;
using Quiz_2.Models;

namespace Quiz_2.Repository_Pattern
{
    public class RepositoryAuthor : IRepositoryAuthor
    {
        private readonly AppDbContext _context;
        public RepositoryAuthor(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AddAuthorDto dto)
        {
            Author author = new Author
            {
                 AuthorEmailAddress = dto.AuthorEmailAddress,
                 AuthorName = dto.AuthorName,
                 AuthorPhone = dto.AuthorPhone,
            };
            _context.Authors.Add(author);
            _context.SaveChanges(); 
        }

        public void AddAllDataFromAuthor(AuthorandBookDto dto)
        {
            Author author = new Author
            {
                AuthorEmailAddress = dto.AuthorEmailAddress,
                AuthorPhone = dto.AuthorPhone,
                AuthorName = dto.AuthorName, 
                books = dto.bookss.Select(x=>new Book
                {
                    BookTitle = x.BookTitle,
                    PublishedYear = x.PublishedYear,
                }).ToList(),
                CrediteCards = dto.CrediteCards.Select(x=>new CrediteCard
                {
                    CardName = x.CardName,
                    CardType = x.CardType,
                }).ToList(),
                IdentityCard = new IdentityCard
                {
                    ExpiryDate = dto.IdentityCard.ExpiryDate,
                }
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddAuthorToJoinTable(int authorId, int bookId)
        {
            var author = _context.Authors.Include(i => i.books).FirstOrDefault(x => x.AuthorId == authorId);
            var book = _context.books.FirstOrDefault(x => x.BookId == bookId);
            author.books.Add(book);
            _context.SaveChanges();
        }
        public List<AuthorandBookDto> GetAllDataFromAuthor()
        {
            var res = _context.Authors.Include(x => x.books)
                .Include(x => x.IdentityCard) 
                .Include(x => x.CrediteCards)
                .Where(x => x.IdentityCard != null) 
                .Select(i => new AuthorandBookDto
                {
                    AuthorEmailAddress = i.AuthorEmailAddress,
                    AuthorName = i.AuthorName,
                    AuthorPhone = i.AuthorPhone,
                    bookss = i.books.Select(x => new BookDto
                    {
                        BookTitle = x.BookTitle,
                        PublishedYear = x.PublishedYear,
                    }).ToList(),
                    CrediteCards = i.CrediteCards.Select(i => new AddCreditWirhAuthorDto
                    {
                        CardName = i.CardName,
                        CardType = i.CardType,
                    }).ToList(),
                    IdentityCard = new AddIdentityCardWithAuthorDto
                    {
                        ExpiryDate = i.IdentityCard.ExpiryDate,
                    }
                }).ToList();

            return res;
        }

        public AuthorandBookDto GetAuthorById(int authorId)
        {
            var author = _context.Authors.Include(x => x.books)
                 .FirstOrDefault(x => x.AuthorId == authorId);
            if(author == null)
            {
                return null;
            }
            return new AuthorandBookDto
            {
                AuthorEmailAddress = author.AuthorEmailAddress,
                AuthorName = author.AuthorName,
                AuthorPhone = author.AuthorPhone,
                bookss = author.books.Select(x=>new BookDto
                {
                    BookTitle = x.BookTitle,
                    PublishedYear = x.PublishedYear,
                }).ToList(),
            };
        }


        public void DeleteAuthorById(int Authorid)
        {
          var res = _context.Authors.FirstOrDefault(x=>x.AuthorId == Authorid);
            _context.Authors.Remove(res);
            _context.SaveChanges();
        }

        public void UpdateAuthor(int id, AuthorandBookDto dto)
        {
            var res = _context.Authors.FirstOrDefault(x => x.AuthorId == id);

        }
        public void UpdateAuthor(UpdateAuthorWithBookDto dto, int Authorid)
        {
            var res = _context.Authors.Include(x=>x.books)
                .FirstOrDefault(x=>x.AuthorId==Authorid);
            if(res != null)
            {
                res.AuthorEmailAddress = dto.AuthorEmailAddress;
                res.AuthorName = dto.AuthorName;
                res.AuthorPhone = dto.AuthorPhone;
                res.books = dto.bookss.Select(x=>new Book
                {
                    BookTitle=x.BookTitle,
                    PublishedYear=x.PublishedYear,
                }).ToList();
            }
            _context.Authors.Update(res);
            _context.SaveChanges();
        }

    }
}
