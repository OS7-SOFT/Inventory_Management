using DevExpress.XtraEditors;
using inventory_management.Views.Forms.Suppliers;
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
    public partial class SuppliersManageFrm : DevExpress.XtraEditors.XtraForm
    {
        Supplier supplier = Supplier.Instance();
        public SuppliersManageFrm()
        {
            InitializeComponent();
            PerformedMethod();
        }

        private void PerformedMethod()
        {
            txtName.Text = supplier.Name;
            txtPhone.Text = supplier.Phone;
            txtEmail.Text = supplier.Email;

            okBtn.Click += delegate
            {
                if (!supplier.isEdit)
                {
                    if (CheckName())
                        SaveChange();
                    else
                        XtraMessageBox.Show("this supplier name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (supplier.isEdit)
                {
                    if (CheckValueChanged())
                        SaveChange();
                    else
                        this.Close();
                }
            };

            cancelBtn.Click += delegate
            {
                this.Close();
            };
            this.FormClosing += delegate
            {
                supplier.Cancel();
            };
        }


        //Save Change
        private void SaveChange()
        {
            supplier.Name = txtName.Text;
            supplier.Phone = txtPhone.Text;
            supplier.Email = txtEmail.Text;
            supplier.Save();
        }

        //Check Name is exsiste
        private bool CheckName()
        {

            List<string> supplierNames = supplier.SuppliersList
               .OfType<DataRowView>()
               .Select(x => x[1].ToString())
               .ToList();
            if (supplierNames.Contains(txtName.Text))
                return false;
            return true;
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (txtName.Text.Trim() == supplier.Name && txtEmail.Text.Trim() == supplier.Email && txtPhone.Text.Trim() == supplier.Phone)
            {
                return false;
            }
            else
                return true;
        }
    }
}