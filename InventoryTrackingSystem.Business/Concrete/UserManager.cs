using InventoryTrackingSystem.Business.Abstract;
using InventoryTrackingSystem.DataAccess;
using InventoryTrackingSystem.Domain.Entities;
using InventoryTrackingSystem.Domain.Enums.InventoryTrackingSystem.Domain.Enums;
using InventoryTrackingSystem.Domain.Request.User;
using InventoryTrackingSystem.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTrackingSystem.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly InventoryTrackingSystemContext ctx;

        public UserManager(InventoryTrackingSystemContext ctx)
        {
            this.ctx = ctx;
        }

        public User UserRegister(UserRegisterRequest userRequest)
        {
            User user = new User();
            if (ctx.Users.FirstOrDefault(x=>x.Email==userRequest.Email)!=null)
            {
                return user;
            }
            user.Email = userRequest.Email;
            user.FullName = userRequest.FullName;
            user.Password = HashPassword(userRequest.Password);
            user.UserType = UserType.User; 
            ctx.Users.Add(user);
            ctx.SaveChanges();
            return user;
        }


        public byte[] HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return hashBytes;

        }



        public UserLoginResponse UserLogin(UserLoginRequest userLoginRequest)
        {
            var user = ctx.Users.FirstOrDefault(s => s.Email == userLoginRequest.Email && s.Password == HashPassword(userLoginRequest.Password));
            UserLoginResponse response= new UserLoginResponse();
            if (user==null)
            {
                response.Registered = false;
            }
            else
            {
                response.Registered = true;
                response.FullName = user.FullName;
                response.UserType = user.UserType;
                response.Id= user.Id;
            }
            return response;
        }

        public bool UserUpdate(UserUpdateRequest userUpdateRequest)
        {
            var user = ctx.Users.FirstOrDefault(s => s.Id == userUpdateRequest.Id);
            if (user==null)
            {
                return false;
            }
            else
            {
                if (userUpdateRequest.Password!=null)
                {
                    user.Password = HashPassword(userUpdateRequest.Password);
                }
                user.Email = userUpdateRequest.Email;
                user.FullName = userUpdateRequest.FullName;
                ctx.Users.Update(user);
                ctx.SaveChanges();
                return true;
            }
        }

        public bool UserDelete(long userId)
        {
            var user = ctx.Users.FirstOrDefault(s => s.Id == userId);
            if (user == null)
            {
                return false;
            }
            else
            {
                ctx.Users.Remove(user);
                ctx.SaveChanges();
                return true;
            }
        }

        public GetUserByIdResponse GetUserById(long id)
        {

            var user = ctx.Users.FirstOrDefault(s => s.Id == id);

            return new GetUserByIdResponse { Id = id, Email = user.Email, FullName = user.FullName };
        }
    }
}
