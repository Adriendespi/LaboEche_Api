using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.TournamentDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
