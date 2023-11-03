using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Data.Repositories
{
    public interface ITaskModelRepository
    {
        // CRUD
        Task<List<TaskModel>> GetTasks();
        Task<TaskModel> GetTaskById(int taskId);
        Task Add(TaskModel task);
        Task Update(TaskModel task);
        Task Delete(int taskId);
    }
}
