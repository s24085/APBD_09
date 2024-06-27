using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyMedicalApp.Services;

namespace APBD_09.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var doctor = await _service.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
    }
}