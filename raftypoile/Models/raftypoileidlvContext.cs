using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace raftypoile.Models
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
                optionsBuilder.UseNpgsql("Name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("authors_pk");

                entity.ToTable("authors", "Blog");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdDocument).HasColumnName("id_document");

                entity.Property(e => e.IdEmail).HasColumnName("id_email");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasComment("Author Pic");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.HasOne(d => d.IdDocumentNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdDocument)
                    .HasConstraintName("to_documents");

                entity.HasOne(d => d.IdEmailNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdEmail)
                    .HasConstraintName("to_emails");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("authors_fk");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("categories_pk");

                entity.ToTable("categories", "Blog");

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

                entity.ToTable("documents", "Blog");

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

                entity.HasOne(d => d.IdDocumentTypeNavigation)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.IdDocumentType)
                    .HasConstraintName("documents_fk");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IdDocumentType)
                    .HasName("document_types_pk");

                entity.ToTable("document_types", "Blog");

                entity.Property(e => e.IdDocumentType).HasColumnName("id_document_type");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("emails_pk");

                entity.ToTable("emails", "Blog");

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

                entity.ToTable("pictures", "Blog");

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

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("pictures_fk");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.IdPost)
                    .HasName("posts_pk");

                entity.ToTable("posts", "Blog");

                entity.Property(e => e.IdPost).HasColumnName("id_post");

                entity.Property(e => e.Body)
                    .HasColumnName("body")
                    .HasComment("HTML code");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
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

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("to_auth");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("to_cat");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("to_pic");
            });

            modelBuilder.Entity<SocialMediaRef>(entity =>
            {
                entity.HasKey(e => e.IdSocialMediaRef)
                    .HasName("social_media_refs_pk");

                entity.ToTable("social_media_refs", "Blog");

                entity.Property(e => e.IdSocialMediaRef).HasColumnName("id_social_media_ref");

                entity.Property(e => e.Href)
                    .IsRequired()
                    .HasColumnName("href")
                    .HasComment("href to social media account");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdSocialMedia)
                    .HasColumnName("id_social_media")
                    .HasComment("social media name");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.SocialMediaRefs)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("to_authors");

                entity.HasOne(d => d.IdSocialMediaNavigation)
                    .WithMany(p => p.SocialMediaRefs)
                    .HasForeignKey(d => d.IdSocialMedia)
                    .HasConstraintName("to_social_media");
            });

            modelBuilder.Entity<SocialMedium>(entity =>
            {
                entity.HasKey(e => e.IdSocialMedia)
                    .HasName("social_media_pk");

                entity.ToTable("social_media", "Blog");

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
