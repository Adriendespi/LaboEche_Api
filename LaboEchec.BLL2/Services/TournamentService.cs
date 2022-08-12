using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.Tools.Mappers;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using LaboEchec.DL.Enum;

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
            tEntity.Status_Tournament = Enum_Status.Waiting;
            if(tEntity.Number_Player_Max < tEntity.Number_Player_Min)
            {
                throw new Exception("Attention le nombre de joueur max est plus petit que le nombre de joueur minimum");
            }
            if (tEntity.Elo_Player_Max < tEntity.Elo_Player_Min)
            {
                throw new Exception("Attention l'ELO max du joueur est inférieur à l'Elo minimum ");
            }
            
            return _ServiceTournament.Insert(tEntity);
        }
    }
}
