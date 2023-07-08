﻿using Application.Dto;
using Application.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IExemploService
    {
        public Task<ExemploDto[]> GETAllExemplo(int pulo, int limite, ExemploFiltroDto filtro);
    }
}
