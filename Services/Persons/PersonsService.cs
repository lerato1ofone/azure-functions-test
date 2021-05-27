using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace PracticalTest.Services.Persons
{
    public class PersonsService : BaseService, IPersonsService
    {
        private readonly ILogger<PersonsService> _logger;
        public PersonsService(ApplicationDbContext dbContext, ILogger<PersonsService> logger) : base(dbContext)
        {
            this._logger = logger;
        }

        public async Task<IEnumerable<Models.Person>> GetPeople()
        {
            try
            {
                return await _dbContext.Person.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}