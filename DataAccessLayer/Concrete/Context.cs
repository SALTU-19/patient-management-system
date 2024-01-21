using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        private static string Host = "flexibledb.postgres.database.azure.com";
        private static string User = "saltu";
        private static string DBname = "postgres";
        private static string Password = "7980106150aA";
        private static string Port = "5432";


        // postgresql connection string get from appsettings.json
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
               string connString =
                String.Format(
                    "Server={0};User Id={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password);
            optionsBuilder.UseNpgsql(connString);
            //optionsBuilder.UseNpgsql("server=flexibleserverdb.postgres.database.azure.com;port=5432;database=postgres;user id=saltu;password=7980106150aA");
        }

        // add postgresql gen_random_uuid() function to ef core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.Entity<DrugHistory>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<DiseaseHistory>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<SurgeryHistory>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<PreOp>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<PostOp>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<PeriodicVisitHistory>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<IrregularVisitHistory>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<User>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<LoginAttempt>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Hospital>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Patient>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Organization>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Session>().Property(x => x.UId).HasDefaultValueSql("uuid_generate_v4()");
        }



        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DiseaseHistory> DiseaseHistories { get; set; }
        public DbSet<DrugHistory> DrugHistories { get; set; }
        public DbSet<SurgeryHistory> SurgeryHistories { get; set; }
        public DbSet<PreOp> PreOps { get; set; }
        public DbSet<PostOp> PostOps { get; set; }
        public DbSet<PeriodicVisitHistory> PeriodicVisitHistories { get; set; }
        public DbSet<IrregularVisitHistory> IrregularVisitHistories { get; set; }




    }
}
