using Microsoft.EntityFrameworkCore;

namespace raftypoile.Models.Main
{
    public partial class mainContext : DbContext
    {
        public mainContext()
        {
        }

        public mainContext(DbContextOptions<mainContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<Icon> Icons { get; set; }
        public virtual DbSet<LoginDatum> LoginData { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<SocialMediaRef> SocialMediaRefs { get; set; }
        public virtual DbSet<SocialMedium> SocialMedia { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_catalog", "uuid-ossp")
                .HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("categories_pk");

                entity.ToTable("categories", "Main");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasDefaultValueSql("'todo'::text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.IdDocument)
                    .HasName("documents_pk");

                entity.ToTable("documents", "Main");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IdDocumentType).HasColumnName("id_document_type");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasComment("Dokumenta ievietotājs,. autors u.t.t");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasComment("Pieejams publiski?");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");

                entity.HasOne(d => d.IdDocumentTypeNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdDocumentType)
                    .HasConstraintName("documents_fk");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_users");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IdDocumentType)
                    .HasName("document_types_pk");

                entity.ToTable("document_types", "Main");

                entity.Property(e => e.IdDocumentType).HasColumnName("id_document_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("emails_pk");

                entity.ToTable("emails", "Main");

                entity.Property(e => e.IdEmail).HasColumnName("id_email");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email");
            });

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.HasKey(e => e.IdFeed)
                    .HasName("feed_pk");

                entity.ToTable("feed", "Main");

                entity.Property(e => e.IdFeed)
                    .HasColumnName("id_feed")
                    .HasDefaultValueSql("nextval('\"Main\".feed_id_seq'::regclass)");

                entity.Property(e => e.FeedName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("feed_name")
                    .HasDefaultValueSql("'feed'::character varying");

                entity.Property(e => e.FeedUrl)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("feed_url");

                entity.Property(e => e.IdIcon).HasColumnName("id_icon");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdIconNavigation)
                    .WithMany(p => p.Feeds)
                    .HasForeignKey(d => d.IdIcon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("to_icons");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Feeds)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_users");
            });

            modelBuilder.Entity<Icon>(entity =>
            {
                entity.HasKey(e => e.IdIcon)
                    .HasName("icons_pk");

                entity.ToTable("icons", "Main");

                entity.Property(e => e.IdIcon).HasColumnName("id_icon");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("source");
            });

            modelBuilder.Entity<LoginDatum>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("users_pk");

                entity.ToTable("login_data", "Main");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.AccountCreated)
                    .HasColumnName("account_created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("username");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.LoginDatum)
                    .HasForeignKey<LoginDatum>(d => d.IdUser)
                    .HasConstraintName("login_data_fk");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.IdPicture)
                    .HasName("pictures_pk");

                entity.ToTable("pictures", "Main");

                entity.Property(e => e.IdPicture).HasColumnName("id_picture");

                entity.Property(e => e.AlternativeText)
                    .IsRequired()
                    .HasColumnName("alternative_text")
                    .HasDefaultValueSql("'todo'::text");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.SourceHeader).HasColumnName("source_header");

                entity.Property(e => e.SourceOriginal).HasColumnName("source_original");

                entity.Property(e => e.SourcePreview).HasColumnName("source_preview");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("pictures_fk");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("posts_pk");

                entity.ToTable("posts", "Main");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasComment("HTML code");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IdCat).HasColumnName("id_cat");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasComment("Mainly for Hero/Header picture");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasComment("Author. Author pic should be added to Author table.");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("to_cat");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("to_pic");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_auth");
            });

            modelBuilder.Entity<Quote>(entity =>
            {
                entity.HasKey(e => e.IdQuote)
                    .HasName("quotes_pk");

                entity.ToTable("quotes", "Main");

                entity.Property(e => e.IdQuote)
                    .HasColumnName("id_quote")
                    .HasDefaultValueSql("nextval('\"Main\".quotes_id_seq'::regclass)");

                entity.Property(e => e.Author)
                    .HasColumnType("character varying")
                    .HasColumnName("author");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.IdSocialMedia).HasColumnName("id_social_media");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdSocialMediaNavigation)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.IdSocialMedia)
                    .HasConstraintName("to_social_media");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_users");
            });

            modelBuilder.Entity<SocialMediaRef>(entity =>
            {
                entity.HasKey(e => e.IdSocialMediaRef)
                    .HasName("social_media_refs_pk");

                entity.ToTable("social_media_refs", "Main");

                entity.Property(e => e.IdSocialMediaRef).HasColumnName("id_social_media_ref");

                entity.Property(e => e.Href)
                    .IsRequired()
                    .HasColumnName("href")
                    .HasComment("href to social media account");

                entity.Property(e => e.IdSocialMedia)
                    .HasColumnName("id_social_media")
                    .HasComment("social media name");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdSocialMediaNavigation)
                    .WithMany(p => p.SocialMediaRefs)
                    .HasForeignKey(d => d.IdSocialMedia)
                    .HasConstraintName("to_social_media");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.SocialMediaRefs)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_authors");
            });

            modelBuilder.Entity<SocialMedium>(entity =>
            {
                entity.HasKey(e => e.IdSocialMedia)
                    .HasName("social_media_pk");

                entity.ToTable("social_media", "Main");

                entity.Property(e => e.IdSocialMedia).HasColumnName("id_social_media");

                entity.Property(e => e.BaseLink)
                    .IsRequired()
                    .HasColumnName("base_link")
                    .HasComment("base link");

                entity.Property(e => e.IdIcon)
                    .HasColumnName("id_icon")
                    .HasComment("from font-awesome");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("name of social media");

                entity.HasOne(d => d.IdIconNavigation)
                    .WithMany(p => p.SocialMedia)
                    .HasForeignKey(d => d.IdIcon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("to_icons");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("authors_pk");

                entity.ToTable("users", "Main");

                entity.Property(e => e.IdUser)
                    .HasColumnName("id_user")
                    .HasDefaultValueSql("uuid_generate_v4()");

                entity.Property(e => e.IdEmail)
                    .HasColumnName("id_email")
                    .HasComment("Main email");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasComment("Author Pic");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdEmailNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdEmail)
                    .HasConstraintName("to_emails");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("authors_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
