﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildManager_Models
{
    public class ServiceResponse<T>
    {
        public T? Data{ get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
