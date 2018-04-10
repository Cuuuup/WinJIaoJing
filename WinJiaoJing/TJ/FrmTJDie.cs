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
    public partial class FrmTJDie : Form
    {
        public FrmTJDie()
        {
            InitializeComponent();
        }



        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //绑定
        public void DataBind(string sCon)
        {
            
            string sError = "";
            string strSql = "select AnQingNo,AnQingDiDian,AnQingDesc,AnQingDate,AnQingDieCount from T_AnQing  where 1=1  " + sCon + " order by AnQingNo";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

            this.grd.DataSource = dt;
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSel_Click(object sender, EventArgs e)
        {
           
            string sError = "";
            string sCon = "";
           
          
            if (CommonInfo.CObjectToStr(this.dateEdit1.EditValue).Trim() != "")
            {
                sCon += " and AnQingDate>='" + CommonInfo.CDate(this.dateEdit1.EditValue).ToString("yyyy-MM-dd") + " 00:00:00' ";
            }
            if (CommonInfo.CObjectToStr(this.dateEdit2.EditValue).Trim() != "")
            {
                sCon += " and AnQingDate<='" + CommonInfo.CDate(this.dateEdit2.EditValue).ToString("yyyy-MM-dd") + " 23:59:59' ";
            }
            DataBind(sCon);
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
            this.dateEdit1.EditValue = DateTime.Now.ToString("yyyy-MM-01");
            this.dateEdit2.EditValue = CommonInfo.CDate(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
           
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
        /// <summary>
        /// 导出表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDcExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();

            sDialog.FileName = "死亡人数统计" + CommonInfo.CObjectToStr(this.dateEdit1.EditValue).Trim() + "至" + CommonInfo.CObjectToStr(this.dateEdit2.EditValue).Trim() + ".xls";
            if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                grd.ExportToXls(sDialog.FileName, options);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
               
                XtraReport report = new XtraReport();
                report.LoadLayout(Application.StartupPath + "/Print/DieCount.repx");
                report.DataSource = (DataTable)grd.DataSource;
               
                //添加参数
                report.Parameters.Clear();
              

                DevExpress.XtraReports.Parameters.Parameter p2 = new DevExpress.XtraReports.Parameters.Parameter();
                p2.Name = "标题";
                p2.Description = "标题"; //死亡人数统计2018 - 03 - 01至2018 - 03 - 31
                p2.Value = CommonInfo.CObjectToStr(this.dateEdit1.EditValue).Trim() + "至" + CommonInfo.CObjectToStr(this.dateEdit2.EditValue).Trim() + "死亡人数统计";
                report.Parameters.Add(p2);

                DevExpress.XtraReports.Parameters.Parameter p3_5 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_5.Name = "死亡人数";
                p3_5.Description = "死亡人数";
                p3_5.Value = gridColumn3.SummaryText;
                report.Parameters.Add(p3_5);



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
