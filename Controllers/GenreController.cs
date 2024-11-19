using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_2.DTO;
using Quiz_2.Repository_Pattern.GenreRepository;

namespace Quiz_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IRepositoryGenre _repo;
        public GenreController(IRepositoryGenre repo)
        {
            _repo = repo;
        }
        [HttpPost("AddGenre")]
        public IActionResult AddGenre(GenreDto dto)
        {
            _repo.AddGenre(dto);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllGenre()
        {
           var genre = _repo.GetAllGenre();
            return Ok(genre);
        }

        [HttpGet("GetGenreById/{id}")]
        public IActionResult GetGenreById(int id)
        {
           var res = _repo.GetById(id);
            return Ok(res);
        }

        [HttpPut("UpdateGenreById")]
        public IActionResult UpdateGenreById(GenreDto dto , int id)
        {
            _repo.UpdateGenreById(dto , id);
            return Ok();
        }

        [HttpDelete("DeleteGenerById")]
        public IActionResult DeleteGenreById(int id)
        {
            _repo.DeleteGenreById(id);
            return Ok();
        }
    }
}
