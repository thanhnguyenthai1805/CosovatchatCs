namespace QuanLyCoSoVatChat
{
    partial class FrmDangnhap
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTendangnhap = new TextBox();
            txtMatkhau = new TextBox();
            btnDangnhap = new Button();
            btnThoatdangnhap = new Button();
            panel1 = new Panel();
            label4 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 221);
            label1.Name = "label1";
            label1.Size = new Size(179, 31);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 292);
            label2.Name = "label2";
            label2.Size = new Size(129, 31);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaption;
            label3.Font = new Font("Arial Rounded MT Bold", 25.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.InactiveBorder;
            label3.Location = new Point(20, 15);
            label3.Name = "label3";
            label3.Size = new Size(527, 51);
            label3.TabIndex = 2;
            label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            label3.Click += label3_Click;
            // 
            // txtTendangnhap
            // 
            txtTendangnhap.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTendangnhap.Location = new Point(228, 221);
            txtTendangnhap.Name = "txtTendangnhap";
            txtTendangnhap.Size = new Size(451, 34);
            txtTendangnhap.TabIndex = 3;
            txtTendangnhap.TextChanged += txtTendangnhap_TextChanged;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMatkhau.Location = new Point(228, 303);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(453, 34);
            txtMatkhau.TabIndex = 4;
            txtMatkhau.UseSystemPasswordChar = true;
            // 
            // btnDangnhap
            // 
            btnDangnhap.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangnhap.Location = new Point(486, 430);
            btnDangnhap.Name = "btnDangnhap";
            btnDangnhap.Size = new Size(154, 46);
            btnDangnhap.TabIndex = 5;
            btnDangnhap.Text = "Đăng nhập";
            btnDangnhap.UseVisualStyleBackColor = true;
            btnDangnhap.Click += btnDangnhap_Click;
            // 
            // btnThoatdangnhap
            // 
            btnThoatdangnhap.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoatdangnhap.Location = new Point(665, 430);
            btnThoatdangnhap.Name = "btnThoatdangnhap";
            btnThoatdangnhap.Size = new Size(124, 46);
            btnThoatdangnhap.TabIndex = 6;
            btnThoatdangnhap.Text = "Thoát";
            btnThoatdangnhap.UseVisualStyleBackColor = true;
            btnThoatdangnhap.Click += btnThoatdangnhap_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.ForeColor = SystemColors.ActiveCaption;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 129);
            panel1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(20, 66);
            label4.Name = "label4";
            label4.Size = new Size(769, 43);
            label4.TabIndex = 3;
            label4.Text = "QUẢN LÝ CƠ SỞ VẬT CHẤT NHÀ TRƯỜNG";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.MenuBar;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(pictureBox1);
            flowLayoutPanel1.Location = new Point(12, 147);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(798, 336);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.hinh_nen_may_tinh_bau_troi;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(794, 523);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmDangnhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 495);
            Controls.Add(label1);
            Controls.Add(btnThoatdangnhap);
            Controls.Add(btnDangnhap);
            Controls.Add(txtMatkhau);
            Controls.Add(txtTendangnhap);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Name = "FrmDangnhap";
            Text = "FrmDangnhap";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTendangnhap;
        private TextBox txtMatkhau;
        private Button btnDangnhap;
        private Button btnThoatdangnhap;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label4;
        public PictureBox pictureBox1;
    }
}