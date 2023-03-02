using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMaster.Repository.Local.Powershell
{
    public class VerifyChocolateyRepository : BasePowershellRepository
    {
        public async Task<string> VerifyChocolateyInstalled(string ip)
        {
            string command = "choco";

            return await RunCommand(command, ip, "-v");
        }
    }
}