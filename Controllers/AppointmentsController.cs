using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Business;
using BarberShop.Application.Models;
using BarberShop.Application.ServicesHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceAppointmentHub _serviceAppointmentHub;

        public AppointmentsController(ILogger<HomeController> logger, IAppointmentService appointmentService, IServiceAppointmentHub serviceAppointmentHub)
        {
            _logger = logger;
            _appointmentService = appointmentService;
            _serviceAppointmentHub = serviceAppointmentHub;
        }

        [HttpGet]
        public IActionResult Appointments()
        {
            _logger.LogInformation("HoursWithAppointments");

            var appointmentsVw = new Appointments(_appointmentService).GetAppointments();
            return Ok(appointmentsVw);
        }

        [HttpGet("{id}")]
        public IActionResult Appointments(string id)
        {
            _logger.LogInformation("HoursWithAppointments");

            var appointmentsVw = new Appointments(_appointmentService).GetAppointments();
            return Ok(appointmentsVw);
        }

        [HttpPost]
        public async Task<IActionResult> Appointments([FromBody] CreateAppointmentViewModel newAppointment)
        {

            _logger.LogInformation("api/appointments/CreateProduct");

            // Envie uma mensagem para os clientes conectados
            await _serviceAppointmentHub.SendAppointmentConfirmedAllClients("VEIO DO SERVER " + newAppointment.AppointmentCode);


            return Ok();
        }
    }
}
