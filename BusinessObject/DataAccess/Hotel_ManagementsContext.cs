using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BusinessObject.DataAccess
{
    public partial class Hotel_ManagementsContext : DbContext
    {
        public Hotel_ManagementsContext()
        {
        }

        public Hotel_ManagementsContext(DbContextOptions<Hotel_ManagementsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
              //  optionsBuilder.UseSqlServer("server =DESKTOP-KO6PNCL\\SQLEXPRESS;database =Hotel_Managements;uid=sa;pwd=1234567890;");
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        public staff getDefaultAccounts()
        {
            var admin = new staff();
            IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            admin.StaffId = "AD";
            admin.StaffName = "ADMIN";
            admin.Email = config["Credentials:Email"];
            admin.Password = config["Credentials:Password"];
            
            return admin;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId)
                    .HasMaxLength(200)
                    .HasColumnName("BookingID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("CustomerID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Custome__38996AB5");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("BookingDetail");

                entity.Property(e => e.BookingDetailId)
                    .HasMaxLength(200)
                    .HasColumnName("Booking_Detail_ID");

                entity.Property(e => e.BookingId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("BookingID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RoomId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Room_ID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingDe__Booki__45F365D3");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BookingDe__Room___46E78A0C");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(200)
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.Property(e => e.HotelId)
                    .HasMaxLength(200)
                    .HasColumnName("HotelID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomId)
                    .HasMaxLength(200)
                    .HasColumnName("RoomID");

                entity.Property(e => e.HotelId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("HotelID");

                entity.Property(e => e.ImageString)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RoomDescription)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.RoomPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TypeId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("TypeID");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__HotelID__3F466844");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__TypeID__403A8C7D");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId)
                    .HasMaxLength(200)
                    .HasColumnName("TypeID");

                entity.Property(e => e.NameType)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name_Type");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.StaffId)
                    .HasMaxLength(200)
                    .HasColumnName("Staff_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.HotelId)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("HotelID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StaffName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Staff__HotelID__4316F928");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
