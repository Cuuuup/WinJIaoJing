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
    public partial class FrmAnQing : Form
    {
        public FrmAnQing()
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
                MessageBox.Show("请选中要修改的案件");
                return;
            }
            if (Program.sOperID.Trim() != "admin")
            {
                if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) == 3)
                {
                    MessageBox.Show("案情已归档,无法修改,如果有需要请联系超级管理员");
                    return;
                }
            }

            FrmBaoFeiEdit frm = new FrmBaoFeiEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要删除的案件");
                return;
            }
            if (Program.sOperID.Trim() != "admin")
            {
                if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) == 3)
                {
                    MessageBox.Show("案情已归档,无法修改,如果有需要请联系超级管理员");
                    return;
                }
            }


            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;


            string sError = "";
            string strSql = "DELETE FROM T_AnQingXiang WHERE AnQingId=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString();
            string strSql1 = "DELETE FROM T_AnQing WHERE AnQingNo=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql1, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("删除失败，错误：" + sError + "！", "提示");
                return;
            }
            this.btnSel_Click(null, null);
        }

        private void toolSH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要提交吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            if (State.Trim() == "已报")
            {
                return;
            }
            string sError = "";
            string strSql = "update T_CarBaoFei set State='已报' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
                return;
            }
            this.btnSel_Click(null, null);
        }

        private void toolQS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要审核吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            if (State.Trim() != "已审")
            {
                return;
            }
            string sError = "";
            string strSql = "update T_CarBaoFei set State='弃审' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
                return;
            }
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
            if (Program.sOperID.Trim() != "admin")
            {
                if (Program.sRoleID == "002")
                    sCon += " and DeftName='" + Program.sDeptName + "' ";
            }

            if (this.checkEdit2.Checked == true)
            {
                sCon += "  and isOk <>3 ";
            }
            if (this.checkEdit3.Checked == true)
            {
                sCon += "  and isOk = 3 ";
            }

            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" SELECT AnQingID, AnQingNo, AnQingDiDian,");
            strSql1.Append(" AnQingDesc, DeftName, OperName, AnQingTeShuXiang, AnQingDate,AnQingDieCount,AnQingBeiZhu,isOk,AnQingTwo");
            strSql1.Append(" FROM T_AnQing");

            strSql1.Append(" WHERE 1=1" + sCon + "order by AnQingNo");




            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);
            this.Grd.DataSource = dt;
        }



        private void xq_btn_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要查询的案件");
                return;
            }
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }

        private void toolPint_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要打印的案件");
                return;
            }
            FrmPrintAnQing frm = new FrmPrintAnQing(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingTwo"]));
            frm.ShowDialog();
        }

        private void FrmAnQing_Load(object sender, EventArgs e)
        {

        }

        private void toolGuiDang_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要归档的案件");
                return;
            }
            //MessageBox.Show(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) == 3)
            {
                MessageBox.Show("案情已归档,请勿重复操作。");
                return;
            }

            MessageBox.Show("归档后无法修改,确定要提交吗？", "提示", MessageBoxButtons.YesNo);
            string sError = "";
            string sql = "update T_AnQing set IsOk = 3 where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
            this.btnSel_Click(null, null);

        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                return;
            }
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }
    }
}
