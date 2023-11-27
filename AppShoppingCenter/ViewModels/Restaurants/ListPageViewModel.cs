using AppShoppinCenter.Models;
using AppShoppingCenter.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Restaurants
{
    public partial class ListPageViewModel : ObservableObject
    {
        private List<Establishment> _fullEstablishMentList;

        [ObservableProperty]
        private string textSearch;

        [ObservableProperty]
        private List<Establishment> _filteredEstablishMentList;

        private readonly RestaurantService _restaurantService;

        public ListPageViewModel()
        {
            _restaurantService = App.Current.Handler.MauiContext.Services.GetRequiredService<RestaurantService>();
            _fullEstablishMentList = _restaurantService.GetRestaurants();
            _filteredEstablishMentList = _fullEstablishMentList.ToList();   
        }

        [RelayCommand]
        private void TextChangedToSearch()
        {
            FilteredEstablishMentList = _fullEstablishMentList.Where(e => e.Name.ToLower().Contains(TextSearch.ToLower())).ToList();
        }

        [RelayCommand]
        private async Task NavigateToDetailPage(Establishment est)
        {
            var dictionary = new Dictionary<string, object>()
            {
                {"establishment", est }
            };

            await Shell.Current.GoToAsync("detail", dictionary);
        }
    }
}
