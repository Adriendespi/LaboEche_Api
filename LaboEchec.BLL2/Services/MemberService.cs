using Isopoh.Cryptography.Argon2;
using LaboEchec.BLL.InterfacesServices;
using LaboEchec.BLL.MemberDTO;
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

            Guid id = _MemberRepositery.Insert(mEntity).ID;
            if(mEntity.ELO is null)
            {
                mEntity.ELO = 1200; 
            }
            // Recuperation du member
            return _MemberRepositery.GetById(id).ToBll();
        }
        public Members Login(MemberLogin mL)
        {
            string hash = _MemberRepositery.GetHashByName(mL.Pseudo);

            if (string.IsNullOrWhiteSpace(hash))
            {
                throw new Exception("Mot de passe manquant");
            }

            // Validation du hash avec le password
            if (Argon2.Verify(hash, mL.Pwd))
            {
                return _MemberRepositery.GetByUsername(mL.Pseudo);
            }
            else
            {
                throw new Exception("User ou mot de passe éronné");
            }

        }
        
    }
}
