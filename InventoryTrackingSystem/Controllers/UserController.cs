using InventoryTrackingSystem.API.Helper;
using InventoryTrackingSystem.Business.Concrete;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Request.User;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager _userManager;

        public UserController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Register")]
        public ActionResult Register(UserRegisterRequest user)
        {
            if (_userManager.UserRegister(user).Email==null)
            {
                return Ok("Kullanıcı Bulunmakta");
            }
            
            return Ok("Kayıt Başarılı");
        }

        [HttpPost("Update")]
        public InventoryTrackingApiResult Update(UserUpdateRequest user)
        {
            var response = _userManager.UserUpdate(user);
            if (response)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Güncelleme Başarılı" };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Kullanıcı Bulunamadı" };
            }
        }

        [HttpPost("DeleteUser")]
        public InventoryTrackingApiResult DeleteUser(long userId)
        {
            var response = _userManager.UserDelete(userId);
            if (response)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Silindi" };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Kullanıcı Bulunamadı" };
            }
        }

        [HttpGet("GetUserById")]
        public InventoryTrackingApiResult GetUserById(long userId)
        {
            var response = _userManager.GetUserById(userId);
            if (response != null)
            {
                return new InventoryTrackingApiResult { Data = response, Status = true, Message = "Kullanıcı Bilgisi Geldi " };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Kullanıcı Bulunamadı" };
            }
        }


    }
}
