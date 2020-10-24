using AutoMapper;
using Rpk_back.Domain.Dtos;
using Rpk_back.Domain.Enums;
using Rpk_back.Domain.Models;

namespace Rpk_back.Domain.Profiles
{
    public class SensorConfiguration : Profile
    {
        public SensorConfiguration()
        {
            CreateMap<SensorCreateDto, Sensor>()
                .ForMember(
                    dest => dest.Localization,
                    opt => opt.MapFrom(src => (SensorLocalizationEnum) src.Localization))
                .ForMember(
                    dest => dest.SensorType,
                    opt => opt.MapFrom(src => (SensorTypeEnum) src.SensorType));
            
            CreateMap<Sensor, SensorReadDto>()
                .ForMember(
                    dest => dest.Localization,
                    opt => opt.MapFrom(src => src.Localization.ToString()))
                .ForMember(
                    dest => dest.SensorType,
                    opt => opt.MapFrom(src => src.SensorType.ToString()));
        }
    }
}