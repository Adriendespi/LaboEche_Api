using LaboEchec.DL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.DTO.TournamentDTO
{
    public  class TournamentLast10Dto
    {
        public string Name { get; set; }

        public string? Location { get; set; }

        public int Number_Player_Max { get; set; }

        public int Number_Player_Min { get; set; }

        public int Elo_Player_Max { get; set; }

        public int Elo_Player_Min { get; set; }
        public Enum_Grade Category_Tournament { get; set; }
        public Enum_Status Status_Tournament { get; set; }

        public DateTime Last_Inscription_Time { get; set; }
        public DateTime Update_Date { get; set; }
    }
}
