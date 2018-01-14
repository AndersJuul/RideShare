using Ajf.RideShare.Models;
using AutoMapper;

namespace Ajf.RideShare.Api
{
    public static class AutoMapperInitializor
    {
        public static void Init()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EventForCreation, Event>()
                    .ForMember(o => o.Cars, o => o.Ignore())
                    .ForMember(o => o.EventId, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore());
                cfg.CreateMap<CarForCreation, Car>()
                    .ForMember(o => o.CarId, o => o.Ignore())
                    //.ForMember(o=> o.Email, o=>o.MapFrom(sm=>sm.Email))
                    ;
            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}