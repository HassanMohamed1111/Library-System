using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_2.DTO;
using Quiz_2.Repository_Pattern;

namespace Quiz_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryBook _repo;
        public BookController(IRepositoryBook repo)
        {
            _repo = repo;
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDto dto)
        {
            try
            {
                _repo.AddBook(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost("AddBookAndAuthorToJoinTable")]
        public IActionResult AddBookAndAuthorToJoinTable(int authorId , int BookId)
        {
         
             _repo.AddBookAndAuthorToJoinTable(authorId, BookId);
             return Ok();
            
        }

        [HttpGet("GetAllBookWithAuthorAndGenre")]
        public IActionResult GetAllBookWithAuthorAndGenre()
        {
           var res =  _repo.GetAllBooks();
            if(res==null)
            {
                return NotFound("Not Found Books");
            }
            return Ok(res);
        }

        [HttpGet("GetBookAndAuthorAndGenreById/{bookId}")]
        public IActionResult GetBookById(int bookId)
        {
           var res = _repo.GetBookAndAuthorAndGenreById(bookId);
            if(res == null)
            {
                return NotFound("Book Not Found");
            }
            return Ok(res);
        }

        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(UpdateBookAndGenreDto dto , int BookId)
        {
            try
            {
                _repo.UpdateBook(dto, BookId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBook")]
        public IActionResult DeleteBook(int bookId)
        {
            try
            {
                _repo.DeleteBookById(bookId);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("AddBookAndGenreToJoinTable")]
        public IActionResult AddBookAndGenreToJoinTable(int bookId , int genreId)
        {
            _repo.AddBookAndGenreToJoinTable(genreId , bookId);
            return Ok();
        }
    }
}
    