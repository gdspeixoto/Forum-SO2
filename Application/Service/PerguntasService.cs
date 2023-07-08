using Application.Dto;
using Application.IService;
using AutoMapper;
using Domain.Model;
using Persistence.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class PerguntasService : IPerguntasService
    {
        private readonly IGeralRepository _geralRepository;
        private readonly IPerguntasRepository _perguntasRepository;
        private readonly IMapper _mapper;

        public PerguntasService(IGeralRepository geralRepository,
                              IPerguntasRepository perguntasRepository,
                              IMapper mapper)
        {
            _geralRepository = geralRepository;
            _perguntasRepository = perguntasRepository;
            _mapper = mapper;
        }

        public async Task<PerguntaDto[]> GETAllPerguntas()
        {
            try
            {
                var list_perguntas = await _perguntasRepository.GETAllPerguntas();
                if (list_perguntas == null) return null;

                return _mapper.Map<PerguntaDto[]>(list_perguntas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<PerguntaDto> GetPerguntaByIdAsync(int id)
        {
            try
            {
                var pergunta = await _perguntasRepository.GetIdPergunta(id);
                if (pergunta == null) return null;

                return _mapper.Map<PerguntaDto>(pergunta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<RespostaDto> AdicionarResposta(int id, RespostaDto resposta)
        {
            var mapperResposta = _mapper.Map<Resposta>(resposta);
            try
            {
                var pergunta = await _perguntasRepository.GetIdPergunta(id);
                pergunta.Respostas.Add(mapperResposta);
                _geralRepository.Add<Resposta>(mapperResposta);
                if (await _geralRepository.SaveChangesAsyncs())
                {
                    return _mapper.Map<RespostaDto>(mapperResposta);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<PerguntaDto> AddPergunta(PerguntaDto perguntaDto)
        {
            var mapperPergunta = _mapper.Map<Pergunta>(perguntaDto);
            try
            {
                mapperPergunta.Ativo = 1;
                _geralRepository.Add<Pergunta>(mapperPergunta);
                if (await _geralRepository.SaveChangesAsyncs())
                {

                    return _mapper.Map<PerguntaDto>(await _perguntasRepository.GetIdPergunta(mapperPergunta.Id));
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
