﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.EntityFrameworkCore;

namespace CouchBotOSS.Data.Models;

public partial class CouchContext : DbContext
{
    public CouchContext(DbContextOptions<CouchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiscordUser> DiscordUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiscordUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("idx_19625_discordusers_pkey");

            entity.ToTable("discordusers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Allowance).HasColumnName("allowance");
            entity.Property(e => e.AllowanceOverride)
                .HasDefaultValueSql("false")
                .HasColumnName("allowanceoverride");
            entity.Property(e => e.CustomPing).HasColumnName("customping");
            entity.Property(e => e.DefaultPlatformId).HasColumnName("defaultplatformid");
            entity.Property(e => e.DiscordUserId).HasColumnName("discorduserid");
            entity.Property(e => e.Discriminator).HasColumnName("discriminator");
            entity.Property(e => e.ModifiedDate).HasColumnName("modifieddate");
            entity.Property(e => e.Nickname).HasColumnName("nickname");
            entity.Property(e => e.PatreonExempt)
                .HasDefaultValueSql("false")
                .HasColumnName("patreonexempt");
            entity.Property(e => e.PatreonId).HasColumnName("patreonid");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}