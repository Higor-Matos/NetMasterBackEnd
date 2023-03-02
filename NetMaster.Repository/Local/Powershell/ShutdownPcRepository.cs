using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMaster.Repository.Local.Powershell
{
    public class ShutdownPcRepository : BasePowershellRepository
    {
        public async Task<string> ShutdownPc(string ip)
        {
            string command = "Stop-Computer";


            return await RunCommand(command, ip, "-Force");
        }
    }
}