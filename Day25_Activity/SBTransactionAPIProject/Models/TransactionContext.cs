using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBTransactionAPIProject.Models
{
    public class TransactionContext:DbContext
    {
        public TransactionContext() : base()
        {

        }
        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}

