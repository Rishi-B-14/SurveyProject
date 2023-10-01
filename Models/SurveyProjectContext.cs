using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SurveyNew.Models;

public partial class SurveyProjectContext : DbContext
{
    public SurveyProjectContext()
    {
    }

    public SurveyProjectContext(DbContextOptions<SurveyProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblUserDetail> TblUserDetails { get; set; }

    public virtual DbSet<TblUserInfo> TblUserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8VEE66M\\SQLEXPRESS;Initial Catalog=SurveyProject;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TblProduct");

            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblUserDetail>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.City)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNum).HasMaxLength(15);
            entity.Property(e => e.SelectedProduct).HasMaxLength(50);
            entity.Property(e => e.SubmissionTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblUserInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Id");

            entity.ToTable("TblUserInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNum).HasMaxLength(15);
            entity.Property(e => e.Village)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
