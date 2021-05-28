using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PracticalTest.Services.PersonalRecords;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PracticalTest.Functions
{
    public class PersonalRecordsFunction
    {
        private readonly ILogger<PersonalRecordsFunction> _logger;

        private readonly IPersonalRecordsService _personalRecordsService;

        public PersonalRecordsFunction(IPersonalRecordsService service, ILogger<PersonalRecordsFunction> logger)
        {
            this._personalRecordsService = service;
            this._logger = logger;
        }

        [OpenApiOperation(operationId: "getPersonalRecords", tags: new[] { "Todo" }, Summary = "Gets personal records based on an employee number", Description = "This gets personal record.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "employeeNumber", In = ParameterLocation.Query, Required = false, Type = typeof(string), Summary = "The employee number", Description = "The employee number", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Models.DTO.PersonalRecords), Summary = "The response", Description = "This returns the response")]
        [FunctionName("getPersonalRecords")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            try
            {
                var employeeNumber = req.Query["employeeNumber"][0];

                if (String.IsNullOrEmpty(employeeNumber))
                    return new BadRequestObjectResult("Please provide an employee number.");

                var personalRecords = await _personalRecordsService.GetPersonalRecords(employeeNumber);

                return personalRecords != null
                  ? (ActionResult)new OkObjectResult(personalRecords)
                  : new NotFoundObjectResult($"Personal records not found for employee number {employeeNumber}.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}