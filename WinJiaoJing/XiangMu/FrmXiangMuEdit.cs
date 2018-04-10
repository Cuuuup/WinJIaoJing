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
    public partial class FrmXiangMuEdit : Form
    {
        public string sID = "";
        public FrmXiangMuEdit()
        {
            InitializeComponent();
        }

        public FrmXiangMuEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "select Bao_TypeId as TypeID,Bao_Name as TypeName from T_BaoType  Order by Bao_TypeId ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            if (sID.Trim() != "")
            {
                sError = "";
                strSql = "SELECT * FROM T_XiangMu WHERE XiangMuID=" + sID;
                dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.txtOperID.Text = dt.Rows[0]["XiangMuName"].ToString();
                    this.txtOperName.Text = dt.Rows[0]["XiangMuNo"].ToString();
                    this.txt_sum.Text= dt.Rows[0]["XiangMuMoney"].ToString();
                    this.cmbDeptID.EditValue = dt.Rows[0]["BaoTypeId"];      

                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, OperID, OperName,DeptID,DeptName,sum;
            ID=sID;
            OperID=this.txtOperID.Text.Trim();
            OperName=this.txtOperName.Text.Trim();          
            DeptID=this.cmbDeptID.EditValue.ToString();
            DeptName=this.cmbDeptID.Text.Trim();
            sum = this.txt_sum.Text.Trim();

            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into T_XiangMu(");
                strSql.Append("XiangMuNo,XiangMuName,XiangMuMoney,BaoTypeId)");
                strSql.Append(" values (");
                strSql.Append("@OperID,@OperName,@XiangMuMoney,@DeptID)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@OperID", SqlDbType.Int),
                    new SqlParameter("@OperName", SqlDbType.VarChar,50),
                    new SqlParameter("@XiangMuMoney", SqlDbType.Money),
                    new SqlParameter("@DeptID", SqlDbType.Int)};
                parameters[0].Value = OperName;
                parameters[1].Value = OperID;
                parameters[2].Value = sum;
                parameters[3].Value = DeptID;          
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
                strSql.Append("update T_XiangMu set ");
                strSql.Append("XiangMuNo=@XiangMuNo,");
                strSql.Append("XiangMuName=@XiangMuName,");
                strSql.Append("XiangMuMoney=@XiangMuMoney,");
                strSql.Append("BaoTypeId=@BaoTypeId");             
                strSql.Append(" where XiangMuID=@XiangMuID");
                SqlParameter[] parameters = {
					new SqlParameter("@XiangMuNo", SqlDbType.Int),
					new SqlParameter("@XiangMuName", SqlDbType.VarChar,50),
                    new SqlParameter("@XiangMuMoney", SqlDbType.Money),
                    new SqlParameter("@BaoTypeId", SqlDbType.Int),
					new SqlParameter("@XiangMuID", SqlDbType.BigInt,8)};
                parameters[0].Value = OperName;
                parameters[1].Value = OperID;
                parameters[2].Value = sum;
                parameters[3].Value = DeptID;
                parameters[4].Value = sID;
            
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
            this.txtOperName.Text = "";           
            this.cmbDeptID.EditValue = "";
            this.txt_sum.Text = "";      
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}
