using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository.Interfaces.FileDistribution;
using NetMaster.Services.Interfaces.BackgroundServices;
using NetMaster.Services.Interfaces.Network;

namespace NetMaster.Services.Implementations.FileDistribution
{
    public class FileDistributionService : IFileDistributionService
    {
        private readonly INetworkService _networkService;
        private readonly ISendFileRepository _sendFileRepository;

        public FileDistributionService(INetworkService networkService, ISendFileRepository sendFileRepository)
        {
            _networkService = networkService;
            _sendFileRepository = sendFileRepository;
        }

        public async Task DistributeFileToNetworkAsync(string filePath)
        {
            NetworkComputer[]? computers = _networkService.ListNetworkComputerCommand();

            foreach (NetworkComputer? computer in computers)
            {
                string? ip = computer?.IP;

                if (ip != null)
                {
                    RepositoryPowerShellParamModel param = new(ip);
                    _ = await _sendFileRepository.SendFile(param, filePath);
                }
            }

            File.Delete(filePath);
        }
    }
}
