using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlModel;
using Sober.IRepository;
using Sober.IService;

namespace Sober.Service
{
    public class V_everydaynewsService : BaseService<V_everydaynews>, IV_everydaynewsService
    {
        public V_everydaynewsService(IV_everydaynewsRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
