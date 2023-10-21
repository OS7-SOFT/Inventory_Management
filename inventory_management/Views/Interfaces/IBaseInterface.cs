using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Interfaces
{
    public interface IBaseInterface
    {   //fileds
        int Id { get; }
        string Message { set; }
        bool IsSuccessed { set; }
        bool IsEdit { set; get; }


        //event 
        event EventHandler SaveEvent;
        event EventHandler AddEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler CancelEvent;

        //Get Data
        BindingSource GetDataList { set; }
    }
}
