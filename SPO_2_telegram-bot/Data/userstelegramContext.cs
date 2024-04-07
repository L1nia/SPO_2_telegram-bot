using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SPO_2_telegram_bot.Data
{
    public partial class userstelegramContext : DbContext
    {
        public userstelegramContext()
        {
        }

        public userstelegramContext(DbContextOptions<userstelegramContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=userstelegram;Username=postgres;Password=1973");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.ToTable("chat");

                entity.Property(e => e.Chatid).HasColumnName("chatid");

                entity.Property(e => e.BonusCount).HasColumnName("bonus_count");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
