using Application.Dto;
using Application.Filter;
using AutoMapper;
using Domain.Filter;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Exemplo, ExemploDto>().ReverseMap();
            CreateMap<ExemploFiltro, ExemploFiltroDto>().ReverseMap();
        }
    }
}
