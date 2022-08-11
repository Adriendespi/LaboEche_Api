using LaboEchec.DL.Enum;
using System.ComponentModel.DataAnnotations;

namespace LaboEchec.DL.Entity
{
    public class Members 
    {
        public Guid ID { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Pwd { get; set; }
        
        public DateTime BirthDay { get; set; }
        
        public Enum_Gender gender { get; set; }

        public int? ELO { get; set; }
        public bool IsAdmin { get; set; }
        
        public virtual ICollection<Tournament> Tournaments { get; set; }

    }

    
}
