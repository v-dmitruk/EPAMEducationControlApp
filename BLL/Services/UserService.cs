using BLL.DTOModels;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Entities;
using UserDAL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        IUserUnitOfWork Database { get; set; }

        public UserService(IUserUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<IdentityResult> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.UserName };
                Database.UserManager.PasswordValidator = new PasswordValidator { RequiredLength = 5 };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return result;
                // добавляем роль
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                ClientProfile clientProfile = new ClientProfile { Id = user.Id, Email = userDto.Email, UserName = userDto.UserName, BirthdayDate = userDto.BirthdayDate, FirstName = userDto.FirstName, LastName = userDto.LastName };
                clientProfile.ApplicationUser = user;
                Database.ClientManager.Create(clientProfile);
                await Database.SaveAsync();
                return result;
            }
            else
            {
                return new IdentityResult("There is already registered user with " + userDto.Email);
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}