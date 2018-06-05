using System.Net.Http;

namespace Lykke.ServiceClient {
    public class RestActionExecutionContext : IRestActionExecutionContext {
        public RestActionExecutionContext(ILykkeServiceRestClientSettings clientSettings, IRestResource resource, HttpClient client) {
            ClientSettings = clientSettings;
            Resource = resource;
            Client = client;
        }

        public ILykkeServiceRestClientSettings ClientSettings { get; }
        public IRestResource Resource { get; }
        public HttpClient Client { get; }
    }
}