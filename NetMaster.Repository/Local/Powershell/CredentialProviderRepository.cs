using NetMaster.Repository.Local.Configuration;
using System.Management.Automation;
using System.Security;

namespace NetMaster.Repository.Local.Powershell
{
    public class CredentialProviderRepository
    {
        private readonly ConfigurationRepository configRep = new();

        public PSCredential GetCredential()
        {
            string username = configRep.GetValue("Credentials:Username");
            string password = configRep.GetValue("Credentials:Password");

            SecureString secureString = new();
            foreach (char letter in password)
            {
                secureString.AppendChar(letter);
            }

            return new PSCredential(username, secureString);
        }
    }
}