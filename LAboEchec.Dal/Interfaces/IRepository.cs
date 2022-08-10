using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboEchec.Dal.Interfaces
{
    public interface IRepository<TEntity>
    {
        // Méthode du CRUD
        // - Create
        TEntity Insert(TEntity entity);
        // - Read
        IEnumerable<TEntity> GetAll();
        TEntity? GetById(params object[] Id);
        // - Update
        bool Update(TEntity entity);
        // - Delete
        bool Delete(TEntity entity);
    }
}

