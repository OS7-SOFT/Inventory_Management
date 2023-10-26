using DevExpress.XtraEditors;
using inventory_management.Views.Forms.Inventories;
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
    public partial class InventoryInfoForm : DevExpress.XtraEditors.XtraForm
    {
        Inventory inventory = Inventory.Instance();

        public InventoryInfoForm()
        {
            InitializeComponent();

            //Get Information
            GetInventoryInfo();
        }

        private void GetInventoryInfo()
        {
            lblInvertoyName.Text = inventory.Name;
            lblCapacity.Text = inventory.Capacity.ToString();
            lblLocationInvent.Text = inventory.Location;
            lblProductsCount.Text = inventory.Products.Count.ToString();

            //Get all products in curren inventory
            dgvCurrentInventory.DataSource = inventory.Products.DataSource;
        }
    }
}