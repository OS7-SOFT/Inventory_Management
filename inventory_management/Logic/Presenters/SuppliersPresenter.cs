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
    public class SuppliersPresenter
    {
        ISuppliersView view;
        BindingSource supplierList;
        private object[] Params;

        SupplierModel model = new SupplierModel();
        SupplierServices supplierServices = new SupplierServices();
        //Constructor
        public SuppliersPresenter(ISuppliersView view)
        {
            supplierList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteSupplier;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.LoadDataEvent += LoadData;
        }

       
        private void ConnectionModelWithView()
        {
            model.Name = view.SuppliersName;
            model.PhoneNumber = view.SuppliersPhone;
            model.Email = view.SuppliersEmail;
        }

        private void LoadData(object sender, EventArgs e)
        {
            //Set data in supplierList from database
            supplierList.DataSource = supplierServices.GetData();
            view.GetDataList = supplierList;
        }

        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current supplier by id 
            DataTable dt = supplierServices.GetDataByValue(model.Id, "selectSupplierById");
            view.SuppliersName = dt.Rows[0][0].ToString();
            view.SuppliersPhone = dt.Rows[0][1].ToString();
            view.SuppliersEmail = dt.Rows[0][2].ToString();
        }

        private void DeleteSupplier(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete supplier
            supplierServices.DeleteData(model.Id);
            view.Message = $"{view.SuppliersName} supplier deleted successfully";
            view.IsSuccessed = true;
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
                        //Edit SupplierMethod 
                        Params = new object[4];
                        Params[0] = model.Id;
                        Params[1] = model.Name;
                        Params[2] = model.PhoneNumber;
                        Params[3] = model.Email;
                        supplierServices.EditData(Params);
                        view.Message = $"{view.SuppliersName} Supplier Edited Successfully";
                    }
                    else
                    {
                        //Add Supplier name Method 
                        Params = new object[3];
                        Params[0] = model.Name;
                        Params[1] = model.PhoneNumber;
                        Params[2] = model.Email;
                        supplierServices.AddData(Params);
                        view.Message = $"{view.SuppliersName} Supplier Added Successfully";
                    }

                    view.IsSuccessed = true;
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
            view.SuppliersName = "";
            view.SuppliersPhone = "";
            view.SuppliersEmail = "";
        }


        private bool CheckInput()
        {
            if (view.SuppliersName.Trim() == "" || view.SuppliersPhone == "" || view.SuppliersEmail == "")
            {

                return false;
            }

            return true;
        }
    }
}
