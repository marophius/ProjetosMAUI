
using MAUIGallery.Models;
using MAUIGallery.Repositories;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MAUIGallery.Views;

public partial class MainPage : ContentPage
{
    private IGroupComponentRepository _repository;
    private BehaviorSubject<List<Component>> _fullList;
    private IObservable<List<Component>> _list;
    private IDisposable _subscription1;
	public MainPage()
	{
		InitializeComponent();

        _repository = new GroupComponentRepository();
        _fullList = new BehaviorSubject<List<Component>>(_repository.GetComponents());
        _list = _fullList.AsObservable();
        CreateObservableSwitchMap();
	}

    private void OnTapComponent(object sender, TappedEventArgs e)
    {
        var component = (Component)e.Parameter;

        if (component.IsReplaceMainPage == false)
        {
            ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage((Page)Activator.CreateInstance(component.Page));
            ((FlyoutPage)App.Current.MainPage).IsPresented = false;
        }
        else
        {
            App.Current.MainPage = (Page)Activator.CreateInstance(component.Page);
        }

    }

    private void CreateObservableSwitchMap()
    {
        // CONSIDERAR USAR CARREGAMENTO SOB DEMANDA PARA OTIMIZAR O USO DE MEMÓRIA EM CASO DE UMA LISTA DE DADOS MUITO GRANDE!
        _subscription1 = Observable.FromEventPattern<TextChangedEventArgs>(
            handler => EntryControl.TextChanged += handler,
            handler => EntryControl.TextChanged -= handler
            )
            .StartWith(new EventPattern<TextChangedEventArgs>(EntryControl, new TextChangedEventArgs("","")))
            .Select(x =>
            {
                if(string.IsNullOrEmpty(x.EventArgs.NewTextValue))
                {
                    return _list;
                }
                return _list.Select(list => list.Where(a => a.Title.ToLower().Contains(x.EventArgs.NewTextValue.ToLower())));
            })
            .Switch()
            .Subscribe(val =>
            {
                ComponentCollection.ItemsSource = val;
            });
    }

    protected override void OnDisappearing()
    {
        _fullList = null;
        _subscription1?.Dispose();
        base.OnDisappearing();
    }
}