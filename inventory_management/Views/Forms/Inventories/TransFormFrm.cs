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

            fromInventCbx.EditValueChanged += delegate
            {
                
                GetInfo(fromInventCbx.EditValue.ToString(),lblfromLocation,lblfromCapacity,lblfromAvailable,lblfromCategory);

                //to fill tocombobox by inventory name 
                List<DataRow> to = ((DataTable)inventory.InventoryList.DataSource)
                .AsEnumerable()
                .Where(row => (row.Field<string>(d.Count - 1) == d[d.Count - 1].ToString() || row.Field<string>(d.Count - 1) == null) && row.Field<string>(1) != fromInventCbx.EditValue.ToString())
                .ToList();
                toInventCbx.Properties.Items.Clear();
                toInventCbx.Properties.Items.AddRange(to.Select(x => x[1]).ToList());

                //set products 
                inventory.GetInfoInventory(GetId(fromInventCbx.EditValue.ToString()));
                SetProducts();


            };

            toInventCbx.EditValueChanged += delegate
            {
                GetInfo(toInventCbx.EditValue.ToString(), lblToLocation, lblToCapacity, lblToAvailable, lblToCategory);
            };

            //Select current product
            productCbx.EditValueChanged += delegate
            {
                List<object> current = ((DataTable)inventory.Products.DataSource)
               .AsEnumerable()
               .Where(row => row.Field<string>(1) == productCbx.EditValue.ToString())
               .FirstOrDefault().ItemArray.ToList();

                prodCount.Properties.MaxValue = Convert.ToInt32(current[2]);
                prodCount.Properties.MinValue = 0;
            };

            //transform
            transformBtn.Click += delegate
            {
                //Check capacity avaible
                if (Convert.ToInt64(lblToAvailable.Text) < prodCount.Value)
                    MessageError();
                else
                {
                    if (Convert.ToInt64(lblToAvailable.Text) - prodCount.Value < 100)
                    {
                        var result = MessageWarring();
                        if (result == DialogResult.Yes )
                            inventory.Transform(GetId(fromInventCbx.EditValue.ToString()), GetId(toInventCbx.EditValue.ToString()), GetId(productCbx.EditValue.ToString()),(int)prodCount.EditValue);
                    }
                }
            };

        }

        //Get All product in current inventory
        private void SetProducts()
        {
            productCbx.Properties.Items.Clear();
            List<string> productsNames = inventory.Products.OfType<DataRowView>()
           .Select(x => x[1].ToString())
           .ToList();
            productCbx.Properties.Items.AddRange(productsNames);
        }

        //to get info for inventory Selected
        private void GetInfo(string val,LabelControl location , LabelControl capacity, LabelControl available, LabelControl category) 
        {
            d.Clear();

            DataRow current = ((DataTable)inventory.InventoryList.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(1) == val)
                .FirstOrDefault();
 
            d = current.ItemArray.ToList();
            location.Text = d[2].ToString();
            capacity.Text = d[3].ToString();
            available.Text = d[4].ToString();
            category.Text = d[d.Count - 1].ToString();

        }

        //Get inventory id
        private int GetId(string val)
        {
            int id = inventory.InventoryList.OfType<DataRowView>()
                        .Where(x => x[1].ToString() == val)
                        .Select(x => Convert.ToInt32(x[0]))
                        .FirstOrDefault();
            return id;
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
        private DialogResult MessageWarring()
        {
           return XtraMessageBox.Show($"if the products transferred from inventory '{fromInventCbx.EditValue.ToString()}'\n" +
                            $"to the inventory '{toInventCbx.EditValue.ToString()}' the available space\n" +
                            $"in inventory '{toInventCbx.EditValue.ToString()}' will be less than 100\n" +
                            $"Do you still want to proceed with the transfer", "Warring", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

    }
}