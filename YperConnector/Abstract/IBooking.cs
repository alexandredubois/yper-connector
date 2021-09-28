using System.Threading.Tasks;
using YperConnector.Models;
using YperConnector.Models.Prebook.Request;
using YperConnector.Models.Prebook.Response;
using YperConnector.Models.PrebookValidation.Response;

namespace YperConnector.Abstract
{
    public interface IBooking
    {
        Task<Result<PrebookResponse>> Prebook(PrebookRequest request);

        Task<Result<PrebookValidationResponse>> ValidatePrebook(string prebookId);
    }
}
