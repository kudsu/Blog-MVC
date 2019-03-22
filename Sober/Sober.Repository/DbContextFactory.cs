using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Sober.Repository
{
   public class DbContextFactory
    {
        /// <summary>
        /// 数据上下文工厂（请求/线程单例）
        /// </summary>
        /// <returns></returns>
        public static SqlModel.SqlModel Instance
        {
            get
            {
                //CallContext是线程槽，一个请求对应一个线程，也就是一个线程槽
                //如果数据上下文存在，就直接获取，如果不存在则创建
                var _dbContext = CallContext.GetData("dbContext") as SqlModel.SqlModel;
                if (_dbContext == null)
                {
                    _dbContext = new SqlModel.SqlModel();
                    CallContext.SetData("dbContext", _dbContext);
                }
                return _dbContext;
            }
        }
    }
}
