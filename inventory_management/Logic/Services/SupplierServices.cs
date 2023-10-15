using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class SupplierServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addSuppliers", () => AddDataParameters(Params, DataBase.command));
        }
        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = (string)Params[0];
            command.Parameters.Add("@phoneNum", SqlDbType.Int).Value = (int)Params[1];
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = (string)Params[2];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteSuppliers", () => DeleteDataParameters(id, DataBase.command));
        }

        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editSuppliers", () => EditDataParameters(Params, DataBase.command));
        }

        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = (string)Params[1];
            command.Parameters.Add("@phoneNum", SqlDbType.Int).Value = (int)Params[2];
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = (string)Params[3];
        }
    }
}
