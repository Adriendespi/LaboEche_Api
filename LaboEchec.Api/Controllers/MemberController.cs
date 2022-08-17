using LaboEchec.Api.Infrastructure;
using LaboEchec.Api.Tools.Mapper;
using LaboEchec.BLL.DTO.MemberDTO;
using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.MemberDTO;
using LaboEchec.DL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LaboEchec.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;
        private TokenManager _tokenManager;
        private ITournamentService _tournamentService;

        public MemberController(IMemberService memberService, TokenManager manager, ITournamentService tournamentService)
        {
            _memberService = memberService;
            _tokenManager = manager;
            _tournamentService = tournamentService;
        }
        [HttpPost]
        public IActionResult Register(MemberRegister member)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                _memberService.Register(member);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login(MemberLogin log)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                MemberDto currentUser = _memberService.Login(log).ToApi();

                currentUser.Token = _tokenManager.GenerateToken(currentUser);

                return Ok(currentUser.Token);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        
    }
}
