namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AreaAffected> AreaAffecteds { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PlasmodiumType> PlasmodiumTypes { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<Symptom> Symptoms { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaAffected>()
                .Property(e => e.PatientCountry)
                .IsUnicode(false);

            modelBuilder.Entity<AreaAffected>()
                .Property(e => e.PatientRegion)
                .IsUnicode(false);

            modelBuilder.Entity<AreaAffected>()
                .HasMany(e => e.Patients)
                .WithRequired(e => e.AreaAffected)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AreaAffected>()
                .HasMany(e => e.Statistics)
                .WithRequired(e => e.AreaAffected)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonationCurrency)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonationAmount)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorFName)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorLName)
                .IsUnicode(false);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorAccNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorTotal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Donor>()
                .Property(e => e.DonorCellphone)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientFName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientSName)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientCellphone)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Medicating)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Race)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.PatientAddress)
                .IsUnicode(false);

            modelBuilder.Entity<PlasmodiumType>()
                .Property(e => e.PlasmodiumName)
                .IsUnicode(false);

            modelBuilder.Entity<PlasmodiumType>()
                .Property(e => e.IncubationPeriod)
                .IsUnicode(false);

            modelBuilder.Entity<Sponsor>()
                .Property(e => e.SponsorFName)
                .IsUnicode(false);

            modelBuilder.Entity<Sponsor>()
                .Property(e => e.SponsorLName)
                .IsUnicode(false);

            modelBuilder.Entity<Sponsor>()
                .Property(e => e.SponsorCellphone)
                .IsUnicode(false);

            modelBuilder.Entity<Sponsor>()
                .Property(e => e.SponsorEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.PerninatalMortalityRate)
                .IsUnicode(false);

            modelBuilder.Entity<Symptom>()
                .Property(e => e.SymptomID)
                .IsUnicode(false);

            modelBuilder.Entity<Symptom>()
                .Property(e => e.SymptomName)
                .IsUnicode(false);

            modelBuilder.Entity<Symptom>()
                .Property(e => e.SymptonDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentMode)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Treatment>()
                .Property(e => e.TreatmentMedication)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.VolunteerCellphone)
                .IsUnicode(false);

            modelBuilder.Entity<Volunteer>()
                .Property(e => e.VolunteerEmergencyContact)
                .IsUnicode(false);
        }
    }
}
