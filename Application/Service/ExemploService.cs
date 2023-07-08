using Application.Dto;
using Application.Filter;
using Application.IService;
using AutoMapper;
using Domain.Filter;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class ExemploService : IExemploService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IExemploRepository _exemploRepository;
        private readonly IMapper _mapper;

        public ExemploService(IGeralRepository geralRepository,
                              IExemploRepository exemploRepository,
                              IMapper mapper)
        {
            _geralRepository = geralRepository;
            _exemploRepository = exemploRepository;
            _mapper = mapper;
        }

        public async Task<ExemploDto[]> GETAllExemplo(int pulo, int limite, ExemploFiltroDto filtro)
        {
            try
            {
                var list_exemplo = await _exemploRepository.GETAllExemplo(pulo,limite, _mapper.Map<ExemploFiltro>(filtro));
                if (list_exemplo == null) return null;
                
                return _mapper.Map<ExemploDto[]>(list_exemplo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
