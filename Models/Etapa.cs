﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGestor.Models
{
    public class Etapa
    {
        private int _id;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public string Nome { get; set; }
        public int ProjetoId { get;set; }
        public int Duracao { get; set; }
        public string Desc { get; set; }
        public string AtividadesRealizadas { get; set; }
        [Column(TypeName="date")]
        public DateTime? DataInicio { get; set; }
        [Column(TypeName="date")]
        public DateTime? DataFim { get; set; }
        public List<EtapaProduto> EtapaProdutos { get; set; }

    }
    public class EtapaProduto
    {   
        [Key]
        public int Id { get; set; }
        public int EtapaId { get; set; }
        public int? ProdutoId { get; set; }
    }
}