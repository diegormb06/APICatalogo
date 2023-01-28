using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
  public partial class PopulaProdutos : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('Cola-Cola', 'Refrigerante de cola', 5000, 'refrigerante.jpg', 100, '2021-01-01', 1)");
      migrationBuilder.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('X-salada', 'Sanduíche clássico de Goiânia', 5, 'lanche.jpg', 100, '2021-01-01', 2)");
      migrationBuilder.Sql("Insert into Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId) values ('Pudim de Leite', 'Clássico pudim da culinária brasileira', 12, 'sobremesa.jpg', 100, '2021-01-01', 3)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("DELETE FROM Produtos");
    }
  }
}
