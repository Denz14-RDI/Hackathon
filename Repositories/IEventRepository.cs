using System.Collections.Generic;
using System.Threading.Tasks;
using EventManagementSystem.Models;

namespace EventManagementSystem.Repositories
{
    public interface IEventRepository
    {
        // Event CRUD
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task AddEventAsync(Event ev);
        Task UpdateEventAsync(Event ev);
        Task DeleteEventAsync(int id);

        // Inline Budgets
        Task AddBudgetAsync(Budget budget);
        Task DeleteBudgetAsync(int id);

        // Inline Tasks
        Task AddTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int id);
        Task UpdateTaskItemStatusAsync(int id, string status);
    }
}

