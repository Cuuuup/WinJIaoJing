namespace WinJiaoJing
{
    partial class FrmAnQingXiangQingList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnQingXiangQingList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
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
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.grd);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(826, 498);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "详细信息";
            // 
            // grd
            // 
            this.grd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grd.Location = new System.Drawing.Point(2, 23);
            this.grd.MainView = this.gv;
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.grd.Size = new System.Drawing.Size(822, 473);
            this.grd.TabIndex = 0;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn2,
            this.gridColumn17,
            this.gridColumn3,
            this.gridColumn4});
            this.gv.GridControl = this.grd;
            this.gv.Name = "gv";
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_RowStyle);
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "案件编号";
            this.gridColumn5.FieldName = "AnQingId";
            this.gridColumn5.MinWidth = 14;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 74;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "中标公司";
            this.gridColumn6.FieldName = "GongSiName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 344;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "检验类型";
            this.gridColumn2.ColumnEdit = this.repositoryItemDateEdit1;
            this.gridColumn2.FieldName = "Bao_Desc";
            this.gridColumn2.MinWidth = 64;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 94;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.Caption = "鉴定项目";
            this.gridColumn17.FieldName = "XiangMuName";
            this.gridColumn17.MinWidth = 84;
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            this.gridColumn17.Width = 144;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "项目编号";
            this.gridColumn3.FieldName = "XiangMuNo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 74;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "中包价格";
            this.gridColumn4.FieldName = "XiangBaoJia";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 74;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "流水号";
            this.gridColumn1.FieldName = "AnQingXiang_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(715, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "价格总计:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(780, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // FrmAnQingXiangQingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 498);
            this.Controls.Add(this.groupControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmAnQingXiangQingList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "案件详情";
            this.Load += new System.EventHandler(this.FrmAnQingXiangQingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}