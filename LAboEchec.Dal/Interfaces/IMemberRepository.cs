using LaboEchec.DL.Entity;

namespace LaboEchec.Dal.Interfaces
{
    public interface IMemberRepository : IRepository<Members>
    {
        IEnumerable<Members> GetFirst10OrderByName();

        Members? GetByUsername(string username);

        bool CheckUser(string name, string email);
    }
}