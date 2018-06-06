using JetBrains.Annotations;

namespace Lykke.ServiceClient {
    [PublicAPI]
    public class ApiResource : IRestResource
    {
        public ApiResource(string name, string version = null)
        {
            Name = name;
            Version = version;
        }

        public string Prefix { get; } = "api";
        public string Name { get; }
        public string Version { get; }
    }
}