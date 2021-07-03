using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


#nullable disable

namespace database
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
        public virtual DbSet<Feed> Feeds { get; set; }
        public virtual DbSet<Icon> Icons { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<IngredientCategory> IngredientCategories { get; set; }
        public virtual DbSet<IngredientIndex> IngredientIndices { get; set; }
        public virtual DbSet<IngredientRef> IngredientRefs { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipePictureIndex> RecipePictureIndices { get; set; }
        public virtual DbSet<RecipeTagIndex> RecipeTagIndices { get; set; }
        public virtual DbSet<RecipeUserIndex> RecipeUserIndices { get; set; }
        public virtual DbSet<SocialMediaRef> SocialMediaRefs { get; set; }
        public virtual DbSet<SocialMedium> SocialMedia { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEmail> UserEmails { get; set; }
        public virtual DbSet<UserLoginDatum> UserLoginData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Connection.ConnectToDb(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp")
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

            modelBuilder.Entity<Feed>(entity =>
            {
                entity.HasKey(e => e.IdFeed)
                    .HasName("feed_pk");

                entity.ToTable("feeds", "Main");

                entity.Property(e => e.IdFeed)
                    .HasColumnName("id_feed")
                    .HasDefaultValueSql("nextval('\"Main\".feed_id_feed_seq'::regclass)");

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
                    .HasColumnType("date")
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

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IdIngredient)
                    .HasName("ingredients_pk");

                entity.ToTable("ingredients", "Main");

                entity.Property(e => e.IdIngredient).HasColumnName("id_ingredient");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("to_ingredients");
            });

            modelBuilder.Entity<IngredientCategory>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("ingredient_categories_pk");

                entity.ToTable("ingredient_categories", "Main");

                entity.HasIndex(e => e.Name, "ingredient_categories_name_uindex")
                    .IsUnique();

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<IngredientIndex>(entity =>
            {
                entity.HasKey(e => new { e.IdRecipe, e.IdIngredient, e.IdRef })
                    .HasName("ingredient_index_pk");

                entity.ToTable("ingredient_index", "Main");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.IdIngredient).HasColumnName("id_ingredient");

                entity.Property(e => e.IdRef)
                    .HasColumnName("id_ref")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Grams).HasColumnName("grams");

                entity.HasOne(d => d.IdIngredientNavigation)
                    .WithMany(p => p.IngredientIndices)
                    .HasForeignKey(d => d.IdIngredient)
                    .HasConstraintName("to_ingredients");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.IngredientIndices)
                    .HasForeignKey(d => d.IdRecipe)
                    .HasConstraintName("to_recipes");

                entity.HasOne(d => d.IdRefNavigation)
                    .WithMany(p => p.IngredientIndices)
                    .HasForeignKey(d => d.IdRef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("to_refs");
            });

            modelBuilder.Entity<IngredientRef>(entity =>
            {
                entity.HasKey(e => e.IdRef)
                    .HasName("ingredient_refs_pk");

                entity.ToTable("ingredient_refs", "Main");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
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
                    .HasColumnType("date")
                    .HasColumnName("date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.IdCat).HasColumnName("id_cat");

                entity.Property(e => e.IdPicture)
                    .HasColumnName("id_picture")
                    .HasDefaultValueSql("0")
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
                    .OnDelete(DeleteBehavior.Cascade)
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

                entity.Property(e => e.IdQuote).HasColumnName("id_quote");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("author");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasColumnName("source");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Quotes)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("to_users");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.IdRecipe)
                    .HasName("recipes_pk");

                entity.ToTable("recipes", "Main");

                entity.HasComment("table for Food API");

                entity.Property(e => e.IdRecipe)
                    .HasColumnName("id_recipe")
                    .HasDefaultValueSql("nextval('\"Main\".recipes_inc'::regclass)");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body");

                entity.Property(e => e.CookingTime)
                    .HasColumnType("time without time zone")
                    .HasColumnName("cooking_time");

                entity.Property(e => e.Servings)
                    .HasColumnName("servings")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("date")
                    .HasColumnName("timestamp")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("title");

                entity.Property(e => e.TotalOutcome)
                    .HasColumnType("character varying")
                    .HasColumnName("total_outcome");
            });

            modelBuilder.Entity<RecipePictureIndex>(entity =>
            {
                entity.HasKey(e => new { e.IdRecipe, e.IdPicture })
                    .HasName("picture_index_pk");

                entity.ToTable("recipe_picture_index", "Main");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.IdPicture).HasColumnName("id_picture");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.RecipePictureIndices)
                    .HasForeignKey(d => d.IdPicture)
                    .HasConstraintName("recipe_picture_index_fk");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.RecipePictureIndices)
                    .HasForeignKey(d => d.IdRecipe)
                    .HasConstraintName("picture_index_fk_1");
            });

            modelBuilder.Entity<RecipeTagIndex>(entity =>
            {
                entity.HasKey(e => new { e.IdTag, e.IdRecipe })
                    .HasName("tag_index_pk");

                entity.ToTable("recipe_tag_index", "Main");

                entity.Property(e => e.IdTag).HasColumnName("id_tag");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.RecipeTagIndices)
                    .HasForeignKey(d => d.IdRecipe)
                    .HasConstraintName("to_recipes");

                entity.HasOne(d => d.IdTagNavigation)
                    .WithMany(p => p.RecipeTagIndices)
                    .HasForeignKey(d => d.IdTag)
                    .HasConstraintName("to_tags");
            });

            modelBuilder.Entity<RecipeUserIndex>(entity =>
            {
                entity.HasKey(e => new { e.IdRecipe, e.IdUser })
                    .HasName("user_index_pk");

                entity.ToTable("recipe_user_index", "Main");

                entity.Property(e => e.IdRecipe).HasColumnName("id_recipe");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdRecipeNavigation)
                    .WithMany(p => p.RecipeUserIndices)
                    .HasForeignKey(d => d.IdRecipe)
                    .HasConstraintName("to_recipes");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RecipeUserIndices)
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

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(e => e.IdTag)
                    .HasName("tags_pk");

                entity.ToTable("tags", "Main");

                entity.HasIndex(e => e.Name, "tags_name_uindex")
                    .IsUnique();

                entity.Property(e => e.IdTag).HasColumnName("id_tag");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
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
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("to_emails");

                entity.HasOne(d => d.IdPictureNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPicture)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("authors_fk");
            });

            modelBuilder.Entity<UserEmail>(entity =>
            {
                entity.HasKey(e => e.IdEmail)
                    .HasName("emails_pk");

                entity.ToTable("user_emails", "Main");

                entity.Property(e => e.IdEmail)
                    .HasColumnName("id_email")
                    .HasDefaultValueSql("nextval('\"Main\".emails_id_email_seq'::regclass)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("email")
                    .HasComment("email from app");
            });

            modelBuilder.Entity<UserLoginDatum>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("users_pk");

                entity.ToTable("user_login_data", "Main");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.AccountCreated)
                    .HasColumnType("date")
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
                    .WithOne(p => p.UserLoginDatum)
                    .HasForeignKey<UserLoginDatum>(d => d.IdUser)
                    .HasConstraintName("login_data_fk");
            });

            modelBuilder.HasSequence("recipes_inc", "Main");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
