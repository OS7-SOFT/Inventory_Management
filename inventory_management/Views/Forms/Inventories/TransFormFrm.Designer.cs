namespace inventory_management.Views.Forms
{
    partial class TransFormFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransFormFrm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toInventCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.prodCount = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.fromInventCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.transformBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelTransBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.productCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.lblToCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblToAvailable = new DevExpress.XtraEditors.LabelControl();
            this.lblToLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblToCapacity = new DevExpress.XtraEditors.LabelControl();
            this.lblfromCategory = new DevExpress.XtraEditors.LabelControl();
            this.lblfromAvailable = new DevExpress.XtraEditors.LabelControl();
            this.lblfromLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblfromCapacity = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.toInventCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromInventCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(19, 131);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "From";
            // 
            // toInventCbx
            // 
            this.toInventCbx.Location = new System.Drawing.Point(419, 128);
            this.toInventCbx.Name = "toInventCbx";
            this.toInventCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toInventCbx.Properties.Appearance.Options.UseFont = true;
            this.toInventCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.toInventCbx.Size = new System.Drawing.Size(229, 30);
            this.toInventCbx.TabIndex = 3;
            // 
            // prodCount
            // 
            this.prodCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prodCount.Location = new System.Drawing.Point(107, 404);
            this.prodCount.Name = "prodCount";
            this.prodCount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodCount.Properties.Appearance.Options.UseFont = true;
            this.prodCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prodCount.Size = new System.Drawing.Size(229, 30);
            this.prodCount.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(19, 407);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Count";
            // 
            // fromInventCbx
            // 
            this.fromInventCbx.Location = new System.Drawing.Point(80, 128);
            this.fromInventCbx.Name = "fromInventCbx";
            this.fromInventCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromInventCbx.Properties.Appearance.Options.UseFont = true;
            this.fromInventCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fromInventCbx.Size = new System.Drawing.Size(229, 30);
            this.fromInventCbx.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(377, 131);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(23, 24);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "To";
            // 
            // transformBtn
            // 
            this.transformBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.transformBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transformBtn.Appearance.Options.UseFont = true;
            this.transformBtn.AutoSize = true;
            this.transformBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("transformBtn.ImageOptions.Image")));
            this.transformBtn.Location = new System.Drawing.Point(459, 454);
            this.transformBtn.Name = "transformBtn";
            this.transformBtn.Size = new System.Drawing.Size(133, 36);
            this.transformBtn.TabIndex = 8;
            this.transformBtn.Text = "Transform";
            // 
            // cancelTransBtn
            // 
            this.cancelTransBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelTransBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelTransBtn.Appearance.Options.UseFont = true;
            this.cancelTransBtn.AutoSize = true;
            this.cancelTransBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancelTransBtn.ImageOptions.Image")));
            this.cancelTransBtn.Location = new System.Drawing.Point(618, 454);
            this.cancelTransBtn.Name = "cancelTransBtn";
            this.cancelTransBtn.Size = new System.Drawing.Size(101, 36);
            this.cancelTransBtn.TabIndex = 9;
            this.cancelTransBtn.Text = "Cancel";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Location = new System.Drawing.Point(173, 15);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(351, 42);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "To transform product from inventory to another\r\nSelect current inventory and anot" +
    "her inventory";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(19, 190);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(74, 21);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Capacity :";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(19, 264);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(73, 21);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Location :";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(19, 227);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(78, 21);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Available :";
            // 
            // productCbx
            // 
            this.productCbx.Location = new System.Drawing.Point(107, 352);
            this.productCbx.Name = "productCbx";
            this.productCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productCbx.Properties.Appearance.Options.UseFont = true;
            this.productCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.productCbx.Size = new System.Drawing.Size(229, 30);
            this.productCbx.TabIndex = 17;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(19, 355);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(67, 24);
            this.labelControl11.TabIndex = 18;
            this.labelControl11.Text = "Product";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.Location = new System.Drawing.Point(19, 301);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(77, 21);
            this.labelControl12.TabIndex = 19;
            this.labelControl12.Text = "Category :";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(377, 301);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(77, 21);
            this.labelControl8.TabIndex = 23;
            this.labelControl8.Text = "Category :";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(377, 227);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(78, 21);
            this.labelControl9.TabIndex = 22;
            this.labelControl9.Text = "Available :";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(377, 264);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(73, 21);
            this.labelControl10.TabIndex = 21;
            this.labelControl10.Text = "Location :";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.Location = new System.Drawing.Point(377, 190);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(74, 21);
            this.labelControl13.TabIndex = 20;
            this.labelControl13.Text = "Capacity :";
            // 
            // lblToCategory
            // 
            this.lblToCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCategory.Appearance.Options.UseFont = true;
            this.lblToCategory.Location = new System.Drawing.Point(468, 301);
            this.lblToCategory.Name = "lblToCategory";
            this.lblToCategory.Size = new System.Drawing.Size(77, 21);
            this.lblToCategory.TabIndex = 27;
            this.lblToCategory.Text = "Category :";
            // 
            // lblToAvailable
            // 
            this.lblToAvailable.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToAvailable.Appearance.Options.UseFont = true;
            this.lblToAvailable.Location = new System.Drawing.Point(468, 227);
            this.lblToAvailable.Name = "lblToAvailable";
            this.lblToAvailable.Size = new System.Drawing.Size(78, 21);
            this.lblToAvailable.TabIndex = 26;
            this.lblToAvailable.Text = "Available :";
            // 
            // lblToLocation
            // 
            this.lblToLocation.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToLocation.Appearance.Options.UseFont = true;
            this.lblToLocation.Location = new System.Drawing.Point(468, 264);
            this.lblToLocation.Name = "lblToLocation";
            this.lblToLocation.Size = new System.Drawing.Size(73, 21);
            this.lblToLocation.TabIndex = 25;
            this.lblToLocation.Text = "Location :";
            // 
            // lblToCapacity
            // 
            this.lblToCapacity.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToCapacity.Appearance.Options.UseFont = true;
            this.lblToCapacity.Location = new System.Drawing.Point(468, 190);
            this.lblToCapacity.Name = "lblToCapacity";
            this.lblToCapacity.Size = new System.Drawing.Size(74, 21);
            this.lblToCapacity.TabIndex = 24;
            this.lblToCapacity.Text = "Capacity :";
            // 
            // lblfromCategory
            // 
            this.lblfromCategory.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromCategory.Appearance.Options.UseFont = true;
            this.lblfromCategory.Location = new System.Drawing.Point(107, 301);
            this.lblfromCategory.Name = "lblfromCategory";
            this.lblfromCategory.Size = new System.Drawing.Size(77, 21);
            this.lblfromCategory.TabIndex = 31;
            this.lblfromCategory.Text = "Category :";
            // 
            // lblfromAvailable
            // 
            this.lblfromAvailable.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromAvailable.Appearance.Options.UseFont = true;
            this.lblfromAvailable.Location = new System.Drawing.Point(107, 227);
            this.lblfromAvailable.Name = "lblfromAvailable";
            this.lblfromAvailable.Size = new System.Drawing.Size(78, 21);
            this.lblfromAvailable.TabIndex = 30;
            this.lblfromAvailable.Text = "Available :";
            // 
            // lblfromLocation
            // 
            this.lblfromLocation.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromLocation.Appearance.Options.UseFont = true;
            this.lblfromLocation.Location = new System.Drawing.Point(107, 264);
            this.lblfromLocation.Name = "lblfromLocation";
            this.lblfromLocation.Size = new System.Drawing.Size(73, 21);
            this.lblfromLocation.TabIndex = 29;
            this.lblfromLocation.Text = "Location :";
            // 
            // lblfromCapacity
            // 
            this.lblfromCapacity.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfromCapacity.Appearance.Options.UseFont = true;
            this.lblfromCapacity.Location = new System.Drawing.Point(107, 190);
            this.lblfromCapacity.Name = "lblfromCapacity";
            this.lblfromCapacity.Size = new System.Drawing.Size(74, 21);
            this.lblfromCapacity.TabIndex = 28;
            this.lblfromCapacity.Text = "Capacity :";
            // 
            // TransFormFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 502);
            this.Controls.Add(this.lblfromCategory);
            this.Controls.Add(this.lblfromAvailable);
            this.Controls.Add(this.lblfromLocation);
            this.Controls.Add(this.lblfromCapacity);
            this.Controls.Add(this.lblToCategory);
            this.Controls.Add(this.lblToAvailable);
            this.Controls.Add(this.lblToLocation);
            this.Controls.Add(this.lblToCapacity);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.productCbx);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cancelTransBtn);
            this.Controls.Add(this.transformBtn);
            this.Controls.Add(this.fromInventCbx);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.prodCount);
            this.Controls.Add(this.toInventCbx);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("TransFormFrm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransFormFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transform Products";
            ((System.ComponentModel.ISupportInitialize)(this.toInventCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromInventCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productCbx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit toInventCbx;
        private DevExpress.XtraEditors.SpinEdit prodCount;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit fromInventCbx;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton transformBtn;
        private DevExpress.XtraEditors.SimpleButton cancelTransBtn;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.ComboBoxEdit productCbx;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl lblToCategory;
        private DevExpress.XtraEditors.LabelControl lblToAvailable;
        private DevExpress.XtraEditors.LabelControl lblToLocation;
        private DevExpress.XtraEditors.LabelControl lblToCapacity;
        private DevExpress.XtraEditors.LabelControl lblfromCategory;
        private DevExpress.XtraEditors.LabelControl lblfromAvailable;
        private DevExpress.XtraEditors.LabelControl lblfromLocation;
        private DevExpress.XtraEditors.LabelControl lblfromCapacity;
    }
}