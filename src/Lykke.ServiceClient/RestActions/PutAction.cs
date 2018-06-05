using System.Net.Http;

namespace Lykke.ServiceClient {
    public class PutAction : JsonActionBase {
        public PutAction(string action, object data = null) {
            Action = action;
            Data = data ?? new object();
        }

        protected override string Action { get; }

        protected override HttpMethod HttpMethod { get; } = HttpMethod.Put;

        protected override object Data { get; }
    }
}