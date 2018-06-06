using System.Collections.Generic;

namespace Lykke.ServiceClient {
    public class PostFileAction : PostMultipartFormAction
    {
        public PostFileAction(string action, string name, FileModel file) {
            Action = action;
            Data = new Dictionary<string, object> { { name, file } };
        }

        protected override string Action { get; }
        protected override IDictionary<string, object> Data { get; }
    }
}