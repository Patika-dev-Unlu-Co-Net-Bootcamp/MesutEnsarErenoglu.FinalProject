

using System.Net.Http;
using System.Threading.Tasks;

namespace FinalProject.UI.RequestOperations
{
    public interface IApiCallService
    {
        Task<HttpResponseMessage> Get(string url);
        Task<HttpResponseMessage> Delete(string url);

    }
}
