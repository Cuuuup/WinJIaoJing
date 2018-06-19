namespace WinJiaoJing
{
    partial class FrmDeptEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeptEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolQingKong = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtSortID = new DevExpress.XtraEditors.SpinEdit();
            this.cmbState = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtRoleID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleID.Properties)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(309, 26);
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
            this.groupControl1.Controls.Add(this.txtSortID);
            this.groupControl1.Controls.Add(this.cmbState);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtRoleName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtRoleID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(309, 191);
            this.groupControl1.TabIndex = 2;
            // 
            // txtSortID
            // 
            this.txtSortID.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSortID.Location = new System.Drawing.Point(86, 104);
            this.txtSortID.Name = "txtSortID";
            this.txtSortID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSortID.Size = new System.Drawing.Size(192, 20);
            this.txtSortID.TabIndex = 2;
            // 
            // cmbState
            // 
            this.cmbState.Location = new System.Drawing.Point(86, 134);
            this.cmbState.Name = "cmbState";
            this.cmbState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbState.Properties.Items.AddRange(new object[] {
            "使用",
            "禁用"});
            this.cmbState.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbState.Size = new System.Drawing.Size(192, 20);
            this.cmbState.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl4.Location = new System.Drawing.Point(25, 134);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "状  态：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Location = new System.Drawing.Point(25, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "排序编码：";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(86, 75);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(192, 20);
            this.txtRoleName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl2.Location = new System.Drawing.Point(25, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "名  称：";
            // 
            // txtRoleID
            // 
            this.txtRoleID.Location = new System.Drawing.Point(86, 44);
            this.txtRoleID.Name = "txtRoleID";
            this.txtRoleID.Size = new System.Drawing.Size(192, 20);
            this.txtRoleID.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Location = new System.Drawing.Point(25, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "编  码：";
            // 
            // FrmDeptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 217);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeptEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "部门信息";
            this.Load += new System.EventHandler(this.FrmRoleEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSortID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleID.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtRoleID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbState;
        private DevExpress.XtraEditors.SpinEdit txtSortID;
    }
}