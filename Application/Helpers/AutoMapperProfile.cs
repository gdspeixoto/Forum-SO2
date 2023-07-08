﻿using Application.Dto;
using AutoMapper;
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
            CreateMap<Resposta, RespostaDto>().ReverseMap();
            CreateMap<Pergunta, PerguntaDto>().ReverseMap();
        }
    }
}
