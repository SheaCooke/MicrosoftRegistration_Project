using Microsoft.EntityFrameworkCore;
using MicroSoftRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroSoftRegistration.Data
{
    public class RegistrationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) :base(options)
        {

        }





    }
}
