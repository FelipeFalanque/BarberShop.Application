using Microsoft.AspNetCore.SignalR;

namespace BarberShop.Application.Hubs
{
    public class AppointmentHub : Hub
    {
        public async Task SendAppointmentConfirmed(string appointmentCode)
        {
            await Clients.All.SendAsync("ReceiveAppointmentConfirmed", appointmentCode);
        }
    }
}
