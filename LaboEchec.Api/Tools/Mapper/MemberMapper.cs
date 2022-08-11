using LaboEchec.BLL.MemberDTO;
using LaboEchec.DL.Entity;

namespace LaboEchec.Api.Tools.Mapper
{
    public static class MemberMapper
    {
        public static MemberDto ToApi(this Members members)
        {
            return new MemberDto
            {
                id = members.ID,
                Pseudo = members.Name,
                Pwd = members.Pwd
            };
        }
    }
}
