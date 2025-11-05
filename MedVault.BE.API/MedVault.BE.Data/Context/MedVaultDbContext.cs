using MedVault.BE.Common.Constants;
using MedVault.BE.Data.Entities.Master;
using MedVault.BE.Data.Entities.Patient;
using MedVault.BE.Data.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace MedVault.BE.Data.Context
{
    public class MedVaultDbContext(DbContextOptions<MedVaultDbContext> options) : DbContext(options)
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<PatientProfile> PatientProfiles { get; set; }
        public DbSet<DoctorProfile> DoctorProfiles { get; set; }
        public DbSet<DocumentCategory> DocumentCategories { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }
        public DbSet<MedicalDocument> MedicalDocumentes { get; set; }
        public DbSet<Reminder> Reminderes { get; set; }
        public DbSet<OtpVerification> OtpVerificationes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data if you have extension method
            modelBuilder.SeedDefaultData();

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<PatientProfile>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<DoctorProfile>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<DocumentCategory>(entity =>
            {
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<PatientHistory>(entity =>
            {
                entity.HasOne(ph => ph.PatientProfile).WithMany().HasForeignKey(ph => ph.PatientId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ph => ph.DoctorProfile).WithMany().HasForeignKey(ph => ph.DoctorId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<MedicalDocument>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(SystemConstant.CURRENT_UTC_DATETIME);
            });

            modelBuilder.Entity<OtpVerification>();
        }
    }
}