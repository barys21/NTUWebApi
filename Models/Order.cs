using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }

        public DateTime CreationTime { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public int Sum { get; set; }

    }
}
