using InventoryTrackingSystem.API.Helper;
using InventoryTrackingSystem.Business.Concrete;
using InventoryTrackingSystem.Domain.Request.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryUseTimeController : ControllerBase
    {
        private readonly InventoryUseTimeManager _ınventoryManager;

        public InventoryUseTimeController(InventoryUseTimeManager ınventoryManager)
        {
            _ınventoryManager = ınventoryManager;
        }

        [HttpGet("GetDashboardInfo")]
        public InventoryTrackingApiResult GetDashboardInfo()
        {
            var data = _ınventoryManager.GetDashboardInfo();
            return new InventoryTrackingApiResult { Data = data, Status = true };
        }

        [HttpGet("GetInventory")]
        public ActionResult GetInventory([FromBody]InventoryGetAndPutRequest userId,[FromQuery] long inventoryId)
        {
            
            _ınventoryManager.GetInventory(long.Parse(userId.id), inventoryId);
            return Ok("Alınma İşlemi Başarılı");
        }
        [HttpPost("PutInventory")]
        public ActionResult PutInventory([FromQuery] long inventoryId, [FromBody] InventoryGetAndPutRequest userId)
        {
            _ınventoryManager.PutInventory(long.Parse(userId.id), inventoryId);
            return Ok("Bırakma İşlemi Başarılı");
        }

        [HttpGet("GetInventoryMaxTotalTime")]
        public InventoryTrackingApiResult GetInventoryMaxTotalTime()
        {
            var data = _ınventoryManager.GetTimeMaxResponse();
            return new InventoryTrackingApiResult { Data= data,Status=true };
        }

        [HttpGet("GetInventoryMinTotalTime")]
        public InventoryTrackingApiResult GetInventoryMinTotalTime()
        {
            var data = _ınventoryManager.GetTimeMinResponse();
            return new InventoryTrackingApiResult { Data = data, Status = true };
        }
    }
}
