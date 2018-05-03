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
    public partial class FrmDeptEdit : Form
    {
        public string sID = "";
        public FrmDeptEdit()
        {
            InitializeComponent();
        }

        public FrmDeptEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            if (sID.Trim() != "")
            {
                string sError = "";
                string strSql = "SELECT * FROM TQx_Dept WHERE ID="+sID;
                DataTable dt=SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.txtRoleID.Enabled = false;
                    this.txtRoleID.Text=dt.Rows[0]["DeptID"].ToString();
                    this.txtRoleName.Text = dt.Rows[0]["DeptName"].ToString();
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
                strSql.Append("insert into TQx_Dept(");
                strSql.Append("DeptID,DeptName,SortID,State,IsSheBeiHz)");
                strSql.Append(" values (");
                strSql.Append("@DeptID,@DeptName,@SortID,@State,@IsSheBeiHz)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@DeptID", SqlDbType.VarChar,50),
					new SqlParameter("@DeptName", SqlDbType.VarChar,50),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.VarChar,50)
               
                };
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
                strSql.Append("update TQx_Dept set ");
                strSql.Append("DeptName=@DeptName,");
                strSql.Append("SortID=@SortID,");
                strSql.Append("State=@State");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@DeptName", SqlDbType.VarChar,50),
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
            //this.checkEdit1.Checked = false;
            //this.ckbIsSheBeiHz.Checked = false;
        }

        
    }
}
