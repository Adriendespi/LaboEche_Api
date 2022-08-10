using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.Tools
{
    public static class Mappers
    {
        public static MemberForm ToBll(this Members member)
        {

            return new MemberForm
            {
                ID = member.ID,
                Email = member.Email,
                Name = member.Name,
                Pwd = member.Pwd
            };

        }

        public static Members ToDal(this MemberForm member)
        {
            return new Members
            {
                ID = member.ID,
                Email = member.Email,
                Name = member.Name,
                Pwd = member.Pwd
            };
        }
    }
}
