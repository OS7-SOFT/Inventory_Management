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
    public class CustomerPresenter
    {
        ICustomerView view;
        BindingSource customerList;
        private object[] Params;

        CustomerModel model = new CustomerModel();
        CustomerServices customerServices = new CustomerServices();
        //Constructor
        public CustomerPresenter(ICustomerView view)
        {
            customerList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteCustomer;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.GetDataList = customerList;
            //load all data
            LoadData();
        }

        private void ConnectionModelWithView()
        {
            model.Name = view.CustomerName;
            model.Phone = view.CustomerPhone;
            model.Email = view.CustomerEmail;
            model.Location = view.CustomerLocation;
        }

        private void LoadData()
        {
            //Set data in customerList from database
            customerList.DataSource = customerServices.GetData();

            //Get Customer Count
            view.CustomersCount = customerServices.GetCustomersCount().Rows[0][0].ToString();
            //Get best Customer

        }



        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current Customer by id 
            DataTable dt = customerServices.GetDataByValue(model.Id);
            view.CustomerName = dt.Rows[0][0].ToString();
            view.CustomerPhone = dt.Rows[0][1].ToString();
            view.CustomerEmail = dt.Rows[0][2].ToString();
            view.CustomerLocation = dt.Rows[0][3].ToString();
        }

        private void DeleteCustomer(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete Customer
            customerServices.DeleteData(model.Id);
            view.Message = "Customer deleted successfully";
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
                        //Edit CustomerMethod 
                        Params = new object[5];
                        Params[0] = model.Id;
                        Params[1] = model.Name;
                        Params[2] = model.Phone;
                        Params[3] = model.Email;
                        Params[4] = model.Location;
                        customerServices.EditData(Params);
                        view.Message = "Customer Edited Successfully";
                    }
                    else
                    {
                        //Add Customer name Method 
                        Params = new object[4];
                        Params[0] = model.Name;
                        Params[1] = model.Phone;
                        Params[2] = model.Email;
                        Params[3] = model.Location;
                        customerServices.AddData(Params);
                        view.Message = "Customer Added Successfully";
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
            view.CustomerName = "";
            view.CustomerPhone = "";
            view.CustomerEmail = "";
            view.CustomerLocation = "";
        }


        private bool CheckInput()
        {
            if (view.CustomerName.Trim() == "" || view.CustomerPhone == "" || view.CustomerEmail == "" || view.CustomerLocation == "")
            {

                return false;
            }

            return true;
        }
    }
}
