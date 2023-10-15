﻿namespace inventory_management.Views.Forms
{
    partial class CategoryManageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryManageFrm));
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.okBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNameCategory = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNameCategory.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.ImageOptions.Image")));
            this.cancelBtn.Location = new System.Drawing.Point(191, 114);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(101, 36);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            // 
            // okBtn
            // 
            this.okBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.Appearance.Options.UseFont = true;
            this.okBtn.AutoSize = true;
            this.okBtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.ImageOptions.Image")));
            this.okBtn.Location = new System.Drawing.Point(108, 114);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(69, 36);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 24);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Name";
            // 
            // txtNameCategory
            // 
            this.txtNameCategory.EditValue = "";
            this.txtNameCategory.Location = new System.Drawing.Point(97, 45);
            this.txtNameCategory.Name = "txtNameCategory";
            this.txtNameCategory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCategory.Properties.Appearance.Options.UseFont = true;
            this.txtNameCategory.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txtNameCategory.Properties.ContextImageOptions.Image")));
            this.txtNameCategory.Size = new System.Drawing.Size(281, 30);
            this.txtNameCategory.TabIndex = 12;
            // 
            // CategoryManageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 172);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNameCategory);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("CategoryManageFrm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(403, 242);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(403, 212);
            this.Name = "CategoryManageFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Category";
            ((System.ComponentModel.ISupportInitialize)(this.txtNameCategory.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton okBtn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNameCategory;
    }
}