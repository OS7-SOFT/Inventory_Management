using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IInventoryView
    {
        //fields
        int InventoryId { get;}
        string InventoryName { get; set; }
        string InventoryLocation { get; set; }
        string InventoryCapacity { get; set; }
        int CategoryId { get; set; }
        string Message { set; }
        bool IsSuccessed {set; }
        bool IsEdit { get; set; }

        //event 
        event EventHandler SaveEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;


        //Get Data
        BindingSource InventoryList { set; }

    }
}
