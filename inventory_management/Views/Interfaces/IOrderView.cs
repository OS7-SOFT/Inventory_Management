using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IOrderView : IBaseInterface
    {
        //fields
        int OrderedQuantity { get; set; }
        DateTime OrderDate { set; get; }
        string DeliveryStatus { get; set; }
        string OrderCount { get; set; }
        string CurrentOrderCount {  set; }
        string CompleteOrderCount {  set; }
        string CanceledOrderCount {  set; }
        List<string> CustomersList {  set; }
        string CustomerName { get; set; }
        List<string> ProductsList {  set; }
        string ProductName { get; set; }

}
}
