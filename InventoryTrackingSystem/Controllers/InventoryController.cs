using InventoryTrackingSystem.API.Helper;
using InventoryTrackingSystem.Business.Concrete;
using InventoryTrackingSystem.Domain.Request.Inventory;
using InventoryTrackingSystem.Domain.Request.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly InventoryManager _ınventoryManager;

        public InventoryController(InventoryManager ınventoryManager)
        {
            _ınventoryManager = ınventoryManager;
        }

        [HttpPost("AddInventory")]
        public ActionResult AddInventory(AddInventoryRequest request)
        {

            if(_ınventoryManager.AddInventory(request).Name==null)
                return Ok("Envanter bulunmakta adını kontrol ediniz");
            return Ok("Kayıt Başarılı");
        }

        [HttpPost("UpdateInventory")]
        public InventoryTrackingApiResult UpdateInventory(InventoryUpdateRequest request)
        {
            var response = _ınventoryManager.UpdateInventory(request);
            if (response)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Güncelleme Başarılı" };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Envanter Bulunamadı veya Envanter Adı Kullanılmakta" };
            }
        }

        [HttpPost("DeleteInventory")]
        public InventoryTrackingApiResult DeleteInventory(long inventoryId)
        {
            var response = _ınventoryManager.DeleteInventory(inventoryId);
            if (response)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Envanter Silindi" };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Envanter Bulunamadı" };
            }
        }

        [HttpGet("GetInventoryById")]
        public InventoryTrackingApiResult GetInventoryById(long inventoryId)
        {
            var response = _ınventoryManager.GetInventory(inventoryId);
            if (response!=null)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Envanter Bilgisi Geldi " };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Envanter Bulunamadı" };
            }
        }



    }
}
