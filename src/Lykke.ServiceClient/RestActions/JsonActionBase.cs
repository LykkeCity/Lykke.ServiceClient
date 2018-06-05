using System.Net.Http;
using System.Text;

using Newtonsoft.Json;

namespace Lykke.ServiceClient {
    public abstract class JsonActionBase : RestActionBase {
        protected abstract object Data { get; }

        protected override string LogDetails => JsonConvert.SerializeObject(Data);

        protected override void FillRequest(HttpRequestMessage request) {
            request.Content = new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json");
        }
    }
}