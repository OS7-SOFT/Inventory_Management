﻿using DevExpress.XtraEditors;
using inventory_management.Views.Forms.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_management.Views.Forms
{
    public partial class ProductManageFrm : DevExpress.XtraEditors.XtraForm
    {
        Product product = Product.Instance();
        public ProductManageFrm()
        {
            InitializeComponent();
            PerformedMethod();
        }

        private void PerformedMethod()
        {
            //set min max value 
            txtSellPrice.Properties.MaxValue = 10000000000000000000;
            txtSellPrice.Properties.MinValue = 0;
            txtBuyPrice.Properties.MaxValue = 10000000000000000000;
            txtBuyPrice.Properties.MinValue = 0;
            quantityProduct.Properties.MaxValue = 10000000000000000000;
            quantityProduct.Properties.MinValue = 0;

            if (txtExDate.DateTime < DateTime.Now)
                txtExDate.DateTime = DateTime.Now;

            //fill comboboxes
            if (product.Categories.Count > 0)
                categoryCbx.Properties.Items.AddRange(product.Categories);
            if (product.Suppliers.Count > 0)
                supplierCbx.Properties.Items.AddRange(product.Suppliers);

            GetDataToEdit();

            FillInventory();


            //Events
            categoryCbx.EditValueChanged += delegate
            {
                CheckValueComboBox(categoryCbx);
                if (categoryCbx.Text.Trim() != null)
                    FillInventory();
            };
            inventoryCbx.EditValueChanged += delegate
            {
                CheckValueComboBox(inventoryCbx);
            };
            supplierCbx.EditValueChanged += delegate
            {
                CheckValueComboBox(supplierCbx);
            };






            okBtn.Click += delegate
            {
                //Add inventory
                if (!product.isEdit)
                {
                    if (CheckName() && CheckQuantity())
                    {
                        product.Entry = DateTime.Now;
                        SaveChange();
                    }
                }
                //Edit inventory
                if (product.isEdit)
                {
                    if (CheckValueChanged()) 
                    {
                        if (CheckQuantity()) 
                        {
                            SaveChange();
                        } 
                    }
                    else
                        this.Close();

                }

            };

            //Close form 
            cancelBtn.Click += delegate
            {
                this.Close();
            };
            this.FormClosing += delegate
            {
                product.Cancel();
            };

        }

        //Get Data to Edit
        private void GetDataToEdit()
        {

            txtProdName.Text = product.Name;
            quantityProduct.Value = product.Quantity;
            txtSellPrice.Value = product.Sell;
            txtBuyPrice.Value = product.Buy;
            txtExDate.DateTime = product.Expiration;
            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                categoryCbx.EditValue = product.Category_name;
            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                supplierCbx.EditValue = product.Supplier_name;
            //Get Current Inventory in edit
            if (product.Inventory_name != "" || product.Inventory_name != null)
                inventoryCbx.EditValue = product.Inventory_name;

        }

        //save change
        private void SaveChange()
        {
            product.Name = txtProdName.Text;
            product.Quantity = (int)quantityProduct.Value;
            product.Sell = txtSellPrice.Value;
            product.Buy = txtBuyPrice.Value;
            product.ExpirationDate = txtExDate.DateTime;
            product.Category_name = categoryCbx.EditValue != null ? categoryCbx.EditValue.ToString() : "";
            product.Supplier_name = supplierCbx.EditValue != null ? supplierCbx.EditValue.ToString() : "";
            product.Inventory_name = inventoryCbx.EditValue != null ? inventoryCbx.EditValue.ToString() : "";
            product.Save();
        }

        //Check Name is exsiste
        private bool CheckName()
        {
            List<string> productsName = product.ProductList
               .OfType<DataRowView>()
               .Select(x => x[1].ToString())
               .ToList();
            if (productsName.Contains(txtProdName.Text))
            {
                XtraMessageBox.Show("this product name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            return true;
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (txtProdName.Text.Trim() == product.Name && quantityProduct.Value == product.Quantity && txtSellPrice.Value == product.Sell && txtBuyPrice.Value == product.Buy && txtExDate.DateTime.ToString("d") == product.Expiration.ToString("d") && categoryCbx.Text.Trim() == product.Category_name && supplierCbx.Text.Trim() == product.Supplier_name && inventoryCbx.Text.Trim() == product.Inventory_name)
            {
                return false;
            }
            else
                return true;
        }

        //get inventory name
        private List<string> GetInventoryName()
        {
            if (categoryCbx.Text.Trim() != null && categoryCbx.Text.Trim() != "")
            {
                return product.Inventories.OfType<DataRowView>()
               .Where(x => x[2].ToString() == categoryCbx.EditValue.ToString())
               .Select(x => x[0].ToString())
               .ToList();
            }
            else
            {
                return product.Inventories.OfType<DataRowView>()
               .Select(x => x[0].ToString())
               .ToList();
            }

        }
        //Fill inventoryCbx
        private void FillInventory()
        {
            inventoryCbx.Properties.Items.Clear();
            if (GetInventoryName().Count > 0)
            {
                inventoryCbx.Properties.Items.AddRange(GetInventoryName());
                inventoryCbx.ToolTip = "Select inventory to store current product";
            }
            else
            {
                inventoryCbx.Text = null;
                inventoryCbx.ToolTip = "No there any inventory conatian this category";
            }
        }


        //check quantity
        private bool CheckQuantity()
        {
            if (inventoryCbx.SelectedItem != null)
            {
                List<object> current = ((DataTable)product.Inventories.DataSource)
             .AsEnumerable()
             .Where(row => row.Field<string>(0) == inventoryCbx.EditValue.ToString())
             .FirstOrDefault().ItemArray.ToList();

                if (Convert.ToInt32(current[1]) < quantityProduct.Value)
                {
                    XtraMessageBox.Show("Product account larg than inventory capacity available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (Convert.ToInt32(current[1]) >= quantityProduct.Value && Convert.ToInt32(current[1]) - quantityProduct.Value <= 100)
                {
                    var result = XtraMessageBox.Show($"iWhen Adding this number of products to the '{inventoryCbx.EditValue.ToString()}' inventory\n" +
                                        $"the available storage capacity after adding will be less than 100\n" +
                                        $"Do you want to continue adding the product to this inventory ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    return result == DialogResult.Yes ? true : false;
                }
                else
                    return true;
            }
            XtraMessageBox.Show("All fields is requird", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        //Check Combobox value
        private void CheckValueComboBox(ComboBoxEdit CB)
        {
            string enteredValue = CB.Text;

            bool isValid = CB.Properties.Items.Contains(enteredValue);

            CB.EditValue = isValid ? enteredValue : null;


        }
    }
}