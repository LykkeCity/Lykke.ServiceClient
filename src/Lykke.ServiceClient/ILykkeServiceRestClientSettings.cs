namespace Lykke.ServiceClient {
    public interface ILykkeServiceRestClientSettings {
        string ServiceUri { get; }

        string ApiKey { get; }
    }
}