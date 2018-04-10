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
    public partial class FrmOperEdit : Form
    {
        public string sID = "";
        public FrmOperEdit()
        {
            InitializeComponent();
        }

        public FrmOperEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "SELECT RoleID as TypeID,RoleName as TypeName  FROM TQx_Role WHERE State='使用' Order by SortID ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbRoleID.Properties.DataSource = dt;

            strSql = "SELECT DeptID as TypeID,DeptName as TypeName  FROM TQx_Dept WHERE State='使用' Order by SortID ";
            dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            if (sID.Trim() != "")
            {
                sError = "";
                strSql = "SELECT * FROM TQx_Oper WHERE ID=" + sID;
                dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.cmbDeptID.Enabled = false;
                    this.txtOperID.Enabled = false;
                    this.txtOperID.Text = dt.Rows[0]["OperID"].ToString();
                    this.txtOperName.Text = dt.Rows[0]["OperName"].ToString();
                    this.txtOperPwd.Text = dt.Rows[0]["OperPwd"].ToString();
                    //this.txtSortID1.Text = dt.Rows[0]["SortID"].ToString();
                    this.cmbDeptID.EditValue = dt.Rows[0]["DeptID"].ToString();
                    this.cmbRoleID.EditValue = dt.Rows[0]["RoleID"].ToString();
                    this.cmbState.Text = dt.Rows[0]["State"].ToString();
                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, OperID, OperName, OperPwd, DeptID, DeptName, RoleID, RoleName, State;
            ID=sID;
            OperID=this.txtOperID.Text.Trim();
            OperName=this.txtOperName.Text.Trim();
            OperPwd=this.txtOperPwd.Text.Trim();
            DeptID=this.cmbDeptID.EditValue.ToString();
            DeptName=this.cmbDeptID.Text.Trim();
            RoleID=this.cmbRoleID.EditValue.ToString();
            RoleName = this.cmbRoleID.Text.Trim();
            State = this.cmbState.Text.Trim();

            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into TQx_Oper(");
                strSql.Append("OperID,OperName,OperPwd,DeptID,DeptName,RoleID,RoleName,State)");
                strSql.Append(" values (");
                strSql.Append("@OperID,@OperName,@OperPwd,@DeptID,@DeptName,@RoleID,@RoleName,@State)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@OperID", SqlDbType.VarChar,50),
					new SqlParameter("@OperName", SqlDbType.VarChar,50),
					new SqlParameter("@OperPwd", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.VarChar,50),
					new SqlParameter("@DeptName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50)};
                parameters[0].Value = OperID;
                parameters[1].Value = OperName;
                parameters[2].Value = OperPwd;
                parameters[3].Value = DeptID;
                parameters[4].Value = DeptName;
                parameters[5].Value = RoleID;
                parameters[6].Value = RoleName;
                parameters[7].Value = State;
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
                strSql.Append("update TQx_Oper set ");
                strSql.Append("OperName=@OperName,");
                strSql.Append("OperPwd=@OperPwd,");
                strSql.Append("DeptID=@DeptID,");
                strSql.Append("DeptName=@DeptName,");
                strSql.Append("RoleID=@RoleID,");
                strSql.Append("RoleName=@RoleName,");
                strSql.Append("State=@State");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@OperName", SqlDbType.VarChar,50),
					new SqlParameter("@OperPwd", SqlDbType.VarChar,50),
					new SqlParameter("@DeptID", SqlDbType.VarChar,50),
					new SqlParameter("@DeptName", SqlDbType.VarChar,50),
					new SqlParameter("@RoleID", SqlDbType.VarChar,50),
					new SqlParameter("@RoleName", SqlDbType.VarChar,50),
					new SqlParameter("@State", SqlDbType.VarChar,50),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
                parameters[0].Value = OperName;
                parameters[1].Value = OperPwd;
                parameters[2].Value = DeptID;
                parameters[3].Value = DeptName;
                parameters[4].Value = RoleID;
                parameters[5].Value = RoleName;
                parameters[6].Value = State;
                parameters[7].Value = ID;
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
            this.txtOperID.Enabled = true;
            this.txtOperID.Text = "";
            this.txtOperName.Text = "";
            this.txtOperPwd.Text = "";
            //this.txtSortID1.Text = "";
            this.cmbDeptID.EditValue = "";
            this.cmbRoleID.EditValue = "";
            this.cmbState.Text = "使用";
            this.cmbDeptID.Enabled = true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
