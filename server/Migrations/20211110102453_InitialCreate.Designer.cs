﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using server.Helpers;

namespace server.Migrations
{
    [DbContext(typeof(cubestocksContext))]
    [Migration("20211110102453_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "fr_FR.UTF-8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("server.Entities.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Codepostal")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("codepostal");

                    b.Property<string>("Nomrue")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nomrue");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("pays");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("ville");

                    b.Property<string>("Voie")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("voie");

                    b.HasKey("Id");

                    b.ToTable("adresse");
                });

            modelBuilder.Entity("server.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Annee")
                        .HasColumnType("date")
                        .HasColumnName("annee");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Domaine")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("domaine");

                    b.Property<string>("Medaille")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("medaille");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nom");

                    b.Property<string>("Producttype")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("producttype");

                    b.Property<string>("Provenance")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("provenance");

                    b.Property<int>("Stock")
                        .HasColumnType("integer")
                        .HasColumnName("stock");

                    b.HasKey("Id");

                    b.ToTable("article");
                });

            modelBuilder.Entity("server.Entities.ArticleJoinCommande", b =>
                {
                    b.Property<int>("Article")
                        .HasColumnType("integer")
                        .HasColumnName("article");

                    b.Property<int>("Commande")
                        .HasColumnType("integer")
                        .HasColumnName("commande");

                    b.HasIndex("Article");

                    b.HasIndex("Commande");

                    b.ToTable("article_join_commande");
                });

            modelBuilder.Entity("server.Entities.ArticleJoinFournisseur", b =>
                {
                    b.Property<int>("Article")
                        .HasColumnType("integer")
                        .HasColumnName("article");

                    b.Property<int>("Fournisseur")
                        .HasColumnType("integer")
                        .HasColumnName("fournisseur");

                    b.HasIndex("Article");

                    b.HasIndex("Fournisseur");

                    b.ToTable("article_join_fournisseur");
                });

            modelBuilder.Entity("server.Entities.Client", b =>
                {
                    b.Property<int>("Adresse")
                        .HasColumnType("integer")
                        .HasColumnName("adresse");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("email");

                    b.Property<int>("Users")
                        .HasColumnType("integer")
                        .HasColumnName("users");

                    b.HasIndex("Adresse");

                    b.HasIndex(new[] { "Email" }, "client_email_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Users" }, "client_users_key")
                        .IsUnique();

                    b.ToTable("client");
                });

            modelBuilder.Entity("server.Entities.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Datecommande")
                        .HasColumnType("date")
                        .HasColumnName("datecommande");

                    b.Property<DateTime?>("Datelivraison")
                        .HasColumnType("date")
                        .HasColumnName("datelivraison");

                    b.Property<decimal>("Prix")
                        .HasColumnType("numeric")
                        .HasColumnName("prix");

                    b.Property<int>("Quantite")
                        .HasColumnType("integer")
                        .HasColumnName("quantite");

                    b.HasKey("Id");

                    b.ToTable("commande");
                });

            modelBuilder.Entity("server.Entities.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Adresse")
                        .HasColumnType("integer")
                        .HasColumnName("adresse");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("nom");

                    b.Property<string>("Telephone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("telephone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Adresse" }, "fournisseur_adresse_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Telephone" }, "fournisseur_telephone_key")
                        .IsUnique();

                    b.ToTable("fournisseur");
                });

            modelBuilder.Entity("server.Entities.HistJoinCom", b =>
                {
                    b.Property<int>("Commande")
                        .HasColumnType("integer")
                        .HasColumnName("commande");

                    b.Property<int>("Users")
                        .HasColumnType("integer")
                        .HasColumnName("users");

                    b.HasIndex("Commande");

                    b.HasIndex("Users");

                    b.ToTable("hist_join_com");
                });

            modelBuilder.Entity("server.Entities.Salarie", b =>
                {
                    b.Property<string>("Poste")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("poste");

                    b.Property<int>("Users")
                        .HasColumnType("integer")
                        .HasColumnName("users");

                    b.HasIndex(new[] { "Users" }, "salarie_users_key")
                        .IsUnique();

                    b.ToTable("salarie");
                });

            modelBuilder.Entity("server.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Username" }, "users_username_key")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("server.Entities.ArticleJoinCommande", b =>
                {
                    b.HasOne("server.Entities.Article", "ArticleNavigation")
                        .WithMany()
                        .HasForeignKey("Article")
                        .HasConstraintName("article_join_commande_article_fkey")
                        .IsRequired();

                    b.HasOne("server.Entities.Commande", "CommandeNavigation")
                        .WithMany()
                        .HasForeignKey("Commande")
                        .HasConstraintName("article_join_commande_commande_fkey")
                        .IsRequired();

                    b.Navigation("ArticleNavigation");

                    b.Navigation("CommandeNavigation");
                });

            modelBuilder.Entity("server.Entities.ArticleJoinFournisseur", b =>
                {
                    b.HasOne("server.Entities.Article", "ArticleNavigation")
                        .WithMany()
                        .HasForeignKey("Article")
                        .HasConstraintName("article_join_fournisseur_article_fkey")
                        .IsRequired();

                    b.HasOne("server.Entities.Fournisseur", "FournisseurNavigation")
                        .WithMany()
                        .HasForeignKey("Fournisseur")
                        .HasConstraintName("article_join_fournisseur_fournisseur_fkey")
                        .IsRequired();

                    b.Navigation("ArticleNavigation");

                    b.Navigation("FournisseurNavigation");
                });

            modelBuilder.Entity("server.Entities.Client", b =>
                {
                    b.HasOne("server.Entities.Adresse", "AdresseNavigation")
                        .WithMany()
                        .HasForeignKey("Adresse")
                        .HasConstraintName("client_adresse_fkey")
                        .IsRequired();

                    b.HasOne("server.Entities.User", "UsersNavigation")
                        .WithOne()
                        .HasForeignKey("server.Entities.Client", "Users")
                        .HasConstraintName("client_users_fkey")
                        .IsRequired();

                    b.Navigation("AdresseNavigation");

                    b.Navigation("UsersNavigation");
                });

            modelBuilder.Entity("server.Entities.HistJoinCom", b =>
                {
                    b.HasOne("server.Entities.Commande", "CommandeNavigation")
                        .WithMany()
                        .HasForeignKey("Commande")
                        .HasConstraintName("hist_join_com_commande_fkey")
                        .IsRequired();

                    b.HasOne("server.Entities.User", "UsersNavigation")
                        .WithMany()
                        .HasForeignKey("Users")
                        .HasConstraintName("hist_join_com_users_fkey")
                        .IsRequired();

                    b.Navigation("CommandeNavigation");

                    b.Navigation("UsersNavigation");
                });

            modelBuilder.Entity("server.Entities.Salarie", b =>
                {
                    b.HasOne("server.Entities.User", "UsersNavigation")
                        .WithOne()
                        .HasForeignKey("server.Entities.Salarie", "Users")
                        .HasConstraintName("salarie_users_fkey")
                        .IsRequired();

                    b.Navigation("UsersNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
