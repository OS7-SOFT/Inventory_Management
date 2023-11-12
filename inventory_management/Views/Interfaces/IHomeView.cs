using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IHomeView
    {
        //Fields
        BindingSource GetFullInventoryList { set; }

        BindingSource GetExpiredProductsList { set; }

        //Events
        event EventHandler LoadDataEvent;

    }
}
