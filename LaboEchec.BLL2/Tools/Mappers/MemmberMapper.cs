using LaboEchec.BLL.DTO.MemberDTO;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.Tools.Mappers
{
    public static class MemmberMapper
    {
        

            public static Members ToEntity(this MemberRegister member)
            {
                return new Members
                {
                    ID = member.ID,
                    Email = member.Email,
                    Name = member.Name,
                    Pwd = member.Pwd,
                    ELO = member.ELO
                };
            }
        
    }
}
