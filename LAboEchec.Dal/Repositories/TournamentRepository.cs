using LaboEchec.Dal.Interfaces;
using LaboEchec.DL;
using LaboEchec.DL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Repositories
{
    public class TournamentRepository : RepositoryBase<Tournament>, ITournamentRepository
    {
        public TournamentRepository(LaboEchecContext context)
            : base(context) { }

        
        public override Tournament Insert(Tournament entity)
        {

            return base.Insert(entity); 
        }
        public bool Delete(Tournament entity) 
        {
           return base.Delete(entity);
        }
        public IEnumerable<Tournament> GetLast10OrderByDate()
        {
            return _Context.tournaments.OrderBy(t => t.Update_Date).Where(t => t.Status_Tournament != DL.Enum.Enum_Status.Finish);
        }
        public Tournament GetByName(string name)
        {
            return  _Context.Set<Tournament>().Find(name);
        }
        public void TournamentRegister(Tournament t, Members m)
        {
            t.Players.Add(m);
            m.Tournaments.Add(t);
        }
        
    }
}
