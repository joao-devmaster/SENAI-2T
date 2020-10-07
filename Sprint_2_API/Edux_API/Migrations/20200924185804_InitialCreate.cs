using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Edux.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__A3C02A104A7A6D0D", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Instituicao",
                columns: table => new
                {
                    IdInstituicao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    UF = table.Column<string>(unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    Logradouro = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Complemento = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Numero = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    CEP = table.Column<string>(unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Institui__B771C0D80244B8AE", x => x.IdInstituicao);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permissao = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Perfil__C7BD5CC18D4885D9", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Objetivo",
                columns: table => new
                {
                    IdObjetivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IdCategoria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Objetivo__E210F071241BBD58", x => x.IdObjetivo);
                    table.ForeignKey(
                        name: "FK__Objetivo__IdCate__534D60F1",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    IdCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IdInstituicao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curso__085F27D6A3EC56A1", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK__Curso__IdInstitu__3C69FB99",
                        column: x => x.IdInstituicao,
                        principalTable: "Instituicao",
                        principalColumn: "IdInstituicao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Senha = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataUltimoAcesso = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdPerfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__5B65BF9713B66C86", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK__Usuario__IdPerfi__4222D4EF",
                        column: x => x.IdPerfil,
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IdCurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Turma__C1ECFFC97B42BF2E", x => x.IdTurma);
                    table.ForeignKey(
                        name: "FK__Turma__IdCurso__3F466844",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "IdCurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dica",
                columns: table => new
                {
                    IdDica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Imagem = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dica__F1688516DC46EA12", x => x.IdDica);
                    table.ForeignKey(
                        name: "FK__Dica__IdUsuario__48CFD27E",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoTurma",
                columns: table => new
                {
                    IdAlunoTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Matricula = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AlunoTur__8F3223BD18815873", x => x.IdAlunoTurma);
                    table.ForeignKey(
                        name: "FK__AlunoTurm__IdTur__5070F446",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlunoTurm__IdUsu__4F7CD00D",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorTurma",
                columns: table => new
                {
                    IdProfessorTurma = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdTurma = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Professo__D4E74F9EF71AF7D9", x => x.IdProfessorTurma);
                    table.ForeignKey(
                        name: "FK__Professor__IdTur__45F365D3",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "IdTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Professor__IdUsu__44FF419A",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curtida",
                columns: table => new
                {
                    IdCurtida = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdDica = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Curtida__2169583A08713BC2", x => x.IdCurtida);
                    table.ForeignKey(
                        name: "FK__Curtida__IdDica__4CA06362",
                        column: x => x.IdDica,
                        principalTable: "Dica",
                        principalColumn: "IdDica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Curtida__IdUsuar__4BAC3F29",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoObjetivo",
                columns: table => new
                {
                    IdAlunoObjetivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    DataAlcancada = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdAlunoTurma = table.Column<int>(nullable: false),
                    IdObjetivo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AlunoObj__DE5E755D582F8C90", x => x.IdAlunoObjetivo);
                    table.ForeignKey(
                        name: "FK__AlunoObje__IdAlu__571DF1D5",
                        column: x => x.IdAlunoTurma,
                        principalTable: "AlunoTurma",
                        principalColumn: "IdAlunoTurma",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AlunoObje__IdObj__5812160E",
                        column: x => x.IdObjetivo,
                        principalTable: "Objetivo",
                        principalColumn: "IdObjetivo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoObjetivo_IdAlunoTurma",
                table: "AlunoObjetivo",
                column: "IdAlunoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoObjetivo_IdObjetivo",
                table: "AlunoObjetivo",
                column: "IdObjetivo");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdTurma",
                table: "AlunoTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTurma_IdUsuario",
                table: "AlunoTurma",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdInstituicao",
                table: "Curso",
                column: "IdInstituicao");

            migrationBuilder.CreateIndex(
                name: "IX_Curtida_IdDica",
                table: "Curtida",
                column: "IdDica");

            migrationBuilder.CreateIndex(
                name: "IX_Curtida_IdUsuario",
                table: "Curtida",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Dica_IdUsuario",
                table: "Dica",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Objetivo_IdCategoria",
                table: "Objetivo",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_IdTurma",
                table: "ProfessorTurma",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorTurma_IdUsuario",
                table: "ProfessorTurma",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoObjetivo");

            migrationBuilder.DropTable(
                name: "Curtida");

            migrationBuilder.DropTable(
                name: "ProfessorTurma");

            migrationBuilder.DropTable(
                name: "AlunoTurma");

            migrationBuilder.DropTable(
                name: "Objetivo");

            migrationBuilder.DropTable(
                name: "Dica");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
