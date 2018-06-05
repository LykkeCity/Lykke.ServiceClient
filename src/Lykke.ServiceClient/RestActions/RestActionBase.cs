using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Lykke.ServiceClient {
    public abstract class RestActionBase : IRestAction {
        protected abstract string Action { get; }
        protected abstract HttpMethod HttpMethod { get; }

        protected virtual string LogMessage => $"{HttpMethod} {Action}";
        protected virtual string LogDetails { get; } = string.Empty;

        protected virtual void FillRequest(HttpRequestMessage request) { }

        protected virtual (string AcceptMediaType, Func<HttpResponseMessage, Task<IRestActionResult>> GetResult) ResponseInfo { get; } =
            ("application/json", async response => {
                    var content = await response.Content.ReadAsStringAsync();
                    return new JsonActionResult(content);
                }
            );

        public async Task<IRestActionResult> ExecuteAsync(IRestActionExecutionContext executionContext) {
            var requestMessage = new HttpRequestMessage(HttpMethod, executionContext.Map(Action));
            requestMessage.Headers.Add("api-key", executionContext.ClientSettings.ApiKey);

            if (!string.IsNullOrEmpty(ResponseInfo.AcceptMediaType)) {
                requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(ResponseInfo.AcceptMediaType));
            }

            FillRequest(requestMessage);

            var response = await executionContext.Client.SendAsync(requestMessage);
            return await ResponseInfo.GetResult(response);
        }

        public (string Message, string Details) ToLogInfo() => (LogMessage, LogDetails);
    }
}