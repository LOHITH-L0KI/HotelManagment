using Microsoft.EntityFrameworkCore;
using Persistance.DataSets;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Persistance
{
    public class PersistanceContext : DbContext
    {

        /// <summary>
        /// Initialize DbContext with DbContextOptions
        /// </summary>
        /// <param name="dbContextOptions">context options with connection string data</param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public PersistanceContext(DbContextOptions<PersistanceContext> dbContextOptions):
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
            base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                Debug.Assert(false, "Datebase connection is not provided.\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                modelBuilder.Entity<User_Details>()
                    .HasIndex(ud => ud.Email)
                    .IsUnique();

                modelBuilder.Entity<User_Details>()
                    .HasIndex(ud => ud.ContactNumber)
                    .IsUnique();

                modelBuilder.Entity<User_Details>()
                    .HasAlternateKey(ud => new { ud.FirstName, ud.LastName });

                modelBuilder.Entity<User_Details>()
                    .Property(ud => ud.Type)
                    .HasDefaultValue(UserType.Default);

            }

            {
                modelBuilder.Entity<User_Login_Data>()
                    .HasIndex(uld => uld.UserName)
                    .IsUnique();
            }

            {
                modelBuilder.Entity<Room_Details>()
                    .HasIndex(rd => new { rd.Number, rd.Floor })
                    .IsUnique();
            }

            {
                modelBuilder.Entity<Customer_Details>()
                   .HasIndex(cd => cd.Email)
                   .IsUnique();

                modelBuilder.Entity<Customer_Details>()
                    .HasIndex(cd => cd.ContactNumber)
                    .IsUnique();

                modelBuilder.Entity<Customer_Details>()
                    .HasAlternateKey(cd => new { cd.FirstName, cd.LastName });
            }
          
        }


        //Db Sets.
        public DbSet<User_Login_Data> userLoginDatas;
        public DbSet<User_Details> userDetails;
        public DbSet<Room_Details> roomDetails;
        public DbSet<Customer_Details> customerDetails;
        public DbSet<Booking_Details> bookingDetails;

    }
}
