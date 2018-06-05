namespace Lykke.ServiceClient {
    public interface IRestResource {
        string Prefix { get; }

        string Version { get; }

        string Name { get; }
    }
}