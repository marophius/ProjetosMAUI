using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIGallery.Views.CommunityToolkit.ViewModels
{
    public class CommunityBehaviorPageViewModel
    {
        public ICommand PressedCommand { get; set; }

        public CommunityBehaviorPageViewModel()
        {
            PressedCommand = new Command(() =>
            {
                App.Current.MainPage.DisplayAlert("Fui pressionado!", "Fui pressionado!", "OK");
            });
        }
    }
}
