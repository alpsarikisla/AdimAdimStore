using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCNedir.Models
{
    public partial class AdimAdimDBModel : DbContext
    {
        public AdimAdimDBModel()
            : base("name=AdimAdimDBModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<ManagerType> ManagerTypes { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
