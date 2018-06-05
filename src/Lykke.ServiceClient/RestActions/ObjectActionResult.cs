namespace Lykke.ServiceClient {
    public class ObjectActionResult<T> : IRestActionResult, IResultMapper<T> {
        private readonly T _data;

        public ObjectActionResult(T data) {
            _data = data;
        }

        public T MapTo() => _data;
    }
}