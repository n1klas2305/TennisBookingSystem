using Microsoft.AspNetCore.Mvc;
using TennisBookingApi.DbRepo;

namespace TennisBookingApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourtController : ControllerBase
{
  private readonly ScottDbContext dbContext;

  public CourtController(ScottDbContext dbContext)
  {
    this.dbContext = dbContext;
  }

  [HttpGet]
  public IEnumerable<Court> getCourts()
  {
    return dbContext.Courts.ToList();
  }
}


