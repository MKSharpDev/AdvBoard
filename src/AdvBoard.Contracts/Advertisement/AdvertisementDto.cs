using AdvBoard.Contracts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvBoard.Contracts.Advertisement
{
    public class AdvertisementDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public OrderStatus ordesStatus { get; set; }
        public DateTime Created { get; set; }
        public Guid CategoryId { get; set; }
    }
}
