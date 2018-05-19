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
    public partial class FrmRoleEdit : Form
    {
        public string sID = "";
        public FrmRoleEdit()
        {
            InitializeComponent();
        }

        public FrmRoleEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            if (sID.Trim() != "")
            {
                string sError = "";
                string strSql = "SELECT * FROM TQx_Role WHERE ID="+sID;
                DataTable dt=SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.txtRoleID.Enabled = false;
                    this.txtRoleID.Text=dt.Rows[0]["RoleID"].ToString();
                    this.txtRoleName.Text = dt.Rows[0]["RoleName"].ToString();
                    this.txtSortID.Text = dt.Rows[0]["SortID"].ToString();
                    this.cmbState.Text = dt.Rows[0]["State"].ToString();

                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, RoleID, RoleName, SortID, State;
            ID=sID;
            RoleID=this.txtRoleID.Text.Trim();
            RoleName=this.txtRoleName.Text.Trim();
            SortID = CommonInfo.CLng(this.txtSortID.Text.Trim()).ToString();
            State = this.cmbState.Text.Trim();
            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into TQx_Role(");
                strSql.Append("RoleID,RoleName,SortID,State)");
                strSql.Append(" values (");
                strSql.Append("@RoleID,@RoleName,@SortID,@State)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,50)};
                parameters[0].Value = RoleID;
                parameters[1].Value = RoleName;
                parameters[2].Value = SortID;
                parameters[3].Value = State;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);
                if(sError.Trim()!="")
                {
                    MessageBox.Show("保存失败，错误："+sError, "提示");
                    return;
                }
                //清空
                this.toolQingKong_Click(null, null);
            }
            else {
                strSql = new StringBuilder();
                strSql.Append("update TQx_Role set ");
                strSql.Append("RoleName=@RoleName,");
                strSql.Append("SortID=@SortID,");
                strSql.Append("State=@State");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
                parameters[0].Value = RoleName;
                parameters[1].Value = SortID;
                parameters[2].Value = State;
                parameters[3].Value = ID;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);
                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
                this.Close();
            }

        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {
            sID = "";
            this.txtRoleID.Enabled = true;
            this.txtRoleID.Text = "";
            this.txtRoleName.Text = "";
            this.txtSortID.Text = "";
            this.cmbState.Text = "";
        }

        
    }
}
