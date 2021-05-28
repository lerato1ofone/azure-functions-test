using System.Threading.Tasks;

namespace PracticalTest.Services.PersonalRecords
{
    public interface IPersonalRecordsService
    {
        Task<Models.DTO.PersonalRecords> GetPersonalRecords(string employeeNumber);
    }
}