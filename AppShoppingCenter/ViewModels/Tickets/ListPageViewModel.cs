using AppShoppinCenter.Models;
using AppShoppingCenter.Libraries.Storages;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    public partial class ListPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Ticket> _ticketList;

        public ListPageViewModel()
        {
            var service = App.Current.Handler.MauiContext.Services.GetService<TicketPreferenceStorage>();

            TicketList = service.Load();
        }
    }
}
