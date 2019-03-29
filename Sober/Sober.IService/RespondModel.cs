using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Sober.IService
{
    public class RespondModel
    {
        public Codestatus Status { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }

        public int Recc { get; set; }

        public byte[] bytes { get; set; }

    }


    public enum Codestatus
    {
        Error,
        NO,
        OK
    }
}
