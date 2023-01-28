using System.Collections.ObjectModel;

namespace APICatalogo.Domain;

public class Categoria
{
  public Categoria()
  {
    Produtos = new Collection<Produto>();
  }

  public int Id { get; set; }
  public string? Nome { get; set; }
  public string? ImgagemUrl { get; set; }
  public ICollection<Produto>? Produtos { get; set; }
}
