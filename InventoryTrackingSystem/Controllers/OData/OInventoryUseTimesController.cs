using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace InventoryTrackingSystem.API.Controllers.OData
{
    [ApiController]
    [Route("api/[controller]/")]
    public class OInventoryUseTimesController : ODataController
    {
        private readonly InventoryTrackingSystemContext ctx;

        public OInventoryUseTimesController(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [EnableQuery]
        public IQueryable<InventoryUseTime> Get()
        {
            return ctx.InventoryUseTimes.AsQueryable();
        }
    }
}
