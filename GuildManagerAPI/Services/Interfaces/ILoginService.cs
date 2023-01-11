﻿using GuildManager_Models;

namespace GuildManagerAPI.Services
{
    public interface ILoginService
    {
        ServiceResponse<string> GenerateJwt(LoginDto dto);
        ServiceResponse<int> RegisterUser(RegisterUserDto dto);
        Task<ServiceResponse<bool>> ChangePassword(int userId, ChangePasswordDto dto);
    }
}