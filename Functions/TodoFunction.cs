using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PracticalTest.Services.Todo;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PracticalTest.Functions
{
    public class TodoFunction
    {
        private readonly ILogger<TodoFunction> _logger;

        private readonly ITodoService _todoService;

        public TodoFunction(ITodoService todoService, ILogger<TodoFunction> logger)
        {
            this._todoService = todoService;
            this._logger = logger;
        }

        [OpenApiOperation(operationId: "getTodo", tags: new[] { "Todo" }, Summary = "Gets a todo", Description = "This gets a todo.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "id", In = ParameterLocation.Query, Required = false, Type = typeof(int), Summary = "The id", Description = "The todo's id", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Models.Todo), Summary = "The response", Description = "This returns the response")]
        [FunctionName("todo")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            try
            {
                int.TryParse(req.Query["id"][0], out int id);

                var todo = await _todoService.GetTodo(id);

                return todo != null
                    ? (ActionResult)new OkObjectResult(todo)
                    : new NotFoundObjectResult($"Todo with id {id} could not found.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}