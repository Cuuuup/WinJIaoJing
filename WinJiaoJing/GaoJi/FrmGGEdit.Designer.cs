namespace WinJiaoJing
{
    partial class FrmGGEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGGEdit));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtTow = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeptID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtTowPY = new DevExpress.XtraEditors.TextEdit();
            this.txtPY = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtRandom = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtOperID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeptID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowPY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPY.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolStripSeparator4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(543, 26);
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
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtTow);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.cmbDeptID);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtTowPY);
            this.groupControl1.Controls.Add(this.txtPY);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtRandom);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtOperID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 26);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(543, 355);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtTow
            // 
            this.txtTow.Location = new System.Drawing.Point(159, 193);
            this.txtTow.Name = "txtTow";
            this.txtTow.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTow.Size = new System.Drawing.Size(175, 20);
            this.txtTow.TabIndex = 16;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl4.Location = new System.Drawing.Point(38, 197);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(115, 16);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "(二次)奖池数量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "*填写中奖数 每次消耗1次，归0后恢复正常";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 14);
            this.label2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "*设定此鉴定机构在每一轮随机的种子数";
            // 
            // cmbDeptID
            // 
            this.cmbDeptID.EditValue = "";
            this.cmbDeptID.Location = new System.Drawing.Point(159, 46);
            this.cmbDeptID.Name = "cmbDeptID";
            this.cmbDeptID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDeptID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeID", "编码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "名称")});
            this.cmbDeptID.Properties.DisplayMember = "TypeName";
            this.cmbDeptID.Properties.ValueMember = "TypeID";
            this.cmbDeptID.Size = new System.Drawing.Size(175, 20);
            this.cmbDeptID.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl7.Location = new System.Drawing.Point(93, 48);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(60, 16);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "包类型：";
            // 
            // txtTowPY
            // 
            this.txtTowPY.Location = new System.Drawing.Point(159, 291);
            this.txtTowPY.Name = "txtTowPY";
            this.txtTowPY.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTowPY.Size = new System.Drawing.Size(175, 20);
            this.txtTowPY.TabIndex = 0;
            // 
            // txtPY
            // 
            this.txtPY.Location = new System.Drawing.Point(159, 242);
            this.txtPY.Name = "txtPY";
            this.txtPY.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPY.Size = new System.Drawing.Size(175, 20);
            this.txtPY.TabIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl5.Location = new System.Drawing.Point(38, 293);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(115, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "(二次)指定次数：";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Location = new System.Drawing.Point(78, 244);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "指定次数：";
            // 
            // txtRandom
            // 
            this.txtRandom.Location = new System.Drawing.Point(159, 144);
            this.txtRandom.Name = "txtRandom";
            this.txtRandom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRandom.Size = new System.Drawing.Size(175, 20);
            this.txtRandom.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl2.Location = new System.Drawing.Point(78, 148);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "奖池数量：";
            // 
            // txtOperID
            // 
            this.txtOperID.Location = new System.Drawing.Point(159, 95);
            this.txtOperID.Name = "txtOperID";
            this.txtOperID.Size = new System.Drawing.Size(359, 20);
            this.txtOperID.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Location = new System.Drawing.Point(78, 97);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "公司名称：";
            // 
            // FrmGGEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 381);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGGEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "高级鉴定机构信息";
            this.Load += new System.EventHandler(this.FrmRoleEdit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDeptID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTowPY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPY.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRandom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.TextEdit txtOperID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cmbDeptID;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtRandom;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtPY;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtTow;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTowPY;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}