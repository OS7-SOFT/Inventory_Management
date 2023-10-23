using inventory_management.Logic.Services;
using inventory_management.Models;
using inventory_management.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Logic.Presenters
{
    public class ProductPresenter
    {
        IProductView view;
        BindingSource productList;
        private object[] Params;

        ProductModel model = new ProductModel();
        ProductServices productServices = new ProductServices();
        //Constructor
        public ProductPresenter(IProductView view)
        {
            productList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteProduct;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = productList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.ProductName;
            model.Quantity = view.ProductQuantity;
            model.SellPrice = view.SellPrice;
            model.BuyPrice = view.BuyPrice;
            model.EntryDate = view.EntryDate;
            model.ExpirationDate = view.ExpirationDate;
            model.CategoryName = view.CategoryName;
            model.SupplierName = view.SupplierName;
        }

        private void LoadData()
        {
            //Set data in productList from database
            productList.DataSource = productServices.GetData();

            //get .Product Count 
            view.ProductCount = productServices.GetProductCount().Rows[0][0].ToString();
            //Set all product
            //Set Category comboBox
            DataTable dt = productServices.GetComboBoxData("categoryComboBox");
            List<string> Custdata = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Custdata.Add(dt.Rows[i][0].ToString());
            }
            view.CategoryList = Custdata.ToList();

            //Set Supplier comboBox
            DataTable dataTable = productServices.GetComboBoxData("supplierComboBox");
            List<string> ProData = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProData.Add(dataTable.Rows[i][0].ToString());
            }
            view.SupplierList = ProData.ToList();

        }



        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current product by id 
            DataTable dt = productServices.GetDataByValue(model.Id);
            model.Name = dt.Rows[0][0].ToString();
            model.Quantity = Convert.ToInt32(dt.Rows[0][1]);
            model.SellPrice = Convert.ToDecimal(dt.Rows[0][2]);
            model.BuyPrice = Convert.ToDecimal(dt.Rows[0][3]);
            model.ExpirationDate = Convert.ToDateTime(dt.Rows[0][4]);

        }

        private void DeleteProduct(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete product
            productServices.DeleteData(model.Id);
            view.Message = $"{view.ProductName} product deleted successfully";
            view.IsSuccessed = true;
            LoadData();
        }

        private void SaveChange(object sender, EventArgs e)
        {
            view.IsSuccessed = false;

            if (CheckInput())
            {
                try
                {
                    ConnectionModelWithView();
                    if (view.IsEdit)
                    {
                        model.Id = view.Id;
                        //Edit productMethod 
                        Params = new object[9];
                        Params[0] = model.Id;
                        Params[1] = model.Name;
                        Params[2] = model.Quantity;
                        Params[3] = model.SellPrice;
                        Params[4] = model.BuyPrice;
                        Params[5] = model.EntryDate;
                        Params[6] = model.ExpirationDate;
                        Params[7] = productServices.GetDataByValue(model.CategoryName, "selectCategoryComboBoxId").Rows[0][0];
                        Params[8] = productServices.GetDataByValue(model.SupplierName, "supplierComboBoxId").Rows[0][0];
                        productServices.EditData(Params);
                        view.Message = $"{view.ProductName} product Edited Successfully";
                    }
                    else
                    {
                        //Add product name Method 
                        Params = new object[8];
                        Params[0] = model.Name;
                        Params[1] = model.Quantity;
                        Params[2] = model.SellPrice;
                        Params[3] = model.BuyPrice;
                        Params[4] = model.EntryDate;
                        Params[5] = model.ExpirationDate;
                        Params[6] = productServices.GetDataByValue(model.CategoryName, "selectCategoryComboBoxId").Rows[0][0];
                        Params[7] = productServices.GetDataByValue(model.SupplierName, "supplierComboBoxId").Rows[0][0];
                        productServices.AddData(Params);
                        view.Message = $"{view.ProductName} product Added Successfully";
                    }

                    view.IsSuccessed = true;
                    LoadData();
                }
                catch (Exception ex)
                {
                    view.Message = ex.Message;
                }
            }
            else view.Message = "All feilds is required";
        }

        private void CancelMethod(object sender, EventArgs e)
        {
            view.ProductName = "";
            view.ProductQuantity = 0;
            view.CategoryName = "";
            view.SupplierName = "";
            view.BuyPrice = 0;
            view.SellPrice = 0;
        }


        private bool CheckInput()
        {
            if (view.ProductName.Trim() == "" || view.ProductQuantity == 0 || view.BuyPrice == 0 || view.SellPrice == 0 || view.SupplierName == "" || view.CategoryName == "" )
            {

                return false;
            }

            return true;
        }
    }
}

