using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
  private readonly AppDbContext _context;

  public ProdutosController(AppDbContext context)
  {
    _context = context;
  }

  [HttpGet]
  public ActionResult<IEnumerable<Produto>> Get()
  {
    var produtos = _context.Produtos.ToList();

    if (produtos is null)
    {
      return NotFound("Nenhum produto encontrado");
    }

    return Ok(produtos);
  }
}
