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
    public partial class FrmAnQing : Form
    {
        public FrmAnQing()
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
                MessageBox.Show("请选中要修改的案件");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("鉴定项已归档,无法修改。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)已结算")
            {
                MessageBox.Show("鉴定项已归档,无法修改。");
                return;
            }
            //if (Program.sOperID.Trim() != "admin")
            //{
            //    if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) == 3)
            //    {
            //        MessageBox.Show("案情已归档,无法修改,如果有需要请联系超级管理员");
            //        return;
            //    }
            //}

            FrmBaoFeiEdit frm = new FrmBaoFeiEdit(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString(), this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString());
            frm.ShowDialog();
            this.btnSel_Click(null, null);
        }

        private void toolDel_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要删除的案件");
                return;
            }
            if (Program.sOperID.Trim() != "admin")
            {
                if (Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["isOk"]) == 3)
                {
                    MessageBox.Show("案情已归档,无法修改,如果有需要请联系超级管理员");
                    return;
                }
            }


            if (MessageBox.Show("您确定要删除吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;


            string sError = "";
            string strSql = "DELETE FROM T_AnQingXiang WHERE AnQingId=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString();
            string strSql1 = "DELETE FROM T_AnQing WHERE AnQingID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql1, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("删除失败，错误：" + sError + "！", "提示");
                return;
            }
            this.btnSel_Click(null, null);
        }

        private void toolSH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要提交吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            if (State.Trim() == "已报")
            {
                return;
            }
            string sError = "";
            string strSql = "update T_CarBaoFei set State='已报' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
                return;
            }
            this.btnSel_Click(null, null);
        }

        private void toolQS_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要审核吗？", "提示", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                return;
            string State = this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString();
            if (State.Trim() != "已审")
            {
                return;
            }
            string sError = "";
            string strSql = "update T_CarBaoFei set State='弃审' WHERE ID=" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["ID"].ToString();
            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql, null, out sError);

            if (sError.Trim() != "")
            {
                MessageBox.Show("审核失败，错误：" + sError + "！", "提示");
                return;
            }
            this.btnSel_Click(null, null);
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                case "(二次)作废":
                    e.Appearance.ForeColor = Color.White;//白色字体
                    e.Appearance.BackColor = Color.DarkGray;// 灰黑背景
                    break;
                case "(二次)进行中":
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
                case "(二次)已结算":
                    e.Appearance.BackColor = Color.PaleGreen;// 深绿背景
                    break;
            }



        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            string sError = "";
            string sCon = "";
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
            if (Program.sOperID.Trim() != "admin")
            {
                if (Program.sRoleID == "002")
                    sCon += " and DeftName='" + Program.sDeptName + "' ";
            }

            if (this.checkEdit2.Checked == true)
            {
                sCon += "  and State = '进行中' ";
            }
            if (this.checkEdit3.Checked == true)
            {
                sCon += "  and State = '已结算' ";
            }
            if (this.checkEdit4.Checked == true)
            {
                sCon += "  and State = '作废' ";
            }
            if (this.ckrw.Checked == true)
            {
                sCon += "  and State = '(二次)未检测' ";
            }
            if (this.ckrj.Checked == true)
            {
                sCon += "  and State = '(二次)进行中' ";
            }
            if (this.ckrs.Checked == true)
            {
                sCon += "  and State = '(二次)已结算' ";
            }
            if (this.ckrz.Checked == true)
            {
                sCon += "  and State = '(二次)作废' ";
            }

            StringBuilder strSql1 = new StringBuilder();
            strSql1 = new StringBuilder();
            strSql1.Append(" SELECT AnQingID, AnQingNo, AnQingDiDian,");
            strSql1.Append(" AnQingDesc, DeftName, OperName, AnQingTeShuXiang, AnQingDate,AnQingDieCount,AnQingBeiZhu,isOk,AnQingTwo,State,insDate");
            strSql1.Append(" FROM T_AnQing");

            strSql1.Append(" WHERE 1=1 and State !='未检测' " + sCon + "order by AnQingNo");




            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql1.ToString(), null, out sError);
            this.grd.DataSource = dt;
        }



        private void xq_btn_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要查询的案件");
                return;
            }
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
            frm.ShowDialog();
        }

        private void toolPint_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要打印的案件");
                return;
            }
            FrmPrintAnQing frm = new FrmPrintAnQing(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString(), Convert.ToInt32(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingTwo"]));
            frm.ShowDialog();
        }

        private void FrmAnQing_Load(object sender, EventArgs e)
        {
            this.dtpDateBegin.EditValue = DateTime.Now.ToString("yyyy-MM-01");
            this.dtpDateEnd.EditValue = CommonInfo.CDate(DateTime.Now.ToString("yyyy-MM-01")).AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");
        }

        private void toolGuiDang_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要归档的鉴定项");
                return;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() =="已结算")
            {
                MessageBox.Show("鉴定项已归档,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)已结算")
            {
                MessageBox.Show("鉴定项已归档,请勿重复操作。");
                return;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "作废")
            {
                MessageBox.Show("鉴定项已作废,无法归档。");
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)作废")
            {
                MessageBox.Show("鉴定项已作废,无法归档。");
            }

            MessageBox.Show("归档后无法修改,确定要提交吗？", "提示", MessageBoxButtons.YesNo);
            string sError = "";
            string sql = "";
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                sql = "update T_AnQing set State = '已结算' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                this.btnSel_Click(null, null);
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)进行中")
            {
                sql = "update T_AnQing set State = '(二次)已结算' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                this.btnSel_Click(null, null);
            }


        }

        private void Grd_DoubleClick(object sender, EventArgs e)
        {
            
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                return;
            }
            FrmAnQingXiangQingList frm = new FrmAnQingXiangQingList(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString());
           
            frm.ShowDialog();
           

        }

        private void toolTwo_Click(object sender, EventArgs e)
        {

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要二次鉴定的案件");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() != "已结算")
            {
                MessageBox.Show("只有已结算的鉴定项才能二次鉴定");
                return;
            }
            FrmTwo frm = new FrmTwo(this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString());
            frm.ShowDialog();
            //this.ckrw.Checked = true;
            //this.ckrw.CheckState = CheckState.Checked;
            btnSel_Click(null,null);
        }

        private void toolZF_Click(object sender, EventArgs e)
        {
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要作废的鉴定项");
                return;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("鉴定项已归档,无法作废。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "作废")
            {
                MessageBox.Show("鉴定项已作废,请勿重复操作");
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)作废")
            {
                MessageBox.Show("鉴定项已作废,无法二次鉴定。");
            }
          
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)已结算")
            {
                MessageBox.Show("鉴定项已结算,无法再次提交。");
                return;
            }
            string sError = "";
            string sql = "";

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                sql = "update T_AnQing set State = '作废' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                //this.checkEdit4.Checked = true;
                //this.checkEdit4.CheckState = CheckState.Checked;
            }

            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)进行中")
            {
                sql = "update T_AnQing set State = '(二次)作废' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

                SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
                //this.ckrz.Checked = true;
                //this.ckrz.CheckState = CheckState.Checked;
            }



            this.btnSel_Click(null, null);
        }

        private void toolTowT_Click(object sender, EventArgs e)
        {
            string sError = "";
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle) == null)
            {
                MessageBox.Show("请选中要提交的二次鉴定项");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "进行中")
            {
                MessageBox.Show("鉴定项正在进行中,无法二次鉴定。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "作废")
            {
                MessageBox.Show("鉴定项已作废,无法二次鉴定。");
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)作废")
            {
                MessageBox.Show("鉴定项已作废,无法二次鉴定。");
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)进行中")
            {
                MessageBox.Show("鉴定项已提交,请勿重复操作。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "(二次)已结算")
            {
                MessageBox.Show("鉴定项已结算,无法再次提交。");
                return;
            }
            if (this.gv.GetDataRow(this.gv.FocusedRowHandle)["State"].ToString() == "已结算")
            {
                MessageBox.Show("鉴定项已结算,无法再次提交。");
                return;
            }
            DialogResult dl= MessageBox.Show("提交后无法修改 请确认填写无误后提交 确定要提交吗？", "提示", MessageBoxButtons.YesNo);
            if (dl==DialogResult.No)
            {
                return;
            }

            string id = this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString();
            string no= this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingNo"].ToString();
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
                    SqlParameter[] parametersupup = {
                         new SqlParameter("@GongSiID", SqlDbType.Int) };
                    parametersupup[0].Value = sumGS;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup, out sError);

                }
                else
                {
                    //摇奖流
                    strSql = new StringBuilder();
                    strSql.Append("select SUM(towRandomCount) from T_GongSi");
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
                        strSql.Append(" towRandomCount=towRandomCount+towRandom");
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
                    strSql.Append(" where BaoTypeNo=@BaoTypeID and towRandomCount<>0  order by newid()");
                    SqlParameter[] parameters12 = {
                                    new SqlParameter("@BaoTypeID", SqlDbType.Int) };
                    parameters12[0].Value = item;

                    SqlDataReader redg = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters12, out sError);

                    while (redg.Read())
                    {
                        sumGS = (int)redg[0];
                    }
                    redg.Close();

                    strSql = new StringBuilder();
                    strSql.Append(" update T_GongSi");
                    strSql.Append(" set towRandomCount=towRandomCount-1 where GongSiId=@GongSiID");
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


            }



             sql = "update T_AnQing set State = '(二次)进行中' where AnQingID = '" + this.gv.GetDataRow(this.gv.FocusedRowHandle)["AnQingID"].ToString() + "'";

            SqlHelper.ExecuteNonQuery(CommandType.Text, sql, null, out sError);
            this.btnSel_Click(null, null);


        }
    }
}
