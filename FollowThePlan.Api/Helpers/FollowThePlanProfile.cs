using AutoMapper;
using FollowThePlan.Api.DTO;
using FollowThePlan.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FollowThePlan.Api.Helpers
{
    public class FollowThePlanProfile : Profile
    {
        public FollowThePlanProfile()
        {
            CreateMap<Personal, PersonalDTO>()
                    .ForMember(
                            dest => dest.Nome,
                            opt => opt.MapFrom(src => $"{src.Nome}")
                        )
                    .ForMember(
                            dest => dest.Idade,
                            opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                    );

            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteRegisterDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>()
               .ForMember(
                       dest => dest.Nome,
                       opt => opt.MapFrom(src => $"{src.Nome}")
                   )
               .ForMember(
                       dest => dest.Idade,
                       opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
               );

            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteRegisterDTO>().ReverseMap();

        }
    }
}
