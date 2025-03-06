using ExpensesBackend.Models;
using System.Data.Entity;
//using Microsoft.EntityFrameworkCore;

namespace ExpensesBackend.DatabaseContext
{
    public class AppDbContext:DbContext
    {
        //public AppDbContext() : base("name=ExpensesDb")
        //{

        //}
        //public AppDbContext(DbContextOptions<AppDbContext> options)
        //   : base(options)
        //{
        //}
        public DbSet<Entry> Entries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

//ExpensesBackend.DatabaseContext.AppDbContext
//  "DefaultConnection": "Server=sumanth\\MSSQLSERVER01;Database=ExpensesDb;Trusted_Connection=True;"
