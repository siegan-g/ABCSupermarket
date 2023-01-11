using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud6212Task2.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// ## References
/// The following info is gathered from the code first tutorial provided by the microsoft docs 
///https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0/// Accessed 29/10/21
/// 
/// ##Notes
/// * This class requires the Microsoft.EntityFramework package. Install using the NuGet package manager 
/// * Install-Package Microsoft.EntityFramework 
/// * EntityFramework Core does not seem to provide the import System.Data.Entity lib but I still kept the package do hopefully not break any dependencies.
/// 
/// ##Why 
/// * DBContext acts as our Data Access Layer(DAL) to facilitate communicate between the Database and the Application
/// * The app defines the model and provides a code-first approach passing queries, the dbcontext establishes a connection to the db to execute the code
/// * We only need to map a single Model not making a User LogIn functionality since its not in the business rules (20/21/21)
/// * we use the base keyword to pass our connection string as a parameter to the DbContext constructor
/// 
/// </summary>

namespace Cloud6212Task2.DAL
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext(DbContextOptions<SupermarketContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }

        //On creating the database if empty EF will create the table
        //If the model is altered it will delete and recreate the model
 
    }
}
