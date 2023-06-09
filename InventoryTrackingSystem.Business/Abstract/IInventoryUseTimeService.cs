using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Business.Abstract
{
    public interface IInventoryUseTimeService
    {
        void GetInventory(long userId, long InventoryId);
        void PutInventory(long userId, long InventoryId);
        List<InventoryUseTimeMaxResponse> GetTimeMaxResponse();
        List<InventoryUseTimeMinResponse> GetTimeMinResponse();
        DashboardInfoResponse GetDashboardInfo();
    }
}
