using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinJiaoJing;

namespace WinJiaoJing
{
    public partial class FrmBao : Form
    {
        public FrmBao()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmBaoEdit frm = new FrmBaoEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmBaoEdit frm = new FrmBaoEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["Bao_TypeId"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM T_BaoType WHERE Bao_TypeId=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["Bao_TypeId"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if(sError.Trim()!="")
            {
                MessageBox.Show("删除失败，错误："+sError+"！","提示");
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
            if(this.textEdit1.Text.Trim()!="")
            {
                sCon += "  and (Bao_Name like '%" + this.textEdit1.Text.Trim() + "%' or  Bao_Desc like '%" + this.textEdit1.Text.Trim() + "%')";
            }
            string strSql = "select * from T_BaoType where 1=1  " + sCon + " order by Bao_TypeId";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.grd.DataSource = dt;
        }

        private void FrmOper_Load(object sender, EventArgs e)
        {
           
        }
    }
}
