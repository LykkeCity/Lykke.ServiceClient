using System.Net.Http;

namespace Lykke.ServiceClient {
    public interface IRestActionExecutionContext {
        ILykkeServiceRestClientSettings ClientSettings { get; }

        IRestResource Resource { get; }

        HttpClient Client { get; }
    }
}