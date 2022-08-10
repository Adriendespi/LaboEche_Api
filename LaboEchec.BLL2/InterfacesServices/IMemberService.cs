using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.InterfacesServices
{
    public interface IMemberService : IRepository<MemberForm>
    {
        MemberForm Register(MemberForm member);
        MemberForm Login(string pseudo, string password);
    }
}
