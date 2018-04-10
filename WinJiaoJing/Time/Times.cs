using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinJiaoJing.Time
{
    public partial class Times : Form
    {
        public int id;
        public Times()
        {
            InitializeComponent();
        }
        public Times(int _ID)
        {
            InitializeComponent();
            id = _ID;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            this.timer1.Enabled = false;

            string sError = "";


            if (id != 0)
            {
                string sql = $"SELECT Bao_Desc,GongSiName FROM T_GongSi g join T_BaoType t on g.BaoTypeNo=t.Bao_TypeId where GongSiId = {id}";
                SqlDataReader red = SqlHelper.ExecuteReader(CommandType.Text, sql, null, out sError);
                while (red.Read())
                {
                    MessageBox.Show(red[0] + ",中标机构：" + red[1]);
                } 
            }
            this.Close();
        }
    }
}
