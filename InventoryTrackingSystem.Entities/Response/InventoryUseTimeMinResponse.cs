using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Response
{
    public class InventoryUseTimeMaxResponse
    {
        public string InventoryName { get; set; }
        public TimeSpan TotalTimeMinute { get; set; }
        public int TotalUserTime { get; set; }
    }
}
