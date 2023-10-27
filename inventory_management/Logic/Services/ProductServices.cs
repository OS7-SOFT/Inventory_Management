using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class ProductServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addProduct", () => AddDataParameters(Params, DataBase.command));
        }
        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@productName", SqlDbType.VarChar).Value = (string)Params[0];
            command.Parameters.Add("@quantity", SqlDbType.Int).Value = (int)Params[1];
            command.Parameters.Add("@sellPrice", SqlDbType.Money).Value = (decimal)Params[2];
            command.Parameters.Add("@buyPrice", SqlDbType.Money).Value = (decimal)Params[3];
            command.Parameters.Add("@entryDate", SqlDbType.Date).Value = (DateTime)Params[4];
            command.Parameters.Add("@expirationDate", SqlDbType.Date).Value = (DateTime)Params[5];
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value = (int)Params[6];
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value = (int)Params[7];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteProduct", () => DeleteDataParameters(id, DataBase.command));
        }
        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editProduct", () => EditDataParameters(Params, DataBase.command));
        }
        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@productName", SqlDbType.VarChar).Value = (string)Params[1];
            command.Parameters.Add("@quantity", SqlDbType.Int).Value = (int)Params[2];
            command.Parameters.Add("@sellPrice", SqlDbType.Money).Value = (decimal)Params[3];
            command.Parameters.Add("@buyPrice", SqlDbType.Money).Value = (decimal)Params[4];
            command.Parameters.Add("@entryDate", SqlDbType.Date).Value = (DateTime)Params[5];
            command.Parameters.Add("@expirationDate", SqlDbType.Date).Value = (DateTime)Params[6];
            command.Parameters.Add("@categoryId", SqlDbType.Int).Value = (int)Params[7];
            command.Parameters.Add("@supplierId", SqlDbType.Int).Value = (int)Params[8];
        }

        //GetData method
        public DataTable GetData()
        {
            return DataBase.Select("selectProduct", () => { });
        }
        //Get Product Count method 
        public DataTable GetProductCount()
        {
            return DataBase.Select("ProductsCount", () => { });
        }
        //GetData By Value method
        public DataTable GetDataByValue(int id, string storedProcedure)
        {
            return DataBase.GetDataByValue(storedProcedure, () => GetDataByValueParameters(id, DataBase.command));//
        }
        public void GetDataByValueParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //Get product id by product name
        public DataTable GetDataByValue(string name, string storedProcedure)
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
