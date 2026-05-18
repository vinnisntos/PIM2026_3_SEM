using Microsoft.AspNetCore.Mvc;
using PimEstoque.Data;
using PimEstoque.Models;

namespace PimEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecosController : ControllerBase
    {
        private readonly PimEstoqueContext _context;

        public EnderecosController(PimEstoqueContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarEndereco([FromBody] Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return Ok(endereco);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_context.Enderecos.ToList());
        }
    }
}