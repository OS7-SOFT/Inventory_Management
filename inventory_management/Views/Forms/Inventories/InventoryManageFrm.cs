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
          
            //select min value 
            capacityInvent.Properties.MaxValue = 10000000000000000000  ;
            capacityInvent.Properties.MinValue = 0  ;


            //Set Data 
            txtNameInvent.Text = inventory.Name;
            txtLocation.Text = inventory.Location;
            capacityInvent.Value = (decimal)inventory.Capacity;
            if (inventory.Categories.Count > 0)
                categoryCbx.Properties.Items.AddRange(inventory.Categories);
            //Get Current Category in edit
            if (inventory.Category_name != "" || inventory.Category_name != null)
                categoryCbx.EditValue = inventory.Category_name;
            else
                categoryCbx.EditValue = "";

            //Events 
            categoryCbx.EditValueChanged += delegate
            {
                CheckValueComboBox();
            };

            okBtn.Click += delegate
            {
                //Add inventory
                if (!inventory.isEdit)
                {
                    if (CheckName())
                        SaveChange();
                    else
                        XtraMessageBox.Show("this inventory name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Edit inventory
                if (inventory.isEdit)
                {
                    if(CheckValueChanged())
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
                inventory.Cancel();
            };
        }

        //save change
        private void SaveChange()
        {
            inventory.Name = txtNameInvent.Text;
            inventory.Location = txtLocation.Text;
            inventory.Capacity = (double)capacityInvent.Value;
            inventory.Category_name = categoryCbx.EditValue != null ? categoryCbx.EditValue.ToString() : null;
            inventory.Save();
        }

        //Check Name is exsiste
        private bool CheckName()
        {
            
            List<string> inventoryNames = inventory.InventoryList
               .OfType<DataRowView>()
               .Select(x => x[1].ToString())
               .ToList();
            if (inventoryNames.Contains(txtNameInvent.Text))
                return false;
            return true;
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (txtNameInvent.Text.Trim() == inventory.Name && txtNameInvent.Text.Trim() == inventory.Name && txtLocation.Text.Trim() == inventory.Location && capacityInvent.Value == (decimal)inventory.Capacity && categoryCbx.Text.Trim() == inventory.Category_name)
            {
                return false;
            }
            else 
                return true;
        }

        //Check Combobox value
        private void CheckValueComboBox()
        {
            string enteredValue = categoryCbx.Text;

            bool isValid = categoryCbx.Properties.Items.Contains(enteredValue);

            categoryCbx.EditValue = isValid ? enteredValue : null;
        }
    }
}