using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UStart.Infrastructure.Migrations
{
    public partial class usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "formas_pagamentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    dias = table.Column<ICollection<string>>(type: "jsonb", nullable: true),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_formas_pagamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    razao_social = table.Column<string>(type: "text", nullable: true),
                    cnpj = table.Column<string>(type: "text", nullable: true),
                    cpf = table.Column<string>(type: "text", nullable: true),
                    rua = table.Column<string>(type: "text", nullable: true),
                    numero = table.Column<string>(type: "text", nullable: true),
                    complemento = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    estado_id = table.Column<string>(type: "text", nullable: true),
                    cidade_id = table.Column<string>(type: "text", nullable: true),
                    cidade_nome = table.Column<string>(type: "text", nullable: true),
                    cep = table.Column<string>(type: "text", nullable: true),
                    fone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    limite_de_credito = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fornecedores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "grupo_produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_grupo_produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "responsaveis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo_externo = table.Column<string>(type: "text", nullable: true),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_responsaveis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    autenticacao = table.Column<string>(type: "text", nullable: true),
                    data_registro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    grupo_produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    fornecedor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    preco = table.Column<decimal>(type: "numeric", nullable: false),
                    url_imagem = table.Column<string>(type: "text", nullable: true),
                    codigo_externo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_produtos", x => x.id);
                    table.ForeignKey(
                        name: "fk_produtos_fornecedores_fornecedor_id",
                        column: x => x.fornecedor_id,
                        principalTable: "fornecedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_produtos_grupo_produtos_grupo_produto_id",
                        column: x => x.grupo_produto_id,
                        principalTable: "grupo_produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "caixas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_caixa = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsavel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    forma_pagamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade_de_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    total_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    total_desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_produtos = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_caixas", x => x.id);
                    table.ForeignKey(
                        name: "fk_caixas_formas_pagamentos_forma_pagamento_id",
                        column: x => x.forma_pagamento_id,
                        principalTable: "formas_pagamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_caixas_responsaveis_responsavel_id",
                        column: x => x.responsavel_id,
                        principalTable: "responsaveis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_caixas_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_pedido = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    responsavel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    usuario_id = table.Column<Guid>(type: "uuid", nullable: false),
                    forma_pagamento_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade_de_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_itens = table.Column<decimal>(type: "numeric", nullable: false),
                    total_desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_produtos = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedidos", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedidos_formas_pagamentos_forma_pagamento_id",
                        column: x => x.forma_pagamento_id,
                        principalTable: "formas_pagamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_responsaveis_responsavel_id",
                        column: x => x.responsavel_id,
                        principalTable: "responsaveis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "caixas_itens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    caixa_id = table.Column<Guid>(type: "uuid", nullable: false),
                    produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_item = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_caixas_itens", x => x.id);
                    table.ForeignKey(
                        name: "fk_caixas_itens_caixas_caixa_id",
                        column: x => x.caixa_id,
                        principalTable: "caixas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_caixas_itens_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedidos_itens",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    pedido_id = table.Column<Guid>(type: "uuid", nullable: false),
                    produto_id = table.Column<Guid>(type: "uuid", nullable: false),
                    observacao = table.Column<string>(type: "text", nullable: true),
                    quantidade = table.Column<decimal>(type: "numeric", nullable: false),
                    preco_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    total_unitario = table.Column<decimal>(type: "numeric", nullable: false),
                    total_item = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pedidos_itens", x => x.id);
                    table.ForeignKey(
                        name: "fk_pedidos_itens_pedidos_pedido_id",
                        column: x => x.pedido_id,
                        principalTable: "pedidos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_pedidos_itens_produtos_produto_id",
                        column: x => x.produto_id,
                        principalTable: "produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_caixas_forma_pagamento_id",
                table: "caixas",
                column: "forma_pagamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_caixas_responsavel_id",
                table: "caixas",
                column: "responsavel_id");

            migrationBuilder.CreateIndex(
                name: "ix_caixas_usuario_id",
                table: "caixas",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_caixas_itens_caixa_id",
                table: "caixas_itens",
                column: "caixa_id");

            migrationBuilder.CreateIndex(
                name: "ix_caixas_itens_produto_id",
                table: "caixas_itens",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_forma_pagamento_id",
                table: "pedidos",
                column: "forma_pagamento_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_responsavel_id",
                table: "pedidos",
                column: "responsavel_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_usuario_id",
                table: "pedidos",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_itens_pedido_id",
                table: "pedidos_itens",
                column: "pedido_id");

            migrationBuilder.CreateIndex(
                name: "ix_pedidos_itens_produto_id",
                table: "pedidos_itens",
                column: "produto_id");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_fornecedor_id",
                table: "produtos",
                column: "fornecedor_id");

            migrationBuilder.CreateIndex(
                name: "ix_produtos_grupo_produto_id",
                table: "produtos",
                column: "grupo_produto_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caixas_itens");

            migrationBuilder.DropTable(
                name: "pedidos_itens");

            migrationBuilder.DropTable(
                name: "caixas");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "formas_pagamentos");

            migrationBuilder.DropTable(
                name: "responsaveis");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "fornecedores");

            migrationBuilder.DropTable(
                name: "grupo_produtos");
        }
    }
}
