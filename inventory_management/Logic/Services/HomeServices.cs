using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class HomeServices
    {
        //Get the full capcity inventory name or near full and ExpiredProducts
        public DataTable Getdata(string storedProcedure)
        {
            return DataBase.Select(storedProcedure, () => { });
        }
    }
}

