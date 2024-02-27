using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Demo_test_app.Models;

public partial class ZayavkerBackContext : DbContext
{
    public ZayavkerBackContext()
    {
    }

    public ZayavkerBackContext(DbContextOptions<ZayavkerBackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<TypeEquipment> TypeEquipments { get; set; }

    public virtual DbSet<TypeProblem> TypeProblems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=zayavker_back;user=root;password=XCR6hs2M", ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.IdApplication).HasName("PRIMARY");

            entity.ToTable("application");

            entity.HasIndex(e => e.IdEmployee, "Fk_IdEmployee_idx");

            entity.HasIndex(e => e.WorkStatus, "Fk_IdStageWork_idx");

            entity.HasIndex(e => e.IdTypeEquipment, "Fk_id_type_equipment_idx");

            entity.HasIndex(e => e.IdTypeProblem, "Fk_id_type_problem_idx");

            entity.Property(e => e.IdApplication).HasColumnName("id_application");
            entity.Property(e => e.Comment)
                .HasColumnType("text")
                .HasColumnName("comment");
            entity.Property(e => e.Cost)
                .HasPrecision(10, 2)
                .HasColumnName("cost");
            entity.Property(e => e.DateAddition).HasColumnName("date_addition");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IdEmployee).HasColumnName("id_employee");
            entity.Property(e => e.IdTypeEquipment).HasColumnName("id_type_equipment");
            entity.Property(e => e.IdTypeProblem).HasColumnName("id_type_problem");
            entity.Property(e => e.NameClient)
                .HasMaxLength(45)
                .HasColumnName("name_client");
            entity.Property(e => e.NameEquipment)
                .HasMaxLength(45)
                .HasColumnName("name_equipment");
            entity.Property(e => e.Number)
                .HasComment("серийный номер")
                .HasColumnName("number");
            entity.Property(e => e.PeriodExecution)
                .HasComment("предварительная дата завершения")
                .HasColumnName("period_execution");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.TimeWork)
                .HasColumnType("time")
                .HasColumnName("time_work");
            entity.Property(e => e.WorkStatus)
                .HasMaxLength(45)
                .HasColumnName("work_status");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("Fk_id_employee");

            entity.HasOne(d => d.IdTypeEquipmentNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdTypeEquipment)
                .HasConstraintName("Fk_id_type_equipment");

            entity.HasOne(d => d.IdTypeProblemNavigation).WithMany(p => p.Applications)
                .HasForeignKey(d => d.IdTypeProblem)
                .HasConstraintName("Fk_id_type_problem");
        });

        modelBuilder.Entity<TypeEquipment>(entity =>
        {
            entity.HasKey(e => e.IdTypeEquipment).HasName("PRIMARY");

            entity.ToTable("type_equipment");

            entity.Property(e => e.IdTypeEquipment)
                .ValueGeneratedNever()
                .HasColumnName("id_type_equipment");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeProblem>(entity =>
        {
            entity.HasKey(e => e.IdTypeProblemt).HasName("PRIMARY");

            entity.ToTable("type_problem");

            entity.Property(e => e.IdTypeProblemt)
                .HasComment("тип неисправностей")
                .HasColumnName("id_type_problemt");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .ValueGeneratedNever()
                .HasColumnName("id_user");
            entity.Property(e => e.FullnameUser)
                .HasMaxLength(100)
                .HasColumnName("fullname_user");
            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(45)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
