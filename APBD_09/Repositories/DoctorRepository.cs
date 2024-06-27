

namespace APBD_09.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.IdDoctor == id);
        }
    }
}