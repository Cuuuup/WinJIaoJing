namespace WinJiaoJing
{
    partial class FrmTJDie
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTJDie));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CO = new DevExpress.XtraEditors.GroupControl();
            this.txtT3 = new DevExpress.XtraEditors.TimeEdit();
            this.txtDateSS = new DevExpress.XtraEditors.TimeEdit();
            this.ckt = new DevExpress.XtraEditors.CheckEdit();
            this.ckd = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comDidIan = new System.Windows.Forms.ComboBox();
            this.dateEdit2 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnDcExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CO)).BeginInit();
            this.CO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtT3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateSS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.toolClose,
            this.toolStripSeparator6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1155, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolClose
            // 
            this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(55, 23);
            this.toolClose.Text = "关闭";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "关闭.jpg");
            this.imageList1.Images.SetKeyName(1, "弃审.jpg");
            this.imageList1.Images.SetKeyName(2, "删除.jpg");
            this.imageList1.Images.SetKeyName(3, "审核.jpg");
            this.imageList1.Images.SetKeyName(4, "添加.jpg");
            this.imageList1.Images.SetKeyName(5, "修改.jpg");
            // 
            // CO
            // 
            this.CO.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.CO.AppearanceCaption.Options.UseFont = true;
            this.CO.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.CO.Controls.Add(this.txtT3);
            this.CO.Controls.Add(this.txtDateSS);
            this.CO.Controls.Add(this.ckt);
            this.CO.Controls.Add(this.ckd);
            this.CO.Controls.Add(this.labelControl3);
            this.CO.Controls.Add(this.labelControl1);
            this.CO.Controls.Add(this.comDidIan);
            this.CO.Controls.Add(this.dateEdit2);
            this.CO.Controls.Add(this.labelControl5);
            this.CO.Controls.Add(this.labelControl4);
            this.CO.Controls.Add(this.dateEdit1);
            this.CO.Controls.Add(this.labelControl2);
            this.CO.Controls.Add(this.btnPrint);
            this.CO.Controls.Add(this.btnDcExcel);
            this.CO.Controls.Add(this.btnSel);
            this.CO.Dock = System.Windows.Forms.DockStyle.Top;
            this.CO.Location = new System.Drawing.Point(0, 26);
            this.CO.Name = "CO";
            this.CO.Size = new System.Drawing.Size(1155, 139);
            this.CO.TabIndex = 1;
            this.CO.Text = "查询条件";
            this.CO.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl1_Paint);
            // 
            // txtT3
            // 
            this.txtT3.EditValue = new System.DateTime(2018, 4, 19, 23, 59, 59, 0);
            this.txtT3.Enabled = false;
            this.txtT3.Location = new System.Drawing.Point(215, 103);
            this.txtT3.Name = "txtT3";
            this.txtT3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtT3.Size = new System.Drawing.Size(84, 20);
            this.txtT3.TabIndex = 69;
            // 
            // txtDateSS
            // 
            this.txtDateSS.EditValue = new System.DateTime(2018, 4, 19, 0, 0, 0, 0);
            this.txtDateSS.Enabled = false;
            this.txtDateSS.Location = new System.Drawing.Point(104, 104);
            this.txtDateSS.Name = "txtDateSS";
            this.txtDateSS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDateSS.Size = new System.Drawing.Size(84, 20);
            this.txtDateSS.TabIndex = 69;
            // 
            // ckt
            // 
            this.ckt.Location = new System.Drawing.Point(313, 107);
            this.ckt.Name = "ckt";
            this.ckt.Properties.Caption = "启用时间段搜索";
            this.ckt.Size = new System.Drawing.Size(135, 19);
            this.ckt.TabIndex = 68;
            this.ckt.CheckedChanged += new System.EventHandler(this.ckt_CheckedChanged);
            // 
            // ckd
            // 
            this.ckd.Location = new System.Drawing.Point(313, 76);
            this.ckd.Name = "ckd";
            this.ckd.Properties.Caption = "启用地点搜索";
            this.ckd.Size = new System.Drawing.Size(135, 19);
            this.ckd.TabIndex = 67;
            this.ckd.CheckedChanged += new System.EventHandler(this.ckd_CheckedChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl3.Location = new System.Drawing.Point(36, 107);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 16);
            this.labelControl3.TabIndex = 65;
            this.labelControl3.Text = "时间段：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl1.Location = new System.Drawing.Point(43, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 16);
            this.labelControl1.TabIndex = 64;
            this.labelControl1.Text = "地  点：";
            // 
            // comDidIan
            // 
            this.comDidIan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comDidIan.Enabled = false;
            this.comDidIan.FormattingEnabled = true;
            this.comDidIan.Items.AddRange(new object[] {
            "请选择"});
            this.comDidIan.Location = new System.Drawing.Point(104, 73);
            this.comDidIan.Name = "comDidIan";
            this.comDidIan.Size = new System.Drawing.Size(197, 22);
            this.comDidIan.TabIndex = 63;
            // 
            // dateEdit2
            // 
            this.dateEdit2.EditValue = null;
            this.dateEdit2.Location = new System.Drawing.Point(234, 38);
            this.dateEdit2.Name = "dateEdit2";
            this.dateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit2.Size = new System.Drawing.Size(105, 20);
            this.dateEdit2.TabIndex = 21;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl5.Location = new System.Drawing.Point(194, 107);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 16);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "至";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl4.Location = new System.Drawing.Point(213, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(15, 16);
            this.labelControl4.TabIndex = 20;
            this.labelControl4.Text = "至";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(104, 38);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(105, 20);
            this.dateEdit1.TabIndex = 19;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.labelControl2.Location = new System.Drawing.Point(21, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 16);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "搜索日期：";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(602, 36);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 25);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDcExcel
            // 
            this.btnDcExcel.Location = new System.Drawing.Point(490, 36);
            this.btnDcExcel.Name = "btnDcExcel";
            this.btnDcExcel.Size = new System.Drawing.Size(87, 25);
            this.btnDcExcel.TabIndex = 11;
            this.btnDcExcel.Text = "导出Excel";
            this.btnDcExcel.Click += new System.EventHandler(this.btnDcExcel_Click);
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(382, 36);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(87, 25);
            this.btnSel.TabIndex = 0;
            this.btnSel.Text = "查询";
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.grd);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 165);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1155, 346);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "详细信息";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grd.Location = new System.Drawing.Point(2, 23);
            this.grd.MainView = this.gv;
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(1151, 321);
            this.grd.TabIndex = 0;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            this.grd.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn24,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5});
            this.gv.GridControl = this.grd;
            this.gv.Name = "gv";
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "案件编号";
            this.gridColumn6.FieldName = "AnQingNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 84;
            // 
            // gridColumn24
            // 
            this.gridColumn24.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn24.AppearanceCell.Options.UseFont = true;
            this.gridColumn24.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn24.AppearanceHeader.Options.UseFont = true;
            this.gridColumn24.Caption = "事发地点";
            this.gridColumn24.FieldName = "AnQingDiDian";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 1;
            this.gridColumn24.Width = 144;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "案件详情";
            this.gridColumn1.FieldName = "AnQingDesc";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 784;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "案发时间";
            this.gridColumn2.FieldName = "AnQingDate";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 84;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "死亡人数";
            this.gridColumn3.FieldName = "AnQingDieCount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AnQingDieCount", "    {0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 84;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "状态";
            this.gridColumn5.FieldName = "State";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "案件编号";
            this.gridColumn4.FieldName = "DeptName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 91;
            // 
            // FrmTJDie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 511);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.CO);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 9.5F);
            this.Name = "FrmTJDie";
            this.Text = "交通事故死亡人数统计";
            this.Load += new System.EventHandler(this.FrmCarTaiZhuang_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CO)).EndInit();
            this.CO.ResumeLayout(false);
            this.CO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtT3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDateSS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private DevExpress.XtraEditors.GroupControl CO;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnSel;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnDcExcel;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.DateEdit dateEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox comDidIan;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit ckt;
        private DevExpress.XtraEditors.CheckEdit ckd;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TimeEdit txtT3;
        private DevExpress.XtraEditors.TimeEdit txtDateSS;
    }
}