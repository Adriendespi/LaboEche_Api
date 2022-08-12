using LaboEchec.Dal.Interfaces;
using LaboEchec.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected LaboEchecContext _Context;

        public RepositoryBase(LaboEchecContext context)
        {
            _Context = context;
        }

        public bool Delete(TEntity entity)
        {
            _Context.Remove(entity);
            return _Context.SaveChanges() > 0;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>();
        }

        public virtual TEntity? GetById(params object[] Id)
        {
            return _Context.Set<TEntity>().Find(Id);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            _Context.Add(entity);
            _Context.SaveChanges();
            return entity;
        }

        public virtual bool Update(TEntity entity)
        {
            _Context.Update(entity);
            return _Context.SaveChanges() > 0;
        }

    }
}
