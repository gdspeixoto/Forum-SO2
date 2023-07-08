﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RespostaDto
    {
        public int Id { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string Nome { get; set; }
        public string TextoResposta { get; set; }
    }
}
