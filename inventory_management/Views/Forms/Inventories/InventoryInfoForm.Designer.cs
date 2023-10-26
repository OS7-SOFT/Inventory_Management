namespace inventory_management.Views.Forms
{
    partial class InventoryInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryInfoForm));
            this.dgvCurrentInventory = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.awdwad = new DevExpress.XtraEditors.LabelControl();
            this.lblInvertoyName = new DevExpress.XtraEditors.LabelControl();
            this.lblLocationInvent = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblCapacity = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblProductsCount = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCurrentInventory
            // 
            this.dgvCurrentInventory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvCurrentInventory.Location = new System.Drawing.Point(0, 275);
            this.dgvCurrentInventory.MainView = this.gridView1;
            this.dgvCurrentInventory.Name = "dgvCurrentInventory";
            this.dgvCurrentInventory.Size = new System.Drawing.Size(1198, 585);
            this.dgvCurrentInventory.TabIndex = 0;
            this.dgvCurrentInventory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.dgvCurrentInventory;
            this.gridView1.Name = "gridView1";
            // 
            // awdwad
            // 
            this.awdwad.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awdwad.Appearance.Options.UseFont = true;
            this.awdwad.Location = new System.Drawing.Point(12, 25);
            this.awdwad.Name = "awdwad";
            this.awdwad.Size = new System.Drawing.Size(134, 21);
            this.awdwad.TabIndex = 1;
            this.awdwad.Text = "Inventory Name  :";
            // 
            // lblInvertoyName
            // 
            this.lblInvertoyName.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvertoyName.Appearance.Options.UseFont = true;
            this.lblInvertoyName.Location = new System.Drawing.Point(205, 25);
            this.lblInvertoyName.Name = "lblInvertoyName";
            this.lblInvertoyName.Size = new System.Drawing.Size(118, 21);
            this.lblInvertoyName.TabIndex = 2;
            this.lblInvertoyName.Text = "Office Inventory";
            // 
            // lblLocationInvent
            // 
            this.lblLocationInvent.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocationInvent.Appearance.Options.UseFont = true;
            this.lblLocationInvent.Location = new System.Drawing.Point(219, 89);
            this.lblLocationInvent.Name = "lblLocationInvent";
            this.lblLocationInvent.Size = new System.Drawing.Size(81, 21);
            this.lblLocationInvent.TabIndex = 4;
            this.lblLocationInvent.Text = "Manchister";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 89);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(158, 21);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Inventory Location  : ";
            // 
            // lblCapacity
            // 
            this.lblCapacity.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.Appearance.Options.UseFont = true;
            this.lblCapacity.Location = new System.Drawing.Point(220, 153);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(134, 21);
            this.lblCapacity.TabIndex = 6;
            this.lblCapacity.Text = "Inventory Name  :";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 153);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(154, 21);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Inventory Capacity  :";
            // 
            // lblProductsCount
            // 
            this.lblProductsCount.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductsCount.Appearance.Options.UseFont = true;
            this.lblProductsCount.Location = new System.Drawing.Point(195, 214);
            this.lblProductsCount.Name = "lblProductsCount";
            this.lblProductsCount.Size = new System.Drawing.Size(36, 21);
            this.lblProductsCount.TabIndex = 8;
            this.lblProductsCount.Text = "2305";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 214);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(128, 21);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Products Count  :";
            // 
            // InventoryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 860);
            this.Controls.Add(this.lblProductsCount);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lblLocationInvent);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblInvertoyName);
            this.Controls.Add(this.awdwad);
            this.Controls.Add(this.dgvCurrentInventory);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("InventoryInfoForm.IconOptions.LargeImage")));
            this.Name = "InventoryInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inventory Information";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl dgvCurrentInventory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl awdwad;
        private DevExpress.XtraEditors.LabelControl lblInvertoyName;
        private DevExpress.XtraEditors.LabelControl lblLocationInvent;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblCapacity;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblProductsCount;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}