using System.Data;
using Microsoft.EntityFrameworkCore;

using Configuration;
using Models;

namespace DbContext;

//DbContext namespace is a fundamental EFC layer of the database context and is
//used for all Database connection as well as for EFC CodeFirst migration and database updates 

public class MainDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    //Table mapping
    public DbSet<Friend> Friend { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Pet> Pet { get; set; }
    public DbSet<Quote> Quote { get; set; }

    //get right DBContext from DbSet configuration in Appsettings
    public static DbContextOptionsBuilder<MainDbContext> DbContextOptions()
    {
        var _optionsBuilder = new DbContextOptionsBuilder<MainDbContext>();

        if (AppConfig.DbSetActive.DbServer == "SQLServer")
        {
            _optionsBuilder.UseSqlServer(AppConfig.DbSetActive.DbConnectionString,
                    options => options.EnableRetryOnFailure());
            return _optionsBuilder;
        }
        else if (AppConfig.DbSetActive.DbServer == "Postgres")
        {
            _optionsBuilder.UseNpgsql(AppConfig.DbSetActive.DbConnectionString);
            return _optionsBuilder;
        }

        //unknown database type
        throw new InvalidDataException($"Database type {AppConfig.DbSetActive.DbServer} does not exist");
    }

    //Given a userlogin, this method finds the LoginDetails in the Active DbSet and return a DbContext
    public static MainDbContext DbContext() =>
        new MainDbContext(MainDbContext.DbContextOptions().Options);


    //constructors
    public MainDbContext() { }
    public MainDbContext(DbContextOptions options) : base(options) { }

    //Here we can modify the migration building
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    // DbContexts for some popular databases
    public class SqlServerDbContext : MainDbContext
    {
        public SqlServerDbContext() { }
        public SqlServerDbContext(DbContextOptions options) : base(options)
        { }


        //Used only for CodeFirst Database Migration and database update commands
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = AppConfig.DbSetActive.DbConnectionString;
                optionsBuilder.UseSqlServer(connectionString,
                    options => options.EnableRetryOnFailure());
                    
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HaveColumnType("money");
            configurationBuilder.Properties<string>().HaveColumnType("nvarchar(200)");

            base.ConfigureConventions(configurationBuilder);
        }

        #region Add your own modelling based on done migrations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }

    public class PostgresDbContext : MainDbContext
    {
        public PostgresDbContext() { }
        public PostgresDbContext(DbContextOptions options) : base(options)
        { }


        //Used only for CodeFirst Database Migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = AppConfig.DbSetActive.DbConnectionString;
                optionsBuilder.UseNpgsql(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveColumnType("varchar(200)");
            base.ConfigureConventions(configurationBuilder);
        }
    }
}