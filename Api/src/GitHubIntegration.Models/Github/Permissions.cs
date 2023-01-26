﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GithubIntegration.Models.Github
{
    public class Permissions
    {
        public bool admin { get; set; }
        public bool maintain { get; set; }
        public bool push { get; set; }
        public bool triage { get; set; }
        public bool pull { get; set; }

    }
}
