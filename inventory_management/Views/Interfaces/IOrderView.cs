using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IOrderView
    {
        //fields
        int OrderId { get; }
        int ProductId { get; set; }
        int OrderedQuantity { get; set; }
        DateTime OrderDate { set; }
        string DeliveryStatus { get; set; }
        int CustomerId { get; set; }
        string Message { set; }
        bool IsSuccessed { set; }
        bool IsEdit { set; get; }

        //event 
        event EventHandler SaveEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;


        //Get Data
        BindingSource OrderList { set; }

    }
}
