﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using APIGestor.Data;
using APIGestor.Models;
using Microsoft.AspNetCore.Identity;
using APIGestor.Security;

namespace APIGestor.Business
{
    public class RecursoMaterialService
    {
        private GestorDbContext _context;

        public RecursoMaterialService(GestorDbContext context)
        {
            _context = context;
        }
        public IEnumerable<RecursoMaterial> ListarTodos(int projetoId)
        {
            var RecursoMaterial = _context.RecursoMateriais
                .Where(p => p.ProjetoId == projetoId)
                .ToList();
            return RecursoMaterial;
        }
        public Resultado Incluir(RecursoMaterial dados)
        {
            Resultado resultado = DadosValidos(dados);
            resultado.Acao = "Inclusão de RecursoMaterial";
            if (dados.ProjetoId <= 0)
            {
                resultado.Inconsistencias.Add("Preencha o ProjetoId");
            }
            else
            {
                Projeto Projeto = _context.Projetos.Where(
                        p => p.Id == dados.ProjetoId).FirstOrDefault();

                if (Projeto == null)
                {
                    resultado.Inconsistencias.Add("Projeto não localizado");
                }
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                var data = new RecursoMaterial
                {
                    ProjetoId = dados.ProjetoId,
                    Nome = dados.Nome,
                    CategoriaContabil = dados.CategoriaContabil,
                    ValorUnitario = dados.ValorUnitario,
                    Especificacao = dados.Especificacao
                };
                _context.RecursoMateriais.Add(data);
                _context.SaveChanges();
            }
            return resultado;
        }
        public Resultado Atualizar(RecursoMaterial dados)
        {
            Resultado resultado = DadosValidos(dados);
            resultado.Acao = "Atualização de RecursoMaterial";

            if (resultado.Inconsistencias.Count == 0)
            {
                RecursoMaterial RecursoMaterial = _context.RecursoMateriais.Where(
                    p => p.Id == dados.Id).FirstOrDefault();

                if (RecursoMaterial == null)
                {
                    resultado.Inconsistencias.Add(
                        "RecursoMaterial não encontrado");
                }
                else
                {
                    RecursoMaterial.Nome = dados.Nome;
                    RecursoMaterial.ValorUnitario = dados.ValorUnitario;
                    RecursoMaterial.CategoriaContabil = dados.CategoriaContabil;
                    RecursoMaterial.Especificacao = dados.Especificacao;
                    _context.SaveChanges();
                }
            }

            return resultado;
        }
        private Resultado DadosValidos(RecursoMaterial dados)
        {
            var resultado = new Resultado();
            if (dados == null)
            {
                resultado.Inconsistencias.Add("Preencha os Dados do RecursoMaterial");
            }
            else
            {
                if (String.IsNullOrEmpty(dados.Nome))
                {
                    resultado.Inconsistencias.Add("Preencha o Nome do RecursoMaterial");
                }
                if (String.IsNullOrEmpty(dados.CategoriaContabil.ToString()))
                {
                    resultado.Inconsistencias.Add("Preencha a Categoria Contável do RecursoMaterial");
                }
                if (String.IsNullOrEmpty(dados.Especificacao))
                {
                    resultado.Inconsistencias.Add("Preencha a Especificação do RecursoMaterial");
                }
                if (String.IsNullOrEmpty(dados.ValorUnitario.ToString()))
                {
                    resultado.Inconsistencias.Add("Preencha o Valor Unitário do RecursoMaterial");
                }     
           }
            return resultado;
        }
        public Resultado Excluir(int id)
        {
            Resultado resultado = new Resultado();
            resultado.Acao = "Exclusão de RecursoMaterial";

            RecursoMaterial RecursoMaterial = _context.RecursoMateriais.First(t => t.Id == id);
            if (RecursoMaterial == null)
            {
                resultado.Inconsistencias.Add("RecursoMaterial não encontrada");
            }
            else
            {
                _context.RecursoMateriais.Remove(RecursoMaterial);
                _context.SaveChanges();
            }

            return resultado;
        }
    }
}