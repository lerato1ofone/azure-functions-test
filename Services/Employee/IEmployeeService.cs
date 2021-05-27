using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalTest.Services.Employee
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Models.Employee>> GetEmployees();
    }
}
