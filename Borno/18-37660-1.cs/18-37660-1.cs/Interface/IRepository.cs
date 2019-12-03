using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_36449_1.cs.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity Get(TEntity entity);
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity evnt);
    }
}
