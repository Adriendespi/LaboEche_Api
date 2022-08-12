using LaboEchec.BLL.Services;
using LaboEchec.BLL.TournamentDTO;

namespace LaboEchec.Api.Tools.Mapper
{
    public static class TournamentMapper
    {
        

        public static TournamentRegister ToBll(this TournamentRegister ts)
        {
            return new TournamentRegister
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
