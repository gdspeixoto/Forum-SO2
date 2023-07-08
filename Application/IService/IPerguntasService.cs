using Application.Dto;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IPerguntasService
    {
        public Task<PerguntaDto[]> GETAllPerguntas();
        public Task<PerguntaDto> AddPergunta(PerguntaDto perguntaDto);
        public Task<PerguntaDto> GetPerguntaByIdAsync(int id);
        public Task<RespostaDto> AdicionarResposta(int id, RespostaDto resposta);
    }
}
