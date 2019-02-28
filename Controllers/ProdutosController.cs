﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using APIGestor.Business;
using APIGestor.Models;

namespace APIGestor.Controllers
{
    [Route("api/projeto/")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProdutosController : ControllerBase
    {
        private ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet("{projetoId}/Produtos")]
        public IEnumerable<Produto> Get(int projetoId)
        {
            return _service.ListarTodos(projetoId);
        }

        [HttpGet("Produto/{id}")]
        public ActionResult<Produto> GetA(int id)
        {
            var Produto = _service.Obter(id);
            if (Produto != null)
                return Produto;
            else
                return NotFound();
        }

        [Route("[controller]")]
        [HttpPost]
        public Resultado Post([FromBody]Produto Produto)
        {
            return _service.Incluir(Produto);
        }

        [Route("[controller]")]
        [HttpPut]
        public Resultado Put([FromBody]Produto Produto)
        {
            return _service.Atualizar(Produto);
        }

        [HttpDelete("[controller]/{Id}")]
        public Resultado Delete(int id)
        {
            return _service.Excluir(id);
        }
    }
}