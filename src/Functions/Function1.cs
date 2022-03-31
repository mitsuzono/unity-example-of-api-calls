using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Functions
{
    public static class Function1
    {
        /// <summary>
        /// VS2022でデフォルト生成されるHTTPトリガーFunction
        /// </summary>
        /// <param name="req"><see cref="HttpRequest"></param>
        /// <param name="log"><see cref="ILogger"></param>
        /// <returns><see cref="IActionResult"></returns>
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // クエリパラメータからname値取得（主にGETリクエストで使用）
            string name = req.Query["name"];

            // リクエストBodyをJSONパース（主にPOSTリクエストで使用。サンプルなので↑と両立している）
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            // （クエリパラメータにnameが無かった場合）Bodyがパースできていればname値取得
            name = name ?? data?.name;

            // nameが無ければ無い旨を、あればname含む文章をレスポンスメッセージに設定
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
