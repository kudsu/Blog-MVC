using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sober.IRepository;
using SqlModel;
using System.Data.Entity;

namespace Sober.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private SqlModel.SqlModel _dbContext = DbContextFactory.Instance;
        private DbSet<TEntity> _dbSet;
        public BaseRepository()
        {
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Delete(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbSet.Remove(tEntity);
        }

        public void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public int QueryCount(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Count(whereLambda);
        }

        public IEnumerable<TEntity> QueryEntities(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.Where(whereLambda);
        }
        /// <summary>
        /// 分页查询实体集合
        /// </summary>
        /// <typeparam name="TType">按那个字段排序</typeparam>
        /// <param name="pageSize">页尺寸</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="isAsc">是否正序</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="orderByLambd">排序条件</param>
        /// <returns></returns>
        public IEnumerable<TEntity> QueryEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambd, ref int recc)
        {
            var result = _dbSet.Where(whereLambda);
            result = isAsc ? result.OrderBy(orderByLambd) : result.OrderByDescending(orderByLambd);
            recc = result.Count();
            var offset = (pageIndex - 1) * pageSize;
            //skip是跳过多少个元素，take从序列开头初获取几个元素
            result = result.Skip(offset).Take(pageSize);

            return result;
        }

        public TEntity QueryEntity(Func<TEntity, bool> whereLambda)
        {
            return _dbSet.FirstOrDefault(whereLambda);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbContext.Entry(tEntity).State = EntityState.Modified;
        }
    }
}
