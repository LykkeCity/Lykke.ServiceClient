using System.Threading.Tasks;

namespace Lykke.ServiceClient {
    public interface IRestAction {
        Task<IRestActionResult> ExecuteAsync(IRestActionExecutionContext executionContext);

        (string Message, string Details) ToLogInfo();
    }
}