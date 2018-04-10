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
    public partial class FrmOperPwdEdit : Form
    {
        public string sID = "";
        public FrmOperPwdEdit()
        {
            InitializeComponent();
        }

        public FrmOperPwdEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            this.txtOperID.Text = Program.sOperID;           
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            string sError = "";
            string ID, sOperID, sPwdOld, sPwdNew;
            ID=sID;
            sOperID=this.txtOperID.Text.Trim();
            sPwdOld = this.txtPwdOld.Text.Trim();
            sPwdNew = this.txtPwdNew.Text.Trim();
            if(Program.SOperPwd != sPwdOld)
            {
                MessageBox.Show("原密码错误，请重新输入！","提示");
                this.txtPwdOld.Focus();
                return;
            }
            string strSql = "UPDATE TQx_Oper SET OperPwd='" + sPwdNew + "' WHERE OperID='" + sOperID + "' AND OperPwd='" + sPwdOld + "'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            if (sError.Trim() != "")
            {
                MessageBox.Show("保存失败，错误：" + sError, "提示");
                return;
            }else{
                Program.SOperPwd = this.txtPwdNew.Text.Trim();
                MessageBox.Show("保存成功！" + sError, "提示");
            }
            

        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {
            //sID = "";
            //this.txtOperID.Enabled = true;
            //this.txtOperID.Text = "";
            //this.txtRoleName.Text = "";
            //this.txtSortID.Text = "";
            //this.cmbState.Text = "";
        }

        
    }
}
