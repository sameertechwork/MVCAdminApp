using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AdminApp.Utility
{
    public class WrappingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content;
            HttpResponseMessage obj_Response;
            ResponseClass obj_ResponseClass = new ResponseClass();

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;

                if (error != null)
                {
                    obj_ResponseClass.Status = 0;
                    obj_ResponseClass.Message = error.Message;
                }
            }
            else
            {
                List<object> responseData = new List<object>();
                responseData.Add((content == null ? new object() : content));
                obj_ResponseClass.data = responseData;
                obj_ResponseClass.Status = 1000;
                obj_ResponseClass.Message = "Success";

            }
            obj_Response = request.CreateResponse<ResponseClass>(response.StatusCode, obj_ResponseClass);
            return obj_Response;
        }

        public class ResponseClass
        {
            public int Status { get; set; }
            public string Message { get; set; }
            public List<object> data { get; set; }
        }
    }
}