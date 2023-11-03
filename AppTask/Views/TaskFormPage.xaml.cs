using AppTask.Data.Repositories;
using AppTask.Models;
using AppTask.Services;
using System.Reactive.Linq;
using System.Text;

namespace AppTask.Views;

public partial class TaskFormPage : ContentPage
{
    private readonly TaskService _taskService;
    private IObservable<TaskModel> _taskObservable;
    private IObservable<List<SubTaskModel>> _subTasksObservable;
    private TaskModel _task;
    private IDisposable _subscription;
    private IDisposable _subscription2;
    private IDisposable _subscription3;

    public TaskFormPage(
        TaskService taskService)
	{
		InitializeComponent();
        _taskService = taskService;
        _taskObservable = _taskService.GetTask();
        _subTasksObservable = _taskService.GetSubTasks();
        CheckStorageTask();
        CheckStorageSubTaskList();
	}

    

    private void FillFields()
    {
        Entry_TaskName.Text = _task.Name;
        Editor_TaskDescription.Text = _task.Description;
        DatePicker_TaskDate.Date = _task.PrevisionDate;

    }

    private void CheckStorageTask()
    {
        _subscription = _taskObservable.Subscribe(
            task =>
        {
            _task = task;
            if (task.Id == 0)
                return;
            FillFields();
            _taskService.SetSubTasksList(_task.Subtasks);
            
            
        });
    }
    
    private void CheckStorageSubTaskList()
    {
        _subscription2 = _subTasksObservable.Subscribe(
            subs =>
        {
            BindableLayout.SetItemsSource(BindableLayout_Steps, subs);
        });
    }

    private async void CloseModal(object sender, EventArgs e)
    {
        GetDataFromForm();
        if (ValidateData())
        {
            SaveData();
            
        }
        await Navigation.PopModalAsync();
    }

    private void GetDataFromForm()
    {
        _task.Name = Entry_TaskName.Text;
        _task.Description = Editor_TaskDescription.Text;
        _task.PrevisionDate = DatePicker_TaskDate.Date;
        _task.Created = DateTime.Now;
        _task.IsCompleted = false;
    }

    private bool ValidateData()
    {
        bool validResult = true;

        if(string.IsNullOrWhiteSpace(_task.Name))
        {
            Lbl_TaskNameAlert.IsVisible = true;
            validResult = false;
        }
        if (string.IsNullOrWhiteSpace(_task.Description))
        {
            Lbl_TaskDescriptionAlert.IsVisible = true;
            validResult = false;
        }

        return validResult;
    }

    private async void SaveData()
    {
        if(_task.Id == 0)
           await _taskService.AddTaskModel(_task);
        else
            await _taskService.UpdateTaskModel(_task);
    }

    private async void AddStep(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa(subtarefa)", "Digite o nome da Etapa(subtarefa):", "Adicionar", "Cancelar");

        if (!string.IsNullOrWhiteSpace(stepName))
        {
            var subtask = new SubTaskModel { Name = stepName, IsCompleted = false };
            _taskService.AddSubTaskModel(subtask);
            _task.Subtasks.Add(subtask);
        }

    }

    private void CreateAddStepObservable()
    {
        Observable.FromEventPattern<EventHandler, EventArgs>(
            handler => Btn_AddStep.Clicked += handler,
            handler => Btn_AddStep.Clicked -= handler
            ).Do(async (e) =>
            {
                var stepName = await DisplayPromptAsync("Etapa(subtarefa)", "Digite o nome da Etapa(subtarefa):", "Adicionar", "Cancelar");

                if (!string.IsNullOrWhiteSpace(stepName))
                {
                    var subtask = new SubTaskModel { Name = stepName, IsCompleted = false };
                    _taskService.AddSubTaskModel(subtask);
                    _task.Subtasks.Add(subtask);
                }
            });
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);

        DatePicker_TaskDate.WidthRequest = width - 40;

    }

    private void OnDelete(object sender, TappedEventArgs e)
    {
        var subTask = (SubTaskModel)e.Parameter;
        _taskService.RemoveSubTaskModel(subTask);
        _task.Subtasks.Remove(subTask);

    }

    protected override void OnDisappearing()
    {

        _subscription?.Dispose();
        _subscription2?.Dispose();
        _taskService.ClearCurrentTaskState();
        base.OnDisappearing();
    }
}