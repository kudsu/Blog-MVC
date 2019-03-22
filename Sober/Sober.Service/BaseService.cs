using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sober.IRepository;
using Sober.IService;

namespace Sober.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public bool Add(TEntity tEntiry)
        {
            _baseRepository.Insert(tEntiry);
            return _baseRepository.SaveChanges();
        }

        public int GetCount(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryCount(whereLambda);
        }

        public IEnumerable<TEntity> GetEntities(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntities(whereLambda);
        }

        public IEnumerable<TEntity> GetEntitiesByPage<TType>(int pageSize, int pageIndex, bool isAsc, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TType>> orderByLambd)
        {
            return _baseRepository.QueryEntitiesByPage(pageSize,pageIndex,isAsc,whereLambda,orderByLambd);
        }

        public TEntity GetEntity(Func<TEntity, bool> whereLambda)
        {
            return _baseRepository.QueryEntity(whereLambda);
        }      

        public bool Modify(TEntity tEntiry)
        {
            _baseRepository.Update(tEntiry);
            return _baseRepository.SaveChanges();
        }

        public bool Remove(TEntity tEntiry)
        {
            _baseRepository.Delete(tEntiry);
            return _baseRepository.SaveChanges();
         }
    }

}
