﻿using GuildManager_Models;
using GuildManager_Models.Members;

namespace GuildManagerAPI.Services.Interfaces
{
    public interface IMembersService
    {
        Task<ServiceResponse<List<MemberDto>>> GetMembers();
    }
}
