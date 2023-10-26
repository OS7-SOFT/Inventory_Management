using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Views.Interfaces
{
    public interface ISuppliersView : IBaseInterface
    {
        string SuppliersName { get; set; }
        string SuppliersPhone { get; set; }
        string SuppliersEmail { get; set; }

    }
}
