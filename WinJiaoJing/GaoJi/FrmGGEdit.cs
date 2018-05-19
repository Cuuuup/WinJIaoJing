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
    public partial class FrmGGEdit : Form
    {
        public string sID = "";
        public FrmGGEdit()
        {
            InitializeComponent();
        }

        public FrmGGEdit(string _ID)
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
                strSql = "SELECT * FROM T_gongsi WHERE GongSiId=" + sID;
                dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.txtOperID.Text = dt.Rows[0]["GongSiName"].ToString();
                    this.cmbDeptID.EditValue = dt.Rows[0]["BaoTypeNo"];
                    this.txtRandom.Text = dt.Rows[0]["random"].ToString();
                    this.txtPY.Text = dt.Rows[0]["PyCount"].ToString();
                    this.txtTow.Text = dt.Rows[0]["towRandom"].ToString();
                    this.txtTowPY.Text = dt.Rows[0]["towPyCount"].ToString(); 

                }
            }
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, GongSiName, OperName, DeptID, DeptName, random, PyCount,Tow,TowPY;
            ID=sID;
            GongSiName = this.txtOperID.Text.Trim();      
            DeptID=this.cmbDeptID.EditValue.ToString();
            DeptName=this.cmbDeptID.Text.Trim();
            random = this.txtRandom.Text.Trim();
            PyCount = this.txtPY.Text.Trim();
            Tow = this.txtTow.Text.Trim();
            TowPY = this.txtTowPY.Text.Trim();

            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into T_gongsi(");
                strSql.Append("GongSiName,BaoTypeNo,random,PyCount,towRandom,towPyCount)");
                strSql.Append(" values (");
                strSql.Append("@GongSiName,@DeptID,@random,@PyCount,@towRandom,@towPyCount)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                    new SqlParameter("@GongSiName", SqlDbType.VarChar,60),
                    new SqlParameter("@DeptID", SqlDbType.Int),
                    new SqlParameter("@random",SqlDbType.Int),
                    new SqlParameter("@PyCount",SqlDbType.Int),
                    new SqlParameter("@towRandom",SqlDbType.Int),
                    new SqlParameter("@towPyCount",SqlDbType.Int)
                };
                    
                parameters[0].Value = GongSiName;
                parameters[1].Value = DeptID;
                parameters[2].Value = random;
                parameters[3].Value = PyCount;
                parameters[4].Value = Tow;
                parameters[5].Value = TowPY;
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
                strSql.Append("update T_gongsi set ");
                strSql.Append("GongSiName=@GongSiName,");
                strSql.Append("BaoTypeNo=@BaoTypeId,");
                strSql.Append("random=@random,");
                strSql.Append("PyCount=@PyCount,");
                strSql.Append("towRandom=@towRandom,");
                strSql.Append("towPyCount=@towPyCount");
                strSql.Append(" where GongSiId=@GongSiId");
                SqlParameter[] parameters = {
					new SqlParameter("@GongSiName", SqlDbType.VarChar,50),
					new SqlParameter("@BaoTypeId", SqlDbType.Int),
                    new SqlParameter("@random",SqlDbType.Int),
                    new SqlParameter("@PyCount",SqlDbType.Int),
                    new SqlParameter("@towRandom",SqlDbType.Int),
                    new SqlParameter("@GongSiId", SqlDbType.BigInt,8),
                    new SqlParameter("@towPyCount",SqlDbType.Int)};
                parameters[0].Value = GongSiName;
                parameters[1].Value = DeptID;
                parameters[2].Value = random;
                parameters[3].Value = PyCount;
                parameters[4].Value =Tow;
                parameters[5].Value = sID;
                parameters[6].Value = TowPY;
            
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
            this.cmbDeptID.EditValue = "";         
            
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}
