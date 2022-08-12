using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Interfaces
{
    public interface ITournamentRepository :IRepository<Tournament>
    {
        IEnumerable<Tournament> GetLast10OrderByDate();
    }
}
