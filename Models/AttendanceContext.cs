using Microsoft.EntityFrameworkCore;

namespace AttendanceAPI2.Models
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Sequance> Sequances { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AttendanceRecord> AttendanceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AttendanceRecord>()
            //    .HasOne(a => a.User)
            //    .WithMany(u => u.AttendanceRecords)
            //    .HasForeignKey(a => a.User_Id)
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            //modelBuilder.Entity<AttendanceRecord>()
            //    .HasOne(a => a.Session)
            //    .WithMany(s => s.AttendanceRecords)
            //    .HasForeignKey(a => a.Session_Id)
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            //modelBuilder.Entity<Session>()
            //    .HasOne(s => s.User)
            //    .WithMany(u => u.Sessions)
            //    .HasForeignKey(s => s.User_Id)
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete


            base.OnModelCreating(modelBuilder);
        }
    }
}
