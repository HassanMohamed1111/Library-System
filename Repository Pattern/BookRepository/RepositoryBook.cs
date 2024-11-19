using Microsoft.EntityFrameworkCore;
using Quiz_2.DTO;
using Quiz_2.Models;
using System.Reflection.Metadata;

namespace Quiz_2.Repository_Pattern
{
    public class RepositoryBook:IRepositoryBook
    {
        private readonly AppDbContext _context;
        public RepositoryBook (AppDbContext context)
        {
            _context = context;
        }
        public void AddBook(BookDto dto)
        {
            Book book = new Book
            {
                BookTitle = dto.BookTitle,
                PublishedYear = dto.PublishedYear,
            };
            _context.books.Add(book);
            _context.SaveChanges();
        }

        public void AddBookAndAuthorToJoinTable(int AuthorId ,int BookId) 
        {
          var author = _context.Authors.Include(x=>x.books)
                .FirstOrDefault(x=>x.AuthorId == AuthorId);
             var book = _context.books.FirstOrDefault(x=>x.BookId == BookId);
            author.books.Add(book);
            _context.SaveChanges();
        }

        public List<AddBookDto> GetAllBooks()
        {
            var res = _context.books.Include(x=>x.Authors).Select(x=> new AddBookDto
            {
                BookTitle=x.BookTitle,
                PublishedYear=x.PublishedYear,
                Authors =x.Authors.Select(x=>new AddAuthorDto
                {
                    AuthorEmailAddress=x.AuthorEmailAddress,
                    AuthorName=x.AuthorName,
                    AuthorPhone = x.AuthorPhone,
                }).ToList(),
                Genres = x.genres.Select(x=>new GenreDto
                {
                    Name = x.Name,
                }).ToList(),
            }).ToList();
            return res;
        }

        public AddBookDto GetBookAndAuthorAndGenreById(int BookId)
        {
            var book = _context.books.Include(x=>x.Authors)
                .FirstOrDefault(x=>x.BookId==BookId);
            if(book == null)
            {
                return null;
            }
            return new AddBookDto
            {
                BookTitle = book.BookTitle,
                PublishedYear = book.PublishedYear,
                Authors = book.Authors.Select(x=>new AddAuthorDto
                {
                    AuthorEmailAddress = x.AuthorEmailAddress,
                    AuthorName = x.AuthorName,
                    AuthorPhone = x.AuthorPhone,    
                }).ToList(),
                Genres = book.genres.Select(x=>new GenreDto 
                {
                    Name = x.Name,
                }).ToList(),
            };
        }

        public void UpdateBook(UpdateBookAndGenreDto dto, int bookId)
        {
            var book = _context.books.Include(x=>x.Authors)
                .Include(x=>x.genres)
                .FirstOrDefault(x=>x.BookId==bookId);
            if(book !=null)
            {
                book.BookTitle = dto.BookTitle;
                book.PublishedYear = dto.PublishedYear;
                book.Authors = dto.Authors.Select(x=>new Author
                {
                    AuthorEmailAddress= x.AuthorEmailAddress,
                    AuthorName= x.AuthorName,
                    AuthorPhone = x.AuthorPhone,
                }).ToList();
                book.genres = dto.Genres.Select(x => new Genre
                {
                    Name = x.Name,
                }).ToList();
            }
            _context.books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBookById(int BookId)
        {
            var book = _context.books.Include(x => x.Authors)
                .FirstOrDefault(x=>x.BookId == BookId);
            if(book!=null)
            {
                _context.books.Remove(book);
                _context.SaveChanges();
            }
        }
        public void AddBookAndGenreToJoinTable(int GenreId, int BookId)
        {
            var book = _context.books.Include(x=>x.genres)
                .FirstOrDefault(x=>x.BookId==BookId);
            var Genre = _context.genres.FirstOrDefault(x=>x.GenreId==GenreId);
            book.genres.Add(Genre);
            _context.SaveChanges();
        }
    }
}
