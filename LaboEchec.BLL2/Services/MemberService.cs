using LaboEchec.BLL.InterfacesServices;
using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.Services
{
    public class MemberService : IMemberService
    {
        IMemberRepository _MemberRepositery;

        public MemberService(IMemberRepository memberRepositery)
        {
            _MemberRepositery = memberRepositery;
        }

        public bool Delete(Members entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Members> GetAll()
        {
            throw new NotImplementedException();
        }

        public Members? GetById(params object[] Id)
        {
            throw new NotImplementedException();
        }

        public Members Insert(Members entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(Members entity)
        {
            throw new NotImplementedException();
        }
    }
}
