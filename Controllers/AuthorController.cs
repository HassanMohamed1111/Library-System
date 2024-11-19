using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_2.DTO;
using Quiz_2.Repository_Pattern;

namespace Quiz_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryAuthor _repo;
        public AuthorController(IRepositoryAuthor repo)
        {
            _repo = repo;
        }
        [HttpPost("AddAllDataFromAuthor")]
        public IActionResult AddAllDataFromAuthor(AuthorandBookDto dto)
        {
            _repo.AddAllDataFromAuthor(dto);
            return Ok();
        }

        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor(AddAuthorDto dto)
        {
            _repo.AddAuthor(dto);
            return Ok();
        }

        [HttpPost("AddAuthorToJoinTable")]
        public IActionResult AddAuthorToJoinTable(int authorId , int BookId)
        {
            _repo.AddAuthorToJoinTable(authorId, BookId);
            return Ok();
        }

        [HttpGet("GetAllDataFromAuthor")]
        public IActionResult GetAuthorBook()
        {
            var res = _repo.GetAllDataFromAuthor();
            return Ok(res);
        }

        [HttpGet("GetAuthorBookById/{id}")]
        public IActionResult GetAuthor(int id)
        {
            var res = _repo.GetAuthorById(id);
            return Ok(res);
        }

        [HttpDelete("DeleteAuthor")]
        public IActionResult DeleteAuthor(int id)
        {
            _repo.DeleteAuthorById(id);
            return Ok();
        }

        [HttpPut("UpdateAuthorBook")]
        public IActionResult UpdateAuthorBook(UpdateAuthorWithBookDto dto , int Authorid)
        {
            _repo.UpdateAuthor(dto , Authorid);
            return Ok();
        }
    }
}
