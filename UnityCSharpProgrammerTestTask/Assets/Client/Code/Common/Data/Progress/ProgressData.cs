﻿using System;

namespace Client.Common.Data.Progress
{
    [Serializable]
    public class ProgressData
    {
        public MiniGame1Progress MiniGame1 = new();
        public MiniGame2Progress MiniGame2 = new();
    }
}