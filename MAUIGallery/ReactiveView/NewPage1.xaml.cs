
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MAUIGallery.ReactiveView;

public partial class NewPage1 : ContentPage
{
	private IObservable<int> _decimalCount;
	private ISubject<long> _countSubject;
	public NewPage1()
	{
		InitializeComponent();

		var sub1 = Observable.Interval(TimeSpan.FromSeconds(1));
		var sub2 = sub1.Select(x => Observable.Range(1, (int)x)).Switch();

	}
}