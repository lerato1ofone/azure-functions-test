using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PracticalTest.Services.Employee;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using System.Net;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace PracticalTest.Functions
{
    public class EmployeesFunction
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesFunction(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [OpenApiOperation(operationId: "getEmployees", tags: new[] { "Employees" }, Summary = "Gets employees", Description = "This gets a list of employees.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Models.Employee), Summary = "The response", Description = "This returns the response")]
        [FunctionName("employees")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Getting employees");

            var Employees = await _employeeService.GetEmployees();

            return Employees != null
                ? (ActionResult)new OkObjectResult(Employees)
                : new NoContentResult();
        }
    }
}