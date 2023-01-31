using APICatalogo.Context;
using APICatalogo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CategoriasController : ControllerBase
  {
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
      var categorias = _context.Categorias!.ToList();

      if (categorias is null)
      {
        return NotFound("Nenhuma categoria encontrada");
      }

      return Ok(categorias);
    }

    [HttpGet("{id:int}", Name = "categoria")]
    public ActionResult<Categoria> Find(int id)
    {
      var categoria = _context.Categorias!.FirstOrDefault(c => c.Id == id);

      if (categoria is null)
      {
        return NotFound("Categoria não encontrada");
      }

      return Ok(categoria);
    }

    [HttpPost]
    public ActionResult<Categoria> Create(Categoria categoria)
    {
      if (categoria is null)
      {
        return BadRequest("Categoria inválida");
      }

      _context.Categorias!.Add(categoria);
      _context.SaveChanges();

      return new CreatedAtRouteResult("categoria", new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult<Categoria> Update(int id, Categoria categoria)
    {
      if (id != categoria.Id)
      {
        return BadRequest("Categoria inválida");
      }

      _context.Entry(categoria).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Categoria> Delete(int id)
    {
      var categoria = _context.Categorias!.FirstOrDefault(c => c.Id == id);

      if (categoria is null)
      {
        return NotFound("Categoria não encontrada");
      }

      _context.Categorias!.Remove(categoria);
      _context.SaveChanges();

      return NoContent();
    }
  }
}