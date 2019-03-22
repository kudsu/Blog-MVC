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

    public class everydaynewsService : BaseService<everydaynews>, IeverydaynewsService
    {
        public everydaynewsService(IeverydaynewsRepository baseRepository) : base(baseRepository)
        {
        }
    }
}
