using AppTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Data.Repositories
{
    public class TaskModelRepository : ITaskModelRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TaskModel task)
        {
            _context.Tasks.Add(task);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int taskId)
        {
            await _context.SubTasks.Where(x => x.TaskId == taskId)
                .ExecuteDeleteAsync();
            await _context.Tasks.Where(x => x.Id == taskId).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<TaskModel> GetTaskById(int taskId)
        {
            var  task = await _context.Tasks.Include(a => a.Subtasks).FirstOrDefaultAsync(x => x.Id == taskId);

            return task;
        }

        public async Task<List<TaskModel>> GetTasks()
        {
            return await _context.Tasks.OrderByDescending(x => x.PrevisionDate).ToListAsync();
        }

        public async Task Update(TaskModel task)
        {
            _context.Tasks.Update(task);

            await _context.SaveChangesAsync();
        }
    }
}
