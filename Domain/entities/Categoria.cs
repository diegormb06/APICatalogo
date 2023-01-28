﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.Domain;

public class Categoria
{
  public Categoria()
  {
    Produtos = new Collection<Produto>();
  }

  [Key]
  public int Id { get; set; }

  [Required]
  [MaxLength(80)]
  public string? Nome { get; set; }

  [Required]
  [MaxLength(300)]
  public string? ImagemUrl { get; set; }
  public ICollection<Produto>? Produtos { get; set; }
}
