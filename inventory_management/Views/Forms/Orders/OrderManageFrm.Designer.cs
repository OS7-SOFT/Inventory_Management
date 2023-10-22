namespace inventory_management.Views.Forms
{
    partial class OrderManageFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderManageFrm));
            this.customerCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ProductCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtQuantity = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.asa = new DevExpress.XtraEditors.LabelControl();
            this.statusCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.customerCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // customerCbx
            // 
            this.customerCbx.Location = new System.Drawing.Point(164, 164);
            this.customerCbx.Name = "customerCbx";
            this.customerCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerCbx.Properties.Appearance.Options.UseFont = true;
            this.customerCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.customerCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("customerCbx.Properties.ContextImageOptions.Image")));
            this.customerCbx.Size = new System.Drawing.Size(281, 30);
            this.customerCbx.TabIndex = 55;
            // 
            // ProductCbx
            // 
            this.ProductCbx.Location = new System.Drawing.Point(164, 16);
            this.ProductCbx.Name = "ProductCbx";
            this.ProductCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCbx.Properties.Appearance.Options.UseFont = true;
            this.ProductCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ProductCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ProductCbx.Properties.ContextImageOptions.Image")));
            this.ProductCbx.Size = new System.Drawing.Size(281, 30);
            this.ProductCbx.TabIndex = 54;
            // 
            // txtQuantity
            // 
            this.txtQuantity.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtQuantity.Location = new System.Drawing.Point(164, 90);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtQuantity.Properties.Appearance.Options.UseFont = true;
            this.txtQuantity.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtQuantity.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtQuantity.Properties.ContextImageOptions.Image")));
            this.txtQuantity.Size = new System.Drawing.Size(281, 30);
            this.txtQuantity.TabIndex = 53;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(12, 170);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(85, 24);
            this.labelControl9.TabIndex = 52;
            this.labelControl9.Text = "Customer";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(12, 22);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(127, 24);
            this.labelControl8.TabIndex = 51;
            this.labelControl8.Text = "Select Product";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.ImageOptions.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(346, 291);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(101, 36);
            this.cancelBtn.TabIndex = 50;
            this.cancelBtn.Text = "Cancel";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Appearance.Options.UseFont = true;
            this.okBtn.AutoSize = true;
            this.okBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.ImageOptions.Image")));
            this.okBtn.Location = new System.Drawing.Point(261, 291);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 36);
            this.okBtn.TabIndex = 49;
            this.okBtn.Text = "OK";
            // 
            // asa
            // 
            this.asa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Appearance.Options.UseFont = true;
            this.asa.Location = new System.Drawing.Point(12, 96);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(76, 24);
            this.asa.TabIndex = 48;
            this.asa.Text = "Quantity";
            // 
            // statusCbx
            // 
            this.statusCbx.Location = new System.Drawing.Point(164, 238);
            this.statusCbx.Name = "statusCbx";
            this.statusCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCbx.Properties.Appearance.Options.UseFont = true;
            this.statusCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.statusCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("comboBoxEdit1.Properties.ContextImageOptions.Image")));
            this.statusCbx.Properties.Items.AddRange(new object[] {
            "Under proccessing",
            "Completed",
            "Canceled"});
            this.statusCbx.Size = new System.Drawing.Size(281, 30);
            this.statusCbx.TabIndex = 57;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 244);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 24);
            this.labelControl1.TabIndex = 56;
            this.labelControl1.Text = "Status";
            // 
            // OrderManageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 339);
            this.Controls.Add(this.statusCbx);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.customerCbx);
            this.Controls.Add(this.ProductCbx);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.asa);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("OrderManageFrm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(459, 324);
            this.Name = "OrderManageFrm";
            this.Text = "Add Order";
            ((System.ComponentModel.ISupportInitialize)(this.customerCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusCbx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit customerCbx;
        private DevExpress.XtraEditors.ComboBoxEdit ProductCbx;
        private DevExpress.XtraEditors.SpinEdit txtQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.LabelControl asa;
        private DevExpress.XtraEditors.ComboBoxEdit statusCbx;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}