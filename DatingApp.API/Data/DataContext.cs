using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        /* The names of the values below will be the generated table name when we scaffold the db.
        We must create a new migration when we make changes in here*/
        public DbSet<Value> Values { get; set; }

        // Generates a table in the db for users based off the user model
        public DbSet<User> Users { get; set; }

        // Generates a table in the db for photos based off the photo model
        public DbSet<Photo> Photos { get; set; }
    }
}