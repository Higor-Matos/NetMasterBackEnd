// NetMaster.Services/Implementations/FileDistributionService.cs
using NetMaster.Domain.Models.DataModels;
using NetMaster.Repository.Implementations.FileDistribution;
using NetMaster.Services.Interfaces;
using NetMaster.Services.Interfaces.Network;
using NetMaster.Repository.Interfaces.FileDistribution;
using NetMaster.Services.Interfaces.BackgroundServices;

namespace NetMaster.Services.Implementations
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

                    await _sendFileRepository.SendFile(new RepositoryPowerShellParamModel(ip), filePath);
                }
            }

            // Delete the file after distributing
            File.Delete(filePath);
        }
    }
}
