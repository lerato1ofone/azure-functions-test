using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest.Services
{
    public class BaseService
    {
        protected ApplicationDbContext _dbContext;

        /// <summary>
        /// Constructor for the base service
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public BaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
