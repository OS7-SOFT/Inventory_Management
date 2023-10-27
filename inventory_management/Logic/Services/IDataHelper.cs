using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    public interface IDataHelper
    {
        // Add method
        void AddData(object[] Params);
        void AddDataParameters(object[] Params, SqlCommand command);
        // Edit method
        void EditData(object[] Params);
        void EditDataParameters(object[] Params, SqlCommand command);
        // Delete method
        void DeleteData(int id);
        void DeleteDataParameters(int id, SqlCommand command);
        //GetData method
        DataTable GetData();
        //GetData By Value method
        DataTable GetDataByValue(int id, string storedProcedure);
        void GetDataByValueParameters(int id, SqlCommand command);
    }
}
