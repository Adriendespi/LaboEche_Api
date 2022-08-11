using LaboEchec.DL.Enum;

namespace LaboEchec.DL.Entity
{
    public class Tournament
    {
        public Guid Id { get; set; }
    
        public string Name { get; set; }

        public string? Location { get; set; }
      
        public int Number_Player_Max { get; set; }
        
        public int Number_Player_Min { get; set; }
       
        public int Elo_Player_Max { get; set; }
       
        public int Elo_Player_Min { get; set; }
        public Enum_Grade Category_Tournament { get; set; }
        public Enum_Status Status_Tournament { get; set; }
        public int Round { get; set; }
        public bool WomenOnly { get; set; }
        public DateTime Last_Inscription_Time { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public ICollection<Members> Players { get; set; } = new List<Members>();
    }
}
