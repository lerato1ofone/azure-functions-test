using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PracticalTest.Services.Persons;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace PracticalTest.Functions
{
    public class PersonsFunction
    {
        private readonly IPersonsService _personsService;

        public PersonsFunction(IPersonsService personsService)
        {
            _personsService = personsService;
        }


        [OpenApiOperation(operationId: "getPersons", tags: new[] { "Person" }, Summary = "Gets persons", Description = "This gets a list of people.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Models.Person), Summary = "The response", Description = "This returns the response")]
        [FunctionName("persons")]
        public async Task<IActionResult> Run(
          [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
          ILogger log)
        {
            log.LogInformation("Getting people");

            var Employees = await _personsService.GetPeople();

            return Employees != null
                ? (ActionResult)new OkObjectResult(Employees)
                : new NoContentResult();
        }
    }
}
