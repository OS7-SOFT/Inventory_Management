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
    public partial class InventoryManageFrm : DevExpress.XtraEditors.XtraForm
    {
        Inventory inventory = Inventory.Instance();  
        public InventoryManageFrm()
        {
            InitializeComponent();

            performedMethod();

        }

        private void performedMethod()
        {
            //Set Data 
            txtNameInvent.Text = inventory.Name;
            txtLocation.Text = inventory.Location;
            capacityInvent.Value = (decimal)inventory.Capacity;
            if (inventory.Categories.Count > 0)
                categoryCbx.Properties.Items.AddRange(inventory.Categories);
             
             
            
            //Get Current Category in edit
            if (inventory.Category_name != "" || inventory.Category_name != null)
                categoryCbx.EditValue = inventory.Category_name;

            okBtn.Click += delegate
            {
                inventory.Name = txtNameInvent.Text;
                inventory.Location = txtLocation.Text;
                inventory.Capacity = (double)capacityInvent.Value;
                inventory.Category_name = categoryCbx.EditValue !=null ? categoryCbx.EditValue.ToString() : "";
                inventory.Save();
            };
            cancelBtn.Click += delegate
            {
                this.Close();
                if(this.IsDisposed)
                    inventory.Cancel();
            };
        }
    }
}