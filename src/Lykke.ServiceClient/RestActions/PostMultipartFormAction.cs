using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Common;
using Newtonsoft.Json;

namespace Lykke.ServiceClient {
    public abstract class PostMultipartFormAction : RestActionBase
    {
        protected abstract IDictionary<string, object> Data { get; }

        protected override HttpMethod HttpMethod { get; } = HttpMethod.Post;

        protected override void FillRequest(HttpRequestMessage request)
        {
            var content = new MultipartFormDataContent();

            foreach (var item in Data)
            {
                switch (item.Value) {
                    case null:
                        break;

                    case FileModel fileModel:
                        var fileContent = new ByteArrayContent(fileModel.Content);
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(fileModel.ContentType);
                        content.Add(fileContent, item.Key, fileModel.Name);
                        break;

                    case object dataTransferObject:
                        var jsonContent = new StringContent(dataTransferObject.ToJson(), Encoding.UTF8, "application/json");
                        content.Add(jsonContent, item.Key);
                        break;
                }
            }

            request.Content = content;
        }
    }
}