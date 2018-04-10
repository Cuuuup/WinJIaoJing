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
    public partial class FrmRoleQxEdit : Form
    {
        public string sID = "";
        public FrmRoleQxEdit()
        {
            InitializeComponent();
        }

        public FrmRoleQxEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = " ";
            string strSql = "SELECT * FROM TQx_Role WHERE State='使用'  ";
            DataTable dt=SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            grdLeft.DataSource = dt;            
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            grdLeft.Focus();
            string sError = "";
            string ID, RoleID, MenuID, MenuName, IsQx;
            ID=sID;
            RoleID=gridViewLeft.GetDataRow(gridViewLeft.FocusedRowHandle)["RoleID"].ToString();
            string strDel = "DELETE FROM TQx_RoleQx WHERE RoleID='"+RoleID+"'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, strDel, null, out sError);

            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i<gridViewQx.DataRowCount;i++ )
            {
                MenuID = gridViewQx.GetDataRow(i)["MenuID"].ToString();
                MenuName = gridViewQx.GetDataRow(i)["MenuName"].ToString();
                IsQx = gridViewQx.GetDataRow(i)["IsQx"].ToString();
                strSql = new StringBuilder();
                strSql.Append("insert into TQx_RoleQx(");
                strSql.Append("RoleID,MenuID,MenuName,IsQx)");
                strSql.Append(" values (");
                strSql.Append("@RoleID,@MenuID,@MenuName,@IsQx)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@MenuID", SqlDbType.VarChar,50),
					new SqlParameter("@MenuName", SqlDbType.VarChar,50),
					new SqlParameter("@IsQx", SqlDbType.Bit,1)};
                parameters[0].Value = RoleID;
                parameters[1].Value = MenuID;
                parameters[2].Value = MenuName;
                parameters[3].Value = IsQx;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);
                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
            }
            MessageBox.Show("保存成功！", "提示");
        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {
            FrmRoleEdit_Load(null, null);
        }

        private void grdLeft_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {
            string sError = " ";
            string strSql = "SELECT cast(0 AS bit)  AS IsQx,* FROM TQx_Menu WHERE State='使用' order by MenuID  ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

            string sRoleID=gridViewLeft.GetDataRow(gridViewLeft.FocusedRowHandle)["RoleID"].ToString();
            strSql = "SELECT * FROM TQx_RoleQx WHERE RoleID='"+sRoleID+"' ";
            DataTable dtQx = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            for (int i = 0;i<dt.Rows.Count ;i++ )
            {
                try
                {
                    DataView dv = dtQx.DefaultView;
                    dv.RowFilter = " MenuID='" + dt.Rows[i]["MenuID"].ToString() + "'";
                    dt.Rows[i]["IsQx"] = CommonInfo.CBoolean(dv.ToTable().Rows[0]["IsQx"].ToString());
                }
                catch { }
            }
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
    }
}
