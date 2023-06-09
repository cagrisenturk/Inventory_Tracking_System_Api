using InventoryTrackingSystem.Business.Abstract;
using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Enums.InventoryTrackingSystem.Domain.Enums;
using InventoryTrackingSystem.Domain.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace InventoryTrackingSystem.Business.Concrete
{
    public class InventoryUseTimeManager : IInventoryUseTimeService
    {
        private readonly InventoryTrackingSystemContext ctx;

        public InventoryUseTimeManager(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }

        public DashboardInfoResponse GetDashboardInfo()
        {
            var inventoryCount =ctx.Inventories.Count();
            var userCount = ctx.Users.Where(x=> x.UserType==UserType.User ).Count();
            var useTimes = ctx.InventoryUseTimes.ToList();
            var todayInventoryCount = useTimes.Where(x =>  x.StartDate.Value.ToString("dd.MM.yyyy") == DateTime.UtcNow.ToString("dd.MM.yyyy")).Count();
            var usingInventoryCount = ctx.Inventories.Count(x=> x.UseCase== Domain.Enums.UseCase.Using);

            return new DashboardInfoResponse { InventoryCount = inventoryCount, UserCount = userCount, TodayInventoryCount = todayInventoryCount, UsingInventoryCount = usingInventoryCount };
        }

        public void GetInventory(long userId,long inventoryId)
        {
            var inventory = ctx.Inventories.FirstOrDefault(s => s.Id == inventoryId);

            InventoryUseTime inventoryUseTime= new InventoryUseTime();
            inventoryUseTime.InventoryId= inventoryId;
            inventory.UseCase = Domain.Enums.UseCase.Using;
            inventoryUseTime.UserId= userId;
            inventoryUseTime.StartDate= DateTime.UtcNow;
            ctx.InventoryUseTimes.Add(inventoryUseTime);
            ctx.SaveChanges();

        }

        public List<InventoryUseTimeMaxResponse> GetTimeMaxResponse()
        {
            var topInventories = ctx.InventoryUseTimes
                .Where(x=>x.TotalTime!=null)
                .GroupBy(iut => iut.InventoryId)
                .Select(group => new {
                    InventoryId = group.Key.Value,
                    TotalTime = group.Sum(iut => iut.TotalTime.Value.TotalMinutes),
                    Count = group.Count(),
                })
                .OrderByDescending(i => i.TotalTime)
                .Take(5)
                .Join(ctx.Inventories,
                    i => i.InventoryId,
                    inv => inv.Id,
                    (i, inv) => new InventoryUseTimeMaxResponse { InventoryName = inv.Name, TotalTimeMinute = TimeSpan.FromMinutes(i.TotalTime), TotalUserTime=i.Count }).ToList();

            return topInventories;
            
        }

        public List<InventoryUseTimeMinResponse> GetTimeMinResponse()
        {
            var topInventories = ctx.InventoryUseTimes
                .Where(x => x.TotalTime != null)
                .GroupBy(iut => iut.InventoryId)
                .Select(group => new {
                    InventoryId = group.Key.Value,
                    TotalTime = group.Sum(iut => iut.TotalTime.Value.TotalMinutes),
                    Count = group.Count(),
                })
                .OrderBy(i => i.TotalTime)
                .Take(5)
                .Join(ctx.Inventories,
                    i => i.InventoryId,
                    inv => inv.Id,
                    (i, inv) => new InventoryUseTimeMinResponse { InventoryName = inv.Name, TotalTimeMinute = TimeSpan.FromMinutes(i.TotalTime), TotalUserTime = i.Count }).ToList();

            return topInventories;
        }

        public void PutInventory(long userId, long inventoryId)
        {
            var inventoryUseTime = ctx.InventoryUseTimes.Where(s => s.UserId == userId && s.InventoryId== inventoryId)
                .OrderByDescending(s => s.StartDate)
                .FirstOrDefault();
            if (inventoryUseTime!=null)
            {
                var inventory = ctx.Inventories.FirstOrDefault(s => s.Id == inventoryId);
                inventory.UseCase = Domain.Enums.UseCase.Available;
                inventoryUseTime.EndDate = DateTime.UtcNow;
                inventoryUseTime.TotalTime = inventoryUseTime.EndDate - inventoryUseTime.StartDate;
                ctx.InventoryUseTimes.Update(inventoryUseTime);
                ctx.SaveChanges();
            }
        }
    }
}
