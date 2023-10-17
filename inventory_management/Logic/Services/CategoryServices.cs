using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventory_management.Logic.Services
{
    internal class CategoryServices : IDataHelper
    {
        // Add method
        public void AddData(object[] Params)
        {
            DataBase.Excute("addCategories", ()=> AddDataParameters(Params,DataBase.command));
        }
        public void AddDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@categoryName", SqlDbType.VarChar).Value =(string)Params[0];
        }
        // Delete method
        public void DeleteData(int id)
        {
            DataBase.Excute("deleteCategories", () => DeleteDataParameters(id, DataBase.command));
        }
        public void DeleteDataParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
        // Edit method
        public void EditData(object[] Params)
        {
            DataBase.Excute("editCategories", () => EditDataParameters(Params, DataBase.command));
        }
        public void EditDataParameters(object[] Params, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = (int)Params[0];
            command.Parameters.Add("@categoryName", SqlDbType.VarChar).Value = (string)Params[1];
        }
        //GetData method
        public DataTable GetData()
        {
            return DataBase.Select("selectCategory", () => { });
        }
        //GetData By Value method
        public DataTable GetDataByValue(int id)
        {
            return DataBase.GetDataByValue("selectCategoriesById", () => GetDataByValueParameters(id,DataBase.command));
        }
        public void GetDataByValueParameters(int id, SqlCommand command)
        {
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        }
    }
}
