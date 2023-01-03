using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ApiDbContext
{
    public class DepartmentDbContext : DbContext 
    {
        public DepartmentDbContext(DbContextOptions options) : base (options)
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<AuthResp> Authresps { get; set; }

        public DbSet<Login> Logins { get; set; } 


    }
}
