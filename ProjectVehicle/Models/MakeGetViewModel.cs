﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectVehicle.Models
{
    public class MakeGetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> ModelName { get; set; }
    }
}
