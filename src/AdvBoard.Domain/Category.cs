using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Domain
{
    public class Category : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Number { get; set; }
        public DateTime Created { get; set; }
        public virtual List<Advertisement> Adverts { get; set; }
        public virtual List<Category> Categories { get; set; }
    }
}
