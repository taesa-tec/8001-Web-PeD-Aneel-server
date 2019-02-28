﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIGestor.Models
{
    public class CatalogPais
    {   
        private int _id;

        [Key]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        private string _nome;
        public string Nome
        {
            get => _nome;
            set => _nome = value?.Trim();
        }
    }
}