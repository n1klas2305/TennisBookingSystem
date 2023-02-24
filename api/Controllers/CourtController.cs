namespace WebApi.Controllers.Court;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Courts;
using WebApi.Services.Court;

[ApiController]
[Route("[controller]")]
public class CourtsController : ControllerBase
{
  private ICourtService _courtService;
  private IMapper _mapper;

  public CourtsController(
      ICourtService courtService,
      IMapper mapper)
  {
    _courtService = courtService;
    _mapper = mapper;
  }

  [HttpGet]
  public IActionResult GetAll()
  {
    var courts = _courtService.GetAll();
    return Ok(courts);
  }

  [HttpGet("{id}")]
  public IActionResult GetById(int id)
  {
    var court = _courtService.GetById(id);
    return Ok(court);
  }

  [HttpPost]
  public IActionResult Create(CreateRequest model)
  {
    _courtService.Create(model);
    return Ok(new { message = "Court created" });
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, UpdateRequest model)
  {
    _courtService.Update(id, model);
    return Ok(new { message = "Court updated" });
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    _courtService.Delete(id);
    return Ok(new { message = "Court deleted" });
  }
}