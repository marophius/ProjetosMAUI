using AppShoppinCenter.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Stores
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string textSearch;

        private List<Establishment> establishmentsFull;
        [ObservableProperty]
        private List<Establishment> establishmentsFiltered;

        private readonly StoreService _storeService;

        public ListPageViewModel()
        {
            _storeService = App.Current.Handler.MauiContext.Services.GetService<StoreService>();
            establishmentsFull = _storeService.GetStores();
            establishmentsFiltered = establishmentsFull.ToList();
        }

        [RelayCommand]
        private void TextSearchInList()
        {
            EstablishmentsFiltered = establishmentsFull.Where(e => e.Name.ToLower().Contains(TextSearch.ToLower())).ToList();
        }

        [RelayCommand]
        private async Task TapEstablishMentGoToDetailPage(Establishment est)
        {
            var navigationParameter = new Dictionary<string, object>()
            {
                {"establishment", est }
            };
            await Shell.Current.GoToAsync("detail", navigationParameter);
        }
    }
}
