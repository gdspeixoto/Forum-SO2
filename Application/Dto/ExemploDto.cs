using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ExemploDto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExclusao { get; set; }
        public DateTime DataAtualizacao { get; set; }


    }
}
