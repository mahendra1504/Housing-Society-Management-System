using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocietyManagementSystem.Models;

namespace SocietyManagementSystem.Models
{
    public class SocietyManagmentContext : IdentityDbContext<ApplicationUser>
    {
        public SocietyManagmentContext(DbContextOptions<SocietyManagmentContext> options):base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<GiveFeedback> Feedback { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Notice> Notice { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<SocietyManagementSystem.Models.Registration> Registration { get; set; }
        public DbSet<Charges> Charges { get; set; }
        public DbSet<Maintenance> Maintenance { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<ExtraCharges> Extracharge { get; set; }
    }
}
