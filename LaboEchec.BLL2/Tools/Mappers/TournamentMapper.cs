
using LaboEchec.BLL.DTO.TournamentDTO;
using LaboEchec.BLL.TournamentDTO;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.Tools.Mappers
{
    public static  class TournamentMapper
    {
        public static Tournament toEntityTournament( this TournamentRegister ts)
        {
            return new Tournament
            {

                Name = ts.Name,
                Location = ts.Location,
                Number_Player_Max = ts.Number_Player_Max,
                Number_Player_Min = ts.Number_Player_Min,
                Elo_Player_Max = ts.Elo_Player_Max,
                Elo_Player_Min = ts.Elo_Player_Min,
                Category_Tournament = ts.Category_Tournament,
                WomenOnly = ts.WomenOnly


            };
        }
        public static TournamentLast10Dto ToApi(this Tournament t)
        {
            return new TournamentLast10Dto
            {
                Name = t.Name,
                Last_Inscription_Time = t.Last_Inscription_Time,
                Location = t.Location,
                Category_Tournament = t.Category_Tournament,
                Elo_Player_Max = t.Elo_Player_Max,
                Elo_Player_Min = t.Elo_Player_Min,
                Number_Player_Min = t.Number_Player_Min,
                Number_Player_Max = t.Number_Player_Max,
                Status_Tournament = t.Status_Tournament,
                Update_Date = t.Update_Date
            };
        }
    }
}
