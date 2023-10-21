namespace inventory_management.Views.Forms
{
    partial class InventoryManageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryManageFrm));
            this.txtNameInvent = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.categoryCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.asa = new DevExpress.XtraEditors.LabelControl();
            this.txtLocation = new DevExpress.XtraEditors.TextEdit();
            this.capacityInvent = new DevExpress.XtraEditors.SpinEdit();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameInvent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityInvent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNameInvent
            // 
            this.txtNameInvent.EditValue = "";
            this.txtNameInvent.Location = new System.Drawing.Point(130, 21);
            this.txtNameInvent.Name = "txtNameInvent";
            this.txtNameInvent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameInvent.Properties.Appearance.Options.UseFont = true;
            this.txtNameInvent.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtNameInvent.Properties.ContextImageOptions.Image")));
            this.txtNameInvent.Size = new System.Drawing.Size(281, 30);
            this.txtNameInvent.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 24);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Name";
            // 
            // categoryCbx
            // 
            this.categoryCbx.Location = new System.Drawing.Point(130, 243);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCbx.Properties.Appearance.Options.UseFont = true;
            this.categoryCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.categoryCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("categoryCbx.Properties.ContextImageOptions.Image")));
            this.categoryCbx.Size = new System.Drawing.Size(221, 30);
            this.categoryCbx.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(32, 98);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 24);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Location";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(31, 172);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(76, 24);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Capacity";
            // 
            // asa
            // 
            this.asa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Appearance.Options.UseFont = true;
            this.asa.Location = new System.Drawing.Point(32, 246);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(80, 24);
            this.asa.TabIndex = 5;
            this.asa.Text = "Category";
            // 
            // txtLocation
            // 
            this.txtLocation.EditValue = "";
            this.txtLocation.Location = new System.Drawing.Point(130, 95);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Properties.Appearance.Options.UseFont = true;
            this.txtLocation.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtLocation.Properties.ContextImageOptions.Image")));
            this.txtLocation.Size = new System.Drawing.Size(281, 30);
            this.txtLocation.TabIndex = 6;
            // 
            // capacityInvent
            // 
            this.capacityInvent.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.capacityInvent.Location = new System.Drawing.Point(130, 169);
            this.capacityInvent.Name = "capacityInvent";
            this.capacityInvent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityInvent.Properties.Appearance.Options.UseFont = true;
            this.capacityInvent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.capacityInvent.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("capacityInvent.Properties.ContextImageOptions.Image")));
            this.capacityInvent.Size = new System.Drawing.Size(125, 30);
            this.capacityInvent.TabIndex = 7;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.ImageOptions.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(213, 315);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(101, 36);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Cancel";
            // 
            // okBtn
            // 
            this.okBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Appearance.Options.UseFont = true;
            this.okBtn.AutoSize = true;
            this.okBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.ImageOptions.Image")));
            this.okBtn.Location = new System.Drawing.Point(129, 315);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 36);
            this.okBtn.TabIndex = 10;
            this.okBtn.Text = "OK";
            // 
            // InventoryManageFrm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 363);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.capacityInvent);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.asa);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNameInvent);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("InventoryManageFrm.IconOptions.LargeImage")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(444, 403);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 403);
            this.Name = "InventoryManageFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.txtNameInvent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capacityInvent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNameInvent;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit categoryCbx;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl asa;
        private DevExpress.XtraEditors.TextEdit txtLocation;
        private DevExpress.XtraEditors.SpinEdit capacityInvent;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton okBtn;
    }
}