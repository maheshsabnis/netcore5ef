using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCore_Net5.Models
{
    public class EFCore5DbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public EFCore5DbContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
                .UseSqlServer(@"Server=tcp:msitdb.database.windows.net,1433;Initial Catalog=Company;Persist Security Info=False;User ID=MaheshAdmin;Password=P@ssw0rd_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                    .HasMany(o => o.Orders)
                    .WithMany(c => c.Customers)
                    .UsingEntity(e => e.ToTable("CustomersOrders"));

            modelBuilder.Entity<Employee>()
                        .HasOne(d => d.Department)
                        .WithMany(e => e.Employees)
                        .HasForeignKey(d => d.DeptNo);

            var movies = new Movie[] {
        new Movie { Id = 1, Name = "Avengers: Endgame", WorldwideBoxOfficeGross = 2_797_800_564, DurationInMinutes = 181, Release = new DateTime(2019, 4, 26) },
        new Movie { Id = 2, Name = "The Lion King", WorldwideBoxOfficeGross = 1_654_791_102, DurationInMinutes     = 118, Release = new DateTime(2019, 7, 19) },
        new Movie { Id = 3, Name = "Ip Man 4", WorldwideBoxOfficeGross = 192_617_891, DurationInMinutes = 105, Release = new DateTime(2019, 12, 25) },
        new Movie { Id = 4, Name = "Gemini Man", WorldwideBoxOfficeGross = 166_623_705, DurationInMinutes = 116, Release = new DateTime(2019, 11, 20) },
        new Movie { Id = 5, Name = "Downton Abbey", WorldwideBoxOfficeGross = 194_051_302, DurationInMinutes = 120, Release = new DateTime(2020, 9, 20 )}
    };
            var series = new Series[] {
        new Series { Id = 6 , Name = "The Fresh Prince of Bel-Air", NumberOfEpisodes = 148, Release = new DateTime(1990, 9, 10) },
        new Series { Id = 7 , Name = "Downton Abbey", NumberOfEpisodes = 52, Release = new DateTime(2010, 09, 26) },
        new Series { Id = 8 , Name = "Stranger Things", NumberOfEpisodes = 34 , Release = new DateTime(2016, 7, 11) },
        new Series { Id = 9 , Name = "Kantaro: The Sweet Tooth Salaryman", NumberOfEpisodes = 12, Release = new DateTime(2017,7, 14) },
        new Series { Id = 10, Name = "The Walking Dead", NumberOfEpisodes = 177 , Release = new DateTime(2010, 10, 31) }
    };
            var productions = movies
                .Cast<Production>()
                .Union(series)
                .ToList();
            modelBuilder.Entity<Movie>().HasData(movies);
            modelBuilder.Entity<Series>().HasData(series);
            base.OnModelCreating(modelBuilder);
        }
    }
}
