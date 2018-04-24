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
    public partial class FrmTwo : Form
    {
        public string sID = "";
        public int isOK = -1;
        public FrmTwo()
        {
            InitializeComponent();

        }

        public FrmTwo(string _ID)
        {
            sID = _ID;
            InitializeComponent();
        }
        public FrmTwo(string _ID,int _isOK)
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



            //包分类
            DataTable dt1 = SqlHelper.RunQuery(CommandType.Text, "select * from T_BaoType", null, out sError);
            //母版分类
            DataTable dt2 = SqlHelper.RunQuery(CommandType.Text, "select * from T_MuBan", null, out sError);
            //地址分类 
            DataTable dt3 = SqlHelper.RunQuery(CommandType.Text, "select * from T_DiZHi", null, out sError);

            comboBox1.DisplayMember = "MuBanName";   // Text，即显式的文本
            comboBox1.ValueMember = "MuBanId";    // Value，即实际的值
            comboBox1.DataSource = dt2;
            comboBox1.SelectedValue = "0";

            comDidIan.DisplayMember = "DiZhiDesc";
            comDidIan.ValueMember = "DiZhiID";
            comDidIan.DataSource = dt3;
            comDidIan.SelectedValue = "1";


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
            string no;
            getNO(sError,out no);

            //项目有编号 修改的情况下 显示数据
            if (sID.Trim() != "")
            {
                //this.groupControl2.Enabled = false;
                sError = "";
                strSql = "SELECT * FROM T_AnQing WHERE AnQingID=" + sID;

                DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                if (dt.Rows.Count > 0)
                {
                    this.comDidIan.Text = dt.Rows[0]["AnQingDiZhi"].ToString();
                    this.txt_AnQingID.Text = dt.Rows[0]["AnQingID"].ToString();
                    this.txt_No.Text = dt.Rows[0]["AnQingNo"].ToString();
                    this.txtDiDian.Text = dt.Rows[0]["AnQingDiDian"].ToString();
                    this.txtOperID.Text = dt.Rows[0]["OperName"].ToString();
                    this.txtDanWei.Text = dt.Rows[0]["DeftName"].ToString();
                    this.txtDemo.Text = dt.Rows[0]["AnQingBeiZhu"].ToString();
                    this.txtAnQingDesc.Text = dt.Rows[0]["AnQingDesc"].ToString();
                    this.txtDate.Text = dt.Rows[0]["AnQingDate"].ToString();
                    this.txtDieCount.Text = dt.Rows[0]["AnQingDieCount"].ToString();
                    this.txtDateSS.EditValue = dt.Rows[0]["AnQingDateSS"].ToString();


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
                        this.gridView1.SetRowCellValue(sum, gridColumn2, red1[1]);

                    }

                    red1.Close();

                    this.txt_AnQingID.Text = null;
                     
                    getNO(sError,out no);
                }
                else
                {
                    toolQingKong_Click(null, null);
                }

            }
        }


        private void toolSave_Click(object sender, EventArgs e)
        {
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
            if (gridView1.SelectedRowsCount <= 0)
            {
                MessageBox.Show("请选择鉴定项目 ！");
                return;
            }
            
            string sError = "";
            string ID, NO, DanWei, OpID, DiDian, Date, AnQingDesc, teshu, beizhu, dieConut, DateSS, DiZhi,isOK;
            getNO(sError, out NO);
            ID = this.txt_AnQingID.Text.Trim();
            DanWei = this.txtDanWei.Text.Trim();
            OpID = this.txtOperID.Text.Trim();
            DiDian = this.txtDiDian.Text.Trim();
            Date = this.txtDate.Text.Trim();
            AnQingDesc = this.txtAnQingDesc.Text.Trim();
            beizhu = this.txtDemo.Text.Trim();
            teshu = this.txt_teshu.Text.Trim();
            dieConut = this.txtDieCount.Text.Trim();
            DateSS = this.txtDateSS.EditValue.ToString() ;
            DiZhi = this.comDidIan.Text;
            isOK = sID;

            StringBuilder strSql = new StringBuilder();
            //新增
            if (ID.Trim() == "")
            {
                DialogResult OK = MessageBox.Show("确认保存信息是否填写正确？", "提示", MessageBoxButtons.YesNo);
                if (OK == DialogResult.No)
                {
                    return;
                }
                strSql = new StringBuilder();
                strSql.Append("insert into T_AnQing(");
                strSql.Append("AnQingDiDian,AnQingDesc,AnQingNo,AnQingDate,");
                strSql.Append(" DeftName,OperName,AnQingTeShuXiang,");
                strSql.Append(" AnQingBeiZhu,AnQingDieCount,AnQingTwo,AnQingDateSS,AnQingDiZhi,State,IsOk)");
                strSql.Append(" values (");
                strSql.Append("@AnQingDiDian,@AnQingDesc,@AnQingNo,@AnQingDate,");
                strSql.Append("@DeftName,@OperName,@AnQingTeShuXiang,");
                strSql.Append("@AnQingBeiZhu,@AnQingDieCount,@AnQingTwo,@AnQingDateSS,@AnQingDiZhi,@State,@isok)");
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
                     new SqlParameter("@AnQingTwo",SqlDbType.Int),
                     new SqlParameter("@AnQingDateSS", SqlDbType.Time),
                     new SqlParameter("@AnQingDiZhi", SqlDbType.VarChar,20),
                     new SqlParameter("@State", SqlDbType.VarChar,20),
                     new SqlParameter("@isok",SqlDbType.Int) };

                parameters[0].Value = DiDian;
                parameters[1].Value = AnQingDesc;
                parameters[2].Value = NO;
                parameters[3].Value = Date;
                parameters[4].Value = DanWei;
                parameters[5].Value = OpID;
                parameters[6].Value = teshu;
                parameters[7].Value = beizhu;
                parameters[8].Value = dieConut;
                parameters[9].Value = 1;
                parameters[10].Value = DateSS;
                parameters[11].Value = DiZhi;
                parameters[12].Value = "(二次)未检测";
                parameters[13].Value = isOK;
               


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
                    parameters1[6].Value = 0;

                    SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters1, out sError);
    

                }

                getBaoJia(sError, NO);
                if (sError.Trim() != "")
                {
                    MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
                MessageBox.Show("添加成功！");
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
            string no;
            getNO("",out no);

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
            this.txtDemo.Text = "";
            this.txtOperID.Text = "";
            this.txtAnQingDesc.Text = "";
            this.txtDiDian.Focus();
            this.txtDiDian.Select(2, 1);
            this.txtDateSS.Text = DateTime.Now.ToString("t");
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
            //sCon += " and CarNO not in (SELECT CarNO FROM T_CarBaoFei WHERE DeptID='"+Program.sDeptID+"') ";

            string strSql = "select * from T_Car where 1=1  " + sCon + " order by ID";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            //this.grd.DataSource = dt;
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

        
      
        
        /// <summary>
        /// A包打包价逻辑 需求： a包 1-10 如果大于5个 并且价钱超过4800 价格自动打包为4800
        /// </summary>
        /// <param name="sError"></param>
        /// <param name="NO"></param>
        private void getBaoJia(string sError,string NO)
        {

            StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(*)jia from");
                strSql.Append("(select top 5 * from T_AnQingXiang");
                strSql.Append("  where XiangMuId <= 10 and AnQingId = @AnQingNo");
                strSql.Append(" AND BaoType_Id = 1 order by XiangMuCount desc)tb1");
                SqlParameter[] parameterscou = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                parameterscou[0].Value = NO;

                int count = 0;
                double sumA = 0;
                double sumA1 = 0;
                double sumA2 = 0;
                double sumB = 0;
                double sumD = 0;
                SqlDataReader redcou = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parameterscou, out sError);

                while (redcou.Read())
                {
                    count=(int)redcou[0];
                }

                redcou.Close();

                strSql = new StringBuilder();
                strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia)end from");
                strSql.Append("(select top 5 * from T_AnQingXiang");
                strSql.Append("  where XiangMuId <= 10 and AnQingId = @AnQingNo");
                strSql.Append(" AND BaoType_Id = 1 order by XiangMuCount desc)tb1");
                SqlParameter[] parametersum = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                parametersum[0].Value = NO;

                SqlDataReader redsum123= SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersum, out sError);
                while (redsum123.Read())
                {
                    sumA = Convert.ToDouble(redsum123[0]);
                }

                
                redcou.Close();
                //A包大于5个项目 并且1-10 最贵的项目总价值大于4800 1-10最贵的5项打包成4800
                if (count==5 && sumA>=4800)
                {
                    sumA = 4800; 

                    //取总包
                    strSql = new StringBuilder();
                    strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end from T_AnQingXiang");
                    strSql.Append(" where AnQingId=@AnQingNo and AnQingXiang_ID not in(");
                    strSql.Append("  select top 5 AnQingXiang_ID from T_AnQingXiang where XiangMuId<=10 and AnQingId=@AnQingNo AND BaoType_Id=1 order by XiangMuCount desc)");
                    SqlParameter[] parametersum1asw = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                    parametersum1asw[0].Value = NO;

                    SqlDataReader redsum1 = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersum1asw, out sError);
                    while (redsum1.Read())
                    {
                        sumA1 = Convert.ToDouble(redsum1[0]);
                    }
                    redsum1.Close();
                    sumA1 += sumA;
                   
                    //取A包
                    strSql = new StringBuilder();
                    strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end  from T_AnQingXiang");
                    strSql.Append(" where AnQingId=@AnQingNo and BaoType_Id=1 and AnQingXiang_ID not in(");
                    strSql.Append("  select top 5 AnQingXiang_ID from T_AnQingXiang where XiangMuId<=10 and AnQingId=@AnQingNo AND BaoType_Id=1 order by XiangMuCount desc)");
                    SqlParameter[] parametersum12zza = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                    parametersum12zza[0].Value = NO;

                    SqlDataReader redsum2 = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersum12zza, out sError);
                    while (redsum2.Read())
                    {
                        sumA2 = Convert.ToDouble(redsum2[0]);
                    }
                    redsum2.Close();
                    sumA2 += sumA;
                   
                }
                else
                {
                    //取Z包
                    strSql = new StringBuilder();
                    strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end  from T_AnQingXiang");
                    strSql.Append(" where AnQingId=@AnQingNo");
                    SqlParameter[] parametersumaz = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                    parametersumaz[0].Value = NO;
                    SqlDataReader redsumbz = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersumaz, out sError);
                    while (redsumbz.Read())
                    {
                        sumA1 = Convert.ToDouble(redsumbz[0]);
                    }
                    redsumbz.Close();
             

                //取a包
                strSql = new StringBuilder();
                    strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end  from T_AnQingXiang");
                    strSql.Append(" where AnQingId=@AnQingNo and BaoType_Id=1 ");
                    SqlParameter[] parametersumBA = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                    parametersumBA[0].Value = NO;

                    SqlDataReader redsumbA = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersumBA, out sError);
                    while (redsumbA.Read())
                    {
                        sumA2 = Convert.ToDouble(redsumbA[0]);
                    }
                    redsumbA.Close();
             
            }

                //取B包
                strSql = new StringBuilder();
                strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end  from T_AnQingXiang");
                strSql.Append(" where AnQingId=@AnQingNo and BaoType_Id=2 ");
                SqlParameter[] parametersumB = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                parametersumB[0].Value = NO;

                SqlDataReader redsumb = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersumB, out sError);
                while (redsumb.Read())
                {
                    sumB = Convert.ToDouble(redsumb[0]);
                }
                redsumb.Close();
              
           

            //取D包
            strSql = new StringBuilder();
                strSql.Append("select case when SUM(XiangBaoJia) is null then 0 else SUM(XiangBaoJia) end  from T_AnQingXiang");
                strSql.Append(" where AnQingId=@AnQingNo and BaoType_Id=3 ");
                SqlParameter[] parametersumD = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int)};

                parametersumD[0].Value = NO;

                SqlDataReader redsumd = SqlHelper.ExecuteReader(CommandType.Text, strSql.ToString(), parametersumD, out sError);
                while (redsumd.Read())
                {
                    sumD = Convert.ToDouble(redsumd[0]);
                }
                redsumd.Close();
      
            //总价赋值
            strSql = new StringBuilder();
                strSql.Append("update T_AnQing set BaoSum =@sum,BaOSumA=@sumA,BaOSumB=@sumB,BaOSumD=@sumD  where AnQingNo =@AnQingNo ");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parametersumup = {
                     new SqlParameter("@AnQingNo", SqlDbType.Int),
                     new SqlParameter("@sum", SqlDbType.Decimal),
                     new SqlParameter("@sumA", SqlDbType.Decimal),
                     new SqlParameter("@sumB", SqlDbType.Decimal),
                     new SqlParameter("@sumD", SqlDbType.Decimal)};

                parametersumup[0].Value = NO;
                parametersumup[1].Value = sumA1;
                parametersumup[2].Value = sumA2;
                parametersumup[3].Value = sumB;
                parametersumup[4].Value = sumD;


                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parametersumup, out sError);

        }

        private void getNO(string sError,out string _no)
        {

            //编号
            DataTable dt3 = SqlHelper.RunQuery(CommandType.Text, $"select max(AnQingNo)+1 as aNO  from T_AnQing", null, out sError);
            
            if (dt3.Rows[0][0].ToString() == "")
            {
                this.txt_No.Text = "1";
                _no = "1";
            }
            else
            {
                this.txt_No.Text = dt3.Rows[0][0].ToString();
                _no = dt3.Rows[0][0].ToString(); 
            }
        }

        private void grd_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                try
                {

                    if (IsExistsCar(this.txtDiDian.ToolTip.Trim()))
                    {
                        MessageBox.Show("演示项目，仅供参考", "提示");

                        return;
                    }
                }

                catch
                {
                    this.txtDiDian.ToolTip = "";
                    this.txtDiDian.Focus();
                }
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
