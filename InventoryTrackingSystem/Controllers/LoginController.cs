using InventoryTrackingSystem.API.Helper;
using InventoryTrackingSystem.Business.Concrete;
using InventoryTrackingSystem.Domain.Request;
using InventoryTrackingSystem.Domain.Request.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OData.Edm;

namespace InventoryTrackingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager _userManager;

        public LoginController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("Login")]
        public InventoryTrackingApiResult Login(UserLoginRequest user)
        {
            var response = _userManager.UserLogin(user);
            if (response.Registered)
            {
                return new InventoryTrackingApiResult{ Data = response, Status = true, Message = "Giriş Başarılı" };
            }
            else
            {
                return new InventoryTrackingApiResult { Status = false, Message = "Şifre Veya Mail Yanlış" };
            }
        }
    }
}
