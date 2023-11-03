using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class OrderServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addOrder", () => AddDataParameters(Params, DataBase.command));
        }
        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@productId", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@orderedQuantity", SqlDbType.Int).Value = (int)Params[1];
            command.Parameters.Add("@orderDate", SqlDbType.Date).Value = (DateTime)Params[2];
            command.Parameters.Add("@deliveryStatus", SqlDbType.VarChar).Value = (string)Params[3];
            command.Parameters.Add("@customerId", SqlDbType.Int).Value = (int)Params[4];
            command.Parameters.Add("@inventoryId", SqlDbType.Int).Value = (int)Params[5];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteOrder", () => DeleteDataParameters(id, DataBase.command));
        }
        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editOrder", () => EditDataParameters(Params, DataBase.command));
        }
        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@productId", SqlDbType.Int).Value = (int)Params[1];
            command.Parameters.Add("@orderedQuantity", SqlDbType.Int).Value = (int)Params[2];
            command.Parameters.Add("@orderDate", SqlDbType.Date).Value = (DateTime)Params[3];
            command.Parameters.Add("@deliveryStatus", SqlDbType.VarChar).Value = (string)Params[4];
            command.Parameters.Add("@customerId", SqlDbType.Int).Value = (int)Params[5];
            command.Parameters.Add("@inventoryId", SqlDbType.Int).Value = (int)Params[6];
        }

        //GetData method
        public DataTable GetData()
        {
            return DataBase.Select("selectOrders", () => { });
        }
        //Get Order Count method 
        public DataTable GetOrderCount()
        {
            return DataBase.Select("OrdersCount", () => { });
        }
        //GetData By Value method
        public DataTable GetDataByValue(int id, string storedProcedure)
        {
            return DataBase.GetDataByValue(storedProcedure, () => GetDataByValueParameters(id, DataBase.command));
        }
        public void GetDataByValueParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //Get order id by order name
        public DataTable GetDataByValue(string name,string storedProcedure)
        {
            return DataBase.GetDataByValue(storedProcedure, () => GetDataByValueParameters(name, DataBase.command));
        }
        public void GetDataByValueParameters(string name, SqlCommand command)
        {
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        }
        //Method to fill  combobox
        public DataTable GetComboBoxData(string storedProcedure)
        {
            return DataBase.Select(storedProcedure, () => { });
        }
    }
}
