using System;
using System.Collections.Generic;
using System.Text;

namespace AdServiceCore.Filters
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public bool OrderAsc { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 10;
            OrderBy = "date";
            OrderAsc = true;
        }
        public PaginationFilter(int pageNumber, int pageSize, string orderBy = "date", bool orderAsc = true)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
            if (orderBy.ToLower().Equals("price"))
            {
                OrderBy = "price";
            }
            else
            {
                OrderBy = "date";
            }
            OrderAsc = orderAsc;
        }
    }
}
