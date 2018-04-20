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
    public partial class FrmDiDianEdit : Form
    {
        public string sID = "";
        public FrmDiDianEdit()
        {
            InitializeComponent();
        }

        public FrmDiDianEdit(string _ID)
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
                strSql = "SELECT * FROM T_DiZHi WHERE DiZhiID=" + sID;
                DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {               
                    this.txtOperID.Text = dt.Rows[0]["DiZhiDesc"].ToString();   
                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, OperID ;
            ID=sID;
            OperID=this.txtOperID.Text.Trim();
         


            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into T_DiZHi(");
                strSql.Append("DiZhiDesc)");
                strSql.Append(" values (");
                strSql.Append("@desc)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@desc", SqlDbType.NVarChar,50)};
                parameters[0].Value = OperID;

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
                strSql.Append("update T_DiZHi set ");
                strSql.Append("DiZhiDesc=@DiZhiDesc");
                strSql.Append(" where DiZhiID=@DiZhiID");
                SqlParameter[] parameters = {
					new SqlParameter("@DiZhiDesc", SqlDbType.VarChar,50),
					new SqlParameter("@DiZhiID", SqlDbType.BigInt,8)};
                parameters[0].Value = OperID;
                parameters[1].Value = ID;
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

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
