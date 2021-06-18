using System;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace app.Models
{
    public partial class raftypoileidlvContext : DbContext
    {
        public raftypoileidlvContext()
        {
        }

        public raftypoileidlvContext(DbContextOptions<raftypoileidlvContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SocialMediaRef> SocialMediaRefs { get; set; }
        public virtual DbSet<SocialMedium> SocialMedia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("authors_pk");

                entity.ToTable("authors", "Testing");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.IdEmail).HasColumnName("id_email");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasComment("Author Pic");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("categories_pk");

                entity.ToTable("categories", "Testing");

                entity.Property(e => e.IdCategory)
                    .HasColumnName("id_category")
                    .HasDefaultValueSql("nextval('\"Blog\".categories_id_cat_seq'::regclass)");

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

                entity.ToTable("documents", "Testing");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IdDocumentType).HasColumnName("id_document_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IdDocumentType)
                    .HasName("document_types_pk");

                entity.ToTable("document_types", "Testing");

                entity.Property(e => e.IdDocumentType).HasColumnName("id_document_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("emails_pk");

                entity.ToTable("emails", "Testing");

                entity.Property(e => e.IdEmail)
                    .HasColumnName("id_email")
                    .HasDefaultValueSql("nextval('\"Blog\".emails_id_seq'::regclass)");

                entity.Property(e => e.Email1)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email")
                    .HasComment("email from app");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.IdPicture)
                    .HasName("pictures_pk");

                entity.ToTable("pictures", "Testing");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasDefaultValueSql("nextval('\"Blog\".pictures_id_pic_seq'::regclass)");

                entity.Property(e => e.AlternativeText)
                    .IsRequired()
                    .HasColumnName("alternative_text")
                    .HasDefaultValueSql("'todo'::text");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.SourceHeader).HasColumnName("source_header");

                entity.Property(e => e.SourceOriginal).HasColumnName("source_original");

                entity.Property(e => e.SourcePreview).HasColumnName("source_preview");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("posts_pk");

                entity.ToTable("posts", "Testing");

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

                entity.Property(e => e.IdAuthor)
                    .HasColumnName("id_author")
                    .HasComment("Author. Author pic should be added to Author table.");

                entity.Property(e => e.IdCat).HasColumnName("id_cat");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasComment("Mainly for Hero/Header picture");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title");
            });

            modelBuilder.Entity<SocialMediaRef>(entity =>
            {
                entity.HasKey(e => e.IdSocialMediaRef)
                    .HasName("social_media_refs_pk");

                entity.ToTable("social_media_refs", "Testing");

                entity.Property(e => e.IdSocialMediaRef).HasColumnName("id_social_media_ref");

                entity.Property(e => e.Href)
                    .IsRequired()
                    .HasColumnName("href")
                    .HasComment("href to social media account");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdSocialMedia)
                    .HasColumnName("id_social_media")
                    .HasComment("social media name");
            });

            modelBuilder.Entity<SocialMedium>(entity =>
            {
                entity.HasKey(e => e.IdSocialMedia)
                    .HasName("social_media_pk");

                entity.ToTable("social_media", "Testing");

                entity.Property(e => e.IdSocialMedia).HasColumnName("id_social_media");

                entity.Property(e => e.BaseLink)
                    .IsRequired()
                    .HasColumnName("base_link")
                    .HasComment("base link");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasComment("from font-awesome");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasComment("name of social media");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
