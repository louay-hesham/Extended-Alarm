﻿using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmPlus.Core
{
    public interface IRingtoneManager
    {
        string GetRingtone();

        Task SetRingtone(FileData filedata);
    }
}
