﻿namespace Service.Common.Paging
{
    public class PagingParameters
    {
        public const int maxPageSize = 10;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 5;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}
