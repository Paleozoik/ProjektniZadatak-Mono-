﻿namespace Service.Paging
{
    public class ModelPaging : PagingParameters
    {
        public int? MakeFilter { get; set; }
        public string SortBy { get; set; } = "";
    }
}
