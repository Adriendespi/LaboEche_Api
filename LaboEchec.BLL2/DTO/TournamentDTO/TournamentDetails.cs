using LaboEchec.DL.Entity;
using LaboEchec.DL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.DTO.TournamentDTO
{
    internal class TournamentDetails
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string? Location { get; set; }
        
        public int Number_Player_Max { get; set; }
        
        public int Number_Player_Min { get; set; }
        
        public int Elo_Player_Max { get; set; }
        
        public int Elo_Player_Min { get; set; }
        public Enum_Grade Category_Tournament { get; set; }
        public bool WomenOnly { get; set; }
        public DateTime Last_Inscription_Time { get; set; }
        public DateTime Creation_Date { get; set; }
        public ICollection<Members> Players { get; set; } = new List<Members>();
    }
}
