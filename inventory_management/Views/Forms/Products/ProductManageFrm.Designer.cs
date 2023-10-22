namespace inventory_management.Views.Forms
{
    partial class ProductManageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManageFrm));
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.asa = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProdName = new DevExpress.XtraEditors.TextEdit();
            this.txtExDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.quantityProduct = new DevExpress.XtraEditors.SpinEdit();
            this.txtBuyPrice = new DevExpress.XtraEditors.SpinEdit();
            this.txtSellPrice = new DevExpress.XtraEditors.SpinEdit();
            this.categoryCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.supplierCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProdName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierCbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.ImageOptions.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(367, 534);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(101, 36);
            this.cancelBtn.TabIndex = 31;
            this.cancelBtn.Text = "Cancel";
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Appearance.Options.UseFont = true;
            this.okBtn.AutoSize = true;
            this.okBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.ImageOptions.Image")));
            this.okBtn.Location = new System.Drawing.Point(282, 534);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 36);
            this.okBtn.TabIndex = 30;
            this.okBtn.Text = "OK";
            // 
            // asa
            // 
            this.asa.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asa.Appearance.Options.UseFont = true;
            this.asa.Location = new System.Drawing.Point(22, 105);
            this.asa.Name = "asa";
            this.asa.Size = new System.Drawing.Size(76, 24);
            this.asa.TabIndex = 28;
            this.asa.Text = "Quantity";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 24);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Product Name";
            // 
            // txtProdName
            // 
            this.txtProdName.EditValue = "";
            this.txtProdName.Location = new System.Drawing.Point(176, 30);
            this.txtProdName.Name = "txtProdName";
            this.txtProdName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProdName.Properties.Appearance.Options.UseFont = true;
            this.txtProdName.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtProdName.Properties.ContextImageOptions.Image")));
            this.txtProdName.Size = new System.Drawing.Size(281, 30);
            this.txtProdName.TabIndex = 24;
            // 
            // txtExDate
            // 
            this.txtExDate.EditValue = null;
            this.txtExDate.Location = new System.Drawing.Point(176, 318);
            this.txtExDate.Name = "txtExDate";
            this.txtExDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExDate.Properties.Appearance.Options.UseFont = true;
            this.txtExDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtExDate.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtExDate.Properties.ContextImageOptions.Image")));
            this.txtExDate.Size = new System.Drawing.Size(281, 30);
            this.txtExDate.TabIndex = 35;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(22, 321);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(138, 24);
            this.labelControl5.TabIndex = 37;
            this.labelControl5.Text = "Expiration Date";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(22, 177);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 24);
            this.labelControl6.TabIndex = 38;
            this.labelControl6.Text = "Sell Price";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(21, 249);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(82, 24);
            this.labelControl7.TabIndex = 39;
            this.labelControl7.Text = "Buy Price";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(22, 393);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 24);
            this.labelControl8.TabIndex = 40;
            this.labelControl8.Text = "Category";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(22, 465);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(72, 24);
            this.labelControl9.TabIndex = 41;
            this.labelControl9.Text = "Supplier";
            // 
            // quantityProduct
            // 
            this.quantityProduct.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.quantityProduct.Location = new System.Drawing.Point(176, 102);
            this.quantityProduct.Name = "quantityProduct";
            this.quantityProduct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.quantityProduct.Properties.Appearance.Options.UseFont = true;
            this.quantityProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.quantityProduct.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("quantityProduct.Properties.ContextImageOptions.Image")));
            this.quantityProduct.Size = new System.Drawing.Size(281, 30);
            this.quantityProduct.TabIndex = 43;
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBuyPrice.Location = new System.Drawing.Point(176, 246);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtBuyPrice.Properties.Appearance.Options.UseFont = true;
            this.txtBuyPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtBuyPrice.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtBuyPrice.Properties.ContextImageOptions.Image")));
            this.txtBuyPrice.Size = new System.Drawing.Size(281, 30);
            this.txtBuyPrice.TabIndex = 44;
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSellPrice.Location = new System.Drawing.Point(176, 174);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSellPrice.Properties.Appearance.Options.UseFont = true;
            this.txtSellPrice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtSellPrice.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtSellPrice.Properties.ContextImageOptions.Image")));
            this.txtSellPrice.Size = new System.Drawing.Size(281, 30);
            this.txtSellPrice.TabIndex = 45;
            // 
            // categoryCbx
            // 
            this.categoryCbx.Location = new System.Drawing.Point(176, 390);
            this.categoryCbx.Name = "categoryCbx";
            this.categoryCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryCbx.Properties.Appearance.Options.UseFont = true;
            this.categoryCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.categoryCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("categoryCbx.Properties.ContextImageOptions.Image")));
            this.categoryCbx.Size = new System.Drawing.Size(281, 30);
            this.categoryCbx.TabIndex = 46;
            // 
            // supplierCbx
            // 
            this.supplierCbx.Location = new System.Drawing.Point(176, 462);
            this.supplierCbx.Name = "supplierCbx";
            this.supplierCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplierCbx.Properties.Appearance.Options.UseFont = true;
            this.supplierCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.supplierCbx.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("supplierCbx.Properties.ContextImageOptions.Image")));
            this.supplierCbx.Size = new System.Drawing.Size(281, 30);
            this.supplierCbx.TabIndex = 47;
            // 
            // ProductManageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 579);
            this.Controls.Add(this.supplierCbx);
            this.Controls.Add(this.categoryCbx);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.quantityProduct);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtExDate);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.asa);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtProdName);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ProductManageFrm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(483, 619);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(483, 619);
            this.Name = "ProductManageFrm";
            this.Text = "Add product";
            ((System.ComponentModel.ISupportInitialize)(this.txtProdName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBuyPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSellPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierCbx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.LabelControl asa;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtProdName;
        private DevExpress.XtraEditors.DateEdit txtExDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.SpinEdit quantityProduct;
        private DevExpress.XtraEditors.SpinEdit txtBuyPrice;
        private DevExpress.XtraEditors.SpinEdit txtSellPrice;
        private DevExpress.XtraEditors.ComboBoxEdit categoryCbx;
        private DevExpress.XtraEditors.ComboBoxEdit supplierCbx;
    }
}