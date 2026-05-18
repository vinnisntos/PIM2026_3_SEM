using Microsoft.AspNetCore.Mvc;
using PimEstoque.Data;
using PimEstoque.Models;

namespace PimEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacoesController : ControllerBase
    {
        private readonly PimEstoqueContext _context;

        public MovimentacoesController(PimEstoqueContext context)
        {
            _context = context;
        }

        [HttpPost("recebimento")]
        public IActionResult RegistrarRecebimento([FromBody] Movimentacao movimentacao)
        {
            _context.Movimentacoes.Add(movimentacao);
            _context.SaveChanges();

            return Ok(movimentacao);
            
        }
    [HttpPost("armazenagem")]
public IActionResult Armazenar([FromBody] Movimentacao movimentacao)
{
    movimentacao.Tipo = "ARMAZENAGEM";

    _context.Movimentacoes.Add(movimentacao);
    _context.SaveChanges();

    return Ok(movimentacao);
}
[HttpGet("estoque/{produtoId}")]
public IActionResult ConsultarEstoque(int produtoId)
{
    var total = _context.Movimentacoes
        .Where(m => m.ProdutoId == produtoId)
        .Sum(m => m.Quantidade);

    return Ok(new
    {
        ProdutoId = produtoId,
        QuantidadeTotal = total
    });
}
[HttpGet("estoque/endereco/{enderecoId}")]
public IActionResult EstoquePorEndereco(int enderecoId)
{
    var estoque = _context.Movimentacoes
        .Where(m => m.EnderecoId == enderecoId)
        .ToList();

    return Ok(estoque);
}
[HttpPost("saida")]
public IActionResult RegistrarSaida([FromBody] Movimentacao movimentacao)
{
    var movimentacoes = _context.Movimentacoes
        .Where(m => m.ProdutoId == movimentacao.ProdutoId && m.EnderecoId == movimentacao.EnderecoId)
        .ToList();

    int saldo = 0;

    foreach (var mov in movimentacoes)
    {
        if (mov.Tipo == "ARMAZENAGEM")
            saldo += mov.Quantidade;
        else if (mov.Tipo == "SAIDA")
            saldo -= mov.Quantidade;
    }

    if (movimentacao.Quantidade > saldo)
    {
        return BadRequest("Estoque insuficiente para realizar a saída.");
    }

    movimentacao.Tipo = "SAIDA";

    _context.Movimentacoes.Add(movimentacao);
    _context.SaveChanges();

    return Ok(movimentacao);
}

    }
}
