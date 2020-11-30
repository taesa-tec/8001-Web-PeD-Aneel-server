using System;
using System.Collections.Generic;
using TaesaCore.Models;

namespace APIGestor.Dtos.Captacao
{
    public class CaptacaoDto : BaseEntity
    {
        public DateTime DataTermino { get; set; }
        public string Status { get; set; }
        public int ConvidadosTotal { get; set; }
        public int PropostaTotal { get; set; }
    }
}