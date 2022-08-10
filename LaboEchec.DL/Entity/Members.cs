﻿using LaboEchec.DL.Enum;
using System.ComponentModel.DataAnnotations;

namespace LaboEchec.DL.Entity
{
    public class Members 
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pwd { get; set; }
        
        public DateTime BirthDay { get; set; }
        [Required]
        public Enum_Gender gender { get; set; }

        public int ELO { get; set; }
        public string status { get; set; }

    }
}
