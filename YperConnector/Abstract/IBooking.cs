using System.Threading.Tasks;
using YperConnector.Models;
using YperConnector.Models.Prebook.Request;
using YperConnector.Models.Prebook.Response;

namespace YperConnector.Abstract
{
    public interface IBooking
    {
        Task<Result<PrebookResponse>> Prebook(PrebookRequest request);
    }
}
