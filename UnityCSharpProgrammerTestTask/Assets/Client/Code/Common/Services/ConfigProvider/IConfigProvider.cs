﻿using Client.Common.Data;

namespace Client.Common.Services.ConfigProvider
{
    public interface IConfigProvider
    {
        ProjectConfig Configs { get; }
    }
}