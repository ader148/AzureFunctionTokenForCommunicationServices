using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Net;
using Microsoft.Extensions.Primitives;
using Azure;
using Azure.Communication;
using Azure.Communication.Identity;

namespace GetIdUserBex
{
    public static class GetIdUserBex
    {
        [FunctionName("GetIdUserBex")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            string CadenaTest = "endpoint=https://llamadastest.communication.azure.com/;accesskey=faCJfhhq88HKovj5eStQNUSMBFws+Gy+izq6jC4RzfavzPiA9lXxGzR81w+Zu1AVt5W/wyozBce8iEaR7ULynQ==";

            //nuevo funcion
            log.LogInformation("Creando un identidad ASC y emitiendo token");
            //CommunicationIdentityClient client = new CommunicationIdentityClient(Environment.GetEnvironmentVariable("ACS_Connection_String"));
            CommunicationIdentityClient client = new CommunicationIdentityClient(CadenaTest);
            var tokenResponse = await client.CreateUserAndTokenAsync(scopes: new[] { CommunicationTokenScope.VoIP });
            return new OkObjectResult(tokenResponse);
            //fin


        }
    }
}
