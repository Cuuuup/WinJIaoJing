using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmAnQingXiangQingList : Form
    {
        public string sID = "";
        public FrmAnQingXiangQingList()
        {
            InitializeComponent();
        }
        public FrmAnQingXiangQingList(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }

      
       

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //int hand = e.RowHandle;
            //if (hand < 0) return;
            //DataRow dr = this.gv.GetDataRow(hand);
            //if (dr == null) return;
            //switch (dr["State"].ToString().Trim())
            //{
            //    case "已报":
            //        e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色                
            //        break;
            //    case "不合格":
            //        e.Appearance.ForeColor = Color.Red;// 改变行背景颜色
            //        break;
            //    case "报废中":
            //        e.Appearance.ForeColor = Color.Yellow;// 改变行背景颜色
            //        break;
            //    case "报废完结":
            //        e.Appearance.ForeColor = Color.Green;// 改变行背景颜色
            //        break;
            //}
        }

        private void FrmAnQingXiangQingList_Load(object sender, EventArgs e)
        {

            //MessageBox.Show(sID);
            //return; 
            string sError = "";
            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" select AnQingXiang_ID,AnQingId,XiangMuNo,Bao_Desc,XiangMuName,XiangBaoJia,GongSiName from T_AnQingXiang ax ");
            strSql1.Append(" join T_XiangMu xm on ax.XiangMuId=xm.XiangMuID");
            strSql1.Append(" join T_BaoType bt on ax.BaoType_Id=bt.Bao_TypeId");
            strSql1.Append(" join T_GongSi gs on ax.GongSiID=gs.GongSiId");
            strSql1.Append(" where AnQingId=" + sID + " order by xm.XiangMuID");


           
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);
            this.grd.DataSource = dt;
          //  grd.RefreshDataSource();
        }
    }
}
