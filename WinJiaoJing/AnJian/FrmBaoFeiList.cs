using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinJiaoJing.AnJian;

namespace WinJiaoJing
{
    public partial class FrmBaoFeiList : Form
    {
        public FrmBaoFeiList()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmBaoFeiEdit frm = new FrmBaoFeiEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {                
                return;
            }
            //if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"])<=0) return;
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }




        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string sError = "";
            string sCon = "";
            if (this.checkEdit2.Checked == true)
            {
                sCon += "  and isOk <>0 ";
            }
            if (this.checkEdit1.Checked == true)
            {
                sCon += "  and isOk = '0' ";
            }

            if (this.txtAnQingSelect.Text.Trim() != "")
            {
                sCon += "  and AnQingNo like '%" + this.txtAnQingSelect.Text.Trim() + "%'";
            }
            if (this.dtpDateBegin.Text.Trim() != "")
            {
                sCon += "  and AnQingDate>='" + CommonInfo.CDate(this.dtpDateBegin.Text.Trim()).ToString("yyyy-MM-dd") + " 00:00:00'";
            }

            if (this.dtpDateEnd.Text.Trim() != "")
            {
                sCon += "  and AnQingDate<='" + CommonInfo.CDate(this.dtpDateEnd.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59'";
            }
            sCon += " and OperName like '" + Program.sOperName + "'";
            // sCon += "  and State in ('未报','已报','不合格') "; 
            string strSql = "select * from T_CarBaoFei where 1=1  " + sCon + " order by ID";
            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" SELECT AnQingID, AnQingNo, AnQingDiDian,");
            strSql1.Append(" AnQingDesc, DeftName, OperName, AnQingTeShuXiang, AnQingDate,AnQingDieCount,AnQingBeiZhu,isOk,AnQingTwo");
            strSql1.Append(" FROM T_AnQing");

            strSql1.Append(" WHERE 1=1" + sCon + "order by AnQingNo");




            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);
            this.grd.DataSource = dt;
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //int hand = e.RowHandle;
            //if (hand < 0) return;
            //DataRow dr = this.gv.GetDataRow(hand);
            //if (dr == null) return;
            //switch (dr["State"].ToString().Trim())
            //{
            //    case "已报":
            //        e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色                
            //        break;
            //    case "不合格":
            //        e.Appearance.ForeColor = Color.Red;// 改变行背景颜色
            //        break;
            //    case "报废中":
            //        e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色
            //        break;
            //    case "报废完结":
            //        e.Appearance.ForeColor = Color.Green;// 改变行背景颜色
            //        break;
            //}
        }

        private void xq_btn_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要查询的案件");
                return;
            }
            //if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"])<=0) return;
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要打印的案件");
                return;
            }
            FrmPrintAnQing frm = new FrmPrintAnQing(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingTwo"]));
            frm.ShowDialog();
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要修改的案件");
                return;
            }
            if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) != 0)
            {
                MessageBox.Show("案情已提交,修改请联系管理员。");
                return;
            }

            

            FrmBaoFeiEdit frm = new FrmBaoFeiEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString(), Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]));
            frm.ShowDialog();
        }

        private void tooltijiao_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要提交的案件");
                return;
            }
            if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) != 0)
            {
                MessageBox.Show("案情已提交,请勿重复操作。");
                return;
            }

            MessageBox.Show("提交后无法修改,确定要提交吗？", "提示", MessageBoxButtons.YesNo);
            string sError = "";
            string sql = "update T_AnQing set IsOk = 1 where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
            this.btnSel_Click(null, null);

        }

        private void toolTwo_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要二次鉴定的案件");
                return;
            }
            FrmTwo frm = new FrmTwo(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }
    }
}
