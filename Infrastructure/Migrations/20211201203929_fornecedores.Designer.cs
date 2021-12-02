﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Migrations
{
    [DbContext(typeof(UStartContext))]
    [Migration("20211201203929_fornecedores")]
    partial class fornecedores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("UStart.Domain.Entities.Caixa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataCaixa")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_caixa");

                    b.Property<Guid>("FormaPagamentoId")
                        .HasColumnType("uuid")
                        .HasColumnName("forma_pagamento_id");

                    b.Property<string>("Observacao")
                        .HasColumnType("text")
                        .HasColumnName("observacao");

                    b.Property<decimal>("QuantidadeDeItens")
                        .HasColumnType("numeric")
                        .HasColumnName("quantidade_de_itens");

                    b.Property<Guid>("ResponsavelId")
                        .HasColumnType("uuid")
                        .HasColumnName("responsavel_id");

                    b.Property<decimal>("TotalDesconto")
                        .HasColumnType("numeric")
                        .HasColumnName("total_desconto");

                    b.Property<decimal>("TotalItens")
                        .HasColumnType("numeric")
                        .HasColumnName("total_itens");

                    b.Property<decimal>("TotalProdutos")
                        .HasColumnType("numeric")
                        .HasColumnName("total_produtos");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id")
                        .HasName("pk_caixas");

                    b.HasIndex("FormaPagamentoId")
                        .HasDatabaseName("ix_caixas_forma_pagamento_id");

                    b.HasIndex("ResponsavelId")
                        .HasDatabaseName("ix_caixas_responsavel_id");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_caixas_usuario_id");

                    b.ToTable("caixas");
                });

            modelBuilder.Entity("UStart.Domain.Entities.CaixaItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CaixaId")
                        .HasColumnType("uuid")
                        .HasColumnName("caixa_id");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("numeric")
                        .HasColumnName("desconto");

                    b.Property<string>("Observacao")
                        .HasColumnType("text")
                        .HasColumnName("observacao");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("preco_unitario");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid")
                        .HasColumnName("produto_id");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("numeric")
                        .HasColumnName("quantidade");

                    b.Property<decimal>("TotalItem")
                        .HasColumnType("numeric")
                        .HasColumnName("total_item");

                    b.Property<decimal>("TotalUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("total_unitario");

                    b.HasKey("Id")
                        .HasName("pk_caixas_itens");

                    b.HasIndex("CaixaId")
                        .HasDatabaseName("ix_caixas_itens_caixa_id");

                    b.HasIndex("ProdutoId")
                        .HasDatabaseName("ix_caixas_itens_produto_id");

                    b.ToTable("caixas_itens");
                });

            modelBuilder.Entity("UStart.Domain.Entities.FormaPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CodigoExterno")
                        .HasColumnType("text")
                        .HasColumnName("codigo_externo");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("numeric")
                        .HasColumnName("desconto");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<ICollection<string>>("Dias")
                        .HasColumnType("jsonb")
                        .HasColumnName("dias");

                    b.HasKey("Id")
                        .HasName("pk_formas_pagamentos");

                    b.ToTable("formas_pagamentos");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Bairro")
                        .HasColumnType("text")
                        .HasColumnName("bairro");

                    b.Property<string>("CEP")
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text")
                        .HasColumnName("cnpj");

                    b.Property<string>("CPF")
                        .HasColumnType("text")
                        .HasColumnName("cpf");

                    b.Property<string>("CidadeId")
                        .HasColumnType("text")
                        .HasColumnName("cidade_id");

                    b.Property<string>("CidadeNome")
                        .HasColumnType("text")
                        .HasColumnName("cidade_nome");

                    b.Property<string>("CodigoExterno")
                        .HasColumnType("text")
                        .HasColumnName("codigo_externo");

                    b.Property<string>("Complemento")
                        .HasColumnType("text")
                        .HasColumnName("complemento");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("EstadoId")
                        .HasColumnType("text")
                        .HasColumnName("estado_id");

                    b.Property<string>("Fone")
                        .HasColumnType("text")
                        .HasColumnName("fone");

                    b.Property<decimal>("LimiteDeCredito")
                        .HasColumnType("numeric")
                        .HasColumnName("limite_de_credito");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Numero")
                        .HasColumnType("text")
                        .HasColumnName("numero");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text")
                        .HasColumnName("razao_social");

                    b.Property<string>("Rua")
                        .HasColumnType("text")
                        .HasColumnName("rua");

                    b.HasKey("Id")
                        .HasName("pk_fornecedores");

                    b.ToTable("fornecedores");
                });

            modelBuilder.Entity("UStart.Domain.Entities.GrupoProduto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CodigoExterno")
                        .HasColumnType("text")
                        .HasColumnName("codigo_externo");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.HasKey("Id")
                        .HasName("pk_grupo_produtos");

                    b.ToTable("grupo_produtos");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_pedido");

                    b.Property<Guid>("FormaPagamentoId")
                        .HasColumnType("uuid")
                        .HasColumnName("forma_pagamento_id");

                    b.Property<string>("Observacao")
                        .HasColumnType("text")
                        .HasColumnName("observacao");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("preco_unitario");

                    b.Property<decimal>("QuantidadeDeItens")
                        .HasColumnType("numeric")
                        .HasColumnName("quantidade_de_itens");

                    b.Property<Guid>("ResponsavelId")
                        .HasColumnType("uuid")
                        .HasColumnName("responsavel_id");

                    b.Property<decimal>("TotalDesconto")
                        .HasColumnType("numeric")
                        .HasColumnName("total_desconto");

                    b.Property<decimal>("TotalItens")
                        .HasColumnType("numeric")
                        .HasColumnName("total_itens");

                    b.Property<decimal>("TotalProdutos")
                        .HasColumnType("numeric")
                        .HasColumnName("total_produtos");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid")
                        .HasColumnName("usuario_id");

                    b.HasKey("Id")
                        .HasName("pk_pedidos");

                    b.HasIndex("FormaPagamentoId")
                        .HasDatabaseName("ix_pedidos_forma_pagamento_id");

                    b.HasIndex("ResponsavelId")
                        .HasDatabaseName("ix_pedidos_responsavel_id");

                    b.HasIndex("UsuarioId")
                        .HasDatabaseName("ix_pedidos_usuario_id");

                    b.ToTable("pedidos");
                });

            modelBuilder.Entity("UStart.Domain.Entities.PedidoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("numeric")
                        .HasColumnName("desconto");

                    b.Property<string>("Observacao")
                        .HasColumnType("text")
                        .HasColumnName("observacao");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid")
                        .HasColumnName("pedido_id");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("preco_unitario");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid")
                        .HasColumnName("produto_id");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("numeric")
                        .HasColumnName("quantidade");

                    b.Property<decimal>("TotalItem")
                        .HasColumnType("numeric")
                        .HasColumnName("total_item");

                    b.Property<decimal>("TotalUnitario")
                        .HasColumnType("numeric")
                        .HasColumnName("total_unitario");

                    b.HasKey("Id")
                        .HasName("pk_pedidos_itens");

                    b.HasIndex("PedidoId")
                        .HasDatabaseName("ix_pedidos_itens_pedido_id");

                    b.HasIndex("ProdutoId")
                        .HasDatabaseName("ix_pedidos_itens_produto_id");

                    b.ToTable("pedidos_itens");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CodigoExterno")
                        .HasColumnType("text")
                        .HasColumnName("codigo_externo");

                    b.Property<string>("Descricao")
                        .HasColumnType("text")
                        .HasColumnName("descricao");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uuid")
                        .HasColumnName("fornecedor_id");

                    b.Property<Guid>("GrupoProdutoId")
                        .HasColumnType("uuid")
                        .HasColumnName("grupo_produto_id");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric")
                        .HasColumnName("preco");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("text")
                        .HasColumnName("url_imagem");

                    b.HasKey("Id")
                        .HasName("pk_produtos");

                    b.HasIndex("FornecedorId")
                        .HasDatabaseName("ix_produtos_fornecedor_id");

                    b.HasIndex("GrupoProdutoId")
                        .HasDatabaseName("ix_produtos_grupo_produto_id");

                    b.ToTable("produtos");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Responsavel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("CodigoExterno")
                        .HasColumnType("text")
                        .HasColumnName("codigo_externo");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_responsaveis");

                    b.ToTable("responsaveis");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean")
                        .HasColumnName("ativo");

                    b.Property<string>("Autenticacao")
                        .HasColumnType("text")
                        .HasColumnName("autenticacao");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("data_registro");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.HasKey("Id")
                        .HasName("pk_usuarios");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Caixa", b =>
                {
                    b.HasOne("UStart.Domain.Entities.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .HasConstraintName("fk_caixas_formas_pagamentos_forma_pagamento_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("fk_caixas_responsaveis_responsavel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_caixas_usuarios_usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPagamento");

                    b.Navigation("Responsavel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("UStart.Domain.Entities.CaixaItem", b =>
                {
                    b.HasOne("UStart.Domain.Entities.Caixa", "Caixa")
                        .WithMany("Itens")
                        .HasForeignKey("CaixaId")
                        .HasConstraintName("fk_caixas_itens_caixas_caixa_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("fk_caixas_itens_produtos_produto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caixa");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("UStart.Domain.Entities.FormaPagamento", "FormaPagamento")
                        .WithMany()
                        .HasForeignKey("FormaPagamentoId")
                        .HasConstraintName("fk_pedidos_formas_pagamentos_forma_pagamento_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .HasConstraintName("fk_pedidos_responsaveis_responsavel_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .HasConstraintName("fk_pedidos_usuarios_usuario_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FormaPagamento");

                    b.Navigation("Responsavel");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("UStart.Domain.Entities.PedidoItem", b =>
                {
                    b.HasOne("UStart.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .HasConstraintName("fk_pedidos_itens_pedidos_pedido_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .HasConstraintName("fk_pedidos_itens_produtos_produto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Produto", b =>
                {
                    b.HasOne("UStart.Domain.Entities.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .HasConstraintName("fk_produtos_fornecedores_fornecedor_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UStart.Domain.Entities.GrupoProduto", "GrupoProduto")
                        .WithMany()
                        .HasForeignKey("GrupoProdutoId")
                        .HasConstraintName("fk_produtos_grupo_produtos_grupo_produto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");

                    b.Navigation("GrupoProduto");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Caixa", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("UStart.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
