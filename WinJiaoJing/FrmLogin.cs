using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {


            this.lookUpEdit1.EditValue = Program.sLoginDept.Trim();

            string sError = "";
            string strSql = "SELECT DeptID as TypeID,DeptName as TypeName,ErBaoTiXingDay,NianJianTiXingDay  FROM TQx_Dept WHERE State='使用' Order by SortID ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            this.cmbDeptID.Properties.DataSource = dt;
            this.cmbDeptID.EditValue = Program.sLogin;

            string strSql1 = "select DeptId as 编号,DeptName as 名称 from TQx_Dept WHERE State='使用' Order by SortID";

            DataTable dt1 = SqlHelper.RunQuery(CommandType.Text, strSql1, null, out sError);
            this.lookUpEdit1.Properties.DataSource = dt1;
            this.lookUpEdit1.EditValue = Program.sLogin;
            if (sError != "")
            {
                MessageBox.Show("获取不到服务器数据", "警告");
                return; 
            }


        }
        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            string sError = ""; 

            string sDeptID = this.lookUpEdit1.EditValue.ToString();
            string sOperID = this.lookUpEdit2.EditValue.ToString();
            string sPwd = this.txtPwd.Text.Trim();

            string strSql = "select TQx_Oper.*,TQx_Dept.ErBaoTiXingDay,TQx_Dept.NianJianTiXingDay from TQx_Oper "
                        + " left join TQx_Dept on TQx_Dept.DeptID=TQx_Oper.DeptID WHERE TQx_Oper.DeptID='" + sDeptID + "' AND  OperID='" + sOperID + "' AND OperPwd='" + sPwd + "' ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);


            if (dt != null && dt.Rows.Count > 0)
            {
                Program.sDeptID = dt.Rows[0]["DeptID"].ToString();
                Program.sDeptName = dt.Rows[0]["DeptName"].ToString();
                Program.sOperID = dt.Rows[0]["OperID"].ToString();
                Program.sOperName = dt.Rows[0]["OperName"].ToString();
                Program.sRoleID = dt.Rows[0]["RoleID"].ToString();             
                Program.SOperPwd = dt.Rows[0]["OperPwd"].ToString();

                Program.iErBaoTiXingDay = CommonInfo.CLng(dt.Rows[0]["ErBaoTiXingDay"].ToString());
                Program.iNianJianTiXingDay = CommonInfo.CLng(dt.Rows[0]["NianJianTiXingDay"].ToString());
                MessageBox.Show("欢迎【" + Program.sDeptName + "】的【" + Program.sOperName + "】您进去本系统！", "提示");
                try
                {
                    Program.UpdateConfig("LoginDept", this.lookUpEdit1.EditValue.ToString());
                }
                catch { }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                
            }
            else   
            {
                MessageBox.Show("用户名或密码错误，请重新输入！", "提示");
                return;
            }

        }
        //取消
        private void btnNO_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定退出系统吗？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                Application.Exit();
        }


        private void labelControl46_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string sError = "";
            string s = "";
            string strSql = $"select OperID as 账号,OperName as 姓名 from TQx_Oper where DeptID='{this.lookUpEdit1.EditValue.ToString()}'";

            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            if (dt == null)
            {
                MessageBox.Show("无法获取数据资料,请检查网络或服务器连接。");
                return;
            }

            this.lookUpEdit2.Properties.DataSource = dt;
            if (dt.Rows.Count > 0)
                this.lookUpEdit2.EditValue = dt.Rows[0]["账号"].ToString();
            else
                this.lookUpEdit2.EditValue = "";

        }
    }
}
