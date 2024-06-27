using System.Linq;
using System.Threading.Tasks;
using MyMedicalApp.Models;
using MyMedicalApp.Repositories;
using MyMedicalApp.DTOs;

namespace APBD_09.Services
{
    public class PrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Prescription> AddPrescriptionAsync(PrescriptionRequest request)
        {
            if (request.Medicaments.Count > 10)
            {
                throw new Exception("Prescription cannot contain more than 10 medicaments.");
            }

            var patient = await _patientRepository.GetPatientByIdAsync(request.Patient.IdPatient);
            if (patient == null)
            {
                patient = new Patient
                {
                    FirstName = request.Patient.FirstName,
                    LastName = request.Patient.LastName,
                    BirthDate = request.Patient.BirthDate
                };
                await _patientRepository.AddPatientAsync(patient);
            }

            var doctor = await _doctorRepository.GetDoctorByIdAsync(request.IdDoctor);
            if (doctor == null)
            {
                throw new Exception("Doctor not found.");
            }

            foreach (var medicament in request.Medicaments)
            {
                if (!await _prescriptionRepository.MedicamentExistsAsync(medicament.IdMedicament))
                {
                    throw new Exception($"Medicament with ID {medicament.IdMedicament} not found.");
                }
            }

            var prescription = new Prescription
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = doctor.IdDoctor,
                PrescriptionMedicaments = request.Medicaments.Select(m => new PrescriptionMedicament
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Details
                }).ToList()
            };

            await _prescriptionRepository.AddPrescriptionAsync(prescription);

            return prescription;
        }
    }
}
