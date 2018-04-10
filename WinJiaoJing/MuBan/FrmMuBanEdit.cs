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
    public partial class FrmMuBanEdit : Form
    {
        public string sID = "";
        public FrmMuBanEdit()
        {
            InitializeComponent();
        }

        public FrmMuBanEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "";

            if (sID.Trim() != "")
            {
                sError = "";
                strSql = "SELECT * FROM T_MuBan WHERE MuBanId=" + sID;
                DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {               
                    this.txtOperID.Text = dt.Rows[0]["MuBanName"].ToString();  
                    this.txtOperPwd.Text = dt.Rows[0]["MuBanDesc"].ToString();
                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, OperID, OperPwd ;
            ID=sID;
            OperID=this.txtOperID.Text.Trim();
            OperPwd=this.txtOperPwd.Text.Trim();


            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into T_MuBan(");
                strSql.Append("MuBanName,MuBanDesc)");
                strSql.Append(" values (");
                strSql.Append("@MuBanName,@MuBanDesc)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@MuBanName", SqlDbType.VarChar,50),
					new SqlParameter("@MuBanDesc", SqlDbType.NVarChar,3000)};
                parameters[0].Value = OperID;
                parameters[1].Value = OperPwd;

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
                strSql.Append("update T_MuBan set ");
                strSql.Append("MuBanName=@MuBanName,");
                strSql.Append("MuBanDesc=@MuBanDesc");
                strSql.Append(" where MuBanId=@MuBanId");
                SqlParameter[] parameters = {
					new SqlParameter("@MuBanName", SqlDbType.VarChar,50),
					new SqlParameter("@MuBanDesc",SqlDbType.NVarChar,3000),
					new SqlParameter("@MuBanId", SqlDbType.BigInt,8)};
                parameters[0].Value = OperID;
                parameters[1].Value = OperPwd;
                parameters[2].Value = ID;
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
            this.txtOperID.Text = "";
            this.txtOperPwd.Text = "";

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
