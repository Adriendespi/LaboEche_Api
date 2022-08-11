using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.Tools.Mappers;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;

namespace LaboEchec.BLL.Services
{
    public class TournamentService : ITournamentService
    {
        ITournamentRepository _ServiceTournament;

        public TournamentService(ITournamentRepository tournamentService)
        {
            _ServiceTournament = tournamentService;
        }

        public Tournament TournamentCreate(TournamentRegister newTournament)
        {

            Tournament tEntity = newTournament.toEntityTournament();
            tEntity.Creation_Date = DateTime.Now;
            tEntity.Update_Date = DateTime.Now;
            tEntity.Last_Inscription_Time = tEntity.Creation_Date.AddDays(tEntity.Number_Player_Max);
            tEntity.Status_Tournament = 0;
            
            
            return _ServiceTournament.Insert(tEntity);
        }
    }
}
