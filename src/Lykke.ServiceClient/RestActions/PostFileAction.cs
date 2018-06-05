using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using Newtonsoft.Json;

namespace Lykke.ServiceClient {
    public class PostFileAction : RestActionBase {
        public PostFileAction(string action, string name, FileModel file, object data = null) {
            Action = action;
            Name = name;
            File = file;
            Data = data;
        }

        protected override string Action { get; }
        protected override HttpMethod HttpMethod { get; } = HttpMethod.Post;

        protected string Name { get; }
        protected FileModel File { get; }
        public object Data { get; }

        protected override string LogDetails => $"{File.Name}";

        protected override void FillRequest(HttpRequestMessage request) {
            var fileContent = new ByteArrayContent(File.Content);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(File.ContentType);

            request.Content = new MultipartFormDataContent {
                { fileContent, Name, File.Name },
                { new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json"), "data" }
            };
        }
    }
}