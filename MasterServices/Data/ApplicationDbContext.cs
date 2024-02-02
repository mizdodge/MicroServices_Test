using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterServices.Model;
using Microsoft.EntityFrameworkCore;
using MyProjectBE.Model;

namespace MasterServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserMasterModel> UserMaster{ get; set; }
        public DbSet<UserDetailMaster> UserDetailMaster{ get; set; }
        public DbSet<UserModel> User{ get; set; }
        public DbSet<ProductModel> Product{ get; set; }
        public DbSet<CategoryModel> Category { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

    }
}
