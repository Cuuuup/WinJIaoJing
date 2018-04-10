using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmDept : Form
    {
        public FrmDept()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmDeptEdit frm = new FrmDeptEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmDeptEdit frm = new FrmDeptEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM TQx_Dept WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if(sError.Trim()!="")
            {
                MessageBox.Show("删除失败，错误："+sError+"！","提示");
            }
            this.btnSel_Click(null, null);
        }

        private void toolSH_Click(object sender, EventArgs e)
        {

        }

        private void toolQS_Click(object sender, EventArgs e)
        {

        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string sError = "";
            string sCon = "";
            if(this.textEdit1.Text.Trim()!="")
            {
                sCon += "  and DeptName like '%"+this.textEdit1.Text.Trim()+"%'";
            }
            string strSql = "select * from TQx_Dept where 1=1  "+sCon+" order by ID";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.grd.DataSource = dt;
        }
    }
}
