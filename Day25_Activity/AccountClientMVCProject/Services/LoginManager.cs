using AccountClientMVCProject.Model;
using AccountClientMVCProject.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace AccountClientMVCProject.Services
{
    public class LoginManager:IRepo<Account>
    {
        private AccountDBContext _context;
        private ILogger<LoginManager> _logger;

        public LoginManager(AccountDBContext context, ILogger<LoginManager> logger)
        {
            _context = context;
            _logger = logger;
        }
        public bool Login(Account t)
        {
            try
            {
                Account account = _context.Accounts.SingleOrDefault(u => u.CustomerName == t.CustomerName);
                if (account.CustomerName == t.CustomerName)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        
    }
}
