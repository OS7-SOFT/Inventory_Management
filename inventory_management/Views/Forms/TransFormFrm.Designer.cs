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
            this.prodTransCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.prodCountSpin = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cateTransCbx = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.transformBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelTransBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.prodTransCbx.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodCountSpin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cateTransCbx.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(127, 24);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Select Product";
            // 
            // prodTransCbx
            // 
            this.prodTransCbx.Location = new System.Drawing.Point(157, 22);
            this.prodTransCbx.Name = "prodTransCbx";
            this.prodTransCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodTransCbx.Properties.Appearance.Options.UseFont = true;
            this.prodTransCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prodTransCbx.Size = new System.Drawing.Size(229, 30);
            this.prodTransCbx.TabIndex = 3;
            // 
            // prodCountSpin
            // 
            this.prodCountSpin.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.prodCountSpin.Location = new System.Drawing.Point(82, 90);
            this.prodCountSpin.Name = "prodCountSpin";
            this.prodCountSpin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prodCountSpin.Properties.Appearance.Options.UseFont = true;
            this.prodCountSpin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.prodCountSpin.Size = new System.Drawing.Size(92, 30);
            this.prodCountSpin.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 24);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Count";
            // 
            // cateTransCbx
            // 
            this.cateTransCbx.Location = new System.Drawing.Point(171, 150);
            this.cateTransCbx.Name = "cateTransCbx";
            this.cateTransCbx.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cateTransCbx.Properties.Appearance.Options.UseFont = true;
            this.cateTransCbx.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cateTransCbx.Size = new System.Drawing.Size(229, 30);
            this.cateTransCbx.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(12, 153);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(145, 24);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Select Inventory";
            // 
            // transformBtn
            // 
            this.transformBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transformBtn.Appearance.Options.UseFont = true;
            this.transformBtn.AutoSize = true;
            this.transformBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.transformBtn.Location = new System.Drawing.Point(51, 224);
            this.transformBtn.Name = "transformBtn";
            this.transformBtn.Size = new System.Drawing.Size(153, 44);
            this.transformBtn.TabIndex = 8;
            this.transformBtn.Text = "Transform";
            // 
            // cancelTransBtn
            // 
            this.cancelTransBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelTransBtn.Appearance.Options.UseFont = true;
            this.cancelTransBtn.AutoSize = true;
            this.cancelTransBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.cancelTransBtn.Location = new System.Drawing.Point(210, 224);
            this.cancelTransBtn.Name = "cancelTransBtn";
            this.cancelTransBtn.Size = new System.Drawing.Size(153, 44);
            this.cancelTransBtn.TabIndex = 9;
            this.cancelTransBtn.Text = "Cancel";
            // 
            // TransFormFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 280);
            this.Controls.Add(this.cancelTransBtn);
            this.Controls.Add(this.transformBtn);
            this.Controls.Add(this.cateTransCbx);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.prodCountSpin);
            this.Controls.Add(this.prodTransCbx);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("TransFormFrm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(416, 320);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 320);
            this.Name = "TransFormFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TransForm Products";
            ((System.ComponentModel.ISupportInitialize)(this.prodTransCbx.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prodCountSpin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cateTransCbx.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit prodTransCbx;
        private DevExpress.XtraEditors.SpinEdit prodCountSpin;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cateTransCbx;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton transformBtn;
        private DevExpress.XtraEditors.SimpleButton cancelTransBtn;
    }
}