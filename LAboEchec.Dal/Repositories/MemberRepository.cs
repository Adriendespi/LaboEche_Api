﻿using LaboEchec.Dal.Interfaces;
using LaboEchec.DL;
using LaboEchec.DL.Entity;
using LaboEchec.DL.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Repositories
{
    public class MemberRepository : RepositoryBase<Members>, IMemberRepository
    {
        public MemberRepository(LaboEchecContext context)
            : base(context)
        { }

        public Members? GetByUsername(string username)
        {
            return _Context.Members.FirstOrDefault(m => m.Name == username || m.Email == username);
        }

        public IEnumerable<Members> GetFirst10OrderByName()
        {
            return _Context.Members.OrderBy(m => m.Name).Take(10);
        }
    }
}
