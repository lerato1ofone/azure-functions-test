using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalTest.Services.Persons
{
    public interface IPersonsService
    {
        Task<IEnumerable<Models.Person>> GetPeople();
    }
}
