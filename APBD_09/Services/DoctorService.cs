namespace APBD_09.Services;

public class DoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Doctor> GetDoctorByIdAsync(int id)
    {
        return await _doctorRepository.GetDoctorByIdAsync(id);
    }
}