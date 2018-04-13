using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmXiangMu : Form
    {
        public FrmXiangMu()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmXiangMuEdit frm = new FrmXiangMuEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmXiangMuEdit frm = new FrmXiangMuEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["XiangMuID"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);        
            
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM T_XiangMu WHERE XiangMuID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["XiangMuID"].ToString();
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
                sCon += "  and (XiangMuNo like '%" + this.textEdit1.Text.Trim() + "%' or  XiangMuName like '%" + this.textEdit1.Text.Trim() + "%')";
            }
            if (CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) != "" && CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) !="0")
            {
                sCon += " and BaoTypeId like '" + CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) + "' ";
            }
            string strSql = "select * from T_XiangMu where 1=1  " + sCon + " order by XiangMuID";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.grd.DataSource = dt;
        }

        private void FrmOper_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "select '' as TypeID,'全选' as TypeName  union all SELECT Bao_TypeId as TypeID,Bao_Name as TypeName   FROM T_BaoType ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
       
        }
    }
}
