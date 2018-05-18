using Agriculture.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agriculture.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonCrop> SeasonCrop { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CropsFeedback> CropsFeedbacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}