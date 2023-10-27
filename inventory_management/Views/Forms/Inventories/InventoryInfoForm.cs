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
            //Get info current Inventory
            List<object> info = ((DataTable)inventory.InventoryList.DataSource)
                .AsEnumerable()
                .Where(x => Convert.ToInt32(x[0]) == inventory.Id)
                .FirstOrDefault().ItemArray.ToList();

            lblInvertoyName.Text = info[1].ToString();
            lblCapacity.Text = info[3].ToString();
            lblAvailable.Text = info[4].ToString();
            lblLocationInvent.Text =info[2].ToString();
            lblProductsCount.Text = info[5].ToString();
            lblCategory.Text = info[6].ToString();

            //Get all products in curren inventory
            dgvCurrentInventory.DataSource = inventory.Products.DataSource;
        }
    }
}