using Isopoh.Cryptography.Argon2;
using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.Tools;
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

        public MemberForm Register(MemberForm member)
        {
            // TODO Check If Pseudo and email exists!
            if (!_MemberRepositery.CheckUser(member.Name, member.Email)) throw new Exception("Pseudo ou Email déjà utilisé");

            // Hashé le MDP
            string pwdHash = Argon2.Hash(member.Pwd);
            // Ajout dans le DB
            Members mEntity = member.ToDal();
            mEntity.Pwd = pwdHash;

            int id = _MemberRepositery.Insert(mEntity).ID;

            // Recuperation du member
            return _MemberRepositery.GetById(id).ToBll();
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
