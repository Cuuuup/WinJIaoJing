using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace WinJiaoJing
{
    public partial class FrmYaoHaoEdit : Form
    {
        public string sID = "";
        public FrmYaoHaoEdit()
        {
            InitializeComponent();
        }

        private void FrmRoleEdit_Load(object sender, EventArgs e)
        {
            string sError = "";
            string strSql = "";

            //是否点击一次 就改变状态
            checkedListBoxControl1.CheckOnClick = true;
            //是否多列显示
            checkedListBoxControl1.MultiColumn = true;
           


            if (sID.Trim() != "")
                {
                    sError = "";
                    strSql = "SELECT * FROM T_CarBaoFei WHERE ID=" + sID;
                    DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                    if (dt.Rows.Count > 0)
                    {
                        this.txtCarID.Enabled = false;
                        this.txtCarID.ToolTip = dt.Rows[0]["CarNO"].ToString();
                        this.txtCarID.Text = dt.Rows[0]["CarID"].ToString();
                        this.txtOperID.Text = dt.Rows[0]["OperName"].ToString();
                        this.txtOperID.ToolTip = dt.Rows[0]["OperID"].ToString();          
                        this.txtCjh.Text = dt.Rows[0]["Cjh"].ToString();
                        this.txtShenQingLiYong.Text = dt.Rows[0]["ShenQingLiYong"].ToString();
                       
                    }
                }
                else
                {
                    toolQingKong_Click(null, null);
                }
            
        }
        private void toolSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("（A类）沈阳机动车司法鉴定所,中标！");
            MessageBox.Show("（B类）唐山宏基司法鉴定中心,中标！");
            this.Close();
            return;
            string sError = "";
            string ID, BNO, CarNO, CarID, A_CpXh, Fdjh, Cjh, DjzcrqDate, GongLiShuNum, ZhangMianYuanZhi, ZhangMianJingZhi, BaoFeiHuiShouGongSi, CanZhiShuXing, ShenQingLiYong, ShenQingDanWeiYiJian, ShenQingDate, ShenQingDanWeiFaRen, JiShuChuYiJian, JiShuChuDate, CaiWuBuYiJian, CaiWuBuDate, Demo, State, OperID, OperName, DeptID, DeptName;
            ID=sID;
            CarNO=this.txtCarID.ToolTip;
            CarID=this.txtCarID.Text.Trim();
            Cjh=this.txtCjh.Text.Trim();    
            ShenQingLiYong=this.txtShenQingLiYong.Text.Trim();  
            OperID=this.txtOperID.ToolTip;
            OperName=this.txtOperID.Text.Trim();
            DeptID = Program.sDeptID;
            DeptName = Program.sDeptName;
            if(CarNO.Trim()=="")
            {
                MessageBox.Show("演示项目，仅供参考", "提示");
                //MessageBox.Show("请输入车辆档案里，存在的车辆信息！！！","提示");
                return;
            }
            StringBuilder strSql = new StringBuilder();
            if (sID.Trim() == "")
            {
                strSql = new StringBuilder();
                strSql.Append("insert into T_CarBaoFei(");
                strSql.Append("BNO,CarNO,CarID,A_CpXh,Fdjh,Cjh,DjzcrqDate,GongLiShuNum,ZhangMianYuanZhi,ZhangMianJingZhi,BaoFeiHuiShouGongSi,CanZhiShuXing,ShenQingLiYong,ShenQingDanWeiYiJian,ShenQingDate,ShenQingDanWeiFaRen,Demo,State,OperID,OperName,DeptID,DeptName)");
                strSql.Append(" values (");
                strSql.Append("@BNO,@CarNO,@CarID,@A_CpXh,@Fdjh,@Cjh,@DjzcrqDate,@GongLiShuNum,@ZhangMianYuanZhi,@ZhangMianJingZhi,@BaoFeiHuiShouGongSi,@CanZhiShuXing,@ShenQingLiYong,@ShenQingDanWeiYiJian,@ShenQingDate,@ShenQingDanWeiFaRen,@Demo,@State,@OperID,@OperName,@DeptID,@DeptName)");
                strSql.Append(";select @@IDENTITY");
                SqlParameter[] parameters = {
					new SqlParameter("@BNO", SqlDbType.VarChar,500),
					new SqlParameter("@CarNO", SqlDbType.VarChar,50),
					new SqlParameter("@CarID", SqlDbType.VarChar,5000),
					new SqlParameter("@A_CpXh", SqlDbType.VarChar,5000),
					new SqlParameter("@Fdjh", SqlDbType.VarChar,5000),
					new SqlParameter("@Cjh", SqlDbType.VarChar,5000),
					new SqlParameter("@DjzcrqDate", SqlDbType.DateTime),
					new SqlParameter("@GongLiShuNum", SqlDbType.Decimal,9),
					new SqlParameter("@ZhangMianYuanZhi", SqlDbType.VarChar,5000),
					new SqlParameter("@ZhangMianJingZhi", SqlDbType.VarChar,5000),
					new SqlParameter("@BaoFeiHuiShouGongSi", SqlDbType.VarChar,5000),
					new SqlParameter("@CanZhiShuXing", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingLiYong", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingDanWeiYiJian", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingDate", SqlDbType.DateTime),
					new SqlParameter("@ShenQingDanWeiFaRen", SqlDbType.VarChar,5000),
					new SqlParameter("@Demo", SqlDbType.VarChar,5000),
					new SqlParameter("@State", SqlDbType.VarChar,500),
					new SqlParameter("@OperID", SqlDbType.VarChar,500),
					new SqlParameter("@OperName", SqlDbType.VarChar,500),
					new SqlParameter("@DeptID", SqlDbType.VarChar,500),
					new SqlParameter("@DeptName", SqlDbType.VarChar,500)};
                //parameters[0].Value =  BNO;
                parameters[1].Value =  CarNO;
                parameters[2].Value =  CarID;
                //parameters[3].Value =  A_CpXh;
                //parameters[4].Value =  Fdjh;
                parameters[5].Value =  Cjh;
                parameters[6].Value =  DjzcrqDate;
                //parameters[7].Value =  GongLiShuNum;
                //parameters[8].Value =  ZhangMianYuanZhi;
                //parameters[9].Value =  ZhangMianJingZhi;
                //parameters[10].Value =  BaoFeiHuiShouGongSi;
              //  parameters[11].Value =  CanZhiShuXing;
                parameters[12].Value =  ShenQingLiYong;
               // parameters[13].Value =  ShenQingDanWeiYiJian;
                //parameters[14].Value =  ShenQingDate;
                //parameters[15].Value =  ShenQingDanWeiFaRen;
                parameters[16].Value =  Demo;
                parameters[17].Value =  State;
                parameters[18].Value =  OperID;
                parameters[19].Value =  OperName;
                parameters[20].Value =  DeptID;
                parameters[21].Value =  DeptName;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);
                if(sError.Trim()!="")
                {
                    MessageBox.Show("演示项目，仅供参考", "提示");
                    // MessageBox.Show("保存失败，错误："+sError, "提示");
                    return;
                }
                //清空
                // this.toolQingKong_Click(null, null);
            }else{
                strSql = new StringBuilder();
                strSql.Append("update T_CarBaoFei set ");
                strSql.Append("BNO=@BNO,");
                strSql.Append("CarNO=@CarNO,");
                strSql.Append("CarID=@CarID,");
                strSql.Append("A_CpXh=@A_CpXh,");
                strSql.Append("Fdjh=@Fdjh,");
                strSql.Append("Cjh=@Cjh,");
                strSql.Append("DjzcrqDate=@DjzcrqDate,");
                strSql.Append("GongLiShuNum=@GongLiShuNum,");
                strSql.Append("ZhangMianYuanZhi=@ZhangMianYuanZhi,");
                strSql.Append("ZhangMianJingZhi=@ZhangMianJingZhi,");
                strSql.Append("BaoFeiHuiShouGongSi=@BaoFeiHuiShouGongSi,");
                strSql.Append("CanZhiShuXing=@CanZhiShuXing,");
                strSql.Append("ShenQingLiYong=@ShenQingLiYong,");
                strSql.Append("ShenQingDanWeiYiJian=@ShenQingDanWeiYiJian,");
                strSql.Append("ShenQingDate=@ShenQingDate,");
                strSql.Append("ShenQingDanWeiFaRen=@ShenQingDanWeiFaRen,");
                strSql.Append("Demo=@Demo");
                strSql.Append(" where ID=@ID");
                SqlParameter[] parameters = {
					new SqlParameter("@BNO", SqlDbType.VarChar,500),
					new SqlParameter("@CarNO", SqlDbType.VarChar,50),
					new SqlParameter("@CarID", SqlDbType.VarChar,5000),
					new SqlParameter("@A_CpXh", SqlDbType.VarChar,5000),
					new SqlParameter("@Fdjh", SqlDbType.VarChar,5000),
					new SqlParameter("@Cjh", SqlDbType.VarChar,5000),
					new SqlParameter("@DjzcrqDate", SqlDbType.DateTime),
					new SqlParameter("@GongLiShuNum", SqlDbType.Decimal,9),
					new SqlParameter("@ZhangMianYuanZhi", SqlDbType.VarChar,5000),
					new SqlParameter("@ZhangMianJingZhi", SqlDbType.VarChar,5000),
					new SqlParameter("@BaoFeiHuiShouGongSi", SqlDbType.VarChar,5000),
					new SqlParameter("@CanZhiShuXing", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingLiYong", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingDanWeiYiJian", SqlDbType.VarChar,5000),
					new SqlParameter("@ShenQingDate", SqlDbType.DateTime),
					new SqlParameter("@ShenQingDanWeiFaRen", SqlDbType.VarChar,5000),
					new SqlParameter("@Demo", SqlDbType.VarChar,5000),
					new SqlParameter("@ID", SqlDbType.BigInt,8)};
                //parameters[0].Value =  BNO;
                parameters[1].Value =  CarNO;
                parameters[2].Value =  CarID;
                //parameters[3].Value =  A_CpXh;
                //parameters[4].Value =  Fdjh;
                parameters[5].Value =  Cjh;
                parameters[6].Value =  DjzcrqDate;
                //parameters[7].Value =  GongLiShuNum;
                //parameters[8].Value =  ZhangMianYuanZhi;
                //parameters[9].Value =  ZhangMianJingZhi;
                //parameters[10].Value =  BaoFeiHuiShouGongSi;
                //parameters[11].Value =  CanZhiShuXing;
                parameters[12].Value =  ShenQingLiYong;
                //parameters[13].Value =  ShenQingDanWeiYiJian;
                //parameters[14].Value =  ShenQingDate;
                //parameters[15].Value =  ShenQingDanWeiFaRen;
                parameters[16].Value =  Demo;
                parameters[17].Value =  ID;
                SqlHelper.ExecuteNonQuery(CommandType.Text, strSql.ToString(), parameters, out sError);
                if (sError.Trim() != "")
                {
                    MessageBox.Show("演示项目，仅供参考", "提示");
                   // MessageBox.Show("保存失败，错误：" + sError, "提示");
                    return;
                }
               
               // this.Close();
            }
            switch (((SimpleButton)sender).Text.Trim())
            {
                case "保存继续":
                    toolQingKong_Click(null, null);
                    break;
                case "保存退出":
                    this.Close();
                    break;
            }
        }

        private void toolQingKong_Click(object sender, EventArgs e)
        {
            sID = "";
            this.txtCarID.Text = "";
            this.txtCarID.ToolTip = ""; 
            this.txtCjh.Text = Program.sDeptName;
           // this.txtDemo.Text = "";
            this.txtOperID.Text = "";
            //this.txtShenQingLiYong.Text = "";
            //this.dtpDjzcrqDate.Text = "";
            this.txtOperID.Text = Program.sOperName;
            this.txtOperID.ToolTip = Program.sOperID;
            this.txtCarID.Focus();
            this.txtCarID.Select(2, 1);
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
            sCon = " and DeptID like '" + Program.sDeptID + "' "+sCon;
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
            sCon += " and CarNO like '%"+sCarNO+"%' ";
            string strSql = "select * from T_CarBaoFei where 1=1  " + sCon + " ";
            DataTable dt = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
            if(sError.Trim()==""&&dt.Rows.Count>0)
            {
                return true;
            }
            return false;
        }


        private void grd_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if(e.KeyChar==13)
            {
                try
                {
                    //groupControlGv.Visible = false;
                    //this.txtCarID.ToolTip = gv.GetDataRow(gv.FocusedRowHandle)["CarNO"].ToString();
                    if(IsExistsCar(this.txtCarID.ToolTip.Trim()))
                    {
                        MessageBox.Show("演示项目，仅供参考", "提示");
                        //MessageBox.Show("该车已做报废申请，请查询！","提示");
                        return;
                    }

                    //this.txtCarID.Text = gv.GetDataRow(gv.FocusedRowHandle)["CarID"].ToString();
                    //this.txtA_CpXh.Text = gv.GetDataRow(gv.FocusedRowHandle)["A_CpXh"].ToString();
                    //this.txtFdjh.Text = gv.GetDataRow(gv.FocusedRowHandle)["Fdjh"].ToString();
                    //this.txtCjh.Text = gv.GetDataRow(gv.FocusedRowHandle)["Cjh"].ToString();
                    //this.dtpDjzcrqDate.Text = gv.GetDataRow(gv.FocusedRowHandle)["DjzcrqDate"].ToString();
                    //this.txtBNO.Text = this.txtCarID.ToolTip;
                   // this.dtpLrDate.Focus();
                    //MessageBox.Show("提示成功！","提示");
                }
                catch { 
                    this.txtCarID.ToolTip = "";
                    this.txtCarID.Focus();
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


        private void langed(object sender, EventArgs e)
        {

        }

        private void checkedListBoxControl1_CheckMemberChanged(object sender, EventArgs e)
        {

        }

        private void btn_mx_CheckedChanged(object sender, EventArgs e)
        {
            string sError = "";
            //清空项
            checkedListBoxControl2.Items.Clear();
            checkedListBoxControl2.DataSource = null;
            //是否点击一次 就改变状态
            checkedListBoxControl2.CheckOnClick = true;
            //是否多列显示
            checkedListBoxControl2.MultiColumn = true;

            int count = this.checkedListBoxControl1.CheckedItems.Count;

            if (count> 0)
            {
                string strSql = "";
                foreach (DataRowView item in this.checkedListBoxControl1.CheckedItems)
                {
                    strSql += $"(select * from T_XiangMu where BaoTypeId={item[0].ToString()})union all";
                   
                }
                if (strSql != null)
                {
                    strSql = "select ('('+t.Bao_Name+')'+a.XiangMuName)title,* from(" + strSql.Substring(0, strSql.Length - 9) + ") a join T_BaoType t on a.BaoTypeId=t.Bao_TypeId ";
                   
                    //自定义一个表
                    DataTable dt2 = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

                    //绑定
                    checkedListBoxControl2.DataSource = dt2;
                    checkedListBoxControl2.ValueMember = "XiangMuNo";
                    checkedListBoxControl2.DisplayMember = "title";
                }
               
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
           // if (comboBox1.SelectedValue==null)
           //     return; 

           //this.txtShenQingLiYong.Text=SqlHelper.ExecuteScalar(CommandType.Text, $"select MuBanDesc from T_MuBan where MuBanId={comboBox1.SelectedValue.ToString()}", null).ToString();


        }
    }
    }
