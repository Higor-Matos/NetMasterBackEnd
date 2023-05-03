using System;

namespace NetMaster.Domain.Models.DataModels
{
    public class OSVersionInfoModel
    {
        public string Caption { get; set; }
        public string Version { get; set; }
        public string PSComputerName { get; set; }
        public string Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}
