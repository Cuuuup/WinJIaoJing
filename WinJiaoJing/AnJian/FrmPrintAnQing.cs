using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;

namespace WinJiaoJing.AnJian
{
    public partial class FrmPrintAnQing : Form
    {
        public string ID;
        public int TYPEID;
        public FrmPrintAnQing()
        {
            InitializeComponent();
        }
        public FrmPrintAnQing(string _ID,int _typeid)
        {
            InitializeComponent();
            ID = _ID;
            TYPEID = _typeid;

        }

        private void FrmPrintAnQing_Load(object sender, EventArgs e)
        {
            string sqlError = "";
            string sql = $"select BaoType_Id from T_AnQingXiang where AnQingId={ID} group by BaoType_Id";

            SqlDataReader red = SqlHelper.ExecuteReader(CommandType.Text, sql, null, out sqlError);
            
            while (red.Read())
            {
                if ((int)red[0] == 1)
                {
                    this.ckA.Enabled = true;
                    this.ckA.Checked = true;
                }
                if ((int)red[0] == 2) 
                {
                    this.ckB.Enabled = true;
                    this.ckB.Checked = true;
                }
                if ((int)red[0] == 3)
                {
                    this.ckD.Enabled = true;
                    this.ckD.Checked = true;
                }
                
            }
            red.Close();


        }


        public void Print(int id)
        {
            DataSet ds = new DataSet();//创建数据集

            //ds.Clear();

            string sqlError = "";
            string sql = $"select * from T_AnQing where AnQingNo={ID}";
            DataTable tb= SqlHelper.RunQuery(CommandType.Text, sql, null, out sqlError);

            sql = $"SELECT GongSiName,Bao_Name FROM T_AnQingXiang x join T_GongSi g on x.GongSiID=g.GongSiId join T_BaoType t on x.BaoType_Id=t.Bao_TypeId where AnQingId={ID} and BaoType_Id ={id}";
            DataTable tb2 = SqlHelper.RunQuery(CommandType.Text, sql, null, out sqlError);

            sql = $"select stuff((SELECT '，' + XiangMuName FROM T_AnQingXiang x JOIN T_XiangMu m ON x.XiangMuId = m.XiangMuNo where x.AnQingId = {ID} and x.BaoType_Id = {id} GROUP BY XiangMuName FOR XML path('')), 1, 1, '')";

            DataTable tb3 = SqlHelper.RunQuery(CommandType.Text, sql, null, out sqlError);

            tb.TableName = "dt1n";
            ds.Tables.Add(tb.Copy());
            tb2.TableName = "dt2n";
            ds.Tables.Add(tb2.Copy());
            tb3.TableName = "dt3n";
            ds.Tables.Add(tb3.Copy());


            XtraReport report = new XtraReport();

            if (TYPEID == 1)
            {
               
                if (id == 1)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/RE_AnQingJD.repx");
                }
                if (id == 2)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/RE_AnQingJDB.repx");
                }
                if (id == 3)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/RE_AnQingJDD.repx");
                }
            }
            else
            {
                if (id==1)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/AnQingJD.repx");
                }
                if (id == 2)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/AnQingJDB.repx");
                }
                if (id == 3)
                {
                    report.LoadLayout(Application.StartupPath + "/Print/AnQingJDD.repx");
                }
                
            }
            
            
            report.DataSource = ds;


            if (Program.sOperID != "admin")
            {
                report.Print();
            }
            else
            {
                report.ShowDesignerDialog();
            }
          
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            
            if (this.ckA.Checked == true)
            {
                Print(1);
            }
            if (this.ckB.Checked == true)
            {
                Print(2);
            }
            if (this.ckD.Checked == true)
            {
                Print(3);
            }

        }
    }
}
