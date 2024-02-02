using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProjectBE.Model;
using Microsoft.EntityFrameworkCore;

namespace MyProjectBE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TransactionModel> Transaction { get; set; }
        public DbSet<TransactionDetailModel> TransactionDetail { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
