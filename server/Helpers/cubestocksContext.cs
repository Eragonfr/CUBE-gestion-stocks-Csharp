using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Entities;

namespace server.Helpers {
    public class cubestocksContext : DbContext {
		protected readonly IConfiguration Configuration;

        public cubestocksContext(IConfiguration configuration) {
			Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseNpgsql(Configuration.GetConnectionString("serverDatabase"));
        }

        public virtual DbSet<Adresse> Adresses { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleJoinCommande> ArticleJoinCommandes { get; set; }
        public virtual DbSet<ArticleJoinFournisseur> ArticleJoinFournisseurs { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<HistJoinCom> HistJoinComs { get; set; }
        public virtual DbSet<Salarie> Salaries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "fr_FR.UTF-8");

            modelBuilder.Entity<Adresse>(entity =>
            {
                entity.ToTable("adresse");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codepostal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("codepostal");

                entity.Property(e => e.Nomrue)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nomrue");

                entity.Property(e => e.Pays)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pays");

                entity.Property(e => e.Ville)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ville");

                entity.Property(e => e.Voie)
                    .HasMaxLength(255)
                    .HasColumnName("voie");
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Annee)
                    .HasColumnType("date")
                    .HasColumnName("annee");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Domaine)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("domaine");

                entity.Property(e => e.Medaille)
                    .HasMaxLength(255)
                    .HasColumnName("medaille");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nom");

                entity.Property(e => e.Producttype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("producttype");

                entity.Property(e => e.Provenance)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("provenance");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<ArticleJoinCommande>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("article_join_commande");

                entity.Property(e => e.Article).HasColumnName("article");

                entity.Property(e => e.Commande).HasColumnName("commande");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_join_commande_article_fkey");

                entity.HasOne(d => d.CommandeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Commande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_join_commande_commande_fkey");
            });

            modelBuilder.Entity<ArticleJoinFournisseur>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("article_join_fournisseur");

                entity.Property(e => e.Article).HasColumnName("article");

                entity.Property(e => e.Fournisseur).HasColumnName("fournisseur");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Article)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_join_fournisseur_article_fkey");

                entity.HasOne(d => d.FournisseurNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Fournisseur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("article_join_fournisseur_fournisseur_fkey");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("client");

                entity.HasIndex(e => e.Email, "client_email_key")
                    .IsUnique();

                entity.HasIndex(e => e.Users, "client_users_key")
                    .IsUnique();

                entity.Property(e => e.Adresse).HasColumnName("adresse");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Users).HasColumnName("users");

                entity.HasOne(d => d.AdresseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Adresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_adresse_fkey");

                entity.HasOne(d => d.UsersNavigation)
                    .WithOne()
                    .HasForeignKey<Client>(d => d.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_users_fkey");
            });

            modelBuilder.Entity<Commande>(entity =>
            {
                entity.ToTable("commande");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datecommande)
                    .HasColumnType("date")
                    .HasColumnName("datecommande");

                entity.Property(e => e.Datelivraison)
                    .HasColumnType("date")
                    .HasColumnName("datelivraison");

                entity.Property(e => e.Prix).HasColumnName("prix");

                entity.Property(e => e.Quantite).HasColumnName("quantite");
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("fournisseur");

                entity.HasIndex(e => e.Adresse, "fournisseur_adresse_key")
                    .IsUnique();

                entity.HasIndex(e => e.Telephone, "fournisseur_telephone_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresse).HasColumnName("adresse");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nom");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(20)
                    .HasColumnName("telephone");
            });

            modelBuilder.Entity<HistJoinCom>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("hist_join_com");

                entity.Property(e => e.Commande).HasColumnName("commande");

                entity.Property(e => e.Users).HasColumnName("users");

                entity.HasOne(d => d.CommandeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Commande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hist_join_com_commande_fkey");

                entity.HasOne(d => d.UsersNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hist_join_com_users_fkey");
            });

            modelBuilder.Entity<Salarie>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("salarie");

                entity.HasIndex(e => e.Users, "salarie_users_key")
                    .IsUnique();

                entity.Property(e => e.Poste)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("poste");

                entity.Property(e => e.Users).HasColumnName("users");

                entity.HasOne(d => d.UsersNavigation)
                    .WithOne()
                    .HasForeignKey<Salarie>(d => d.Users)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("salarie_users_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Username, "users_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });
        }
    }
}
