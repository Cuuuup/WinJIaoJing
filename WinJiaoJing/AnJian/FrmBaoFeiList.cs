using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinJiaoJing.AnJian;
using WinJiaoJing.Time;


namespace WinJiaoJing
{
    public partial class FrmBaoFeiList : Form
    {


        public FrmBaoFeiList()
        {
            InitializeComponent();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            FrmBaoFeiEdit frm = new FrmBaoFeiEdit();
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                return;
            }
            //if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"])<=0) return;
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }




        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string sError = "";
            string sCon = "";
            if (this.checkEdit2.Checked == true)
            {
                sCon += "  and State ='进行中' ";
            }
            if (this.checkEdit1.Checked == true)
            {
                sCon += "  and State = '未检测' ";
            }
            if (this.checkEdit4.Checked == true)
            {
                sCon += "  and State ='作废' ";
            }
            if (this.checkEdit5.Checked == true)
            {
                sCon += "  and State ='已结算' ";
            }


            if (this.txtAnQingSelect.Text.Trim() != "")
            {
                sCon += "  and AnQingNo like '%" + this.txtAnQingSelect.Text.Trim() + "%'";
            }
            if (this.dtpDateBegin.Text.Trim() != "")
            {
                sCon += "  and AnQingDate>='" + CommonInfo.CDate(this.dtpDateBegin.Text.Trim()).ToString("yyyy-MM-dd") + " 00:00:00'";
            }

            if (this.dtpDateEnd.Text.Trim() != "")
            {
                sCon += "  and AnQingDate<='" + CommonInfo.CDate(this.dtpDateEnd.Text.Trim()).ToString("yyyy-MM-dd") + " 23:59:59'";
            }
            sCon += " and OperName like '" + Program.sOperName + "'";
            // sCon += "  and State in ('未报','已报','不合格') "; 
            string strSql = "select * from T_CarBaoFei where 1=1  " + sCon + " order by ID";
            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" SELECT AnQingID, AnQingNo, AnQingDiDian,");
            strSql1.Append(" AnQingDesc, DeftName, OperName, AnQingTeShuXiang, AnQingDate,AnQingDieCount,AnQingBeiZhu,isOk,AnQingTwo,State,insDate");
            strSql1.Append(" FROM T_AnQing");

            strSql1.Append(" WHERE 1=1 and AnQingTwo=0 " + sCon + "order by AnQingNo desc");




            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);
            this.grd.DataSource = dt;
        }



        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

            int hand = e.RowHandle;
            if (hand < 0) return;
            DataRow dr = this.gv.GetDataRow(hand);
            if (dr == null) return;

            int cha = CommonInfo.DateDiff(Convert.ToDateTime(dr["insDate"]), DateTime.Now);


            switch (dr["State"].ToString().Trim())
            {
                case "作废":
                    e.Appearance.ForeColor = Color.White;//白色字体
                    e.Appearance.BackColor = Color.DarkGray;// 灰黑背景
                    break;
                case "进行中":
                    e.Appearance.BackColor = Color.LightYellow;// 浅黄背景
                    if (cha >= 15 && cha < 20)
                    {
                        e.Appearance.ForeColor = Color.Red;//红色字体
                        e.Appearance.BackColor = Color.Yellow;// 黄背景
                    }
                    if (cha >= 20)
                    {
                        e.Appearance.ForeColor = Color.White;//白色字体
                        e.Appearance.BackColor = Color.Red;// 红背景
                    }
                    break;
                case "已结算":
                    e.Appearance.BackColor = Color.PaleGreen;// 深绿背景
                    break;
            }



        }

        private void xq_btn_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要查询的案件");
                return;
            }
            //if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"])<=0) return;
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要打印的案件");
                return;
            }
            FrmPrintAnQing frm = new FrmPrintAnQing(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingTwo"]));
            frm.ShowDialog();
        }

        private void toolUpdate_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要修改的案件");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                MessageBox.Show("案情已提交,无法修改。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("案情已结算,无法修改。");
                return;
            }

            FrmBaoFeiEdit frm = new FrmBaoFeiEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString(), this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString());
            frm.ShowDialog();
        }

        private void tooltijiao_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要提交的案件");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                MessageBox.Show("案情已提交,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("案情已结算,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "作废")
            {
                MessageBox.Show("作废案情无法提交。");
                return;
            }



            DialogResult dl = MessageBox.Show("提交后无法修改 请确认填写无误后提交 确定要提交吗？", "提示", MessageBoxButtons.YesNo);
            if (dl == DialogResult.No)
            {
                return;
            }

            string sError = "";
            string id = this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString();
            string no = this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString();
            string sql = "";
            StringBuilder strSql;
            int py, sumGS, SumCount, sum;
            py = -1;
            sumGS = 0;
            SumCount = -1;
            sum = -1;



            sql = "select BaoType_Id from T_AnQingXiang where AnQingId=" + no + "  group by BaoType_Id";

            SqlDataReader sumData = SqlHelper.ExecuteReader(CommandType.Text, sql, null, out sError);

            List<int> sumList = new List<int>();
            while (sumData.Read())
            {
                sumList.Add((int)sumData[0]);
            }
            sumData.Close();

            foreach (var item in sumList)
            {


                if (item != sum)
                {

                    strSql = new StringBuilder();
                    strSql.Append("select SUM(PyCount) from T_GongSi");
                    strSql.Append("  where BaoTypeNo=@No");
                    SqlParameter[] parametersNopy = {
                        new SqlParameter("@No", SqlDbType.Int) };
                    parametersNopy[0].Value = item;

                    SqlDataReader redpy = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersNopy, out sError);

                    while (redpy.Read())
                    {
                        //获取指定值数量
                        py = (int)redpy[0];

                    }
                    redpy.Close();


                    if (py > 0)
                    {
                        //PY流
                        strSql = new StringBuilder();
                        strSql.Append("select top 1 GongSiId from T_GongSi");
                        strSql.Append(" where BaoTypeNo=@BaoTypeID and PyCount<>0  order by newid()");
                        SqlParameter[] parameters122 = {
                               new SqlParameter("@BaoTypeID", SqlDbType.Int) };
                        parameters122[0].Value = item;

                        SqlDataReader redg = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters122, out sError);

                        while (redg.Read())
                        {
                            sumGS = (int)redg[0];

                        }
                        redg.Close();

                        strSql = new StringBuilder();
                        strSql.Append(" update T_GongSi");
                        strSql.Append(" set PyCount=PyCount-1 where GongSiId=@GongSiID");
                        SqlParameter[] parametersupup222 = {
                         new SqlParameter("@GongSiID", SqlDbType.Int) };
                        parametersupup222[0].Value = sumGS;

                        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup222, out sError);

                        strSql = new StringBuilder();
                        strSql.Append(" update T_AnQing");
                        strSql.Append(" set AnQingTwo=2 where AnQingID=@AnQingID");
                        SqlParameter[] parametersupup111 = {
                         new SqlParameter("@AnQingID", SqlDbType.Int) };
                        parametersupup111[0].Value = id;

                        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup111, out sError);


                    }
                    else
                    {
                        //摇奖流
                        strSql = new StringBuilder();
                        strSql.Append("select SUM(randomCount) from T_GongSi");
                        strSql.Append("  where BaoTypeNo=@No");
                        SqlParameter[] parametersNo = {
                        new SqlParameter("@No", SqlDbType.Int) };
                        parametersNo[0].Value = item;

                        SqlDataReader red = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersNo, out sError);

                        while (red.Read())
                        {
                            //获取奖池剩余数量
                            SumCount = (int)red[0];

                        }
                        red.Close();


                        //如果 奖池空了 补充奖池
                        if (SumCount == 0)
                        {
                            strSql = new StringBuilder();
                            strSql.Append("update T_GongSi set");
                            strSql.Append(" randomCount=randomCount+random");
                            strSql.Append(" where BaoTypeNo=@No");
                            SqlParameter[] parametersAdd = {
                                    new SqlParameter("@No", SqlDbType.Int) };
                            parametersAdd[0].Value = item;

                            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersAdd, out sError);

                            //strSql = new StringBuilder();
                            //strSql.Append(" update T_GongSi");
                            //strSql.Append(" set randomCount=randomCount-1 where GongSiId=@GongSiID");
                            //SqlParameter[] parametersupup33 = {
                            //            new SqlParameter("@GongSiID", SqlDbType.Int) };
                            //parametersupup33[0].Value = sumGS;

                            //SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup33, out sError);

                        }
                        //随机获取 一个数据
                        strSql = new StringBuilder();
                        strSql.Append("select top 1 GongSiId from T_GongSi");
                        strSql.Append(" where BaoTypeNo=@BaoTypeID and randomCount<>0  order by newid()");
                        SqlParameter[] parameters12 = {
                                    new SqlParameter("@BaoTypeID", SqlDbType.Int) };
                        parameters12[0].Value = item;
                        

                        SqlDataReader redg = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters12, out sError);

                        while (redg.Read())
                        {
                            sumGS = (int)redg[0];
                        }
                        redg.Close();


                    }

                    strSql = new StringBuilder();
                    strSql.Append(" update T_GongSi");
                    strSql.Append(" set randomCount=randomCount-1 where GongSiId=@GongSiID");
                    SqlParameter[] parametersupup = {
                             new SqlParameter("@GongSiID", SqlDbType.Int) };
                    parametersupup[0].Value = sumGS;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup, out sError);

                    strSql = new StringBuilder();
                    strSql.Append(" update T_AnQing set insDate=@insDate,");

                    if (item == 1)
                    {
                        strSql.Append(" GongSiA=@gongsi where AnQingNo=@idid");
                    }
                    if (item == 2)
                    {
                        strSql.Append(" GongSiB=@gongsi where AnQingNo=@idid");
                    }
                    if (item == 3)
                    {
                        strSql.Append(" GongSiD=@gongsi where AnQingNo=@idid");
                    }
                    SqlParameter[] parametersupupdate = {
                             new SqlParameter("@gongsi", SqlDbType.Int),
                             new SqlParameter("@idid", SqlDbType.Int),
                             new SqlParameter("@insDate", SqlDbType.DateTime)};
                    parametersupupdate[0].Value = sumGS;
                    parametersupupdate[1].Value = no;
                    parametersupupdate[2].Value = DateTime.Now;
                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupupdate, out sError);


                    strSql = new StringBuilder();
                    strSql.Append("update T_AnQingXiang");
                    strSql.Append(" set");
                    strSql.Append(" GongSiID=@GongSiID");
                    strSql.Append(" where AnQingId=@AnQingId and BaoType_Id=@BaoType");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters1 = {
                     new SqlParameter("@AnQingId", SqlDbType.Int),
                     new SqlParameter("@BaoType", SqlDbType.Int),
                     new SqlParameter("@GongSiID",SqlDbType.Int)
                    };

                    parameters1[0].Value = no;
                    parameters1[1].Value = item;
                    parameters1[2].Value = sumGS;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters1, out sError);



                    //摇奖窗体


                    Times frm = new Times(sumGS);
                    frm.ShowDialog();
                    sum = item;





                }


            }



            sql = "update T_AnQing set State = '进行中' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);


            //放到最下面
            this.btnSel_Click(null, null);
        }

        private void toolTwo_Click(object sender, EventArgs e)
        {
            string sError = "";
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                MessageBox.Show("案情已提交,无法删除,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("案情已结算,无法删除,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "作废")
            {
                MessageBox.Show("以作废,无法删除,请勿重复操作。");
                return;
            }
            DialogResult dl = MessageBox.Show("是否删除此案情？", "提示", MessageBoxButtons.YesNo);
            if (dl == DialogResult.No)
            {
                return;
            }

            string sql = "delete T_AnQingXiang where AnQingId = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString() + "'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
            sql = "delete T_AnQing where AnQingNo = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString() + "'";
            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
            this.btnSel_Click(null, null);
        }

        private void FrmBaoFeiList_Load(object sender, EventArgs e)
        {
            this.dtpDateBegin.EditValue = DateTime.Now.ToString("yyyy-MM-01");
            this.dtpDateEnd.EditValue = CommonInfo.CDate(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
        }
    }
}
