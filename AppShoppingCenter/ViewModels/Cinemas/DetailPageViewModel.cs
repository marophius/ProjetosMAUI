﻿using AppShoppinCenter.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Cinemas
{
    [QueryProperty(nameof(Movie), "movie")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Movie movie;


        [RelayCommand]
        private void OnTapToListPage()
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
