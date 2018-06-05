using System.Net.Http;

namespace Lykke.ServiceClient {
    public class GetAction : RestActionBase {
        public GetAction(string action) {
            Action = action;
        }

        protected override string Action { get; }

        protected override HttpMethod HttpMethod { get; } = HttpMethod.Get;
    }
}