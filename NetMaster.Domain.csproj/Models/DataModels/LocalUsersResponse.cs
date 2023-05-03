namespace NetMaster.Domain.Models.DataModels
{
    public class LocalUser
    {
        public string Name { get; set; }
    }

    public class LocalUsersResponse
    {
        public List<LocalUser> Users { get; set; }
        public string PSComputerName { get; set; }
        public string Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}