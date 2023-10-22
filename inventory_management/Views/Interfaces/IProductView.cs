using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Views.Interfaces
{
    public interface IProductView : IBaseInterface
    {
        //fileds
        string ProductName { get; set; }
        int ProductQuantity { get; set; }
        decimal SellPrice { get; set; }
        decimal BuyPrice { get; set; }
        DateTime EntryDate { get; set; }
        DateTime ExpirationDate { get; set; }
        string CategoryName { get; set; }
        List<string> CategoryList { set; }
        string SupplierName { get; set; }
        List<string> SupplierList { set; }
        string ProductCount {  set; }
        string ProductSold {  set; }
        string ProductDefective {  set; }

    }
}
