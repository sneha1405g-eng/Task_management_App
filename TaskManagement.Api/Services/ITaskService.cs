using TaskManagement.Api.Models;

namespace TaskManagement.Api.Services
{
    public interface ITaskService
    {
        Task<List<TaskItem>> GetAllTasks();
        Task<TaskItem?> GetTask(int id);
        Task<TaskItem> CreateTask(TaskItem task);
        Task<bool> UpdateTask(int id, TaskItem task);
        Task<bool> DeleteTask(int id);
    }
}