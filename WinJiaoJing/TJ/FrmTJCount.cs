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
            string strSql = " select *  from T_AnQing  where 1=1 " + sCon + " order by AnQingNo";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

            this.grd.DataSource = dt;
        }
        //查询
        private void btnSel_Click(object sender, EventArgs e)
        {

            string sError = "";
            string sCon = "";

            if (this.ckhdy.Checked==true)
            {
                sCon += " and StateMo ='已核对'";
            }
            if (this.ckhdn.Checked==true)
            {
                sCon += " and StateMo ='未核对'";
            }

            if (this.ck1.Checked==true)
            {
                sCon += "  and State ='已结算' ";
            }
            if (this.ck2.Checked == true)
            {
                sCon += "  and State ='进行中' ";
            }
            if (this.ck3.Checked == true)
            {
                sCon += "  and State ='(二次)已结算' ";
            }
            if (this.ck4.Checked == true)
            {
                sCon += "  and State ='(二次)进行中' ";
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

            if (CommonInfo.CObjectToStr(this.cmbgs.Text) != "")
            {
                if (this.cmbgs.Text == "全部")
                    sCon += " ";
                else
                {
                    if (Convert.ToInt32(this.cmbgs.EditValue)<=3)
                    {
                        sCon += " and GongSiA = '" + Convert.ToInt32(this.cmbgs.EditValue) + "' ";
                    }
                    if (Convert.ToInt32(this.cmbgs.EditValue) > 3 && Convert.ToInt32(this.cmbgs.EditValue)<=6)
                    {
                        sCon += " and GongSiB = '" + Convert.ToInt32(this.cmbgs.EditValue) + "' ";
                    }
                    if (Convert.ToInt32(this.cmbgs.EditValue) > 6 && Convert.ToInt32(this.cmbgs.EditValue) <= 9)
                    {
                        sCon += " and GongSiD = '" + Convert.ToInt32(this.cmbgs.EditValue) + "' ";
                    }

                }
                    
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

            strSql = "select '全部' as TypeName,-1 as TypeID union all select '('+bt.Bao_Name+')'+GongSiName as TypeName ,GongSiId as TypeID from T_GongSi gs join T_BaoType bt on gs.BaoTypeNo=bt.Bao_TypeId  where GongSiId<>0 ";
            DataTable dt1 = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbgs.Properties.DataSource = dt1;
            this.cmbgs.EditValue = -1;
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
            FrmTJXQ jxq = new FrmTJXQ(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString());
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

                DevExpress.XtraReports.Parameters.Parameter p3_2 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_2.Name = "A统计";
                p3_2.Description = "A统计";
                p3_2.Value = " " + gridColumn5.SummaryText; 
                report.Parameters.Add(p3_2);
                DevExpress.XtraReports.Parameters.Parameter p3_3 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_3.Name = "B统计";
                p3_3.Description = "B统计";
                p3_3.Value = " " + gridColumn7.SummaryText;
                report.Parameters.Add(p3_3);
                DevExpress.XtraReports.Parameters.Parameter p3_4 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_4.Name = "D统计";
                p3_4.Description = "D统计";
                p3_4.Value = " " + gridColumn8.SummaryText;
                report.Parameters.Add(p3_4);
                DevExpress.XtraReports.Parameters.Parameter p3_5 = new DevExpress.XtraReports.Parameters.Parameter();
                p3_5.Name = "S统计";
                p3_5.Description = "S统计";
                p3_5.Value = " "+gridColumn9.SummaryText;
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

        private void toolJieSuan_Click(object sender, EventArgs e)
        {
            string sql = "";
            string sError = "";
            if (Program.sRoleID!="001")
            {
                MessageBox.Show("只有支队管理员及以上权限才可操作此项。");
                return;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() != "已结算" && this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() != "(二次)已结算")
            {
                MessageBox.Show("确认核对前请先归档案情。");
                return;
            }


            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["StateMo"].ToString() == "已核对")
            {
                MessageBox.Show("该项已结算核对。");
               
                return;
            }
            DialogResult dr = MessageBox.Show("确认核对信息是否正确，确认无误请点击确定。", "提示", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["StateMo"].ToString() == "未核对")
            {
                sql = "update T_AnQing set StateMo = '已核对' where AnQingNo = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                this.btnSel_Click(null, null);
                return;
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sql = "";
            string sError = "";
            if (Program.sRoleID != "001")
            {
                MessageBox.Show("只有支队管理员及以上权限才可操作此项。");
                return;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["StateMo"].ToString() == "未核对")
            {
                MessageBox.Show("该项还未结算核对。");

                return;
            }
            DialogResult dr = MessageBox.Show("确认核对信息是否正确，确认无误请点击确定。", "提示", MessageBoxButtons.YesNo);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["StateMo"].ToString() == "已核对")
            {
                sql = "update T_AnQing set StateMo = '未核对' where AnQingNo = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                this.btnSel_Click(null, null);
                return;
            }
        }
    }
}
