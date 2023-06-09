using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Response
{
    public class DashboardInfoResponse
    {
        public int InventoryCount { get; set; }
        public int UserCount { get; set; }
        public int TodayInventoryCount { get; set; }
        public int UsingInventoryCount { get; set; }
    }
}
