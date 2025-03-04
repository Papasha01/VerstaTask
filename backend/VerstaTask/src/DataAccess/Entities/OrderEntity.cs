using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public required string SenderCity { get; set; }
        public required string SenderAddress { get; set; }
        public required string RecipientCity { get; set; }
        public required string RecipientAddress { get; set; }
        public decimal CargoWeight { get; set; }
        public DateOnly PickupDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
