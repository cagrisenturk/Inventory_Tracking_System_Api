using InventoryTrackingSystem.Domain.Entities.Cammon;
using InventoryTrackingSystem.Domain.Enums;
using InventoryTrackingSystem.Domain.Enums.InventoryTrackingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Entities
{
    public class User:BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public UserType UserType { get; set; }
    }
}
