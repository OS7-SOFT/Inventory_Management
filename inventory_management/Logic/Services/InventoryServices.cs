using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class InventoryServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addInventory", () => AddDataParameters(Params, DataBase.command));
        }
        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@inventoryName", SqlDbType.VarChar).Value = (string)Params[0];
            if (Params[1] == null)
            {
                command.Parameters.Add("@categoriesId", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@categoriesId", SqlDbType.Int).Value = (int)Params[1];
            }
            command.Parameters.Add("@inventoryLocation", SqlDbType.VarChar).Value = (string)Params[2];
            command.Parameters.Add("@inventoryCapacity", SqlDbType.BigInt).Value = (double)Params[3];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteInventory", () => DeleteDataParameters(id, DataBase.command));
        }
        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editInventory", () => EditDataParameters(Params, DataBase.command));
        }
        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@inventoryName", SqlDbType.VarChar).Value = (string)Params[1];
            if (Params[2] == null)
            {
                command.Parameters.Add("@categoriesId", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                command.Parameters.Add("@categoriesId", SqlDbType.Int).Value = (int)Params[2];
            }
            command.Parameters.Add("@inventoryLocation", SqlDbType.VarChar).Value = (string)Params[3];
            command.Parameters.Add("@inventoryCapacity", SqlDbType.BigInt).Value = (double)Params[4];
        }
        //Method to get all inventory data
        public DataTable GetData()
        {
            return DataBase.Select("selectInventory", () => { });
        }
        //Method to fill category combobox
        public DataTable GetComboBoxData()
        {
            return DataBase.Select("categoryComboBox", () => { });
        }
        //GetData By Value method
        public DataTable GetDataByValue(int id,string storedProcedure)
        {
            return DataBase.GetDataByValue(storedProcedure, () => GetDataByValueParameters(id, DataBase.command));
        }
        public void GetDataByValueParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        //Get category id by category name
        public DataTable GetDataByValue(string name)
        {
            if(name == null)
            {
                return null; 
            }
            else
            {
                return DataBase.GetDataByValue("selectCategoryComboBoxId", () => GetDataByValueParameters(name, DataBase.command));
            }
        }
        public void GetDataByValueParameters(string name, SqlCommand command)
        {
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
        }
    }
}
