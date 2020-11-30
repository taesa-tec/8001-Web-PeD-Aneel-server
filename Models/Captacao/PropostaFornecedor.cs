using System.Collections.Generic;
using TaesaCore.Models;

namespace APIGestor.Models.Captacao
{
    public class PropostaFornecedor : BaseEntity
    {
        public enum StatusParticipacao
        {
            Pendente,
            Aceito,
            Rejeitado
        }

        public int FornecedorId { get; set; }
        public Fornecedores.Fornecedor Fornecedor { get; set; }
        public int CaptacaoId { get; set; }
        public Captacao Captacao { get; set; }
        public bool Finalizado { get; set; }
        public StatusParticipacao Participacao { get; set; }
        public List<SugestaoClausula> SugestaoClausulas { get; set; }
    }
}