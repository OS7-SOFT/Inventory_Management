using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface ICustomerView
    {
        //fields
        int CustomerId { get; }
        string CustomerName { get; set; }
        int CustomerPhone { get; set; }
        string CustomerEmail { get; set; }
        string CustomerLocation { get; set; }
        string Message { set; }
        bool IsSuccessed { set; }
        bool IsEdit { set; get; }

        //event 
        event EventHandler SaveEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;


        //Get Data
        BindingSource CustomerList { set; }

    }
}
