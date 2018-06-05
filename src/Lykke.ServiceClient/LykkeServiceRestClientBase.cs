using System;
using System.Net.Http;
using System.Threading.Tasks;

using Common.Log;

using JetBrains.Annotations;

namespace Lykke.ServiceClient {
    [PublicAPI]
    public abstract class LykkeServiceRestClientBase<TSettings> : IDisposable where TSettings: ILykkeServiceRestClientSettings {
        protected abstract TSettings ClientSettings { get; }

        protected abstract IRestResource DefaultResource { get; }

        protected abstract ILog Log { get; }

        private readonly HttpClient _httpClient = new HttpClient();

        public void Dispose() {
            _httpClient?.Dispose();
        }

        protected async Task<IRestActionResult> ExecuteAsync(IRestAction action, IRestResource resource = null) {
            try {
                resource = resource ?? DefaultResource;
                var context = new RestActionExecutionContext(ClientSettings, resource, _httpClient);
                return await action.ExecuteAsync(context);
            }
            catch (Exception ex) {
                var (actionName, request) = action.ToLogInfo();
                await Log.WriteErrorAsync(GetType().Name, actionName, request, ex);
                throw;
            }
        }

        protected async Task<TResponse> GetDataAsync<TResponse>(string actionName) {
            var action = new GetAction(actionName);
            var result = await ExecuteAsync(action);
            return result.ToObject<TResponse>();
        }

        protected async Task<TResponse> PostDataAsync<TResponse>(string actionName, object data = null) {
            var action = new PostAction(actionName, data);
            var result = await ExecuteAsync(action);
            return result.ToObject<TResponse>();
        }

        protected async Task PutDataAsync(string actionName, object data = null) {
            var action = new PutAction(actionName, data);
            await ExecuteAsync(action);
        }

        protected async Task DeleteDataAsync(string actionName) {
            var action = new DeleteAction(actionName);
            await ExecuteAsync(action);
        }

        protected async Task<FileModel> GetFileAsync(string actionName) {
            var action = new GetFileAction(actionName);
            var result = await ExecuteAsync(action);
            return result.ToObject<FileModel>();
        }

        protected async Task<TResponse> PostFileAsync<TResponse>(string actionName, string name, FileModel file) {
            var action = new PostFileAction(actionName, name, file);
            var result = await ExecuteAsync(action);
            return result.ToObject<TResponse>();
        }
    }
}