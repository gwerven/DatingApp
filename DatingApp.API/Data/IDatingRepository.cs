using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
         // 5 generic methods in this repository
         // Make them generic so that one method for adding a user or adding a photo
         // Add to db
         void Add<T>(T entity) where T: class;
         // Delete from db
         void Delete<T>(T entity) where T: class;
         // Save changes to the db (after saving changes to db, return true if there were changes to save, false otherwise)
         Task<bool> SaveAll();
         // Get multiple users from db
         Task<IEnumerable<User>> GetUsers();
         // Get a single user from db with the specified id
         Task<User> GetUser(int id);
    }
}