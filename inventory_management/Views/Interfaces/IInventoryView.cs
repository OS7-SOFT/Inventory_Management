using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IInventoryView : IBaseInterface
    {
        //fields
        string InventoryName { get; set; }
        string InventoryLocation { get; set; }
        double InventoryCapacity { get; set; }
        string CategoryName { get; set; }
        List<string> CategoryList { set; }

    }
}
