using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Quiz_2.DTO;
using Quiz_2.Repository_Pattern.CreditCardRepository;
using System.Runtime.InteropServices;

namespace Quiz_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IRepositoryCreditCard _repo;
        public CreditCardController(IRepositoryCreditCard repo)
        {
            _repo = repo;
        }

        [HttpPost("AddCreditCard")]
        public IActionResult AddCreditCard(CreditCardDto dto)
        {
            try
            {
                _repo.AddCreditCard(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllCreditCards")]
        public IActionResult GetAllCreditCards()
        {
            try
            {
                var res = _repo.GetAllCreditCard();
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound("Not Found Credits");
            }
        }

        [HttpGet("GetCreditCardById")]
        public IActionResult GetCreditById(int Creditid)
        {
            try
            {
                var res = _repo.GetCreditCardById(Creditid);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return NotFound("Credit Not Found");
            }
        }

        [HttpPut("UpdateCreditCard")]
        public IActionResult UpdateCredit(CreditCardDto dto , int CreditId)
        {
            try
            {
                _repo.UpdateCreditCard(dto, CreditId);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete CreditCard")]
        public IActionResult DeleteCreditCard(int Creditid)
        {
            try
            {
                _repo.DeleteCreditCard(Creditid);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound("Not Found Credit");
            }
        }
    }
}
