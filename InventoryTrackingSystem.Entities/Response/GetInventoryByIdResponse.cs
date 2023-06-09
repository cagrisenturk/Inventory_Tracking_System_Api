using InventoryTrackingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Response
{
    public class GetInventoryByIdResponse
    {
        public long InventoryId { get; set; }
        public string? Name { get; set; }
        public string? GetQrCode { get; set; }
        public string? PutQrCode { get; set; }
    }
}
