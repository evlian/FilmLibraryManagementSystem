using FilmLibraryManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmLibraryManagementSystem.Data
{
    public class FilmLibraryContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public FilmLibraryContext() 
        { }

        public FilmLibraryContext(DbContextOptions<FilmLibraryContext> options)
        { }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (LocalDb)\\MSSQLLocalDB; Initial Catalog=FilmLibrary");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Films)
                .UsingEntity<FilmGenre>(
                    x => x.HasOne(x => x.Genre)
                    .WithMany().HasForeignKey(x => x.GenreId),
                    x => x.HasOne(x => x.Film)
                    .WithMany().HasForeignKey(x => x.FilmId));
        }
    }
}
