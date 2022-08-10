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
        public MemberForm Login(string name, string password)
        {
            string hash = _MemberRepositery.GetHashByName(name);

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("Mot de passe manquant");
            }

            // Validation du hash avec le password
            if (Argon2.Verify(hash, password))
            {
                return _MemberRepositery.GetByUsername(name).ToBll();
            }
            else
            {
                throw new Exception("User ou mot de passe éronné");
            }

        }
        public MemberForm Insert(MemberForm entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<MemberForm> IRepository<MemberForm>.GetAll()
        {
            throw new NotImplementedException();
        }

        MemberForm? IRepository<MemberForm>.GetById(params object[] Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(MemberForm entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MemberForm entity)
        {
            throw new NotImplementedException();
        }
    }
}
