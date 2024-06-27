namespace APBD_09.Repositories

{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
    }
}