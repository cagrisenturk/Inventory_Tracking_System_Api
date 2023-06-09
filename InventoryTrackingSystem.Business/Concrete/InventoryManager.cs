using InventoryTrackingSystem.Business.Abstract;
using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Request.Inventory;
using InventoryTrackingSystem.Domain.Request.User;
using InventoryTrackingSystem.Domain.Response;
using IronBarCode;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryTrackingSystem.Business.Concrete
{
    public class InventoryManager : IInventoryService
    {
        private readonly InventoryTrackingSystemContext ctx;

        public InventoryManager(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }

        public Inventory AddInventory(AddInventoryRequest inventoryRequest)
        {
            
            Inventory inventory = new Inventory();
            if (ctx.Inventories.FirstOrDefault(x=> x.Name.ToLower()==inventoryRequest.Name.ToLower())!=null)
            {
                return inventory;
            }
            inventory.Name = inventoryRequest.Name;

            ctx.Inventories.Add(inventory);
            ctx.SaveChanges();

            GeneratedBarcode getQr = QRCodeWriter.CreateQrCode("https://localhost:7040/api/InventoryUseTime/GetInventory?inventoryId="+ inventory.Id, 200);
            var byteGetQr = getQr.ToPngBinaryData();
            var base64GetQr = Convert.ToBase64String(byteGetQr);

            GeneratedBarcode putQr = QRCodeWriter.CreateQrCode("https://localhost:7040/api/InventoryUseTime/PutInventory?inventoryId=" + inventory.Id, 200);
            var bytePutQr = putQr.ToPngBinaryData();
            var base64PutQr = Convert.ToBase64String(bytePutQr);
            inventory.GetQrCode = base64GetQr;
            inventory.PutQrCode = base64PutQr;
            ctx.SaveChanges();
            return inventory;
        }

        public bool DeleteInventory(long inventoryId)
        {
            var inventory = ctx.Inventories.FirstOrDefault(s => s.Id == inventoryId);
            if (inventory == null)
            {
                return false;
            }
            else
            {
                ctx.Remove(inventory);
                ctx.SaveChanges();
                return true;
            }
        }

        public GetInventoryByIdResponse GetInventory(long inventoryId)
        {
            var inventory = ctx.Inventories.FirstOrDefault(s => s.Id == inventoryId);
            
            return new GetInventoryByIdResponse { InventoryId=inventoryId, GetQrCode=inventory.GetQrCode,PutQrCode=inventory.PutQrCode,Name=inventory.Name };
        }

        public bool UpdateInventory(InventoryTrackingSystem.Domain.Request.Inventory.InventoryUpdateRequest request)
        {
            var inventory = ctx.Inventories.FirstOrDefault(s => s.Id == request.InventoryId);
            if (inventory == null)
            {
                return false;
            }
            else if (ctx.Inventories.FirstOrDefault(x => x.Name.ToLower() == request.Name.ToLower()) != null)
            {
                return false;
            }
            else
            {
                inventory.Name = request.Name;
                ctx.Inventories.Update(inventory);
                ctx.SaveChanges();
                return true;
            }
        }
    }
}
