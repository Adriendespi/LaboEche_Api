
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
    }
}
