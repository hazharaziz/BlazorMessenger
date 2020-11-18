using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlazorMessenger.Models;

#nullable disable

namespace BlazorMessenger.Context
{
    public partial class MessengerContext : DbContext
    {
        public MessengerContext()
        {
        }

        public MessengerContext(DbContextOptions<MessengerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Follower> Followers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionString.Messenger");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follower>(entity =>
            {
                entity.HasOne(d => d.FollowerNavigation)
                    .WithMany(p => p.FollowerFollowerNavigations)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Follower_Follower");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FollowerUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Follower_User");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.Composer)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.ComposerId)
                    .HasConstraintName("FK_Message_Composer");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.IsPublic).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
