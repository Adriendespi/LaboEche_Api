using LaboEchec.BLL.DTO.TournamentDTO;
using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.Tools.Mappers;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using LaboEchec.DL.Enum;
using System.Collections.Generic;

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
        public bool TournementDelete(Tournament tournament)
        {
            if(tournament.Status_Tournament == Enum_Status.InProgress)
            {
                return false;
            }
            else
            {
                return _ServiceTournament.Delete(tournament);
            }
        }
        public IEnumerable<TournamentLast10Dto> GetLast10()
        {
             IEnumerable<TournamentLast10Dto> malist = _ServiceTournament.GetLast10OrderByDate().Select(m => m.ToApi());
            return malist;
        }
    }
}
