using LaboEchec.BLL.Services;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.InterfacesServices
{
    public interface ITournamentService
    {
        Tournament TournamentCreate(TournamentRegister newTournament);
    }
}
