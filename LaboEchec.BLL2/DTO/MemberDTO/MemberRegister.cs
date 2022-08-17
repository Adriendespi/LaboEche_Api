using LaboEchec.DL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.DTO.MemberDTO
{
    public  class MemberRegister
    {


        public string Name { get; set; }

        public string Email { get; set; }

        public string Pwd { get; set; }

        public DateTime BirthDay { get; set; }

        public Enum_Gender gender { get; set; }

        public int? ELO { get; set; }
        public bool IsAdmin { get; set; }   
    }

}

