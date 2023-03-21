using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApplication;

public partial class DblibraryContext : DbContext
{
    public DblibraryContext()
    {
    }

    public DblibraryContext(DbContextOptions<DblibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Runner> Runners { get; set; }

    public virtual DbSet<Shedule> Shedules { get; set; }

    public virtual DbSet<TrainingProgram> TrainingPrograms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= DESKTOP-QUU2DMM;\nDatabase=DBLibrary; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coach>(entity =>
        {
            entity.ToTable("Coach");

            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.CoachBirthDay)
                .HasColumnType("date")
                .HasColumnName("coach_birthDay");
            entity.Property(e => e.CoachName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coach_name");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExId);

            entity.ToTable("Exercise");

            entity.Property(e => e.ExId).HasColumnName("ex_id");
            entity.Property(e => e.ExDuration).HasColumnName("ex_duration");
            entity.Property(e => e.ExName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ex_name");
            entity.Property(e => e.NumOfSets).HasColumnName("num_of_sets");
            entity.Property(e => e.SheduleId).HasColumnName("shedule_id");

            entity.HasOne(d => d.Shedule).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.SheduleId)
                .HasConstraintName("FK_Exercise_Shedule");
        });

        modelBuilder.Entity<Runner>(entity =>
        {
            entity.HasKey(e => e.RunnerId).HasName("PK_unner");

            entity.ToTable("Runner");

            entity.Property(e => e.RunnerId).HasColumnName("runner_id");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Mobile).HasColumnName("mobile");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.RunnerBirthDay)
                .HasColumnType("date")
                .HasColumnName("runner_birthDay");
            entity.Property(e => e.RunnerWeight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("runner_weight");

            entity.HasOne(d => d.Coach).WithMany(p => p.Runners)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK_Runner_Coach");

            entity.HasOne(d => d.Program).WithMany(p => p.Runners)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("FK_Runner_Training_Program");
        });

        modelBuilder.Entity<Shedule>(entity =>
        {
            entity.ToTable("Shedule");

            entity.Property(e => e.SheduleId)
                .ValueGeneratedNever()
                .HasColumnName("shedule_id");
            entity.Property(e => e.AvgPace)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("avg_pace");
            entity.Property(e => e.Calories).HasColumnName("calories");
            entity.Property(e => e.CoachId).HasColumnName("coach_id");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Distant).HasColumnName("distant");
            entity.Property(e => e.ProgramId)
                .ValueGeneratedOnAdd()
                .HasColumnName("program_id");
            entity.Property(e => e.RunnerId).HasColumnName("runner_id");

            entity.HasOne(d => d.Coach).WithMany(p => p.Shedules)
                .HasForeignKey(d => d.CoachId)
                .HasConstraintName("FK_Shedule_Coach");

            entity.HasOne(d => d.Program).WithMany(p => p.Shedules)
                .HasForeignKey(d => d.ProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shedule_Training_Program");

            entity.HasOne(d => d.Runner).WithMany(p => p.Shedules)
                .HasForeignKey(d => d.RunnerId)
                .HasConstraintName("FK_Shedule_Runner");
        });

        modelBuilder.Entity<TrainingProgram>(entity =>
        {
            entity.HasKey(e => e.ProgramId);

            entity.ToTable("Training_Program");

            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ProgramDuration).HasColumnName("program_duration");
            entity.Property(e => e.ProgramType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("program_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
