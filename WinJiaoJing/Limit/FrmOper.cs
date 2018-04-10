using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmOper : Form
    {
        public FrmOper()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmOperEdit frm = new FrmOperEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmOperEdit frm = new FrmOperEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM TQx_Oper WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
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
                sCon += "  and (OperID like '%" + this.textEdit1.Text.Trim() + "%' or  OperName like '%" + this.textEdit1.Text.Trim() + "%')";
            }
            if (CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) != "")
            {
                sCon += " and DeptID like '" + CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) + "' ";
            }
            string strSql = "select * from TQx_Oper where 1=1  "+sCon+" order by ID";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.grd.DataSource = dt;
        }

        private void FrmOper_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "select '' as TypeID,'' as TypeName,-1 as SortID union all SELECT DeptID as TypeID,DeptName as TypeName,SortID   FROM TQx_Dept WHERE State='使用' Order by SortID ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            //this.cmbDeptID.EditValue = Program.sDeptID;
            //if (CommonInfo.CObjectToStr(this.cmbDeptID.EditValue) != "JJZD")
            //{
            //    this.cmbDeptID.Enabled = false;
            //}
        }
    }
}
