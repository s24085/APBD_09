using System.Threading.Tasks;


namespace APBD_09.Repositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetDoctorByIdAsync(int id);
    }
}