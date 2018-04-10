namespace WinJiaoJing.AnJian
{
    partial class FrmPrintAnQing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ckA = new DevExpress.XtraEditors.CheckEdit();
            this.ckB = new DevExpress.XtraEditors.CheckEdit();
            this.ckD = new DevExpress.XtraEditors.CheckEdit();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ckA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckD.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ckA
            // 
            this.ckA.Enabled = false;
            this.ckA.Location = new System.Drawing.Point(70, 53);
            this.ckA.Name = "ckA";
            this.ckA.Properties.Caption = "痕迹检验（A包）";
            this.ckA.Size = new System.Drawing.Size(122, 19);
            this.ckA.TabIndex = 0;
            // 
            // ckB
            // 
            this.ckB.Enabled = false;
            this.ckB.Location = new System.Drawing.Point(70, 98);
            this.ckB.Name = "ckB";
            this.ckB.Properties.Caption = "酒精检验（B包）";
            this.ckB.Size = new System.Drawing.Size(122, 19);
            this.ckB.TabIndex = 0;
            // 
            // ckD
            // 
            this.ckD.Enabled = false;
            this.ckD.Location = new System.Drawing.Point(70, 148);
            this.ckD.Name = "ckD";
            this.ckD.Properties.Caption = "尸体检验（D包）";
            this.ckD.Size = new System.Drawing.Size(122, 19);
            this.ckD.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(80, 208);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "打 印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "请勾选打印项:";
            // 
            // FrmPrintAnQing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.ckD);
            this.Controls.Add(this.ckB);
            this.Controls.Add(this.ckA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmPrintAnQing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择打印包";
            this.Load += new System.EventHandler(this.FrmPrintAnQing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckD.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit ckA;
        private DevExpress.XtraEditors.CheckEdit ckB;
        private DevExpress.XtraEditors.CheckEdit ckD;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
    }
}