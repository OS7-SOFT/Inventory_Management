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
                supplier.Name = txtName.Text;
                supplier.Phone = txtPhone.Text;
                supplier.Email = txtEmail.Text;
                supplier.Save();
            };

            cancelBtn.Click += delegate
            {
                this.Close();
                if (this.IsDisposed)
                    supplier.Cancel();

            };
        }
    }
}