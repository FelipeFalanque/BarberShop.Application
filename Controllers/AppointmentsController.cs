using BarberShop.Application.BarberShop.Domain.Interfaces;
using BarberShop.Application.Business;
using BarberShop.Application.Models;
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

        public AppointmentsController(ILogger<HomeController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
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
        public IActionResult Appointments([FromBody] ModelData data)//(CreateAppointmentViewModel newAppointment)
        {

            _logger.LogInformation("api/appointments/CreateProduct");

            return Ok();
        }
    }

    public class ModelData
    {
        public string Chave1 { get; set; }

        public string Chave2 { get; set; }

        public ModelData()
        {
            
        }
    }
}
