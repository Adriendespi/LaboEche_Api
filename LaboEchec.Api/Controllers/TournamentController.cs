using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.DL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaboEchec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        public ITournamentService _tournamentService;
        
        


        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
            
            

        }

        [HttpPost]
        [Authorize("Admin")] //IsAdmin == true

        public IActionResult TournamentCreate(TournamentRegister tr)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                _tournamentService.TournamentCreate(tr);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{ID}")]
        [Authorize("Admin")]
        public IActionResult TournamentDelete(Guid ID)
        {
            try
            {
                _tournamentService.TournementDelete(ID);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]

        public IActionResult TournamentLast10()
        {
            try
            {
                var items = _tournamentService.GetLast10();
                return Ok(items);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public IActionResult TournamentRegister(string name)
        {
            try
            {
                Guid id = new   Guid(User.FindFirstValue("Sid"));
                _tournamentService.TournamentRegister(name, id);
                return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        [HttpGet("{id}")]
        public IActionResult TournamentDetails(int id)
        {
            try 
            { 
            _tournamentService.GetByIdForDetails(id);
            return Ok();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpDelete("Unregistered")]
        public IActionResult UnRegistered(string name)
        {

            try
            {
                _tournamentService.UnRegistered(new Guid(User.FindFirstValue("Sid")),name);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }
}
