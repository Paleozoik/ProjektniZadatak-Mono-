﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Paging
{
    public class ModelPaging : PagingParameters
    {
        public Guid MakeFilter { get; set; }
        public string SortBy { get; set; } = "ModelA";
    }
}
