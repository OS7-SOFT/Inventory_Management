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
                if (!customer.isEdit)
                {
                    if (CheckName())
                        SaveChange();
                    else
                        XtraMessageBox.Show("this customer name is already exist\nchange name to another name", "Name Already exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (customer.isEdit)
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
                customer.Cancel();
            };
        }

        //Save Change
        private void SaveChange()
        {
            customer.Name = txtName.Text;
            customer.Phone = txtPhone.Text;
            customer.Email = txtEmail.Text;
            customer.Location = txtLocation.Text;
            customer.Save();
        }

        //Check Name is exsiste
        private bool CheckName()
        {

            List<string> customerNames = customer.CustomersList
               .OfType<DataRowView>()
               .Select(x => x[1].ToString())
               .ToList();
            if (customerNames.Contains(txtName.Text))
                return false;
            return true;
        }

        //check if user is change value
        private bool CheckValueChanged()
        {
            if (txtName.Text.Trim() == customer.Name && txtEmail.Text.Trim() == customer.Email && txtLocation.Text.Trim() == customer.Location)
            {
                return false;
            }
            else
                return true;
        }
    }
}