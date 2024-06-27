namespace APBD_09.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientsController(PatientService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _service.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    } 
