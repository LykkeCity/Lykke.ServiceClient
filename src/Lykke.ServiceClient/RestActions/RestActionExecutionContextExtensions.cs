using System;

namespace Lykke.ServiceClient {
    public static class RestActionExecutionContextExtensions {
        public static Uri Map(this IRestActionExecutionContext executionContext, string action) {
            var baseUri = new Uri(executionContext.ClientSettings.ServiceUri);
            return new Uri(baseUri, executionContext.VersionToUri(action));
        }

        public static string VersionToUri(this IRestActionExecutionContext executionContext, string action) {
            return $"{executionContext.Resource.Prefix}/{executionContext.Resource.Version}/{executionContext.Resource.Name}/{action}".Trim('/');
        }

        public static T ToObject<T>(this IRestActionResult actionResult, T defautValue = default(T)) {
            switch (actionResult) {
                case IResultMapper mapper:
                    return mapper.MapTo<T>();
                case IResultMapper<T> mapper:
                    return mapper.MapTo();
                default:
                    return defautValue;
            }
        }
    }
}