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


        public TournamentService(ITournamentRepository tournamentService, IMemberRepository serviceMember)
        {
            _ServiceTournament = tournamentService;
            _ServiceMember = serviceMember;

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

        public void TournamentRegister(string name,int id)
        {
            Tournament t= _ServiceTournament.GetByName(name);
            Members m = _ServiceMember.GetById(id);

            if(t.Last_Inscription_Time < DateTime.Now)
            {
                throw new Exception("La date d'inscription est depasser");
            }
            if (t.Status_Tournament != Enum_Status.Waiting)
            {
                throw new Exception("Le Tournoi est fini ou deja commencer");
            }
            if (t.Players.Any(me => me.Name == m.Name))
            {
                throw new Exception("Vous etes deja Inscrit");
            }
            if(t.Players.Count() > t.Number_Player_Max)
            {
                throw new Exception("Le nombre de joueur max est atteint");
            }
            int age = CalculAge(m.BirthDay, t.Last_Inscription_Time);
            if(age < 18)
            {
                if (t.Category_Tournament != Enum_Grade.Junior)
                {
                    throw new Exception("Vous N'avez pas l'age requis");
                }
            }
            if (age >= 60)
            {
                if (t.Category_Tournament != Enum_Grade.Senior)
                {
                    throw new Exception("Vous N'avez pas l'age requis");
                }
            }

            if(m.ELO<t.Elo_Player_Min || m.ELO > t.Elo_Player_Max)
            {
                throw new Exception("Vous n'avez pas le bon niveau");
            }
            if(t.WomenOnly && m.gender == Enum_Gender.Male)
            {
                throw new Exception("Ce tournoi est reserver au femme");
            }
            _ServiceTournament.TournamentRegister(t, m);


        }

        private int CalculAge(DateTime anniversaire, DateTime tournoidate)
        {
            DateTime now = tournoidate;
            int age = now.Year - anniversaire.Year;
            if (anniversaire > now.AddYears(-age))
                age--;
            return age;
        }




        public Tournament GetByIdForDetails(int id)
        {
            Tournament tournament = _ServiceTournament.GetById(id);
            
            return tournament;
        }

        public void UnRegistered(int id, string tournament)
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
