using DevExpress.XtraEditors;
using inventory_management.Views.Forms.Customers;
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
    public partial class CustomersManageFrm : DevExpress.XtraEditors.XtraForm
    {
        Customer customer = Customer.Instance();
        public CustomersManageFrm()
        {
            InitializeComponent();

            PerformedMethod();
        }

        private void PerformedMethod()
        {
            txtName.Text = customer.Name;
            txtPhone.Text = customer.Phone;
            txtEmail.Text = customer.Email;
            txtLocation.Text = customer.Location;

            okBtn.Click += delegate
            {
                customer.Name = txtName.Text;
                customer.Phone = txtPhone.Text;
                customer.Email = txtEmail.Text;
                customer.Location = txtLocation.Text;
                customer.Save();
            };

            cancelBtn.Click += delegate
            {
                this.Close();
                if (this.IsDisposed)
                    customer.Cancel();
                
            };
        }
    }
}