using inventory_management.Models;
using inventory_management.Views.Interfaces;
using inventory_management.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace inventory_management.Logic.Presenters
{
    public class CategoryPresenter
    {

        ICategoryView view;
        BindingSource categoryList;
        private object[] Params;

        CategoryModel model = new CategoryModel();
        CategoryServices categoryServices = new CategoryServices();

        //Constructor
        public CategoryPresenter(ICategoryView view)
        {
            categoryList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteCategory;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.LoadDataEvent += LoadDatad;
        }

        private void LoadDatad(object sender, EventArgs e)
        {
            //Set data in categoryList from database
            categoryList.DataSource = categoryServices.GetData();
            view.GetDataList = categoryList;
            //view.InventoryNamesList = ((DataTable)categoryList.DataSource)
            //        .AsEnumerable()
            //        .Select(row => row.Field<string>("Inventory Names"))
            //        .SelectMany(names => names.Split(','))
            //        .Select(name => name.Trim()) // Optional: Remove leading/trailing spaces
            //        .ToList();
            //var inventoryData = ((DataTable)categoryList.DataSource)
            //     .AsEnumerable()
            //     .Select(row => new
            //     {
            //         Names = row.Field<string>("InventoryName"),
            //         CategoryId = row.Field<int>("Category Id")
            //     });

            //// Group inventory names
            //var groupedInventoryData = inventoryData
            //    .GroupBy(name => name.CategoryId)
            //    .ToDictionary(group => group.Key, group => group.Select(name => name.Names).ToList());

            //// Create a list of inventory names for each category ID
            //view.InventoryNamesList = groupedInventoryData.Values.ToList();

            //List<string> s = ((DataTable)categoryList.DataSource)
            //            .AsEnumerable()
            //            .SelectMany(row => row.Field<string>("Inventory Names")
            //                .Split(',')
            //                .Select(name => name.Trim())
            //            )
            //            .ToList();
        }
        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current Category by id 
            DataTable CategoryName =  categoryServices.GetDataByValue(model.Id, "selectCategoriesById");
            view.CategoryName = CategoryName.Rows[0][0].ToString();
        }

        private void DeleteCategory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Categroy
            categoryServices.DeleteData(model.Id);
            view.Message = $"{view.CategoryName} category deleted successfully";
            view.IsSuccessed = true;
        }

        private void SaveChange(object sender, EventArgs e)
        {
            view.IsSuccessed = false;

            if(view.CategoryName != "")
            {
                try
                {
                    model.Name = view.CategoryName;
                    model.Id = view.Id;
                    if (view.IsEdit)
                    {
                        //Edit Category name Method 
                        Params = new object[2];
                        Params[0] = model.Id;
                        Params[1] = model.Name;
                        categoryServices.EditData(Params);
                        view.Message = $"{view.CategoryName} category Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 
                        Params = new object[1];
                        Params[0] = model.Name;
                        categoryServices.AddData(Params);
                        view.Message = $"{view.CategoryName} category Added Successfully";
                    }

                    view.IsSuccessed = true;
                }
                catch(Exception ex)
                {
                    view.Message = ex.Message;
                }
            }
            else
                view.Message = "The name filed is requird";            
        }

        private void CancelMethod(object sender, EventArgs e)
        {
            view.CategoryName = "";
        }
    }
}
