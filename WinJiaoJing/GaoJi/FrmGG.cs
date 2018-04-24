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
    public partial class FrmGG : Form
    {
        public string sID = "";
        public FrmGG()
        {
            InitializeComponent();
        }

        public FrmGG(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = " ";
            string strSql = "select * from T_BaoType";
            DataTable dt=SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            grdLeft.DataSource = dt;            
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            grdLeft.Focus();
            string sError = "";
            string ID, XiangMuID;
            ID=sID;
            XiangMuID = gridViewLeft.GetDataRow(gridViewLeft.FocusedRowHandle)["GongSiId"].ToString();
            
            string strDel = "DELETE FROM T_gongsi WHERE GongSiId='" + XiangMuID + "'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, strDel, null, out sError);

                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
            
            MessageBox.Show("保存成功！", "提示");
        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {
            FrmRoleEdit_Load(null, null);
        }

        private void grdLeft_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            string Bao_TypeId = gridViewLeft.GetDataRow(gridViewLeft.FocusedRowHandle)["Bao_TypeId"].ToString();
            string sError = " ";
            string strSql = "select * from T_gongsi where BaoTypeNo='" + Bao_TypeId + "'  ";
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
            FrmGGEdit frm = new FrmGGEdit();
            frm.sID = "";            
            frm.ShowDialog();
            grdLeft_FocusedViewChanged(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            FrmGGEdit frm = new FrmGGEdit(this.gridViewQx.GetDataRow(this.gridViewQx.FocusedRowHandle)["GongSiId"].ToString());
            frm.ShowDialog();
            grdLeft_FocusedViewChanged(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string sError = "";
            string strSql = "DELETE FROM T_gongsi WHERE GongSiId=" + this.gridViewQx.GetDataRow(this.gridViewQx.FocusedRowHandle)["GongSiId"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if (sError.Trim() != "")
            {
                MessageBox.Show("删除失败，错误：" + sError + "！", "提示");
            }
            grdLeft_FocusedViewChanged(null, null);
        }
    }
}
