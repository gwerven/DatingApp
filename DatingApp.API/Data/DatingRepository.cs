using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        // Bring in the data context for use with the contsructor
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;
        }

        // Add to db
        public void Add<T>(T entity) where T : class
        {
            // Will be saved in memory until we save changes to db
            _context.Add(entity);
        }

        // Delete from db
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        // Get a single user from the db with the specified id
        public async Task<User> GetUser(int id)
        {
            // Photos considered navigation properties, so we must include
            // Will return either first user that appears with the matching id or the default user if none is found with the id
            // Default user is null
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        // Get multiple users from the db
        public async Task<IEnumerable<User>> GetUsers()
        {
            // Return the list of users
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        // Save changes made to the db
        public async Task<bool> SaveAll()
        {
            // True if 1 or more changes saved, false if 0 changes saved (no changes)
            return await _context.SaveChangesAsync() > 0;
        }
    }
}