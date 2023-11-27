using AppShoppinCenter.Models;
using AppShoppingCenter.Libraries.Storages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShoppingCenter.ViewModels.Tickets
{
    [QueryProperty(nameof(Ticket), "ticket")]
    public partial class PayPageViewModel : ObservableObject
    {
        
        private Ticket ticket;

        public Ticket Ticket { get => ticket;
            set
            {
                GenerateDateOut(value);
                GeneratePrice(value);
                SetProperty(ref ticket, value);
            }
        }

        [ObservableProperty]
        private string pixCode = "00020126360014BR.GOV.BCB.PIX0114+5561999...";

        [RelayCommand]
        private async Task CopyAndPaste()
        {
            await Clipboard.Default.SetTextAsync(PixCode);

            await Task.Delay(3000);

            var ticketPreferences = App.Current.Handler.MauiContext.Services.GetService<TicketPreferenceStorage>();

            ticketPreferences.Save(Ticket);

            var param = new Dictionary<string, object>()
            {
                {"ticket", Ticket }
            };

            await Shell.Current.GoToAsync("../results", param);
        }

        private void GenerateDateOut(Ticket ticket)
        {
            var rd = new Random();
            var hour = rd.Next(0, 12);
            var minutes = rd.Next(0, 60);
            ticket.DateOut = ticket.DateIn.AddHours(hour).AddMinutes(minutes);
            ticket.DateTolerance = ticket.DateOut.AddMinutes(30);
        }

        private double HourValue = 0.05;
        private void GeneratePrice(Ticket ticket)
        {
            var dif = ticket.DateOut.Ticks - ticket.DateIn.Ticks;
            var difTs =  new TimeSpan(dif);

            ticket.Price = difTs.TotalMinutes* HourValue;
        }
    }
}
