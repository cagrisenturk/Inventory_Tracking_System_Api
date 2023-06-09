using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Enums.InventoryTrackingSystem.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace InventoryTrackingSystem.API.Controllers.OData
{
    [ApiController]
    [Route("api/[controller]/")]
    public class OUsersController : ODataController
    {
        private readonly InventoryTrackingSystemContext ctx;

        public OUsersController(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }
        [HttpGet]
        [EnableQuery]
        public IQueryable<User> Get()
        {
            return ctx.Users.Where(x=>x.UserType==UserType.User).AsQueryable();
        }
    }
}
