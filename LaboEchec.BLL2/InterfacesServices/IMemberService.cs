
﻿using LaboEchec.BLL.DTO.MemberDTO;

using LaboEchec.Dal.Interfaces;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.BLL.InterfacesServices
{

    public interface IMemberService
    {
        Members Register(MemberRegister member);
        MemberLogin Login(string pseudo, string password);

    }

