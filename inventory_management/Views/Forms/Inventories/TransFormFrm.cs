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
            List<string> inventoryNames = inventory.InventoryList.OfType<DataRowView>()
                .Select(x => x[1].ToString())
                .ToList();
            fromInventCbx.Properties.Items.AddRange(inventoryNames);

            fromInventCbx.EditValueChanged += delegate
            {
                
                GetInfo(fromInventCbx.EditValue.ToString(),lblfromLocation,lblfromCapacity,lblfromAvailable,lblfromCategory);

                //to fill combobox by inventory 
                List<DataRow> to = ((DataTable)inventory.InventoryList.DataSource)
                .AsEnumerable()
                .Where(row => row.Field<string>(d.Count - 1) == d[d.Count - 1].ToString() || row.Field<string>(d.Count - 1) == "")
                .ToList();
                toInventCbx.Properties.Items.Clear();
                toInventCbx.Properties.Items.AddRange(to.Select(x => x[1]).ToList());

                //Get products


            };

            toInventCbx.EditValueChanged += delegate
            {
                GetInfo(toInventCbx.EditValue.ToString(), lblToLocation, lblToCapacity, lblToAvailable, lblToCategory);
            };

            //transform
            transformBtn.Click += delegate
            {
                //Check capacity avaible
                //if(Convert.ToInt64(lblToAvailable.Text) < prodCount.Value )
                //    XtraMessageBox.Show("",)
            };

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
    }
}