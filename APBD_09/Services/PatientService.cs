namespace APBD_09.Services;

public class PatientService
{
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }
    }
