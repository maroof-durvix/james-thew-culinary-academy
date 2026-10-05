using JamesThew.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Data
{
    public class JamesThewDbContext : DbContext
    {
        public JamesThewDbContext(DbContextOptions<JamesThewDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Tip> Tips { get; set; } = null!;
        public DbSet<Contest> Contests { get; set; } = null!;
        public DbSet<ContestEntry> ContestEntries { get; set; } = null!;
        public DbSet<Announcement> Announcements { get; set; } = null!;
        public DbSet<RecipeFeedback> RecipeFeedbacks { get; set; } = null!;
        public DbSet<SiteFeedback> SiteFeedbacks { get; set; } = null!;
        public DbSet<ContactMessage> ContactMessages { get; set; } = null!;
        public DbSet<Faq> Faqs { get; set; } = null!;
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
                
            modelBuilder.Entity<ContestEntry>()
                .HasOne(e => e.WinnerAnnouncement)
                .WithOne(a => a.WinnerEntry)
                .HasForeignKey<Announcement>(a => a.WinnerEntryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Author)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tip>()
                .HasOne(t => t.Author)
                .WithMany(u => u.Tips)
                .HasForeignKey(t => t.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ContestEntry>()
                .HasOne(e => e.User)
                .WithMany(u => u.ContestEntries)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Subscription>()
                .Property(s => s.Amount)
                .HasPrecision(18, 2);
        }
    }
}
