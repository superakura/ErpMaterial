using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErpMaterial.Repository
{
    public interface IGenericRepository<T>
    {
        Task<bool> Add(T Entity);
        Task<bool> Delete(T Entity);
        Task<bool> Update(T Entity);
        T GetEntity(Expression<Func<T, bool>> exp);
        IEnumerable<T> GetEntities(Expression<Func<T, bool>> exp);
        IQueryable<T> GetList(Expression<Func<T, bool>> exp);
        IEnumerable<T> GetEntitiesForPaging(int Page, int pageSize, Expression<Func<T, bool>> exp);
    }
}
