using Business.FormModel;
using Database.Context;
using Database.Model;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class UserService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // 1. Register a new User
        public Result Registration(UserForm user)
        {
            bool exists = labInventoryContext.UserInfo.Any(x => x.Email == user.Email);
            if (exists) return new Result(false, "Email already registered!");

            UserInfo userInfo = new UserInfo
            {
                FullName = user.FullName,
                Email = user.Email,
                PasswordHash = new PasswordHasher<UserInfo>().HashPassword(null, user.Password),
                RoleId = user.RoleId == 0 ? 2 : user.RoleId,  // 2: Default Staff Role
                IsActive = true,
                CreatedBy = user.CreatedBy,
                UpdatedBy = user.UpdatedBy,
                UpdatedDate = user.UpdatedDate
            };

            labInventoryContext.UserInfo.Add(userInfo);
            return new Result().DBCommit(labInventoryContext, "Registered Successfully!", null, user);
        }

        // 2. Login existing User
        public Result Login(UserLoginForm user)
        {
            UserInfo? userInfo = labInventoryContext.UserInfo.FirstOrDefault(x => x.Email == user.Email);
            if (userInfo == null) return new Result(false, "User not registered!");

            PasswordVerificationResult passwordResult = new PasswordHasher<UserInfo>().VerifyHashedPassword(userInfo, userInfo.PasswordHash, user.Password);
            if (passwordResult != PasswordVerificationResult.Failed)
            {
                return new Result(true, $"{userInfo.FullName} successfully logged in!", userInfo);
            }
            else
            {
                return new Result(false, "Incorrect password!");
            }
        }

        // 3. Update User Information
        public Result Update(UserForm user)
        {
            var existingUser = labInventoryContext.UserInfo.FirstOrDefault(x => x.UserInfoId == user.Id);
            if (existingUser == null) return new Result(false, "User not found!");

            existingUser.FullName = user.FullName ?? existingUser.FullName;
            existingUser.Email = user.Email ?? existingUser.Email;
            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.PasswordHash = new PasswordHasher<UserInfo>().HashPassword(existingUser, user.Password);
            }
            existingUser.RoleId = user.RoleId != 0 ? user.RoleId : existingUser.RoleId;
            existingUser.IsActive = user.IsActive;
            existingUser.UpdatedDate = DateTime.Now;
            existingUser.UpdatedBy = user.UpdatedBy;

            return new Result().DBCommit(labInventoryContext, "User updated successfully!", null, user);
        }

        // 4. List all Users
        public Result List()
        {
            try
            {
                var users = labInventoryContext.UserInfo.ToList();
                return new Result(true, "Success", users);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // 5. Get Single User by Id
        public Result Single(string id)
        {
            try
            {
                var user = labInventoryContext.UserInfo.FirstOrDefault(x => x.UserInfoId == id);
                return user != null
                    ? new Result(true, "Success", user)
                    : new Result(false, "User not found!");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // 6. Delete User (Deactivate Instead of Hard Delete)
        public Result Delete(string id, string updatedBy)
        {
            try
            {
                var user = labInventoryContext.UserInfo.FirstOrDefault(x => x.UserInfoId == id);
                if (user == null) return new Result(false, "User not found!");

                user.IsActive = false;
                user.UpdatedBy = updatedBy;
                user.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "User deactivated successfully!", null, user);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}

