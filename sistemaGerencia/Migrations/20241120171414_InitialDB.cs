using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sistemaGerencia.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    IdGrupo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeGrupo = table.Column<string>(type: "nvarchar(125)", maxLength: 125, nullable: false),
                    DescricaoGrupo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.IdGrupo);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    IdPermissao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePermissão = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescricaoPermissao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.IdPermissao);
                });

            migrationBuilder.CreateTable(
                name: "sistema",
                columns: table => new
                {
                    IdSistema = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSistema = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DescricaoSistema = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sistema", x => x.IdSistema);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUsuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmailUsuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "GrupoModelPermissaoModel",
                columns: table => new
                {
                    gruposIdGrupo = table.Column<int>(type: "int", nullable: false),
                    permissoesIdPermissao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoModelPermissaoModel", x => new { x.gruposIdGrupo, x.permissoesIdPermissao });
                    table.ForeignKey(
                        name: "FK_GrupoModelPermissaoModel_grupo_gruposIdGrupo",
                        column: x => x.gruposIdGrupo,
                        principalTable: "grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoModelPermissaoModel_permissao_permissoesIdPermissao",
                        column: x => x.permissoesIdPermissao,
                        principalTable: "permissao",
                        principalColumn: "IdPermissao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoModelSistemaModel",
                columns: table => new
                {
                    gruposIdGrupo = table.Column<int>(type: "int", nullable: false),
                    sistemasIdSistema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoModelSistemaModel", x => new { x.gruposIdGrupo, x.sistemasIdSistema });
                    table.ForeignKey(
                        name: "FK_GrupoModelSistemaModel_grupo_gruposIdGrupo",
                        column: x => x.gruposIdGrupo,
                        principalTable: "grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoModelSistemaModel_sistema_sistemasIdSistema",
                        column: x => x.sistemasIdSistema,
                        principalTable: "sistema",
                        principalColumn: "IdSistema",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrupoModelUsuarioModel",
                columns: table => new
                {
                    gruposIdGrupo = table.Column<int>(type: "int", nullable: false),
                    usuariosIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoModelUsuarioModel", x => new { x.gruposIdGrupo, x.usuariosIdUsuario });
                    table.ForeignKey(
                        name: "FK_GrupoModelUsuarioModel_grupo_gruposIdGrupo",
                        column: x => x.gruposIdGrupo,
                        principalTable: "grupo",
                        principalColumn: "IdGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrupoModelUsuarioModel_usuario_usuariosIdUsuario",
                        column: x => x.usuariosIdUsuario,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupoModelPermissaoModel_permissoesIdPermissao",
                table: "GrupoModelPermissaoModel",
                column: "permissoesIdPermissao");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoModelSistemaModel_sistemasIdSistema",
                table: "GrupoModelSistemaModel",
                column: "sistemasIdSistema");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoModelUsuarioModel_usuariosIdUsuario",
                table: "GrupoModelUsuarioModel",
                column: "usuariosIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupoModelPermissaoModel");

            migrationBuilder.DropTable(
                name: "GrupoModelSistemaModel");

            migrationBuilder.DropTable(
                name: "GrupoModelUsuarioModel");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "sistema");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
