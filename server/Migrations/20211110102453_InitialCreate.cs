using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "adresse",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codepostal = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    nomrue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    voie = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    pays = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ville = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresse", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    producttype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    provenance = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    medaille = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    annee = table.Column<DateTime>(type: "date", nullable: false),
                    domaine = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_article", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "commande",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    datecommande = table.Column<DateTime>(type: "date", nullable: false),
                    datelivraison = table.Column<DateTime>(type: "date", nullable: true),
                    quantite = table.Column<int>(type: "integer", nullable: false),
                    prix = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commande", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "fournisseur",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    adresse = table.Column<int>(type: "integer", nullable: false),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fournisseur", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "article_join_commande",
                columns: table => new
                {
                    article = table.Column<int>(type: "integer", nullable: false),
                    commande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "article_join_commande_article_fkey",
                        column: x => x.article,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "article_join_commande_commande_fkey",
                        column: x => x.commande,
                        principalTable: "commande",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "article_join_fournisseur",
                columns: table => new
                {
                    article = table.Column<int>(type: "integer", nullable: false),
                    fournisseur = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "article_join_fournisseur_article_fkey",
                        column: x => x.article,
                        principalTable: "article",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "article_join_fournisseur_fournisseur_fkey",
                        column: x => x.fournisseur,
                        principalTable: "fournisseur",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    users = table.Column<int>(type: "integer", nullable: false),
                    adresse = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "client_adresse_fkey",
                        column: x => x.adresse,
                        principalTable: "adresse",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "client_users_fkey",
                        column: x => x.users,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "hist_join_com",
                columns: table => new
                {
                    users = table.Column<int>(type: "integer", nullable: false),
                    commande = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "hist_join_com_commande_fkey",
                        column: x => x.commande,
                        principalTable: "commande",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "hist_join_com_users_fkey",
                        column: x => x.users,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "salarie",
                columns: table => new
                {
                    users = table.Column<int>(type: "integer", nullable: false),
                    poste = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "salarie_users_fkey",
                        column: x => x.users,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_article_join_commande_article",
                table: "article_join_commande",
                column: "article");

            migrationBuilder.CreateIndex(
                name: "IX_article_join_commande_commande",
                table: "article_join_commande",
                column: "commande");

            migrationBuilder.CreateIndex(
                name: "IX_article_join_fournisseur_article",
                table: "article_join_fournisseur",
                column: "article");

            migrationBuilder.CreateIndex(
                name: "IX_article_join_fournisseur_fournisseur",
                table: "article_join_fournisseur",
                column: "fournisseur");

            migrationBuilder.CreateIndex(
                name: "client_email_key",
                table: "client",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "client_users_key",
                table: "client",
                column: "users",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_client_adresse",
                table: "client",
                column: "adresse");

            migrationBuilder.CreateIndex(
                name: "fournisseur_adresse_key",
                table: "fournisseur",
                column: "adresse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fournisseur_telephone_key",
                table: "fournisseur",
                column: "telephone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hist_join_com_commande",
                table: "hist_join_com",
                column: "commande");

            migrationBuilder.CreateIndex(
                name: "IX_hist_join_com_users",
                table: "hist_join_com",
                column: "users");

            migrationBuilder.CreateIndex(
                name: "salarie_users_key",
                table: "salarie",
                column: "users",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_username_key",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "article_join_commande");

            migrationBuilder.DropTable(
                name: "article_join_fournisseur");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "hist_join_com");

            migrationBuilder.DropTable(
                name: "salarie");

            migrationBuilder.DropTable(
                name: "article");

            migrationBuilder.DropTable(
                name: "fournisseur");

            migrationBuilder.DropTable(
                name: "adresse");

            migrationBuilder.DropTable(
                name: "commande");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
