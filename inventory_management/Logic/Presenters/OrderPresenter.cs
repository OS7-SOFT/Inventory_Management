﻿using inventory_management.Logic.Services;
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
    public class OrderPresenter
    {
        IOrderView view;
        BindingSource orderList;
        private object[] Params;

        OrderModel model = new OrderModel();
        OrderServices orderServices = new OrderServices();
        //Constructor
        public OrderPresenter(IOrderView view)
        {
            orderList = new BindingSource();
            this.view = view;
            this.view.AddEvent += AddMethod;
            this.view.EditEvent += LoadDataToEdit;
            this.view.DeleteEvent += DeleteOrder;
            this.view.SaveEvent += SaveChange;
            this.view.CancelEvent += CancelMethod;
            this.view.LoadDataEvent += LoadData;
       
        }

        private void ConnectionModelWithView()
        {
            model.OrderedQuantity = view.OrderedQuantity;
            model.DeliveryStatus = view.DeliveryStatus;
            model.OrderDate = view.OrderDate;
            model.CustomerName = view.CustomerName;
            model.ProductName = view.ProductName;
          
        }
        private void LoadData(object sender, EventArgs e)
        {
            //Set data in orderList from database
            orderList.DataSource = orderServices.GetData();
            view.GetDataList = orderList;
            //Set all order
            //Set Customer comboBox
            DataTable dt = orderServices.GetComboBoxData("customerComboBox");
            List<string> Custdata = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Custdata.Add(dt.Rows[i][0].ToString());
            }
            view.CustomersList = Custdata.ToList();

            //Set Product comboBox
            DataTable dataTable = orderServices.GetComboBoxData("productComboBox");
            List<string> ProData = new List<string>();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                ProData.Add(dataTable.Rows[i][0].ToString());
            }
            view.ProductsList = ProData.ToList();
        }

        private void AddMethod(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadDataToEdit(object sender, EventArgs e)
        {
            view.IsEdit = true;
            model.Id = view.Id;

            //Get current order by id 
            DataTable dt = orderServices.GetDataByValue(model.Id);
            view.ProductName =dt.Rows[0][0].ToString();
            view.OrderedQuantity = Convert.ToInt32(dt.Rows[0][1]);
            view.CustomerName = dt.Rows[0][2].ToString();
            view.DeliveryStatus = dt.Rows[0][3].ToString();
            view.OrderDate =Convert.ToDateTime(dt.Rows[0][4]);

        }

        private void DeleteOrder(object sender, EventArgs e)
        {
            model.Id = view.Id;

            //delete order
            orderServices.DeleteData(model.Id);
            view.Message = $"Order {view.Id} deleted successfully";
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
                        //Edit orderMethod 
                        Params = new object[6];
                        Params[0] = model.Id;
                        Params[1] = orderServices.GetDataByValue(model.ProductName, "selectProductComboBoxId").Rows[0][0];
                        Params[2] = model.OrderedQuantity;
                        Params[3] = model.OrderDate;
                        Params[4] = model.DeliveryStatus;
                        Params[5] = orderServices.GetDataByValue(model.CustomerName, "selectCustomerComboBoxId").Rows[0][0];
                        orderServices.EditData(Params);
                        view.Message = $"Order {view.Id} Edited Successfully";
                    }
                    else
                    {
                        //Add order name Method 
                        Params = new object[5];
                        Params[0] = orderServices.GetDataByValue(model.ProductName, "selectProductComboBoxId").Rows[0][0];
                        Params[1] = model.OrderedQuantity;
                        Params[2] = model.OrderDate;
                        Params[3] = model.DeliveryStatus;
                        Params[4] = orderServices.GetDataByValue(model.CustomerName, "selectCustomerComboBoxId").Rows[0][0];                     
                        orderServices.AddData(Params);
                        view.Message = $"Order {view.Id}  Added Successfully";
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
            view.OrderedQuantity = 0;
            view.CustomerName = "";
            view.ProductName = "";

        }


        private bool CheckInput()
        {
            if (view.OrderedQuantity == 0 || view.CustomerName == "" || view.ProductName == "" || view.DeliveryStatus == "")
            {

                return false;
            }

            return true;
        }
    }
}