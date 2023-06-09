using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace InventoryTrackingSystem.API.Controllers.OData
{
    [ApiController]
    [Route("api/[controller]/")]
    public class OInventoriesController : ODataController
    {
        private readonly InventoryTrackingSystemContext ctx;

        public OInventoriesController(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Inventory> Get()
        {
            return ctx.Inventories.AsQueryable();
        }
    }
}
