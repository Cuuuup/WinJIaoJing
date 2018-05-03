using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using System.Xml;

namespace WinJiaoJing
{
    static class Program
    {
        public static string sOperID = "";
        public static string sOperName = "";
        public static string SOperPwd = "";
        public static string sDeptID = "";
        public static string sDeptName = ""; 
        public static string sRoleID = "";
        public static int iErBaoTiXingDay = 1;
        public static int iNianJianTiXingDay = 1;
        public static DataTable dtQx;
        public static string sVersion = "V2018.4.20";

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmLogin frm = new FrmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (sOperName == "高级用户")
                {
                    Application.Run(new FrmMain1());
                }
                else
                {
                    Application.Run(new FrmMain());
                }

            }
            else {
                Application.Exit();
            }
        }

        //加载下拉框
        public static void LoadCmb(LookUpEdit cmb, string sValueMember, string sDisplayMember, string strSql)
        {
            string sError = ""; 
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            cmb.Properties.ValueMember = sValueMember;
            cmb.Properties.DisplayMember = sDisplayMember;
            cmb.Properties.DataSource = dt;
        }

        public static Boolean IsQx(string sMenuID)
        {
            if(Program.sOperID.Trim()=="admin")
            {
                return true;
            }
            try
            {
                DataView dv = dtQx.DefaultView;
                dv.RowFilter = " MenuID='" + sMenuID + "'";
                if (CommonInfo.CBoolean(dv.ToTable().Rows[0]["IsQx"].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public static string sLoginDept = System.Configuration.ConfigurationSettings.AppSettings["LoginDept"];
        /// <summary>
        /// 更新配置文件信息
        /// </summary>
        /// <param name="name">配置文件字段名称</param>
        /// <param name="Xvalue">值</param>
        public static void UpdateConfig(string name, string Xvalue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + name + "']");
            XmlElement ele = (XmlElement)node;
            ele.SetAttribute("value", Xvalue);
            doc.Save(Application.ExecutablePath + ".config");
        }
    }
}
