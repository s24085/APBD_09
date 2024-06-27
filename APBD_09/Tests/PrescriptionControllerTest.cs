using APBD_09.Controllers;
using APBD_09.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_09.Tests;

public class PrescriptionsControllerTests
{
    private readonly ApplicationDbContext _context;
    private readonly PrescriptionsController _controller;

    public PrescriptionsControllerTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new ApplicationDbContext(options);
        _controller = new PrescriptionsController(_context);
    }

    [Fact]
    public async Task AddPrescription_ReturnsOkResult()
    {
        var request = new PrescriptionRequest
        {
            Patient = new PatientRequest { FirstName = "John", LastName = "Doe", BirthDate = DateTime.Now },
            Medicaments = new List<MedicamentRequest> { new MedicamentRequest { IdMedicament = 1, Dose = 1, Details = "Test" } },
            Date = DateTime.Now,
            DueDate = DateTime.Now.AddDays(7),
            IdDoctor = 1
        };

        var result = await _controller.AddPrescription(request);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task GetPatientPrescriptions_ReturnsNotFound()
    {
        var result = await _controller.GetPatientPrescriptions(999);

        Assert.IsType<NotFoundResult>(result);
    }

    // Add more tests to cover other scenarios and edge cases
}
