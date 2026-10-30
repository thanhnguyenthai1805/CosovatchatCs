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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(42, 136);
            label1.Name = "label1";
            label1.Size = new Size(179, 31);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(92, 220);
            label2.Name = "label2";
            label2.Size = new Size(129, 31);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(158, 21);
            label3.Name = "label3";
            label3.Size = new Size(447, 50);
            label3.TabIndex = 2;
            label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // txtTendangnhap
            // 
            txtTendangnhap.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTendangnhap.Location = new Point(227, 136);
            txtTendangnhap.Name = "txtTendangnhap";
            txtTendangnhap.Size = new Size(339, 34);
            txtTendangnhap.TabIndex = 3;
            txtTendangnhap.TextChanged += txtTendangnhap_TextChanged;
            // 
            // txtMatkhau
            // 
            txtMatkhau.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMatkhau.Location = new Point(227, 220);
            txtMatkhau.Name = "txtMatkhau";
            txtMatkhau.Size = new Size(339, 34);
            txtMatkhau.TabIndex = 4;
            txtMatkhau.UseSystemPasswordChar = true;
            // 
            // btnDangnhap
            // 
            btnDangnhap.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangnhap.Location = new Point(236, 287);
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
            btnThoatdangnhap.Location = new Point(442, 287);
            btnThoatdangnhap.Name = "btnThoatdangnhap";
            btnThoatdangnhap.Size = new Size(124, 46);
            btnThoatdangnhap.TabIndex = 6;
            btnThoatdangnhap.Text = "Thoát";
            btnThoatdangnhap.UseVisualStyleBackColor = true;
            btnThoatdangnhap.Click += btnThoatdangnhap_Click;
            // 
            // FrmDangnhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThoatdangnhap);
            Controls.Add(btnDangnhap);
            Controls.Add(txtMatkhau);
            Controls.Add(txtTendangnhap);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmDangnhap";
            Text = "FrmDangnhap";
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
    }
}