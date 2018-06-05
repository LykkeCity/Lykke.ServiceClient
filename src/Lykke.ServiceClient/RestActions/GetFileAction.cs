using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lykke.ServiceClient {
    public class GetFileAction : RestActionBase {
        public GetFileAction(string action) {
            Action = action;
        }

        protected override string Action { get; }
        protected override HttpMethod HttpMethod { get; } = HttpMethod.Get;

        protected override (string AcceptMediaType, Func<HttpResponseMessage, Task<IRestActionResult>> GetResult) ResponseInfo { get; } =
            (string.Empty, async response => {

                    var file = new FileModel {
                        Name = response.Content.Headers.ContentDisposition.FileName,
                        ContentType = response.Content.Headers.ContentType.MediaType,
                        Content = await response.Content.ReadAsByteArrayAsync()
                    };

                    return new ObjectActionResult<FileModel>(file);
                }
            );
    }
}