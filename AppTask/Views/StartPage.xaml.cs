using AppTask.Data.Repositories;
using AppTask.Models;
using AppTask.Services;
using System.Reactive;
using System.Reactive.Linq;

namespace AppTask.Views;

public partial class StartPage : ContentPage
{
    private IObservable<List<TaskModel>> _tasksObservable;
    private readonly TaskService _taskService;
    private IDisposable _subscription;
    private IDisposable _subscription2;

	public StartPage(TaskService taskService)
	{
		InitializeComponent();
        _taskService = taskService;
        _tasksObservable = _taskService.GetAllTasks();
        
	}

    protected override void OnAppearing()
    {
        GetTasksSwitch();
        base.OnAppearing();
    }

    private void GetTasksSwitch()
    {
        _subscription = Observable.FromEventPattern<TextChangedEventArgs>(
            handler => Entry_Search.TextChanged += handler,
            handler => Entry_Search.TextChanged -= handler
            )
            .StartWith(new EventPattern<TextChangedEventArgs>(Entry_Search, new TextChangedEventArgs("", "")))
            .Select(x =>
            {
                var searchString = x.EventArgs.NewTextValue.ToLower();
                if (string.IsNullOrEmpty(searchString) || string.IsNullOrWhiteSpace(searchString))
                {
                    return _tasksObservable;
                }

                return _tasksObservable
                                    .Select(taskList => taskList
                                                            .Where(t => t.Name.ToLower().Contains(searchString))
                                                            .ToList());
            })
            .Switch()
            .Do(val =>
            {
                CollectionViewTasks.ItemsSource = val;
                LblEmptyText.IsVisible = val.Count <= 0;
            })
            .Catch<List<TaskModel>, Exception>(tx =>
            {
                DisplayAlert("Ops!!!", $"Houve um erro ao carregar a lista: {tx.Message}", "Ok");
                return Observable.Return(new List<TaskModel>());
            })
            .Subscribe();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new TaskFormPage(_taskService));
    }

    private void OnBorderClickedToFocusEntry(object sender, TappedEventArgs e)
    {
        Entry_Search.Focus();
    }

    private async void OnDelete(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        var confimacao = await DisplayAlert("Confirme a exclusão!", $"Tem certeza que deseja realmente excluir essa tarefa: {task.Name}?", "Sim", "Não");
        if (confimacao)
        {
            await _taskService.RemoveTaskModel(task.Id);
        }
            
    }

    private async void OnChangeTaskStatus(object sender, TappedEventArgs e)
    {
        var checkbox = ((CheckBox)sender);
        var task = (TaskModel)e.Parameter;

        if (DeviceInfo.Platform != DevicePlatform.WinUI)
            checkbox.IsChecked = !checkbox.IsChecked;

        task.IsCompleted = checkbox.IsChecked;
        await _taskService.UpdateTaskModel(task);
    }

    private async void OnTapToEdit(object sender, TappedEventArgs e)
    {
        var task = (TaskModel)e.Parameter;
        _taskService.SetTaskModelToEdit(task);
        await Navigation.PushModalAsync(new TaskFormPage(_taskService));
    }

    

    protected override void OnDisappearing()
    {
        _subscription?.Dispose();
        _subscription2?.Dispose();
        base.OnDisappearing();
    }
}