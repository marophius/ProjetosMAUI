

using AppShoppingCenter.Views.Tickets;

namespace AppShoppingCenter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("stores/detail", typeof(Views.Stores.DetailPage));
            Routing.RegisterRoute("restaurants/detail", typeof(Views.Restaurants.DetailPage));
            Routing.RegisterRoute("cinemas/detail", typeof(Views.Cinemas.DetailPage));
            Routing.RegisterRoute("cinemas/detaildesktop", typeof(Views.Cinemas.DetailDesktopPage));
            Routing.RegisterRoute("tickets/pay", typeof(PayPage));
            Routing.RegisterRoute("tickets/list", typeof(ListPage));
            Routing.RegisterRoute("tickets/result", typeof(ResultPage));
            Routing.RegisterRoute("tickets/camera", typeof(CameraPage));
        }
    }
}