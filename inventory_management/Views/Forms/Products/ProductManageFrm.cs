using DevExpress.XtraEditors;
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
            txtProdName.Text = product.Name;
            quantityProduct.Value = product.Quantity;
            txtSellPrice.Value = product.Sell;
            txtBuyPrice.Value = product.Buy;
            txtExDate.DateTime = product.Expiration;
            if (txtExDate.DateTime < DateTime.Now)
                txtExDate.DateTime = DateTime.Now; 
            if (product.Categories.Count > 0)
                categoryCbx.Properties.Items.AddRange(product.Categories);
            if (product.Suppliers.Count > 0)
                supplierCbx.Properties.Items.AddRange(product.Suppliers);
             if (product.Inventories.Count > 0)
                inventoryCbx.Properties.Items.AddRange(product.Inventories);

            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                categoryCbx.EditValue = product.Category_name;
            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                supplierCbx.EditValue = product.Supplier_name;
             //Get Current Inventory in edit
            if (product.Inventory_name != "" || product.Inventory_name != null)
                supplierCbx.EditValue = product.Inventory_name;

            okBtn.Click += delegate
            {
                //Add inventory
                if (!product.isEdit)
                {
                    if (CheckName())
                    {
                        product.Entry = DateTime.Now;
                        SaveChange();
                    }  
                    else
                        XtraMessageBox.Show("this product name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Edit inventory
                if (product.isEdit)
                {
                    if (CheckValueChanged())
                        SaveChange();
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
                return false;
            return true;
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (txtProdName.Text.Trim() == product.Name && quantityProduct.Value == product.Quantity && txtSellPrice.Value == product.Sell && txtBuyPrice.Value == product.Buy && txtExDate.DateTime == product.Expiration && categoryCbx.EditValue.ToString().Trim() == product.Category_name && supplierCbx.EditValue.ToString().Trim() == product.Supplier_name && inventoryCbx.EditValue.ToString().Trim() == product.Inventory_name )
            {
                return false;
            }
            else
                return true;
        }
    }
}