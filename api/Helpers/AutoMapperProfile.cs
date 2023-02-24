namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    // CreateRequest -> Booking
    CreateMap<Models.Bookings.CreateRequest, Booking>();

    // UpdateRequest -> Booking
    CreateMap<Models.Bookings.UpdateRequest, Booking>()
        .ForAllMembers(x => x.Condition(
            (src, dest, prop) =>
            {
              // ignore both null & empty string properties
              if (prop == null) return false;
              if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

              return true;
            }
        ));
    // CreateRequest -> Court
    CreateMap<Models.Courts.CreateRequest, Court>();

    // UpdateRequest -> Court
    CreateMap<Models.Courts.UpdateRequest, Court>()
        .ForAllMembers(x => x.Condition(
            (src, dest, prop) =>
            {
              // ignore both null & empty string properties
              if (prop == null) return false;
              if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

              return true;
            }
        ));
  }
}