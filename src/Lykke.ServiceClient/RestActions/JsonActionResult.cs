using Newtonsoft.Json;

namespace Lykke.ServiceClient {
    public class JsonActionResult : IRestActionResult, IResultMapper {
        private readonly string _content;

        public JsonActionResult(string content) {
            _content = content;
        }

        public T MapTo<T>() {
            return JsonConvert.DeserializeObject<T>(_content);
        }
    }
}