﻿using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.TournamentDTO;
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
        //[Authorize("Admin") //IsAdmin == true

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
        [HttpDelete]
        [Authorize("Admin")]
        public IActionResult TournamentDelete(int id)
        {
            try
            {
                _tournamentService.TournementDelete(id);
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
                _tournamentService.GetLast10();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult TournamentRegister(string name)
        {
            try
            {
                int id = Int32.Parse(User.FindFirstValue("Sid"));
                _tournamentService.TournamentRegister(name,id);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
