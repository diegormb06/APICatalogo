using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

  [HttpGet("{id:int}", Name = "produto")]
  public ActionResult<Produto> Find(int id)
  {
    var produto = _context.Produtos!.FirstOrDefault(p => p.Id == id);

    if (produto is null)
    {
      return NotFound("Produto não encontrado");
    }

    return Ok(produto);
  }

  [HttpPost]
  public ActionResult<Produto> Create(Produto produto)
  {
    if (produto is null)
    {
      return BadRequest("Produto inválido");
    }

    _context.Produtos!.Add(produto);
    _context.SaveChanges();

    return new CreatedAtRouteResult("produto", new { id = produto.Id }, produto);
  }

  [HttpPut("{id:int}")]
  public ActionResult<Produto> Update(int id, Produto produto)
  {
    if (id != produto.Id)
    {
      return BadRequest("Produto inválido");
    }

    _context.Entry(produto).State = EntityState.Modified;
    _context.SaveChanges();

    return Ok(produto);
  }

  [HttpDelete("{id:int}")]
  public ActionResult<Produto> Delete(int id)
  {
    var produto = _context.Produtos!.FirstOrDefault(p => p.Id == id);

    if (produto is null)
    {
      return NotFound("Produto não encontrado");
    }

    _context.Produtos!.Remove(produto);
    _context.SaveChanges();

    return NoContent();
  }
}
