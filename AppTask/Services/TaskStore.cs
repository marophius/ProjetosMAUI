using AppTask.Data.Repositories;
using AppTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace AppTask.Services
{
    public class TaskStore
    {
        private readonly BehaviorSubject<List<TaskModel>> _tasksSubject;
        private readonly BehaviorSubject<TaskModel> _taskSubject;
        private readonly BehaviorSubject<List<SubTaskModel>> _subTasksSubject;
        public IObservable<List<TaskModel>> Tasks;
        public IObservable<TaskModel> TaskObservable;
        public IObservable<List<SubTaskModel>> SubTasksModel;

        public TaskStore()
        {
            _tasksSubject = new BehaviorSubject<List<TaskModel>>(new List<TaskModel>());
            _taskSubject = new BehaviorSubject<TaskModel>(new TaskModel());
            _subTasksSubject = new BehaviorSubject<List<SubTaskModel>>(new List<SubTaskModel>());
            Tasks = _tasksSubject.AsObservable();
            TaskObservable = _taskSubject.AsObservable();
            SubTasksModel = _subTasksSubject.AsObservable();
        }

        public void SetTaskModelSubject(TaskModel task)
        {
            _taskSubject.OnNext(task);
        }

        public void UpdateSubTasks(Func<List<SubTaskModel>, List<SubTaskModel>> updateFunction) 
        {
            var list = _subTasksSubject.Value;
            var newSubtasks = updateFunction(list);
            _subTasksSubject.OnNext(newSubtasks);
        }

        public void UpdateTasks(Func<List<TaskModel>, List<TaskModel>> updateFunction)
        {
            var list = _tasksSubject.Value;
            var newTasks = updateFunction(list);
            _tasksSubject.OnNext(newTasks);
        }

        public void ClearFullState()
        {
            _tasksSubject?.Dispose();
            _taskSubject?.Dispose();
            _subTasksSubject?.Dispose();
        }
        
    }
}
