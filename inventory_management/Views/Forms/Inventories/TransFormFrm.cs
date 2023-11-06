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
    public partial class TransFormFrm : DevExpress.XtraEditors.XtraForm
    {
        Inventory inventory = Inventory.Instance();
        List<object> d = new List<object>();
        public TransFormFrm()
        {
            InitializeComponent();

            PerformedMethod();
        }

        private void PerformedMethod()
        {
            fromInventCbx.Properties.AutoComplete = true;

            List<string> inventoryNames = inventory.InventoryList.OfType<DataRowView>()
                .Select(x => x[1].ToString())
                .ToList();
            fromInventCbx.Properties.Items.AddRange(inventoryNames);


            //Events
            fromInventCbx.EditValueChanged += delegate
            {
                if (CheckValueComboBox(fromInventCbx))
                {
                    GetInfo(fromInventCbx.EditValue.ToString(), lblfromLocation, lblfromCapacity, lblfromAvailable, lblfromCategory);

                    //to fill tocombobox by inventory name 
                    List<DataRow> to = ((DataTable)inventory.InventoryList.DataSource)
                    .AsEnumerable()
                    .Where(row => (row.Field<string>(d.Count - 1) == d[d.Count - 1].ToString() || row.Field<string>(d.Count - 1) == null) && row.Field<string>(1) != fromInventCbx.EditValue.ToString())
                    .ToList();
                    toInventCbx.Properties.Items.Clear();
                    toInventCbx.Properties.Items.AddRange(to.Select(x => x[1]).ToList());

                    //set products 
                    inventory.GetInfoInventory(GetId(fromInventCbx.EditValue.ToString(), inventory.InventoryList));
                    SetProducts();
                    prodCount.Value = 0;
                }
            };

            toInventCbx.EditValueChanged += delegate
            {
                if (CheckValueComboBox(toInventCbx))
                    GetInfo(toInventCbx.EditValue.ToString(), lblToLocation, lblToCapacity, lblToAvailable, lblToCategory);
            };

            //Select current product
            productCbx.EditValueChanged += delegate
            {
                if (CheckValueComboBox(productCbx))
                {
                    List<object> current = ((DataTable)inventory.Products.DataSource)
                    .AsEnumerable()
                    .Where(row => row.Field<string>(1) == productCbx.EditValue.ToString())
                    .FirstOrDefault().ItemArray.ToList();

                    prodCount.Properties.MaxValue = Convert.ToInt32(current[2]);
                    prodCount.Properties.MinValue = 0;
                }
            };

            //transform
            transformBtn.Click += delegate
            {
                if(fromInventCbx.EditValue != null && toInventCbx.EditValue != null)
                {
                    if (productCbx.Properties.Items.Count > 0)
                    {
                        //Check capacity avaible
                        if (Convert.ToInt64(lblToAvailable.Text) < prodCount.Value)
                            MessageError();
                        else
                        {
                            if (Convert.ToInt64(lblToAvailable.Text) - prodCount.Value < 100)
                            {
                                var result = MessageWarringInventory();
                                if (result == DialogResult.Yes)
                                    inventory.Transform(GetId(fromInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(toInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(productCbx.EditValue.ToString(), inventory.Products), Convert.ToInt32(prodCount.EditValue));
                            }

                            else if (lblfromCategory.Text != lblToCategory.Text)
                            {
                                var result = MessageWarringCategory();
                                if (result == DialogResult.Yes)
                                    inventory.Transform(GetId(fromInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(toInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(productCbx.EditValue.ToString(), inventory.Products), Convert.ToInt32(prodCount.EditValue));
                            }

                            else
                                inventory.Transform(GetId(fromInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(toInventCbx.EditValue.ToString(), inventory.InventoryList), GetId(productCbx.EditValue.ToString(), inventory.Products), Convert.ToInt32(prodCount.EditValue));

                        }
                    }
                    else
                        XtraMessageBox.Show($"No there any products in '{fromInventCbx.EditValue.ToString()}' inventory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else 
                    XtraMessageBox.Show($"Please Select inventory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            };

            cancelTransBtn.Click += delegate
            {
                this.Close();
            };

        }

        //Get All product in current inventory
        private void SetProducts()
        {
            productCbx.Text = null;
            productCbx.Properties.Items.Clear();
            List<string> productsNames = inventory.Products.OfType<DataRowView>()
           .Select(x => x[1].ToString())
           .ToList();
            productCbx.Properties.Items.AddRange(productsNames);
        }

        //to get info for inventory Selected
        private void GetInfo(string val, LabelControl location, LabelControl capacity, LabelControl available, LabelControl category)
        {
            d.Clear();

            DataRow current = ((DataTable)inventory.InventoryList.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(1) == val)
                .FirstOrDefault();

            d = current.ItemArray.ToList();
            location.Text = d[2].ToString();
            capacity.Text = d[3].ToString();
            available.Text = d[5].ToString();
            category.Text = d[d.Count - 1].ToString();

        }

        //Get inventory id
        private int GetId(string val, BindingSource bindingSource)
        {
            int id = bindingSource.OfType<DataRowView>()
                        .Where(x => x[1].ToString() == val)
                        .Select(x => Convert.ToInt32(x[0]))
                        .FirstOrDefault();
            return id;
        }

        //Check Combobox value
        private bool CheckValueComboBox(ComboBoxEdit CB)
        {
            string enteredValue = CB.Text;

            bool isValid = CB.Properties.Items.Contains(enteredValue);

            CB.EditValue = isValid ? enteredValue : null;

            return isValid;
        }


        //Message Error 
        private void MessageError()
        {
            XtraMessageBox.Show($"You cannot transfer the producs form " +
                       $"inventory '{fromInventCbx.EditValue.ToString()}'\n" +
                       $" to inventory '{toInventCbx.EditValue.ToString()}'" +
                       $"because the number of products is\ngreater than " +
                       $"the available space in " +
                       $"inventory {toInventCbx.EditValue.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //message warring
        private DialogResult MessageWarringInventory()
        {
            return XtraMessageBox.Show($"if the products transferred from inventory '{fromInventCbx.EditValue.ToString()}'\n" +
                             $"to the inventory '{toInventCbx.EditValue.ToString()}' the available space\n" +
                             $"in inventory '{toInventCbx.EditValue.ToString()}' will be less than 100\n" +
                             $"Do you still want to proceed with the transfer", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
        private DialogResult MessageWarringCategory()
        {
            return XtraMessageBox.Show($"the '{toInventCbx.EditValue.ToString()}' inventory not contain any category\n" +
                $"if transfer product will automatically be assigned the '{lblfromCategory.Text}'\n " +
                $"Do you still want to proceed with the transfer", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }
    }
}