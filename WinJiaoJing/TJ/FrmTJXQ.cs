using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmTJXQ : Form
    {
        public string sID = "";
        public int sum = 0;
        public string ja = "";
        public FrmTJXQ()
        {
            InitializeComponent();
        }
        public FrmTJXQ(string _ID,string _ja)
        {
            sID = _ID;
            ja = _ja;
            InitializeComponent();
        }

        private void FrmAnQingXiangQingList_Load(object sender, EventArgs e)
        {

            string sError = "";
            string strSql = $"select '全部' as TypeName,-1 as TypeID union all select Bao_desc as TypeName,BaoType_Id as TypeID from T_AnQingXiang xq join T_BaoType bt on xq.BaoType_Id=bt.Bao_TypeId  where AnQingId={sID} group by baoType_Id,Bao_desc  ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            this.cmbDeptID.EditValue = -1;


        }

        private void btn_cx_Click(object sender, EventArgs e)
        {

            string sCon = "";
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 1)
            {
                sCon += "  and ax.BaoType_Id=1 ";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 2)
            {
                sCon += "  and ax.BaoType_Id=2 ";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 3)
            {
                sCon += "  and ax.BaoType_Id=3 ";
            }



            string sError = "";
            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" select AnQingXiang_ID,XiangBaoJia,AnQingId,Bao_Desc,XiangMuName,XiangMuSum,XiangMuCount,GongSiName from T_AnQingXiang ax ");
            strSql1.Append(" join T_XiangMu xm on ax.XiangMuId=xm.XiangMuID");
            strSql1.Append(" join T_BaoType bt on ax.BaoType_Id=bt.Bao_TypeId");
            strSql1.Append(" join T_GongSi gs on ax.GongSiID=gs.GongSiId");
            strSql1.Append(" where AnQingId=" + sID + sCon + " order by xm.XiangMuID");

            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);

           

            this.grd.DataSource = dt;
            this.txtBao.Text = gridColumn4.SummaryText.Trim();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string sCon = "";
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == -1)
            {
                sCon += "  set BaOSum";
            }

            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 1)
            {
                sCon += "  set BaOSumA";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 2)
            {
                sCon += "  set BaOSumB";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 3)
            {
                sCon += "  set BaOSumD";
            }


            MessageBox.Show("（请保证输入正确）确定要使用打包价吗？","提示",MessageBoxButtons.YesNo);
            string sError = "";
            string strSql = $"update T_AnQing {sCon}={this.txtBao.Text.Trim()} where AnQingNo={sID}";
          int ok=  SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if(ok>0)
                MessageBox.Show("已启用打包价。");

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            string sError = "";
            string strSql = "";

            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == -1)
            {
                strSql = $"select BaoSum from T_AnQing where AnQingNo={sID} ";
            }

            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 1)
            {
                strSql = $"select BaOSumA from T_AnQing where AnQingNo={sID} ";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 2)
            {
                strSql = $"select BaOSumB from T_AnQing where AnQingNo={sID} ";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 3)
            {
                strSql = $"select BaOSumD from T_AnQing where AnQingNo={sID} ";
            }

            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            sum = Convert.ToInt32(dt.Rows[0][0]);
            
            try
            {


                DataSet ds = new DataSet();//创建数据集

                string sql = $"select * from T_AnQing where AnQingNo={sID}";
                DataTable tb = SqlHelper.RunQuery(CommandType.Text, sql, null, out sError);
                DataTable tb2= (DataTable)grd.DataSource;

                tb.TableName = "dt1n";
                ds.Tables.Add(tb2.Copy());
                tb2.TableName = "dt2n";
                ds.Tables.Add(tb.Copy());

                XtraReport report = new XtraReport();

                report.LoadLayout(Application.StartupPath + "/Print/AnQingXX.repx");

                report.DataSource = ds;
                // report.PageHeight = 320 + 18 * dt.Rows.Count;
                //添加参数
                report.Parameters.Clear();


                DevExpress.XtraReports.Parameters.Parameter p2 = new DevExpress.XtraReports.Parameters.Parameter();
                p2.Name = "标题";
                p2.Description = "标题";

                if (CommonInfo.CLng(this.cmbDeptID.EditValue) == -1)
                {
                    p2.Value = "案情编号:" + sID + " 交通事故详情";
                }

                if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 1)
                {
                    p2.Value = "案情编号:" + sID + " 交通事故痕迹检验详情";
                }
                if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 2)
                {
                    p2.Value = "案情编号:" + sID + " 交通事故酒精检验详情";
                }
                if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 3)
                {
                    p2.Value = "案情编号:" + sID + " 交通事故尸体检验详情";
                }

                

                report.Parameters.Add(p2);


                DevExpress.XtraReports.Parameters.Parameter p3_1 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_1.Name = "统计";
                p3_1.Description = "统计";
                p3_1.Value = gridColumn4.SummaryText; ; ; ;
                report.Parameters.Add(p3_1);

                DevExpress.XtraReports.Parameters.Parameter p3_2 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_2.Name = "打包价";
                p3_2.Description = "打包价";
                if (sum==0)
                {
                    p3_2.Value = " "+gridColumn4.SummaryText;
                }
                else
                {
                    p3_2.Value = " "+sum;
                }
                
                report.Parameters.Add(p3_2);

                DevExpress.XtraReports.Parameters.Parameter p3_3 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_3.Name = "状态";
                p3_3.Description = "状态";
                p3_3.Value = ja;
                report.Parameters.Add(p3_3);



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

        private void btnDcExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sDialog = new SaveFileDialog();
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == -1)
            {
                sDialog.FileName = "编号：" + sID + "交通事故详情" + ".xls";
            }

            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 1)
            {
                sDialog.FileName = "编号：" + sID + "交通事故痕迹检验详情" + ".xls";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 2)
            {
                sDialog.FileName = "编号：" + sID + "交通事故酒精检验详情" + ".xls";
            }
            if (CommonInfo.CLng(this.cmbDeptID.EditValue) == 3)
            {
                sDialog.FileName = "编号：" + sID + "交通事故尸体检验详情" + ".xls";
            }

            if (sDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                grd.ExportToXls(sDialog.FileName, options);
                DevExpress.XtraEditors.XtraMessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmTJXQ_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
    
}
