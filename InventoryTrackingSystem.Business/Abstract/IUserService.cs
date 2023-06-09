using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Request.User;
using InventoryTrackingSystem.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Business.Abstract
{
    public interface IUserService
    {
        User UserRegister(UserRegisterRequest user);

        UserLoginResponse UserLogin(UserLoginRequest userLoginRequest);
        
        bool UserUpdate(UserUpdateRequest userUpdateRequest);

        bool UserDelete(long userId);
        GetUserByIdResponse GetUserById(long id);

    }
}
