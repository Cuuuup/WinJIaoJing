using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace WinJiaoJing
{
    public partial class FrmTJtop : Form
    {
        public FrmTJtop()
        {
            InitializeComponent();
        }

     

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //绑定
        public void DataBind()
        {
            string sError = "";

            DataTable dt = SqlHelper.RunQuery(CommandType.StoredProcedure, "GetGaiLv", null, out sError);
            this.grd.DataSource = dt;
        }
        //查询
        private void btnSel_Click(object sender, EventArgs e)
        {         
          
            string sError = "";
            string sCon = "";

            DataBind();
        }
        public void Init()
        {
            string sError = "";
            string strTmp = "SELECT SxMxID as TypeID,SxMxName as TypeName  FROM T_CarShuXingMx "
                        + " WHERE ShuXingName='车辆类别' Order by SortID ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strTmp, null, out sError);
            
        }
        private void FrmCarTaiZhuang_Load(object sender, EventArgs e)
        {
            Init();
           
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grd_DoubleClick(object sender, EventArgs e)
        {
            if (this.gv.FocusedRowHandle < 0)
            {
                return;
            }

           
        }

        private void btnDcExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.FileName = "中标次数统计报表" + DateTime.Now.ToString("yyyy-MM-dd") + ".xls";
            if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                grd.ExportToXls(sDialog.FileName, options);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                XtraReport report = new XtraReport();

                report.LoadLayout(Application.StartupPath + "/Print/TongJiCount.repx");
                
                report.DataSource = (DataTable)grd.DataSource;
                
                report.Parameters.Clear();
                
                DevExpress.XtraReports.Parameters.Parameter p2 = new DevExpress.XtraReports.Parameters.Parameter();
                p2.Name = "标题";
                p2.Description = "标题"; 
                p2.Value = "鉴定机构中标率统计报表  " + DateTime.Now.ToString("yyyy-MM-dd");
                report.Parameters.Add(p2);
             
                if (Program.sOperID != "admin")
                {
                    report.Print();
                }
                else
                {
                    report.ShowDesignerDialog();
                }
               

            }
            catch { }
        }
    }
}
