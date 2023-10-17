using inventory_management.Models;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Logic.Presenters
{
    public class CategoryPresenter
    {

        ICategoryView view;
        BindingSource categoryList;

        CategoryModel model = new CategoryModel();

        //Constructor
        public CategoryPresenter(ICategoryView view)
        {
            categoryList = new BindingSource();
            this.view = view;
            this.view.AddEvent += (object s, EventArgs e) => { view.IsEdit = false; };
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteCategory;
            this.view.SaveEvent += SaveChange;
            this.view.SetCategoriesData(categoryList);
        }

        private void LoadData()
        {
            //Set data in categoryList from database

        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.CategoryId;
            
            //Get current Category by id 
        }

        private void DeleteCategory(object sender, EventArgs e)
        {
            model.Id = view.CategoryId;

            //delete Categroy then return Message and result in IsSuccessed
        }

        private void SaveChange(object sender, EventArgs e)
        {
            view.IsSuccessed = false;

            if(view.CategoryName != "")
            {
                try
                {
                    model.Name = view.CategoryName;

                    if (view.IsEdit)
                    {
                        //Edit Category name Method 

                        view.Message = "Category Edited Successfully";
                    }
                    else
                    {
                        //Add Category name Method 

                        view.Message = "Category Added Successfully";
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


    }
}
