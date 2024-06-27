using APBD_09.Models;

namespace APBD_09.Repositories

{
    public interface IPrescriptionRepository
    {
        Task<Prescription> GetPrescriptionByIdAsync(int id);
        Task AddPrescriptionAsync(Prescription prescription);
        Task<bool> MedicamentExistsAsync(int idMedicament);
    }
}