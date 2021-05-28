using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Services.PersonalRecords
{
    public class PersonalRecordsService : IPersonalRecordsService
    {
        public Task<Models.DTO.PersonalRecords> GetPersonalRecords(string employeeNumber)
        {
            throw new NotImplementedException();
        }
    }
}