using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.MemberDTO
{
    public class MemberLogin
    {
        public string Pseudo { get; set; }
        public string Pwd { get; set; }
    }


    public class MemberLoginOut
    {
        public string Token { get; set; }
    }

    public class MemberDto
    {
        public Guid id { get; set; }
        public string Pseudo { get; set; }
        public string Pwd { get; set; }
         
        public string Token { get; set; }


    }
   

}
