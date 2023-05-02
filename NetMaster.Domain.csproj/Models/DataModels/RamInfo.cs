using System;

namespace NetMaster.Domain.Models.DataModels
{
    public class RamInfo
    {
        public double FreePhysicalMemory_GB { get; set; }
        public double TotalVisibleMemorySize_GB { get; set; }
        public string PSComputerName { get; set; }
        public string Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}
