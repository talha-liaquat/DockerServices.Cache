﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockerServices.Cache
{
    public interface ICacheChannel
    {
        void Start();

        void Stop();
    }
}
