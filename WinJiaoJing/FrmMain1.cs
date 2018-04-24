using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinJiaoJing
{
    public partial class FrmMain1 : Form
    {
        public FrmMain1()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                //if (Program.sOperID.Trim() == "admin")
                //{
                    //barQx.Enabled = true;
                    //brahw.Enabled = true;
                //}
                //else
                //{
                //    barQx.Enabled = false;
                //    brahw.Enabled = false;
                //}
                barInfo.Caption = "部门：" + Program.sDeptName + "        登陆人：" + Program.sOperID + " | " + Program.sOperName;
                try
                {
                    this.treeView1.Nodes[0].Expand();
                    this.treeView1.Nodes[3].Expand();
                }
                catch { }
               

                Form1 childForm = new Form1();
                childForm.MdiParent = this;
                childForm.Text = "我的桌面";
                childForm.Show();


                string sError = "";
                string sql = $"select AnQingDate,insDate from T_AnQing where DeftName='{ Program.sDeptName}' and OperName='{Program.sOperName}' and State='进行中'";

                string sumdate= "";
                string _sumdate = "";
                DataTable tbDate = SqlHelper.RunQuery(CommandType.Text, sql, null,out sError);
                if (tbDate.Rows.Count!=0)
                {
                    int cha = 0;
                    for (int i = 0; i < tbDate.Rows.Count; i++)
                    {
                        cha = CommonInfo.DateDiff(Convert.ToDateTime(tbDate.Rows[i]["insDate"]), DateTime.Now);

                        
                        if (cha >= 20)
                        {

                            sumdate=Convert.ToDateTime(tbDate.Rows[i]["AnQingDate"]).ToString("M月");

                            if (sumdate!=_sumdate)
                            {
                                MessageBox.Show(sumdate+"有正在进行中的检测项以超过20天,请尽快处理！","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                _sumdate = sumdate;
                            }   
                         
                        }

                    }
                   
                }

                if (Program.sRoleID == "003")
                {
                    FrmBaoFeiEdit bf = new FrmBaoFeiEdit();
                    bf.ShowDialog();
                }


                               

                //菜单权限读取
                
                string sRoleID = Program.sRoleID;
                string strSql = "SELECT *,TQx_Menu.TreeNodeName FROM TQx_RoleQx left join TQx_Menu on TQx_Menu.MenuID=TQx_RoleQx.MenuID  WHERE IsQx=1 and TQx_Menu.TreeNodeName<>'' and  RoleID='" + sRoleID + "' order by TQx_Menu.SortID ";
                DataTable dtQx = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);
                
                if (Program.sOperID.Trim() != "admin")
                {
                    LoadTreeViewQx(treeView1.Nodes[0], dtQx.DefaultView, CommonInfo.CLng(treeView1.Nodes[0].Tag));
                    LoadTreeViewQx(treeView1.Nodes[1], dtQx.DefaultView, CommonInfo.CLng(treeView1.Nodes[1].Tag));

                }
                else
                {
                    //treeView1.Nodes.Clear();
                }
            }
            catch { }

            try
            {
                string sError = "";
                string strSql = "select * from T_BanBen where 1=1";
                DataTable dtInit = SqlHelper.RunQuery(CommandType.Text, strSql, null, out sError);

                barButtonItem9.Caption = dtInit.Rows[0]["BanBenDesc"].ToString();
                if (dtInit.Rows[0]["BanBenDesc"].ToString().Trim() != Program.sVersion)
                {
                    MessageBox.Show("您的当前版本不是最新版本，请更新到最新版本[" + dtInit.Rows[0]["BanBenDesc"].ToString().Trim() + "]！", "提示");
                    this.Close();
                }
            }
            catch { barButtonItem9.Caption = "       "; }


        }

        public void LoadTreeViewQx(TreeNode tnode, DataView dvQx, int iLen)
        {
            tnode.Nodes.Clear();
            DataView dv = dvQx;
            dv.RowFilter = " MenuID  like '" + tnode.ToolTipText.Trim() + "%'  and  Len(MenuID) >= " + iLen;
            try
            {
                for (int i = 0; i < dv.ToTable().Rows.Count; i++)
                {
                    TreeNode tn = new TreeNode();
                    tn.SelectedImageIndex = 4;
                    tn.ImageIndex = 3;
                    tn.Text = dv.ToTable().Rows[i]["TreeNodeName"].ToString();
                    tnode.Nodes.Add(tn);
                }
            }
            catch { }

        }

        public Boolean IsExistsForm(string sFormTitle)
        {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
                if (this.MdiChildren[i].Text.Trim() == sFormTitle)
                {
                    this.MdiChildren[i].Activate();
                    return true;
                }
            }
            return false;
        }
        public void ShowMenu(string sPMenuName, string sMenuName)
        {
            switch (sPMenuName)
            {



                case "案件管理":
                    switch (sMenuName)
                    {

                        case "案情录入":
                            if (IsExistsForm("案情录入"))
                                return;
                            FrmBaoFeiList FrmBaoFeiList = new FrmBaoFeiList();
                            FrmBaoFeiList.MdiParent = this;
                            FrmBaoFeiList.Text = "案情录入";
                            FrmBaoFeiList.Show();
                            break;
                        case "案情管理":
                            if (IsExistsForm("案情管理"))
                                return;
                            FrmAnQing FrmAnQing = new FrmAnQing();
                            FrmAnQing.MdiParent = this;
                            FrmAnQing.Text = "案情管理";
                            FrmAnQing.Show();
                            break;

                    }
                    break;

                case "统计报表":
                    switch (sMenuName)
                    {

                        case "交通事故案件统计报表":
                            if (IsExistsForm("交通事故案件统计报表"))
                                return;
                            FrmTJCount FrmBao = new FrmTJCount();
                            FrmBao.MdiParent = this;
                            FrmBao.Text = "交通事故案件统计报表";
                            FrmBao.Show();
                            break;
                        case "招标公司中标次数统计报表":
                            if (IsExistsForm("招标公司中标次数统计报表"))
                                return;
                            FrmTJtop FrmBao1 = new FrmTJtop();
                            FrmBao1.MdiParent = this;
                            FrmBao1.Text = "招标公司中标次数统计报表";
                            FrmBao1.Show();
                            break;

                        case "死亡人数统计表":
                            if (IsExistsForm("死亡人数统计表"))
                                return;
                            FrmTJDie FrmBao12 = new FrmTJDie();
                            FrmBao12.MdiParent = this;
                            FrmBao12.Text = "死亡人数统计表";
                            FrmBao12.Show();
                            break;


                    }
                    break;


                case "系统设置":
                    switch (sMenuName)
                    {
                        case "修改密码":
                            FrmOperPwdEdit FrmOperPwdEdit = new FrmOperPwdEdit();
                            FrmOperPwdEdit.ShowDialog();
                            break;
                    }
                    break;
                case "权限管理":
                    switch (sMenuName)
                    {
                        case "操作员管理":
                            if (IsExistsForm("操作员管理"))
                                return;
                            FrmOper childForm = new FrmOper();
                            childForm.MdiParent = this;
                            childForm.Text = "操作员管理";
                            childForm.Show();
                            break;
                        case "角色管理":
                            if (IsExistsForm("角色管理"))
                                return;
                            FrmRole FrmRole = new FrmRole();
                            FrmRole.MdiParent = this;
                            FrmRole.Text = "角色管理";
                            FrmRole.Show();
                            break;
                        case "权限管理":
                            if (IsExistsForm("权限管理"))
                                return;
                            FrmRoleQxEdit FrmRoleQxEdit = new FrmRoleQxEdit();
                            FrmRoleQxEdit.MdiParent = this;
                            FrmRoleQxEdit.Text = "权限管理";
                            FrmRoleQxEdit.Show();
                            break;
                        case "部门管理":
                            if (IsExistsForm("部门管理"))
                                return;
                            FrmDept FrmDept = new FrmDept();
                            FrmDept.MdiParent = this;
                            FrmDept.Text = "部门管理";
                            FrmDept.Show();
                            break;
                    }
                    break;
                case "信息维护":
                    switch (sMenuName)
                    {

                        case "包鉴定项目维护":
                            if (IsExistsForm("包鉴定项目维护"))
                                return;
                            FrmBao FrmBao = new FrmBao();
                            FrmBao.MdiParent = this;
                            FrmBao.Text = "包鉴定项目维护";
                            FrmBao.Show();
                            break;
                        case "检验项目维护":
                            if (IsExistsForm("检验项目维护"))
                                return;
                            FrmCarShuXing CarShuXing = new FrmCarShuXing();
                            CarShuXing.MdiParent = this;
                            CarShuXing.Text = "检验项目维护";
                            CarShuXing.Show();
                            break;
                        case "鉴定机构维护":
                            if (IsExistsForm("鉴定机构维护"))
                                return;
                            FrmGongSi FrmGongSi = new FrmGongSi();
                            FrmGongSi.MdiParent = this;
                            FrmGongSi.Text = "鉴定机构维护";
                            FrmGongSi.Show();
                            break;
                        case "案件详情母版维护":
                            if (IsExistsForm("案件详情母版维护"))
                                return;
                            FrmMuBan FrmMuBan = new FrmMuBan();
                            FrmMuBan.MdiParent = this;
                            FrmMuBan.Text = "案件详情母版维护";
                            FrmMuBan.Show();
                            break;
                        case "案发地点维护":
                            if (IsExistsForm("案发地点维护"))
                                return;
                            FrmDiDian FrmDiDian = new FrmDiDian();
                            FrmDiDian.MdiParent = this;
                            FrmDiDian.Text = "案发地点维护";
                            FrmDiDian.Show();
                            break;

                    }
                    break;


                case "高级维护":
                    switch (sMenuName)
                    {
                        case "高级鉴定机构维护":
                            if (IsExistsForm("高级鉴定机构维护"))
                                return;
                            FrmGG GG = new FrmGG();
                            GG.MdiParent = this;
                            GG.Text = "高级鉴定机构维护";
                            GG.Show();
                            break;
                    }

                    break;

                    switch (sMenuName)
                    {
                        case "关于":
                            FrmAbout FrmAbout = new FrmAbout();
                            FrmAbout.ShowDialog();
                            break;
                    }
                    break;

            }
        }

        //权限
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string sMenu = e.Item.Tag.ToString();
            ShowMenu(sMenu.Split('|')[0].ToString(), sMenu.Split('|')[1].ToString());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ShowMenu(treeView1.SelectedNode.Parent.Text.Trim(), treeView1.SelectedNode.Text.Trim());
            }
            catch { }

        }

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            //if(e.Page.Text.Trim()=="我的桌面")
            //{
            //    Form1 Form1 = new Form1();
            //    Form1.MdiParent = this;
            //    Form1.Text = "我的桌面";
            //    Form1.Show();
            //}
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    ShowMenu(treeView1.SelectedNode.Parent.Text.Trim(), treeView1.SelectedNode.Text.Trim());
            //}
            //catch { }
        }

        private void barClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItemAllClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            xtraTabbedMdiManager1.Pages.Clear();
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
            Form1 childForm = new Form1();
            childForm.MdiParent = this;
            childForm.Text = "我的桌面";
            childForm.Show();

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //try
            //{
            //    ShowMenu(treeView1.SelectedNode.Parent.Text.Trim(), treeView1.SelectedNode.Text.Trim());
            //}
            //catch { }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
