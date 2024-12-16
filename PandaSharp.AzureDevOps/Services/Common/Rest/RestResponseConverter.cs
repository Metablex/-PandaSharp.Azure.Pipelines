using System;
using System.Linq;
using PandaSharp.AzureDevOps.Services.Common.Contract;
using PandaSharp.Framework.Rest.Contract;
using RestSharp;

namespace PandaSharp.AzureDevOps.Services.Common.Rest
{
    internal sealed class RestResponseConverter : IRestResponseConverter
    {
        private const string ContinuationTokenIdentifier = "x-ms-continuationtoken";

        public T ConvertRestResponse<T>(RestResponse<T> response)
        {
            var responseData = response.Data;
            if (responseData is IPaginationSupportedResponse paginationSupportedResponse)
            {
                var continuationToken = ExtractContinuationToken(response);
                paginationSupportedResponse.ContinuationToken = continuationToken;
            }

            return responseData;
        }

        private static string ExtractContinuationToken(RestResponse response)
        {
            var header = response
                .Headers!
                .FirstOrDefault(i => StringComparer.OrdinalIgnoreCase.Equals(i.Name, ContinuationTokenIdentifier));

            return header?.Value;
        }
    }
}
