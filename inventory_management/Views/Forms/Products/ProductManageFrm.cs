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
            
            if (product.Categories.Count > 0)
                categoryCbx.Properties.Items.AddRange(product.Categories);
            else
                categoryCbx.Properties.Items.Add("No there any suppliers");
            if (product.Suppliers.Count > 0)
                categoryCbx.Properties.Items.AddRange(product.Suppliers);
            else
                categoryCbx.Properties.Items.Add("No there any suppliers");
            
            categoryCbx.Properties.Items.AddRange(product.Categories);
            supplierCbx.Properties.Items.AddRange(product.Suppliers);

            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                categoryCbx.EditValue = product.Category_name;
            //Get Current Category in edit
            if (product.Category_name != "" || product.Category_name != null)
                supplierCbx.EditValue = product.Supplier_name;

            okBtn.Click += delegate
            {
                product.Name = txtProdName.Text;
                product.Quantity = (int)quantityProduct.Value;
                product.Sell = txtSellPrice.Value;
                product.Buy = txtBuyPrice.Value;
                product.Entry = DateTime.Now;
                product.ExpirationDate = txtExDate.DateTime;
                product.Category_name = categoryCbx.EditValue.ToString(); 
                product.Supplier_name = supplierCbx.EditValue.ToString();
                product.Save();

            };
            cancelBtn.Click += delegate
            {
                this.Close();
                if (this.IsDisposed)
                    product.Cancel();
            };

        }
    }
}