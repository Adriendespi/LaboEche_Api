﻿using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        ITournamentRepository _ServiceTournament;

        public TournamentService(ITournamentRepository tournamentService)
        {
            _ServiceTournament = tournamentService;
        }


        Tournament ITournamentService.TournamentCreate(TournamentService newTournament)
        {
            throw new NotImplementedException();
        }
    }
}
