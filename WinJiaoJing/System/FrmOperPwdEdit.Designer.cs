﻿namespace WinJiaoJing
{
    partial class FrmOperPwdEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOperPwdEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolQingKong = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPwdNew = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPwdOld = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtOperID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolStripSeparator4,
            this.toolQingKong,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(238, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(71, 23);
            this.toolSave.Text = "保存(&S)";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // toolQingKong
            // 
            this.toolQingKong.Image = ((System.Drawing.Image)(resources.GetObject("toolQingKong.Image")));
            this.toolQingKong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolQingKong.Name = "toolQingKong";
            this.toolQingKong.Size = new System.Drawing.Size(74, 23);
            this.toolQingKong.Text = "清空(&Q)";
            this.toolQingKong.Click += new System.EventHandler(this.toolQingKong_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtPwdNew);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtPwdOld);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtOperID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(238, 160);
            this.groupControl1.TabIndex = 2;
            // 
            // txtPwdNew
            // 
            this.txtPwdNew.Location = new System.Drawing.Point(87, 104);
            this.txtPwdNew.Name = "txtPwdNew";
            this.txtPwdNew.Properties.PasswordChar = '*';
            this.txtPwdNew.Size = new System.Drawing.Size(122, 20);
            this.txtPwdNew.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Location = new System.Drawing.Point(26, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "新密码：";
            // 
            // txtPwdOld
            // 
            this.txtPwdOld.Location = new System.Drawing.Point(87, 73);
            this.txtPwdOld.Name = "txtPwdOld";
            this.txtPwdOld.Properties.PasswordChar = '*';
            this.txtPwdOld.Size = new System.Drawing.Size(122, 20);
            this.txtPwdOld.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl4.Location = new System.Drawing.Point(26, 77);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 16);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "原密码：";
            // 
            // txtOperID
            // 
            this.txtOperID.Enabled = false;
            this.txtOperID.Location = new System.Drawing.Point(87, 43);
            this.txtOperID.Name = "txtOperID";
            this.txtOperID.Size = new System.Drawing.Size(122, 20);
            this.txtOperID.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Location = new System.Drawing.Point(26, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用户名：";
            // 
            // FrmOperPwdEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 186);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOperPwdEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.Load += new System.EventHandler(this.FrmRoleEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwdOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolQingKong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtOperID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPwdNew;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPwdOld;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}