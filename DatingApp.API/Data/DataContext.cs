using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        // Values below represents the generated table name when we scaffold the db
        public DbSet<Value> Values { get; set; }
    }
}