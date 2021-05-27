using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTest.Services.Employee
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(ApplicationDbContext dbContext, ILogger<EmployeeService> logger) : base(dbContext)
        {
            this._logger = logger;
        }

        public async Task<IEnumerable<Models.Employee>> GetEmployees()
        {
            try
            {
                return await _dbContext.Employee.ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}