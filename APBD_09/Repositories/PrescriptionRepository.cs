

namespace APBD_09.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public PrescriptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Prescription> GetPrescriptionByIdAsync(int id)
        {
            return await _context.Prescriptions
                .Include(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
                .FirstOrDefaultAsync(p => p.IdPrescription == id);
        }

        public async Task AddPrescriptionAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> MedicamentExistsAsync(int idMedicament)
        {
            return await _context.Medicaments.AnyAsync(m => m.IdMedicament == idMedicament);
        }
    }
}