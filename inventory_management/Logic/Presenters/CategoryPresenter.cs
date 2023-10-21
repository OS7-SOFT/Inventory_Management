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
            this.view.GetDataList =  categoryList;
            //load all data
            LoadData();
        }

        private void LoadData()
        {
            //Set data in categoryList from database
            categoryList.DataSource = categoryServices.GetData();

            //get Category Count 
            //..use..view.CategoryCount;
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
            DataTable CategoryName =  categoryServices.GetDataByValue(model.Id);
            view.CategoryName = CategoryName.Rows[0][0].ToString();
        }

        private void DeleteCategory(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Categroy
            categoryServices.DeleteData(model.Id);
            view.Message = "Category deleted successfully";
            view.IsSuccessed = true;
            LoadData();
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
                        view.Message = "Category Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 
                        Params = new object[1];
                        Params[0] = model.Name;
                        categoryServices.AddData(Params);
                        view.Message = "Category Added Successfully";
                    }

                    view.IsSuccessed = true;
                    LoadData();
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
