using Microsoft.EntityFrameworkCore;
using TheScouts.Models;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheScouts.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
		public DbSet<Position> Positions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Application> Applications { get; set; }
		public DbSet<Newsletter> Newsletters { get; set; }
    }
}

