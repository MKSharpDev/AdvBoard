using AdvBoard.Contracts.Enums;

namespace AdvBoard.Domain
{
    public class Advertisement : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public OrderStatus ordesStatus { get; set; }
        public DateTime Created { get; set; }
        public Guid? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
