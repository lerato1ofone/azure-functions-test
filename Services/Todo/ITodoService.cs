using System.Threading.Tasks;

namespace PracticalTest.Services.Todo
{
    public interface ITodoService
    {
        Task<Models.Todo> GetTodo(int id);
    }
}