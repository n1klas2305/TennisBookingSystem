namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Bookings;

public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    // CreateRequest -> Booking
    CreateMap<CreateRequest, Booking>();

    // UpdateRequest -> Booking
    CreateMap<UpdateRequest, Booking>()
        .ForAllMembers(x => x.Condition(
            (src, dest, prop) =>
            {
              // ignore both null & empty string properties
              if (prop == null) return false;
              if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

              // ignore null role
            //   if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

              return true;
            }
        ));
  }
}