﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerApi.Domain
{
    public interface INoteDto
    {
        string date { get; set; }
        string text { get; set; }
    }
}