using InventoryTrackingSystem.Domain.Entities.Cammon;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Entities
{
    public class InventoryUseTime: BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public long? InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public long? UserId { get; set; }
        public User? User { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? TotalTime { get; set; }





    }
}
