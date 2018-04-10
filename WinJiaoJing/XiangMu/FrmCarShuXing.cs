using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinJiaoJing
{
    public partial class FrmCarShuXing : Form
    {
        public string sID = "";
        public FrmCarShuXing()
        {
            InitializeComponent();
        }

        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = " ";
            string strSql = "select * from T_BaoType";
            DataTable dt=SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            grdLeft.DataSource = dt;            
        }
      


        private void grdLeft_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            string Bao_TypeId = gridViewLeft.GetDataRow(gridViewLeft.FocusedRowHandle)["Bao_TypeId"].ToString();
            string sError = " ";
            string strSql = "select * from T_XiangMu where BaoTypeId='" + Bao_TypeId + "'  ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

            grdQx.DataSource = dt;        
        }

        private void grdLeft_Click(object sender, EventArgs e)
        {
            grdLeft_FocusedViewChanged(null, null);
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmXiangMuEdit frm = new FrmXiangMuEdit();
            frm.sID = "";         
            frm.ShowDialog();
            grdLeft_FocusedViewChanged(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmXiangMuEdit frm = new FrmXiangMuEdit(this.gridViewQx.GetDataRow(this.gridViewQx.FocusedRowHandle)["XiangMuID"].ToString());
            frm.ShowDialog();
            grdLeft_FocusedViewChanged(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM T_XiangMu WHERE XiangMuID=" + this.gridViewQx.GetDataRow(this.gridViewQx.FocusedRowHandle)["XiangMuID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if (sError.Trim() != "")
            {
                MessageBox.Show("删除失败，错误：" + sError + "！", "提示");
            }
            grdLeft_FocusedViewChanged(null, null);
        }
    }
}
