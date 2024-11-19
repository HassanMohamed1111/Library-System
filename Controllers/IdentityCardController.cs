using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_2.DTO;
using Quiz_2.Repository_Pattern.IdentityCardRepository;

namespace Quiz_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityCardController : ControllerBase
    {
        private readonly IRepositoryIdentityCard _repo;
        public IdentityCardController(IRepositoryIdentityCard repo)
        {
            _repo = repo;
        }

        [HttpPost("AddIdentityCard")]
        public IActionResult AddIdentityCard(IdentityCardDto dto)
        {
            _repo.AddIdentityCard(dto);
            return Ok();
        }

        [HttpGet("GetAllIdentityCards")]
        public IActionResult GetIdentityCard()
        {

           var res = _repo.GetIdentityCard();
            if (res == null)
            {
                return NotFound("Not Found Identity Cards");
            }
            return Ok(res);
        }

        [HttpGet("GetIdentityById")]
        public IActionResult GetIdentityById(int Identityid)
        {
            var res = _repo.GetIdentityCardById(Identityid);
            if (res == null)
            {
                return NotFound("Identity Card Not Found");
            }
            return Ok(res);
        }

        [HttpPut("UpdateIdentityCard")]
        public IActionResult UpdateIdentityCard(IdentityCardDto dto , int IdentityCardId)
        {
            try
            {
                _repo.UpdateIdentityCard(dto, IdentityCardId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteIdentityCard")]
        public IActionResult DeleteIdentityCard(int IdentityId)
        {
            
            _repo.DeleteIdentityCard(IdentityId);
            return Ok();
            
        }
    }
}
