using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Models
{
    public class ProductClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

    }
}
