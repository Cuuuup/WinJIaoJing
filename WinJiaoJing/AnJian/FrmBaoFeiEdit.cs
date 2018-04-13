using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using WinJiaoJing.Time;
using System.Threading;

namespace WinJiaoJing
{
    public partial class FrmBaoFeiEdit : Form
    {
        public string sID = "";
        public int isOK = -1;
        public FrmBaoFeiEdit()
        {
            InitializeComponent();

        }

        public FrmBaoFeiEdit(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        public FrmBaoFeiEdit(string _ID,int _isOK)
        {
            sID = _ID;
            isOK = _isOK;
            InitializeComponent();
        }
        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
          
            string sError = "";
            string strSql = "";

            this.txtDieCount.Text = "0";

            if (isOK == 0)
            {
                this.groupControl2.Enabled = false;
                this.groupControl3.Enabled = false;
            }

            //包分类
            DataTable dt1 = SqlHelper.RunQuery(CommandType.Text, "select * from T_BaoType", null, out sError);
            //母版分类
            DataTable dt2 = SqlHelper.RunQuery(CommandType.Text, "select * from T_MuBan", null, out sError);


            comboBox1.DisplayMember = "MuBanName";   // Text，即显式的文本
            comboBox1.ValueMember = "MuBanId";    // Value，即实际的值
            comboBox1.DataSource = dt2;
            comboBox1.SelectedValue = "0";


            //清空项
            checkedListBoxControl1.Items.Clear();
            checkedListBoxControl1.DataSource = null;

            //绑定
            checkedListBoxControl1.DataSource = dt1;
            checkedListBoxControl1.ValueMember = "Bao_TypeId";
            checkedListBoxControl1.DisplayMember = "Bao_Desc";



            //是否点击一次 就改变状态
            checkedListBoxControl1.CheckOnClick = true;
            //是否多列显示
            checkedListBoxControl1.MultiColumn = true;

            getNO(sError);

            //项目有编号 修改的情况下 显示数据
            if (sID.Trim() != "")
            {
                this.groupControl2.Enabled = false;
                sError = "";
                strSql = "SELECT * FROM T_AnQing WHERE AnQingID=" + sID;

                DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.txt_AnQingID.Text = dt.Rows[0]["AnQingID"].ToString();
                    this.txt_No.Text = dt.Rows[0]["AnQingNo"].ToString();
                    this.txtDiDian.Text = dt.Rows[0]["AnQingDiDian"].ToString();
                    this.txtOperID.Text = dt.Rows[0]["OperName"].ToString();
                    this.txtDanWei.Text = dt.Rows[0]["DeftName"].ToString();
                    this.txtDemo.Text = dt.Rows[0]["AnQingBeiZhu"].ToString();
                    this.txtAnQingDesc.Text = dt.Rows[0]["AnQingDesc"].ToString();
                    this.txtDate.Text = dt.Rows[0]["AnQingDate"].ToString();
                    this.txtDieCount.Text = dt.Rows[0]["AnQingDieCount"].ToString();
                    if (dt.Rows[0]["AnQingTeShuXiang"].ToString() != "")
                    {
                        this.ck_t.Checked = true;
                        this.txt_teshu.Enabled = true;
                        this.txt_teshu.Text = dt.Rows[0]["AnQingTeShuXiang"].ToString();


                    }
                    //包项 选择按钮赋值
                    strSql = "SELECT BaoType_Id FROM T_AnQingXiang WHERE AnQingId=" + this.txt_No.Text + "group by BaoType_Id";
                    SqlDataReader red = SqlHelper.ExecuteReader(CommandType.Text, strSql, null, out sError);
                    while (red.Read())
                    {
                        checkedListBoxControl1.SetItemChecked(Convert.ToInt32(red[0]) - 1, true);

                    }
                    red.Close();


                    xmlist();


                    //项目 选择按钮赋值
                    strSql = "SELECT XiangMuId,XiangMuSum FROM T_AnQingXiang WHERE AnQingId=" + this.txt_No.Text + "group by XiangMuId,XiangMuSum";
                    SqlDataReader red1 = SqlHelper.ExecuteReader(CommandType.Text, strSql, null, out sError);
                    int sum = 0;
                    while (red1.Read())
                    {
                        SelectRow(gridView1, this.gridColumn1.FieldName, Convert.ToInt32(red1[0]), out sum);
                        if (sum == 0)
                        {
                            sum = 1;
                        }
                        this.gridView1.SetRowCellValue(sum, gridColumn2, red1[1]);
                    }

                    red1.Close();



                }
            }
            else
            {
                toolQingKong_Click(null, null);
            }



        }


        private void toolSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("确认保存信息是否填写正确？", "提示",MessageBoxButtons.YesNo);
            string sError = "";
            string ID, NO, DanWei, OpID, DiDian, Date, AnQingDesc, teshu, beizhu, dieConut;
            ID = this.txt_AnQingID.Text.Trim();
            NO = this.txt_No.Text.Trim();
            DanWei = this.txtDanWei.Text.Trim();
            OpID = this.txtOperID.Text.Trim();
            DiDian = this.txtDiDian.Text.Trim();
            Date = this.txtDate.Text.Trim();
            AnQingDesc = this.txtAnQingDesc.Text.Trim();
            beizhu = this.txtDemo.Text.Trim();
            teshu = this.txt_teshu.Text.Trim();
            dieConut = this.txtDieCount.Text.Trim();

            StringBuilder strSql = new StringBuilder();
            //新增
            if (ID.Trim() == "")
            {

                strSql = new StringBuilder();
                strSql.Append("insert into T_AnQing(");
                strSql.Append("AnQingDiDian,AnQingDesc,AnQingNo,AnQingDate,");
                strSql.Append(" DeftName,OperName,AnQingTeShuXiang,");
                strSql.Append(" AnQingBeiZhu,AnQingDieCount,IsOk)");
                strSql.Append(" values (");
                strSql.Append("@AnQingDiDian,@AnQingDesc,@AnQingNo,@AnQingDate,");
                strSql.Append("@DeftName,@OperName,@AnQingTeShuXiang,");
                strSql.Append("@AnQingBeiZhu,@AnQingDieCount,@IsOk)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
                     new SqlParameter("@AnQingDiDian", SqlDbType.VarChar,70),
                     new SqlParameter("@AnQingDesc", SqlDbType.NVarChar,3000),
                     new SqlParameter("@AnQingNo", SqlDbType.Int),
                     new SqlParameter("@AnQingDate", SqlDbType.DateTime),
                     new SqlParameter("@DeftName", SqlDbType.VarChar,50),
                     new SqlParameter("@OperName", SqlDbType.VarChar,50),
                     new SqlParameter("@AnQingTeShuXiang", SqlDbType.VarChar,50),
                     new SqlParameter("@AnQingBeiZhu", SqlDbType.VarChar,150),
                     new SqlParameter("@AnQingDieCount", SqlDbType.Int),
                     new SqlParameter("@IsOk", SqlDbType.Int)};

                parameters[0].Value = DiDian;
                parameters[1].Value = AnQingDesc;
                parameters[2].Value = NO;
                parameters[3].Value = Date;
                parameters[4].Value = DanWei;
                parameters[5].Value = OpID;
                parameters[6].Value = teshu;
                parameters[7].Value = beizhu;
                parameters[8].Value = dieConut;
                parameters[9].Value = 0;

                if (this.txtDiDian.Text.Trim() == "")
                {
                    MessageBox.Show("请输入案发地点。");
                    return;
                }
                if (this.txtAnQingDesc.Text.Trim() == "")
                {
                    MessageBox.Show("请输入案件详情。");
                    return;
                }

                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);


                if (gridView1.SelectedRowsCount <= 0)
                {
                    MessageBox.Show("请选择鉴定项目 ！");
                    return;
                }

                // 获取选项
                int sum = -1;
                int sum1 = 0;
                int sum2 = 0;
                int sumGS = 0;
                int i = 0;
                int i1 = 0;
                int SumCount = -1;
                int py = -1;




                //根据行号获取相应行的数据;   
                foreach (int item in this.gridView1.GetSelectedRows())
                {

                    strSql = new StringBuilder();
                    strSql.Append("select BaoTypeId from T_XiangMu");
                    strSql.Append("  where XiangMuNo=@Xno");
                    SqlParameter[] parametersNosum = {
                        new SqlParameter("@Xno", SqlDbType.Int) };
                    parametersNosum[0].Value = Convert.ToInt32(this.gridView1.GetDataRow(item)[2]);

                    SqlDataReader redsum = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersNosum, out sError);

                    while (redsum.Read())
                    {
                        //获取指定值数量
                        sum = (int)redsum[0];

                    }

                    redsum.Close();
                   

                    if (sum == -1)
                    {
                        MessageBox.Show("请勾选鉴定项目类型。");
                        return;
                    }

                    // MessageBox.Show(sum.ToString());
                    //判断包类型 一包一次摇奖
                    if (sum != i1)
                    {

                        strSql = new StringBuilder();
                        strSql.Append("select SUM(PyCount) from T_GongSi");
                        strSql.Append("  where BaoTypeNo=@No");
                        SqlParameter[] parametersNopy = {
                        new SqlParameter("@No", SqlDbType.Int) };
                        parametersNopy[0].Value = sum;

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
                            parameters122[0].Value = sum;

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
                            strSql.Append("select SUM(randomCount) from T_GongSi");
                            strSql.Append("  where BaoTypeNo=@No");
                            SqlParameter[] parametersNo = {
                        new SqlParameter("@No", SqlDbType.Int) };
                            parametersNo[0].Value = sum;

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
                                parametersAdd[0].Value = sum;

                                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersAdd, out sError);

                                strSql = new StringBuilder();
                                strSql.Append(" update T_GongSi");
                                strSql.Append(" set randomCount=randomCount-1 where GongSiId=@GongSiID");
                                SqlParameter[] parametersupup33 = {
                                new SqlParameter("@GongSiID", SqlDbType.Int) };
                                parametersupup33[0].Value = sumGS;

                                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup33, out sError);

                            }

                            //随机获取 一个数据
                            strSql = new StringBuilder();
                            strSql.Append("select top 1 GongSiId from T_GongSi");
                            strSql.Append(" where BaoTypeNo=@BaoTypeID and randomCount<>0  order by newid()");
                            SqlParameter[] parameters12 = {
                                new SqlParameter("@BaoTypeID", SqlDbType.Int) };
                            parameters12[0].Value = sum;

                            SqlDataReader redg = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameters12, out sError);

                            while (redg.Read())
                            {
                                sumGS = (int)redg[0];
                            }
                            redg.Close();

                            strSql = new StringBuilder();
                            strSql.Append(" update T_GongSi");
                            strSql.Append(" set randomCount=randomCount-1 where GongSiId=@GongSiID");
                            SqlParameter[] parametersupup = {
                         new SqlParameter("@GongSiID", SqlDbType.Int) };
                            parametersupup[0].Value = sumGS;

                            SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupup, out sError);


                        }


                        strSql = new StringBuilder();
                        strSql.Append(" update T_AnQing ");

                        if (sum == 1)
                        {
                            strSql.Append(" set GongSiA=@gongsi where AnQingNo=@idid");
                        }
                        if (sum == 2)
                        {
                            strSql.Append(" set GongSiB=@gongsi where AnQingNo=@idid");
                        }
                        if (sum == 3)
                        {
                            strSql.Append(" set GongSiD=@gongsi where AnQingNo=@idid");
                        }
                        SqlParameter[] parametersupupdate = {
                         new SqlParameter("@gongsi", SqlDbType.Int),
                         new SqlParameter("@idid", SqlDbType.Int)};
                        parametersupupdate[0].Value = sumGS;
                        parametersupupdate[1].Value = NO;
                        SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersupupdate, out sError);


                        i1 = sum;
                    }



                    //MessageBox.Show(sumGS.ToString());


                    strSql = new StringBuilder();
                    strSql.Append("insert into T_AnQingXiang(");
                    strSql.Append("AnQingId,BaoType_Id,XiangMuId,XiangBaoJia,XiangMuSum,XiangMuCount,GongSiID)");
                    strSql.Append(" values (");
                    strSql.Append("@AnQingId,@BaoType_Id,@XiangMuId,@XiangBaoJia,@XiangMuSum,@XiangMuCount,@GongSiID)");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters1 = {
                     new SqlParameter("@AnQingId", SqlDbType.Int),
                     new SqlParameter("@BaoType_Id", SqlDbType.Int),
                     new SqlParameter("@XiangMuId", SqlDbType.Int),
                     new SqlParameter("@XiangBaoJia", SqlDbType.Money),
                     new SqlParameter("@XiangMuSum",SqlDbType.Int),
                     new SqlParameter("@XiangMuCount",SqlDbType.Money),
                     new SqlParameter("@GongSiID",SqlDbType.Int)
                    };

                    sum1 = Convert.ToInt32(this.gridView1.GetDataRow(item)[4]);
                    sum2 = Convert.ToInt32(this.gridView1.GetDataRow(item)["sum"]);

                    parameters1[0].Value = this.txt_No.Text;
                    parameters1[1].Value = sum;
                    parameters1[2].Value = this.gridView1.GetDataRow(item)[2].ToString();
                    parameters1[3].Value = this.gridView1.GetDataRow(item)[4].ToString();
                    parameters1[4].Value = this.gridView1.GetDataRow(item)["sum"].ToString();
                    parameters1[5].Value = sum1 * sum2;
                    parameters1[6].Value = sumGS;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters1, out sError);


                    if (sum != i)
                    {
                        Times frm = new Times(sumGS);
                        frm.ShowDialog();
                        i = sum;

                    }


                }


                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
                toolQingKong_Click(null, null);
            }
            else
            {

                if (gridView1.SelectedRowsCount <= 0)
                {
                    MessageBox.Show("请选择鉴定项目 ！");
                    return;
                }
                strSql = new StringBuilder();
                strSql.Append("update T_AnQing set ");
                strSql.Append("AnQingDiDian=@AnQingDiDian,");
                strSql.Append("AnQingDate=@AnQingDate,");
                strSql.Append("AnQingDesc=@AnQingDesc,");
                strSql.Append("AnQingTeShuXiang=@AnQingTeShuXiang,");
                strSql.Append("AnQingBeiZhu=@AnQingBeiZhu,");
                strSql.Append("AnQingDieCount=@AnQingDieCount");
                strSql.Append(" where AnQingID=@AnQingID");
                SqlParameter[] parameters = {
                        new SqlParameter("@AnQingDiDian", SqlDbType.VarChar,70),
                        new SqlParameter("@AnQingDate",SqlDbType.DateTime),
                        new SqlParameter("@AnQingDesc", SqlDbType.VarChar,3000),
                        new SqlParameter("@AnQingTeShuXiang", SqlDbType.VarChar, 50),
                        new SqlParameter("@AnQingBeiZhu", SqlDbType.VarChar, 150),
                        new SqlParameter("@AnQingDieCount", SqlDbType.Int),
                        new SqlParameter("@AnQingID", SqlDbType.Int)};

                parameters[0].Value = DiDian;
                parameters[1].Value = Date;
                parameters[2].Value = AnQingDesc;
                parameters[3].Value = teshu;
                parameters[4].Value = beizhu;
                parameters[5].Value = dieConut;
                parameters[6].Value = ID;

                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);

                string strSql1 = "DELETE FROM T_AnQingXiang WHERE AnQingId=" + NO;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql1, null, out sError);


                #region 获取选项
                int sum = 0;
                int sum1 = 0;
                int sum2 = 0;
                int gongsi = -1;
                //根据行号获取相应行的数据;   
                foreach (int item in this.gridView1.GetSelectedRows())
                {

                    if (Convert.ToInt32(this.gridView1.GetDataRow(item)[2]) <= 13)
                    {
                        sum = 1;
                    }
                    if (Convert.ToInt32(this.gridView1.GetDataRow(item)[2]) == 14)
                    {
                        sum = 2;
                    }
                    if (Convert.ToInt32(this.gridView1.GetDataRow(item)[2]) >= 16 && Convert.ToInt32(this.gridView1.GetDataRow(item)[2]) <= 20)
                    {
                        sum = 3;
                    }



                    strSql = new StringBuilder();
                    strSql.Append(" select ");

                    if (sum == 1)
                    {
                        strSql.Append(" GongSiA from T_AnQing where AnQingNo=@idid");
                    }
                    if (sum == 2)
                    {
                        strSql.Append(" GongSiB from T_AnQing where AnQingNo=@idid");
                    }
                    if (sum == 3)
                    {
                        strSql.Append(" GongSiD from T_AnQing where AnQingNo=@idid");
                    }
                    SqlParameter[] parametersupupdate1 = {
                         new SqlParameter("@idid", SqlDbType.Int)};
                    parametersupupdate1[0].Value = NO;
                    SqlDataReader red= SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersupupdate1, out sError);

                    while (red.Read())
                    {
                        gongsi = (int)red[0];
                    }
                    red.Close();


                    strSql = new StringBuilder();
                    strSql.Append("insert into T_AnQingXiang(");
                    strSql.Append("AnQingId,BaoType_Id,XiangMuId,XiangBaoJia,XiangMuSum,XiangMuCount,GongSiID)");
                    strSql.Append(" values (");
                    strSql.Append("@AnQingId,@BaoType_Id,@XiangMuId,@XiangBaoJia,@XiangMuSum,@XiangMuCount,@GongSiID)");
                    strSql.Append(";select @@IDENTITY");
                    SqlParameter[] parameters1 = {
                     new SqlParameter("@AnQingId", SqlDbType.Int),
                     new SqlParameter("@BaoType_Id", SqlDbType.Int),
                     new SqlParameter("@XiangMuId", SqlDbType.Int),
                     new SqlParameter("@XiangBaoJia", SqlDbType.Money),
                     new SqlParameter("@XiangMuSum",SqlDbType.Int),
                     new SqlParameter("@XiangMuCount",SqlDbType.Money),
                     new SqlParameter("@GongSiID",SqlDbType.Int)
                    };

                    sum1 = Convert.ToInt32(this.gridView1.GetDataRow(item)[4]);
                    sum2 = Convert.ToInt32(this.gridView1.GetDataRow(item)["sum"]);

                    parameters1[0].Value = this.txt_No.Text;
                    parameters1[1].Value = sum;
                    parameters1[2].Value = this.gridView1.GetDataRow(item)[2].ToString();
                    parameters1[3].Value = this.gridView1.GetDataRow(item)[4].ToString();
                    parameters1[4].Value = this.gridView1.GetDataRow(item)["sum"].ToString();
                    parameters1[5].Value = sum1 * sum2;
                    parameters1[6].Value = gongsi;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters1, out sError);

                }
                #endregion

                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }

                MessageBox.Show("修改成功");

                this.Close();

            }


        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {


            //ID = this.txt_AnQingID.Text.Trim();
            //NO = this.txt_No.Text.Trim();
            //DanWei = this.txtDanWei.Text.Trim();
            //OpID = this.txtOperID.Text.Trim();
            //DiDian = this.txtDiDian.Text.Trim();
            //Date = this.txtDate.Text.Trim();
            //AnQingDesc = this.txtAnQingDesc.Text.Trim();
            //beizhu = this.txtDemo.Text.Trim();
            //teshu = this.txt_teshu.Text.Trim();
            //dieConut = this.txtDieCount.Text.Trim();
            getNO("");

            sID = "";
            this.txt_AnQingID.Text = "";
            this.txt_teshu.Text = "";
            this.txt_teshu.Enabled = false;
            this.checkedListBoxControl1.UnCheckAll();
            this.checkedListBoxControl2.Items.Clear();
            this.grlAnJian.DataSource = null;
            this.txtDieCount.Text = "0";
            this.txtDiDian.Text = "";
            this.txtDiDian.ToolTip = "";
            this.txtDanWei.Text = Program.sDeptName;
            this.txtDemo.Text = "";
            this.txtOperID.Text = "";
            this.txtAnQingDesc.Text = "";
            this.txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.txtOperID.Text = Program.sOperName;
            this.txtOperID.ToolTip = Program.sOperID;
            this.txtDiDian.Focus();
            this.txtDiDian.Select(2, 1);
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCarID_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        public void BingGrid(string sCon)
        {
            string sError = "";
            sCon = " and DeptID like '" + Program.sDeptID + "' " + sCon;
            string strSql = "select * from T_Car where 1=1  " + sCon + " order by ID";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

        }

        public Boolean IsExistsCar(string sCarNO)
        {
            string sError = "";
            string sCon = "";
            sCon = " and DeptID like '" + Program.sDeptID + "' " + sCon;
            sCon += " and CarNO like '%" + sCarNO + "%' ";
            string strSql = "select * from T_CarBaoFei where 1=1  " + sCon + " ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            if (sError.Trim() == "" && dt.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }


        private void getNO(string sError)
        {

            //编号
            DataTable dt3 = SqlHelper.RunQuery(CommandType.Text, $"select max(AnQingNo)+1 as aNO  from T_AnQing", null, out sError);
            
            if (dt3.Rows[0][0].ToString() == "")
            {
                this.txt_No.Text = "1";
            }
            else
            {
                this.txt_No.Text = dt3.Rows[0][0].ToString();
            }
        }

    

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCarID_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn_clear_CheckedChanged(object sender, EventArgs e)
        {

            checkedListBoxControl1.UnCheckAll();

        }

        private void btn_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            //全选
            checkedListBoxControl1.CheckAll();
        }


        private void checkedListBoxControl1_CheckMemberChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 调用 项目选择项
        /// </summary>
        private void xmlist()
        {
            string sError = "";
            string sCon = "";

            this.grlAnJian.DataSource = null;

            //清空项
            checkedListBoxControl2.Items.Clear();
            checkedListBoxControl2.DataSource = null;
            //是否点击一次 就改变状态
            checkedListBoxControl2.CheckOnClick = true;
            //是否多列显示
            checkedListBoxControl2.MultiColumn = true;

            int count = this.checkedListBoxControl1.CheckedItems.Count;

            if (count > 0)
            {
                string strSql = "";
                foreach (DataRowView item in this.checkedListBoxControl1.CheckedItems)
                {
                    strSql += $"(select * from T_XiangMu where BaoTypeId={item[0].ToString()})union all";

                }
                if (strSql != null)
                {
                    strSql = "select ('('+t.Bao_Name+')'+a.XiangMuName)title,* from(" + strSql.Substring(0, strSql.Length - 9) + ") a join T_BaoType t on a.BaoTypeId=t.Bao_TypeId ";

                    DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

                    DataColumn dc2 = new DataColumn("sum", typeof(string));
                    dc2.DefaultValue = "1";
                    dc2.AllowDBNull = false;//这在创建表的时候，起作用，在为已有表新增列的时候，不起作用
                    dt.Columns.Add(dc2);


                    this.grlAnJian.DataSource = dt;

                    //自定义一个表
                    DataTable dt2 = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

                    //绑定
                    checkedListBoxControl2.DataSource = dt2;
                    checkedListBoxControl2.ValueMember = "XiangMuNo";
                    checkedListBoxControl2.DisplayMember = "title";
                }

            }
        }

        private void btn_mx_CheckedChanged(object sender, EventArgs e)
        {
            string strSql = "";
            string sError = "";

            xmlist();
            if (this.txt_AnQingID.Text != "")
            {
                //项目 选择按钮赋值
                strSql = "SELECT XiangMuId,XiangMuSum FROM T_AnQingXiang WHERE AnQingId=" + this.txt_No.Text + "group by XiangMuId,XiangMuSum";
                SqlDataReader red1 = SqlHelper.ExecuteReader(CommandType.Text, strSql, null, out sError);
                int sum = 0;
                while (red1.Read())
                {
                    SelectRow(gridView1, this.gridColumn1.FieldName, Convert.ToInt32(red1[0]), out sum);
                    if (sum == 0)
                    {
                        sum = 1;
                    }
                    this.gridView1.SetRowCellValue(sum, gridColumn2, red1[1]);
                }
                red1.Close();
            }


        }

        private void checkButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxControl2.CheckAll();
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkedListBoxControl2.UnCheckAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
                return;

            this.txtAnQingDesc.Text = SqlHelper.ExecuteScalar(CommandType.Text, $"select MuBanDesc from T_MuBan where MuBanId={comboBox1.SelectedValue.ToString()}", null).ToString();


        }

        private void ck_t_Click(object sender, EventArgs e)
        {

        }

        private void ck_t_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ck_t.Checked == true)
            {
                this.txt_teshu.Enabled = true;
            }
            else
            {
                this.txt_teshu.Enabled = false;
            }
        }

        private void grlAnJian_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 根据列来选中一行
        /// </summary>
        /// <param name="gridView">GridView</param>
        /// <param name="colName">列名称</param>
        /// <param name="colValue">列值</param>
        private void SelectRow(GridView gridView, string colName, object colValue, out int row)
        {
            row = 1;
            //gridView.ClearSelection();
            for (int rowHandle = 0; rowHandle < gridView.RowCount; rowHandle++)
            {
                object _cellValue = gridView.GetRowCellValue(rowHandle, colName);
                if (_cellValue != null)
                {
                    if ((int)_cellValue == (int)colValue)
                    {
                        gridView.SelectRow(rowHandle);
                        row = rowHandle;

                    }
                }
            }
        }


    }
}
