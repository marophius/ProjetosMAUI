using AppTask.Data.Repositories;
using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Services
{
    public class TaskService
    {
        private readonly ITaskModelRepository _repository;
        private readonly TaskStore _taskStore;
        public TaskService(ITaskModelRepository repository, TaskStore taskStore)
        {
            _repository = repository;
            _taskStore = taskStore;
            _taskStore.UpdateTasks(taskList => _repository.GetTasks().Result);
        }
        public IObservable<List<TaskModel>> GetAllTasks()
        {
            return _taskStore.Tasks;
        }
        public IObservable<TaskModel> GetTask()
        {
            return _taskStore.TaskObservable;
        }
        public IObservable<List<SubTaskModel>> GetSubTasks()
        {
            return _taskStore.SubTasksModel;
        }
        public async Task GetTaskById(int id)
        {
            var task = await _repository.GetTaskById(id);
            _taskStore.SetTaskModelSubject(task);
        }
        public async Task UpdateTaskModel(TaskModel task)
        {
            _taskStore.UpdateTasks(tasks =>
            {
                var existingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
                if(existingTask != null)
                {
                    var index = tasks.IndexOf(existingTask);
                    tasks[index] = task;
                }

                return tasks.ToList();
            });
            await _repository.Update(task);
        }
        public async Task AddTaskModel(TaskModel task)
        {
            await _repository.Add(task);
            _taskStore.UpdateTasks(tasks =>
            {
                var newTasks = tasks.ToList();
                newTasks.Add(task);
                return newTasks;
            });
        }
        public async void SetTaskModelToEdit(TaskModel task)
        {
            var newTask = await _repository.GetTaskById(task.Id);
            _taskStore.SetTaskModelSubject(newTask);
        }
        public async Task RemoveTaskModel(int taskId)
        {
            await _repository.Delete(taskId);
            _taskStore.UpdateTasks(tasks => tasks.Where(t => t.Id != taskId).ToList());
        }
        public void SetSubTasksList(List<SubTaskModel> subTasks)
        {
            _taskStore.UpdateSubTasks(s => subTasks);
        }
        public void AddSubTaskModel(SubTaskModel subTaskModel)
        {
            _taskStore.UpdateSubTasks(subs =>
            {
                var newSubtasks = subs.ToList();
                newSubtasks.Add(subTaskModel);
                return newSubtasks;
            });
        }
        public void RemoveSubTaskModel(SubTaskModel subTaskModel)
        {
            _taskStore.UpdateSubTasks(subs =>
            {
                var newSubtasks = subs.ToList();
                newSubtasks.Remove(subTaskModel);
                return newSubtasks;
            });
        }
        public void ClearCurrentTaskState()
        {
            _taskStore.SetTaskModelSubject(new TaskModel());
            _taskStore.UpdateSubTasks(tasks => new());
        }
        public void ClearFullState()
        {
            _taskStore.ClearFullState();
        }
    }
}
