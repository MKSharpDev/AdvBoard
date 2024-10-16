using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Contracts.Category
{
    public class CategoryWithIdRequest : CategoryRequest
    {
        public Guid Id { get; set; }
    }
}
