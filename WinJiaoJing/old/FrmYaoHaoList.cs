using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmYaoHaoList : Form
    {
        public FrmYaoHaoList()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmYaoHaoEdit frm = new FrmYaoHaoEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            //string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            //if (State.Trim() == "已报")
            //{
            //    return;
            //}
            //FrmYaoHaoEdit frm = new FrmYaoHaoEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString());
            //frm.ShowDialog();
            //this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //    return;
            //string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            //if (State.Trim() == "已报")
            //{
            //    return;
            //}
            //string sError = "";
            //string strSql = "DELETE FROM T_CarBaoFei WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            //SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            //if(sError.Trim()!="")
            //{
            //    MessageBox.Show("删除失败，错误："+sError+"！","提示");
            //}
            //this.btnSel_Click(null, null);
        }

        private void toolSH_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("您确定要提交吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //    return;
            //string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            //if (State.Trim() == "已报")
            //{
            //    return;
            //}
            //string sError = "";
            //string strSql = "update T_CarBaoFei set State='已报' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            //SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            //if (sError.Trim() != "")
            //{
            //    MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
            //    return;
            //}
            //this.btnSel_Click(null, null);
        }

        private void toolQS_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("您确定要审核吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            //    return;
            //string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            //if (State.Trim() != "已审")
            //{
            //    return;
            //}
            //string sError = "";
            //string strSql = "update T_CarBaoFei set State='弃审' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            //SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            //if (sError.Trim() != "")
            //{
            //    MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
            //    return;
            //}
            //this.btnSel_Click(null, null);
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            //string sError = "";
            //string sCon = "";
            //if(this.txtCarID.Text.Trim()!="")
            //{
            //    sCon += "  and CarID like '%" + this.txtCarID.Text.Trim() + "%'";
            //}
            //if(this.dtpDateBegin.Text.Trim()!="")
            //{
            //    sCon += "  and ShenQingDate>='" + CommonInfo.CDate(this.dtpDateBegin.Text.Trim()).ToString("yyyy-MM-dd") + " 00:00:00'";
            //}

            //if (this.dtpDateEnd.Text.Trim() != "")
            //{
            //    sCon += "  and ShenQingDate<='" + CommonInfo.CDate(this.dtpDateBegin.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59'";
            //}
            //sCon += " and DeptID like '"+Program.sDeptID+"'";
            //sCon += "  and State in ('未报','已报','不合格') "; 
            //string strSql = "select * from T_CarBaoFei where 1=1  " + sCon + " order by ID";
            //DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            //this.grd.DataSource = dt;
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            int hand = e.RowHandle;
            if (hand < 0) return;
            DataRow dr = this.gv.GetDataRow(hand);
            if (dr == null) return;
            switch (dr["State"].ToString().Trim())
            {
                case "已报":
                    e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色                
                    break;
                case "不合格":
                    e.Appearance.ForeColor = Color.Red;// 改变行背景颜色
                    break;
                case "报废中":
                    e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色
                    break;
                case "报废完结":
                    e.Appearance.ForeColor = Color.Green;// 改变行背景颜色
                    break;
            }
        }
    }
}
