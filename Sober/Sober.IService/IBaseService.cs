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
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TType">分页查询</typeparam>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="isAsc">是否倒序</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderByLambd">排序条件</param>
        /// <param name="recc"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambd, ref int recc);
    }
}
