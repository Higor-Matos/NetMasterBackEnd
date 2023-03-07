using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMaster.Domain.Models
{
    public class ServiceParamModel
    {
        public ServiceParamModel(string ip)
        {
            Ip = ip;
        }

        public string Ip { get; }
    }
}
