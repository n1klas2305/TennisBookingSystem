namespace WebApi.Services.Court;

using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Courts;

public interface ICourtService
{
  IEnumerable<Court> GetAll();
  Court GetById(int id);
  void Create(CreateRequest model);
  void Update(int id, UpdateRequest model);
  void Delete(int id);
}

public class CourtService : ICourtService
{
  private DataContext _context;
  private readonly IMapper _mapper;

  public CourtService(
      DataContext context,
      IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public IEnumerable<Court> GetAll()
  {
    return _context.Courts;
  }

  public Court GetById(int id)
  {
    return getCourt(id);
  }

  public void Create(CreateRequest model)
  {
    // validate
    if (_context.Courts.Any(b => b.CourtId == model.CourtId))
      throw new AppException("Court with the id '" + model.CourtId + "' already exists");

    // map model to new court object
    var court = _mapper.Map<Court>(model);

    // save court
    _context.Courts.Add(court);
    _context.SaveChanges();
  }

  public void Update(int id, UpdateRequest model)
  {
    var court = getCourt(id);

    // copy model to court and save
    _mapper.Map(model, court);
    _context.Courts.Update(court);
    _context.SaveChanges();
  }

  public void Delete(int id)
  {
    var court = getCourt(id);
    _context.Courts.Remove(court);
    _context.SaveChanges();
  }

  // helper methods
  private Court getCourt(int id)
  {
    var court = _context.Courts.Find(id);
    if (court == null) throw new KeyNotFoundException("Court not found");
    return court;
  }
}