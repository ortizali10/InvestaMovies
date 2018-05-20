using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.Entity;

namespace InvestaMovies.Models.Context
{
    /// <summary>
    /// Stores configuration regarding repository
    /// </summary>
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=default")
        {
            //Create database if not exist
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        public DbSet<Movie> Movies { get; set; }
    }
}