using InventoryTrackingSystem.Domain.Entities.Cammon;
using InventoryTrackingSystem.Domain.Enums;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Entities
{
    public class Inventory:BaseEntity
    {
        public string? Name { get; set; }
        public UseCase? UseCase { get; set; } = Enums.UseCase.Available;
        public string? GetQrCode { get; set; }
        public string? PutQrCode { get; set; }

    }
}
