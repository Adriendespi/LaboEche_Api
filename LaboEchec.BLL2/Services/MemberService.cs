using Isopoh.Cryptography.Argon2;
using LaboEchec.BLL.DTO.MemberDTO;
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
        IMemberRepository _Service;

        public MemberService(IMemberRepository memberRepositery)
        {
            _Service = memberRepositery;
        }

        public Members Register(MemberRegister member)
        {
            // TODO Check If Pseudo and email exists!
            if (!_Service.CheckUser(member.Name, member.Email)) throw new Exception("Pseudo ou Email déjà utilisé");

            // Hashé le MDP
            string pwdHash = Argon2.Hash(member.Pwd);
            // Ajout dans le DB
            Members mEntity = member.ToEntity();
            mEntity.Pwd = pwdHash;


            int id = _Service.Insert(mEntity).ID;

            if(mEntity.ELO is null)
            {
                mEntity.ELO = 1200; 
            }
            // Recuperation du member
            return _Service.GetById(id);
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
