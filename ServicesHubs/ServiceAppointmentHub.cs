using BarberShop.Application.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BarberShop.Application.ServicesHubs
{
    public interface IServiceAppointmentHub
    {
        Task SendAppointmentConfirmedAllClients(string appointmentCode);
    }

    public class ServiceAppointmentHub : IServiceAppointmentHub
    {
        private readonly IHubContext<AppointmentHub> _hubContext;

        public ServiceAppointmentHub(IHubContext<AppointmentHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendAppointmentConfirmedAllClients(string appointmentCode)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveAppointmentConfirmed", appointmentCode);
        }
    }
}
