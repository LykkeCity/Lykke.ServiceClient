namespace Lykke.ServiceClient {
    public interface IRestResource {
        string Prefix { get; }
        string Name { get; }
        string Version { get; }
    }
}