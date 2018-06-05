using System.Net.Http;

namespace Lykke.ServiceClient {
    public class DeleteAction : RestActionBase {
        public DeleteAction(string action) {
            Action = action;
        }

        protected override string Action { get; }

        protected override HttpMethod HttpMethod { get; } = HttpMethod.Delete;
    }
}