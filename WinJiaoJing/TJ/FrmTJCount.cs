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
    public partial class FrmTJCount : Form
    {
        public FrmTJCount()
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
            string strSql = " select *,(case when IsOk =3 then '已结案' else '未结案'  end) as ja  from T_AnQing where 1=1 " + sCon + " order by AnQingNo";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

            this.grd.DataSource = dt;
        }
        //查询
        private void btnSel_Click(object sender, EventArgs e)
        {

            string sError = "";
            string sCon = "";

            if (this.ck1.Checked==true)
            {
                sCon += "  and IsOk =3 ";
            }
            if (this.ck2.Checked == true)
            {
                sCon += "  and IsOk <>3 ";
            }


            if (this.textEdit1.Text.Trim() != "")
            {
                sCon += "  and AnQingNo like '%" + this.textEdit1.Text.Trim() + "%'";
            }

            if (CommonInfo.CObjectToStr(this.cmbDeptID.Text) != "")
            {
                if (this.cmbDeptID.Text=="全部")
                    sCon += " ";
                else
                    sCon += " and DeftName like '" + CommonInfo.CObjectToStr(this.cmbDeptID.Text) + "' ";
            }
           
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
 
        private void FrmCarTaiZhuang_Load(object sender, EventArgs e)
        {
            this.dateEdit1.EditValue = DateTime.Now.ToString("yyyy-MM-01");
            this.dateEdit2.EditValue = CommonInfo.CDate(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
            string sError = "";
            string strSql = "select '' as TypeID,'全部' as TypeName,-1 as SortID union all SELECT DeptID as TypeID,DeptName as TypeName,SortID   FROM TQx_Dept WHERE State='使用' Order by SortID ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            this.cmbDeptID.EditValue = Program.sDeptID;
            if (Program.sRoleID == "002")
            {
                this.cmbDeptID.Enabled = false;
            }


        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {







        }

        private void grd_DoubleClick(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {               
                return;
            }
            FrmTJXQ jxq = new FrmTJXQ(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), this.gv.GetDataRow(this.gv.FocusedRowHandle)["ja"].ToString());
            jxq.ShowDialog();
        }

        private void btnDcExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            sDialog.FileName = "交通事故案情报表" + CommonInfo.CDate(this.dateEdit1.EditValue).ToString("yyyy-MM-dd") + "至" + CommonInfo.CDate(this.dateEdit2.EditValue).ToString("yyyy-MM-dd") + ".xls";
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
            
                    report.LoadLayout(Application.StartupPath + "/Print/AnQingCount.repx");

                report.DataSource = (DataTable)grd.DataSource;            
                //添加参数
                report.Parameters.Clear();
               

                DevExpress.XtraReports.Parameters.Parameter p2 = new DevExpress.XtraReports.Parameters.Parameter();
                p2.Name = "标题";
                p2.Description = "标题";
                p2.Value = "交通事故案情报统计  " + CommonInfo.CDate(this.dateEdit1.EditValue).ToString("yyyy-MM-dd") + "至" + CommonInfo.CDate(this.dateEdit2.EditValue).ToString("yyyy-MM-dd");

                report.Parameters.Add(p2);


                DevExpress.XtraReports.Parameters.Parameter p3_1 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_1.Name = "统计";
                p3_1.Description = "统计";
                p3_1.Value = gridColumn2.SummaryText; ; ; ;
                report.Parameters.Add(p3_1);


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
        
        private void toolXiangQing_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要查询的案件");
                return;
            }
            FrmTJXQ jxq = new FrmTJXQ(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), this.gv.GetDataRow(this.gv.FocusedRowHandle)["ja"].ToString());
            jxq.ShowDialog();

        }
    }
}
