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
        IMemberRepository _ServiceMember;

        public TournamentService(ITournamentRepository tournamentService, IMemberRepository memberservice)
        {
            _ServiceTournament = tournamentService;
            _ServiceMember = memberservice;
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
        public bool TournementDelete(int id)
        {
            Tournament tournament= _ServiceTournament.GetById(id);
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

        public Tournament GetByIdForDetails(int id)
        {
            Tournament tournament = _ServiceTournament.GetById(id);
            
            return tournament;
        }

        public Members UnRegistered(int id, string tournament)
        {
            Members LoginMember = _ServiceMember.GetById(id);
            Tournament t = _ServiceTournament.GetByName(tournament);

            if (t.Status_Tournament == Enum_Status.InProgress)
            {
                throw new Exception("Le Tournoi à commencé, vous ne pouvez pas vous désincrire");
            }
            foreach( Members m in t.Players)
            {
                if(m.ID == LoginMember.ID)
                {
                    t.Players.Remove(LoginMember);
                }
            }
            
           
            throw new Exception("Vous n'êtes pas inscrit");
        }
    }
}
