using Quiz_2.DTO;
using Quiz_2.Models;

namespace Quiz_2.Repository_Pattern
{
    public interface IRepositoryBook
    {
       public void AddBook(BookDto dto);
        public void AddBookAndAuthorToJoinTable(int AuthorId, int BookId);
        public void AddBookAndGenreToJoinTable(int GenreId, int BookId);
        public List<AddBookDto> GetAllBooks();
        public AddBookDto GetBookAndAuthorAndGenreById(int BookId);
        public void UpdateBook(UpdateBookAndGenreDto dto, int bookId);
        public void DeleteBookById(int BookId); 
    }
}
