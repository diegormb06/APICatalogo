using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
  public partial class PopulaCategorias : Migration
  {
    protected override void Up(MigrationBuilder m)
    {
      m.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Bebidas', 'https://img.freepik.com/premium-photo/three-drinks-made-with-passion-fruit-strawberry-kiwi-caipirinha_70216-4007.jpg?w=740')");
      m.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Lanches', 'https://cdn.pixabay.com/photo/2014/10/19/20/59/hamburger-494706_960_720.jpg')");
      m.Sql("INSERT INTO Categorias (Nome, ImagemUrl) VALUES ('Sobremesas','https://cdn.pixabay.com/photo/2016/10/31/18/14/dessert-1786311_640.jpg')");
    }

    protected override void Down(MigrationBuilder m)
    {
      m.Sql("DELETE FROM Categorias");
    }
  }
}
