using System.Collections.Generic;

namespace NetMaster.Domain.Models.DataModels
{
    public class InstalledProgramsResponse
    {
        public string Timestamp { get; set; }
        public string PSComputerName { get; set; }
        public string IpAddress { get; set; }
        public List<InstalledProgram> InstalledPrograms { get; set; }
    }

    public class InstalledProgram
    {
        public string DisplayName { get; set; }
        public string DisplayVersion { get; set; }
    }

}
