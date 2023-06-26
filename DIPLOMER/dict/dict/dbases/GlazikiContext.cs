using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dict.dbases;

public partial class GlazikiContext : DbContext
{
    public GlazikiContext()
    {
    }

    public GlazikiContext(DbContextOptions<GlazikiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Mark> Marks { get; set; }

    public virtual DbSet<Marktype> Marktypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=glaziki;userid=postgres;password=1q3e2w4r");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("group_pk");

            entity.ToTable("group");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Mark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mark_pk");

            entity.ToTable("mark");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.MarkId).HasColumnName("mark_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.SubId).HasColumnName("sub_id");

            entity.HasOne(d => d.MarkNavigation).WithMany(p => p.Marks)
                .HasForeignKey(d => d.MarkId)
                .HasConstraintName("mark_fk");

            entity.HasOne(d => d.Student).WithMany(p => p.Marks)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("mark_fk3");

            entity.HasOne(d => d.Sub).WithMany(p => p.Marks)
                .HasForeignKey(d => d.SubId)
                .HasConstraintName("mark_fk2");
        });

        modelBuilder.Entity<Marktype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("marktype_pk");

            entity.ToTable("marktype");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Mark).HasColumnName("mark");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pk");

            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pk");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("student_fk");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subject_pk");

            entity.ToTable("subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Subname)
                .HasColumnType("character varying")
                .HasColumnName("subname");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("subject_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teacher_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('teacher_id_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasColumnType("character varying")
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasColumnType("character varying")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
