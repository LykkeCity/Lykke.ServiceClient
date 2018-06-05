using System.Net.Http;

namespace Lykke.ServiceClient {
    public class PostAction : JsonActionBase {
        public PostAction(string action, object data = null) {
            Action = action;
            Data = data ?? new object();
        }

        protected override string Action { get; }

        protected override HttpMethod HttpMethod { get; } = HttpMethod.Post;

        protected override object Data { get; }
    }
}