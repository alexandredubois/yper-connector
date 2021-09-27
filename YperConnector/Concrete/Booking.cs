using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YperConnector.Abstract;
using YperConnector.Models;
using YperConnector.Models.Prebook.Request;
using YperConnector.Models.Prebook.Response;

namespace YperConnector.Concrete
{
    class Booking : IBooking
    {

        private readonly WebClient _webClient;
        private readonly string _proId;

        public Booking(string proId, WebClient webClient)
        {
            _proId = proId;
            _webClient = webClient;
        }

        public async Task<Result<PrebookResponse>> Prebook(PrebookRequest request)
        {
            try
            {
                var response = await _webClient.PostAsync($"/pro/{_proId}/prebook", request).ConfigureAwait(false);
                var result = new Result<PrebookResponse>();

                if (response.IsSuccessStatusCode)
                {
                    result.Data = await response.Content.ReadAsAsync<PrebookResponse>().ConfigureAwait(false);
                    return result;
                }

                result.Error = response.Content.ReadAsAsync<ErrorResponse>().Result;

                return result;
            }
            catch (Exception e)
            {
                throw new HttpRequestException($"{nameof(Prebook)} failed", e);
            }
            
        }
    }
}
