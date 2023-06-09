using InventoryTrackingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.DataAccess
{
    public class InventoryTrackingSystemContext: DbContext
    {
        public InventoryTrackingSystemContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryUseTime> InventoryUseTimes { get; set; }



    }
}
