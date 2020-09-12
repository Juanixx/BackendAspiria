using Contratos.Modelos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Negocios.Help
{
    public class HttpActionResult : IHttpActionResult
    {
        private object _object;
        private readonly HttpStatusCode _statusCode;

        public HttpActionResult(HttpStatusCode statusCode, object obj = null)
        {
            _statusCode = statusCode;
            _object = obj;
        }

        public HttpActionResult(HttpStatusCode statusCode, ModelStateDictionary modelState)
        {
            string messages = string.Join("; ", modelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
            _statusCode = statusCode;
            _object = messages;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = new HttpResponseMessage(_statusCode)
            {
            };

            if (_object is string)
            {
                ModelResult modelResult = new ModelResult()
                {
                    StatusCode = (int)_statusCode,
                    Message = _object.ToString()
                };
                _object = modelResult;
            }

            response.Content = _object != null ? new StringContent(JsonConvert.SerializeObject(_object, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }), Encoding.UTF8, "application/json") : null;
            return Task.FromResult(response);
        }
    }
}
