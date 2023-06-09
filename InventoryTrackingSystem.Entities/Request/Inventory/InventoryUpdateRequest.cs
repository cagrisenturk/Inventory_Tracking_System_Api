
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Request.Inventory
{
    public class InventoryUpdateRequest
    {

        public long InventoryId { get; set; }
        public string Name { get; set; }
    }
}
