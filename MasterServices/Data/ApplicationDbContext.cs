using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterServices.Model;
using Microsoft.EntityFrameworkCore;

namespace MasterServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> UserMaster{ get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
