using TaskManagement.Api.Models;
using TaskManagement.Api.Repositories;

namespace TaskManagement.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TaskItem>> GetAllTasks()
            => await _repo.GetAllAsync();

        public async Task<TaskItem?> GetTask(int id)
            => await _repo.GetByIdAsync(id);

        public async Task<TaskItem> CreateTask(TaskItem task)
            => await _repo.AddAsync(task);

        public async Task<bool> UpdateTask(int id, TaskItem task)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.IsCompleted = task.IsCompleted;

            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteTask(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return false;

            await _repo.DeleteAsync(task);
            return true;
        }
    }
}