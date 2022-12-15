using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.EF.Dto
{
    public class ProductQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 2;
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
