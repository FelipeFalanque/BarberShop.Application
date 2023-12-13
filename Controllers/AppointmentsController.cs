using BarberShop.Application.BarberShop.Data.Repositories;
using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.BarberShop.Domain.Services;
using BarberShop.Application.Business;
using BarberShop.Application.Models;
using BarberShop.Application.ServicesHubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BarberShop.Application.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<AppointmentsController> _logger;
        private readonly IAppointmentService _appointmentService;
        private readonly ISettingsRepository _settingsRepository;
        private readonly IServiceAppointmentHub _serviceAppointmentHub;

        public AppointmentsController(ILogger<AppointmentsController> logger, IAppointmentService appointmentService, ISettingsRepository settingsRepository, IServiceAppointmentHub serviceAppointmentHub)
        {
            _logger = logger;
            _appointmentService = appointmentService;
            _settingsRepository = settingsRepository;
            _serviceAppointmentHub = serviceAppointmentHub;
        }

        [HttpGet]
        public IActionResult Appointments()
        {
            var appointmentsVw = new AppointmentsBusiness(_appointmentService, _settingsRepository).GetAppointments();
            return Ok(appointmentsVw);
        }

        [HttpGet("{id}")]
        public IActionResult Appointments(string id)
        {
            var appointmentsVw = new AppointmentsBusiness(_appointmentService, _settingsRepository).GetAppointments();
            return Ok(appointmentsVw);
        }

        [HttpPost]
        public async Task<IActionResult> Appointments([FromBody] CreateAppointmentViewModel newAppointment)
        {

            _logger.LogInformation("api/appointments [HttpPost]");

            if (_appointmentService.IsAvailable(newAppointment.AppointmentCode))
            {
                var claims = HttpContext.User.Claims;
                string code = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Hash).Value;

                Appointment appointment = newAppointment.GetAppointmentBD(newAppointment.AppointmentCode);
                appointment.ClientCode = code;

                _appointmentService.Add(appointment);
            }

            // Envie uma mensagem para os clientes conectados
            await _serviceAppointmentHub.SendAppointmentConfirmedAllClients(newAppointment.AppointmentCode);


            return Ok();
        }

        [HttpPost("/api/appointments/cancel")]
        public IActionResult Cancel([FromBody] string code)
        {

            var appointment = _appointmentService.Get(code);

            if (appointment != null)
            {
                appointment.Canceled = true;

                _appointmentService.Edit(appointment);
            }

            return Ok("Sucesso");
        }
    }
}
