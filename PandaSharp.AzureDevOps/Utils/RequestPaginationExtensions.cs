using System;
using System.Threading;
using System.Threading.Tasks;
using PandaSharp.AzureDevOps.Services.Common.Contract;
using PandaSharp.Framework.Services.Contract;

namespace PandaSharp.AzureDevOps.Utils
{
    public static class RequestPaginationExtensions
    {
        public static Task<TResponse> ExecuteWithMaximumNumberOfResults<TResponse>(
            this IRequestBase<TResponse> request,
            int maxResults,
            CancellationToken token = default)
        {
            if (!(request is IPaginationSupportedRequest paginationSupportedRequest))
            {
                throw new InvalidOperationException("The request does not support retrieving results in chunks");
            }
            
            paginationSupportedRequest.WithMaxResult(maxResults);
            return request.ExecuteAsync(token);
        }
        
        public static async Task ExecuteWithChunkedResultsAsync<TResponse>(
            this IRequestBase<TResponse> request,
            int chunkSize,
            Func<TResponse, bool> handleResult,
            CancellationToken token = default)
            where TResponse : class
        {
            if (!(request is IPaginationSupportedRequest paginationSupportedRequest))
            {
                throw new InvalidOperationException("The request does not support retrieving results in chunks");
            }
            
            paginationSupportedRequest.WithMaxResult(chunkSize);

            while (true)
            {
                var result = await request.ExecuteAsync(token);

                if (!handleResult(result))
                {
                    return;
                } 
                
                if (!TryGetContinuationToken(result, out var continuationToken))
                {
                    return;
                }
                
                paginationSupportedRequest.WithContinuationToken(continuationToken);
            }
        }

        private static bool TryGetContinuationToken<TResponse>(TResponse response, out string continuationToken) 
            where TResponse : class
        {
            if (response is IPaginationSupportedResponse paginationSupportedResponse)
            {
                continuationToken = paginationSupportedResponse.ContinuationToken;
                return continuationToken != null;
            }

            continuationToken = null;
            return false;
        }
    }
}