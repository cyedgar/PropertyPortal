using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PropertyPortal.Data;

namespace PropertyPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PropertyPortal.Data.Property> Property { get; set; }
        public DbSet<PropertyPortal.Data.Transaction> Transaction { get; set; }
    }
}
