using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class UserServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addUser", () => AddDataParameters(Params, DataBase.command));
        }

        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@fulltName", SqlDbType.VarChar).Value = (string)Params[0];
            command.Parameters.Add("@userName", SqlDbType.VarChar).Value = (string)Params[1];
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = (string)Params[2];
            command.Parameters.Add("@permission", SqlDbType.VarChar).Value = (string)Params[3];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteUser", () => DeleteDataParameters(id, DataBase.command));
        }

        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editUser", () => EditDataParameters(Params, DataBase.command));
        }

        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@fulltName", SqlDbType.VarChar).Value = (string)Params[0];
            command.Parameters.Add("@userName", SqlDbType.VarChar).Value = (string)Params[1];
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = (string)Params[2];
            command.Parameters.Add("@permission", SqlDbType.VarChar).Value = (string)Params[3];
        }

        public DataTable GetData()
        {
            throw new NotImplementedException();
        }
    }
}
