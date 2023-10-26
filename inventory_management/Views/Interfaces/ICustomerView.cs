using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface ICustomerView : IBaseInterface
    {
        //fields
        string CustomerName { get; set; }
        string CustomerPhone { get; set; }
        string CustomerEmail { get; set; }
        string CustomerLocation { get; set; }
        string BestCustomer { set; }
 

    }
}
