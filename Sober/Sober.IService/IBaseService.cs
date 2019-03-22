using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sober.IService
{
    /// <summary>
    ///业务基类接口
    /// </summary>
    /// <typeparam name="TEntiry"></typeparam>
  public  interface IBaseService<TEntity>where TEntity:class,new()
    {
        bool Add(TEntity tEntiry);
        bool Remove(TEntity tEntiry);
        bool Modify(TEntity tEntiry);
        int GetCount(Func<TEntity, bool> whereLambda);
        TEntity GetEntity(Func<TEntity,bool>whereLambda);
        IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda);
        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambd);
    }
}
