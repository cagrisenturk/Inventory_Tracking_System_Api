using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Request.Inventory;
using InventoryTrackingSystem.Domain.Request.User;
using InventoryTrackingSystem.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Business.Abstract
{
    public interface IInventoryService
    {
        Inventory AddInventory(AddInventoryRequest inventory);

        bool UpdateInventory(InventoryTrackingSystem.Domain.Request.Inventory.InventoryUpdateRequest request);

        bool DeleteInventory(long inventoryId);

        GetInventoryByIdResponse GetInventory(long inventoryId);
    }
}
