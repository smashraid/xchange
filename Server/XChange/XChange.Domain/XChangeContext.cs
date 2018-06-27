using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace XChange.Domain
{
    public class XChangeContext : IdentityDbContext<ApplicationUser>
    {
        public XChangeContext(DbContextOptions<XChangeContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // builder.Entity<ApplicationUser>().HasData(
            //     new ApplicationUser{
            //         FirstName = "Saulo",
            //         LastName = "Tsuchida",
            //         Email = "smashraid@gmail.com",
            //         UserName = "smashraid",
            //         P
            //     }
            // )
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CurrencyRate> CurrencyRates { get; set; }
    }
}
