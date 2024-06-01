﻿using Microsoft.EntityFrameworkCore;

namespace EFCodeFirst.Models
{

    public class EFCodeFirstDbContext : DbContext
    {

        public EFCodeFirstDbContext(DbContextOptions<EFCodeFirstDbContext> options) : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void onModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

            modelBuilder.Entity<PrescriptionMedicament>().HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments).HasForeignKey(pm => pm.IdPrescription);

            modelBuilder.Entity<PrescriptionMedicament>().HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments).HasForeignKey(pm => pm.IdMedicament);
        }
    }
}



