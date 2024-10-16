using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Contracts.Category
{
    public class CategoryRequest
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Number { get; set; }
    }
}
