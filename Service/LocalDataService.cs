using CargoManagementSystem.Exception;
using CargoManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoManagementSystem.Service
{
    public partial class CargoManagementContext : DbContext
    {
        public CargoManagementContext()
            : base("name=CargoManagementSystem")
        {
        }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<Block> Block { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<CargoCollection> CargoCollection { get; set; }
        public virtual DbSet<PurchasePrizeDic> PurchasePrizeDic { get; set; }
        public virtual DbSet<SellOrder> SellOrder { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<SellOrderCollection> SellOrderCollection { get; set; }
        public virtual DbSet<PurchaseOrderCollection> PurchaseOrderCollection { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CargoManagementContext>(null);
            modelBuilder.Entity<Block>()
                .HasMany(e => e.CargoCollections)
                .WithRequired(e => e.Block)
                .HasForeignKey(e => new { e.WarehouseName, e.PlaneName, e.BlockName })
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CargoCollection>()
                .HasMany(e => e.PurchasePrizeDics)
                .WithRequired(e => e.CargoCollection)
                .HasForeignKey(e => new { e.WarehouseName, e.PlaneName, e.BlockName, e.PreciseCargoName })
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Plane>()
                .HasMany(e => e.Blocks)
                .WithRequired(e => e.Plane)
                .HasForeignKey(e => new { e.WarehouseName, e.PlaneName })
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<CargoCollection>()
            //    .HasRequired(e => e.Cargo)
            //    .WithMany(e => e.CargoCollections)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Cargo>()
            //    .HasMany(e => e.CargoCollections)
            //    .WithRequired(e => e.Cargo)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Warehouse>()
            //    .HasMany(e => e.Planes)
            //    .WithRequired(e => e.Warehouse)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<PurchasePrizeDic>()
            //    .HasRequired(e => e.CargoCollection)
            //    .WithMany(e => e.PurchasePrizeDics)
            //    .WillCascadeOnDelete(true);

            modelBuilder.Entity<SellOrder>()
                .HasRequired(e => e.SellOrderCollection)
                .WithMany(e => e.SellOrders)
                .HasForeignKey(e => new { e.SellTime })
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<SellOrderCollection>()
            //    .HasMany(e => e.SellOrders)
            //    .WithRequired(e => e.SellOrderCollection)
            //    .WillCascadeOnDelete(true);

            modelBuilder.Entity<PurchaseOrder>()
                .HasRequired(e => e.PurchaseOrderCollection)
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(e => new { e.PurchaseTime})
                .WillCascadeOnDelete(true);

            //modelBuilder.Entity<PurchaseOrderCollection>()
            //    .HasMany(e => e.PurchaseOrders)
            //    .WithRequired(e => e.PurchaseOrderCollection)
            //    .WillCascadeOnDelete(true);
        }
    }
}
