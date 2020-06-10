namespace BookMyShow.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookMyShowDbContext : DbContext
    {
        public BookMyShowDbContext()
            : base("name=BookMyShowDbContext")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<StarRatings> StarRatings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.SeatNumber)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.MovieName)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .Property(e => e.Icon)
                .IsUnicode(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Shows)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Movie)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.SeatNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Show>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Show>()
                .HasMany(e => e.Bookings)
                .WithRequired(e => e.Show)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Show>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Show)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Show>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.Show)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.State)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ticket>()
                .Property(e => e.TicketType)
                .IsUnicode(false);

            modelBuilder.Entity<Ticket>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Ticket)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<BookMyShow.Models.ReportInfo> ReportInfoes { get; set; }
    }
}
