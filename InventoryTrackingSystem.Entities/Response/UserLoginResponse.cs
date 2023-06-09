using InventoryTrackingSystem.Domain.Enums.InventoryTrackingSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Domain.Response
{
    public class UserLoginResponse
    {
        public string FullName { get; set; }
        public long Id { get; set; }
        public UserType UserType { get; set; }
        public bool Registered { get; set; }
    }
}
