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

        public List<Item> Items { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int Sum { get; set; }

    }
}
