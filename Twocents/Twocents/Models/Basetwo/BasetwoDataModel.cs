namespace Twocents
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BasetwoDataModel : DbContext
    {
        public BasetwoDataModel()
            : base("name=BasetwoDataModel")
        {
        }

        public virtual DbSet<AccessType> AccessTypes { get; set; }
        public virtual DbSet<CommentFlag> CommentFlags { get; set; }
        public virtual DbSet<CommentRating> CommentRatings { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentSource> CommentSources { get; set; }
        public virtual DbSet<Edit> Edits { get; set; }
        public virtual DbSet<FlagType> FlagTypes { get; set; }
        public virtual DbSet<SourceType> SourceTypes { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteType> VoteTypes { get; set; }
        public virtual DbSet<Webpage> Webpages { get; set; }
        public virtual DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AccessType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<AccessType>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.AccessType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommentFlag>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CommentFlag>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.CommentFlag)
                .HasForeignKey(e => e.FlagId);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.CommentRatings)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.Edits)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>()
                .HasMany(e => e.Votes)
                .WithRequired(e => e.Comment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CommentSource>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.CommentSource)
                .HasForeignKey(e => e.SourceId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Edit>()
                .Property(e => e.Changes)
                .IsUnicode(false);

            modelBuilder.Entity<Edit>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<FlagType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FlagType>()
                .HasMany(e => e.CommentFlags)
                .WithRequired(e => e.FlagType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SourceType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SourceType>()
                .HasMany(e => e.CommentSources)
                .WithRequired(e => e.SourceType)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoteType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<VoteType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<VoteType>()
                .HasMany(e => e.CommentRatings)
                .WithRequired(e => e.VoteType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VoteType>()
                .HasMany(e => e.Votes)
                .WithRequired(e => e.VoteType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Webpage>()
                .Property(e => e.url)
                .IsUnicode(false);

            modelBuilder.Entity<Webpage>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Webpage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Website>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
