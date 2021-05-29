using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVCApplicationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApplicationProject.Services
{
    public class UserManager:IRepo<User>
    {
        private UserContext _context;
        private ILogger<UserManager> _logger;

        public UserManager(UserContext context, ILogger<UserManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        

        

        public User Get(int id)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(a => a.UserId == id);
                return user;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                if (_context.Users.Count() == 0)
                    return null;
                return _context.Users
                    .Include(e=>e.Employees)
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public bool Login(User t)
        {
            try
            {
                User user = _context.Users.SingleOrDefault(u => u.Username == t.Username);
                if (user.Password == t.Password)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool Register(User t)
        {
            try
            {
                _context.Users.Add(t);
                _context.SaveChanges();
                return true;
                
            }
            catch(Exception)
            {
                return false;
            }
        }

       

        
    }
}
