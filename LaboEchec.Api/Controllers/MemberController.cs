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
            string MemberCreatedMail = @$"
            Félicitations !
            Votre compte a bien été crée sur le serveur des services CheckMate !
            Voici les informations de votre compte. Nous vous invitons à noter ces informtions en lieu sûr et à supprimer ce mail dès que possible.
            Pseudo = {member.Name}
            Adresse mail = {member.Email}
            Mot de Passe = {member.Pwd}
            Bien à vous,
            l'équipe de développement du service CheckMate.";
            try
            {
                _memberService.Register(member);
                MailManager.SendFromKhunly(member.Email, MemberCreatedMail, "NIKOUMOUK");

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
