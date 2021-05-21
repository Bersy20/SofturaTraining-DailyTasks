using Microsoft.Extensions.Logging;
using ProfileMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMVCProject.Services
{
    public class ProfileManager : IRepo<Profile>
    {
        private ProfileContext _context;
        private ILogger<ProfileManager> _logger;

        public ProfileManager(ProfileContext context, ILogger<ProfileManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Delete(Profile t)
        {
            try
            {
                _context.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Profile Get(int id)
        {
            try
            {
                Profile profile = _context.Profiles.FirstOrDefault(a => a.Id == id);
                return profile;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Profile> GetAll()
        {
            try
            {
                if (_context.Profiles.Count() == 0)
                    return null;
                return _context.Profiles;
                  
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public bool Login(Profile t)
        {
            try
            {
                Profile profile = _context.Profiles.SingleOrDefault(u => u.Name == t.Name);
                if (profile.Id == t.Id)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public bool Register(Profile t)
        {
            try
            {
                _context.Profiles.Add(t);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Update(int id, Profile t)
        {
            Profile profile = Get(id);
            if (profile != null)
            {
                profile.Name = t.Name;
                profile.Age = t.Age;
                profile.Qualification = t.Qualification;
                profile.IsEmployed = t.IsEmployed;
                profile.NoticePeriod = t.NoticePeriod;
                profile.CurrentCTC = t.CurrentCTC;
            }
            _context.SaveChanges();
        }
    }
}
