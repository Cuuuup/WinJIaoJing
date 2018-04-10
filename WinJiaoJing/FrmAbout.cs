using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //checkedComboBoxEdit1.Properties.Items.GetCheckedValues();
        }

        public void DataBind()
        {
            //string sError = "";
            //string strSql = "SELECT DeptID as TypeID,DeptName as TypeName  FROM TQx_Dept WHERE State='使用' Order by SortID ";
            //DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            //this.checkedComboBoxEdit1.Properties.DisplayMember = "TypeName";
            //this.checkedComboBoxEdit1.Properties.ValueMember = "TypeID";
            //this.checkedComboBoxEdit1.Properties.DataSource = dt;
        }

        
    }
}
