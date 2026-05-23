using System.Collections.Generic;
using System.Threading.Tasks;
using DenzelDev.Models;

namespace DenzelDev.Repositories
{
    public interface IPortfolioRepository
    {
        // Projects CRUD
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<IEnumerable<Project>> GetProjectsByCategoryAsync(string category);
        Task<Project?> GetProjectBySlugAsync(string slug);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);

        // Blogs CRUD
        Task<IEnumerable<Blog>> GetAllBlogsAsync(bool includeUnpublished = false);
        Task<Blog?> GetBlogBySlugAsync(string slug);
        Task AddBlogAsync(Blog blog);
        Task UpdateBlogAsync(Blog blog);
        Task DeleteBlogAsync(int id);

        // Skills Matrix CRUD
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
        Task AddSkillAsync(Skill skill);
        Task DeleteSkillAsync(int id);

        // Contact Capture CRUD
        Task<IEnumerable<ContactMessage>> GetAllMessagesAsync();
        Task AddMessageAsync(ContactMessage message);
        Task MarkMessageAsReadAsync(int id);

        // Event Management System (EventList) CRUD
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(int id);
        Task AddEventAsync(Event ev);
        Task UpdateEventAsync(Event ev);
        Task DeleteEventAsync(int id);

        // Inline Event Budgets
        Task AddBudgetAsync(Budget budget);
        Task DeleteBudgetAsync(int id);

        // Inline Event Tasks
        Task AddTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int id);
        Task UpdateTaskItemStatusAsync(int id, string status);
    }
}
