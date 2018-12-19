namespace AdvanceDB
{
    partial class KiemTraSach
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
            this.dgvKiemTraSach = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnMuon = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.btnTracuu = new System.Windows.Forms.Button();
            this.lblMa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTraSach)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvKiemTraSach
            // 
            this.dgvKiemTraSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKiemTraSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKiemTraSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKiemTraSach.Location = new System.Drawing.Point(193, 0);
            this.dgvKiemTraSach.MultiSelect = false;
            this.dgvKiemTraSach.Name = "dgvKiemTraSach";
            this.dgvKiemTraSach.ReadOnly = true;
            this.dgvKiemTraSach.Size = new System.Drawing.Size(559, 218);
            this.dgvKiemTraSach.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHuy);
            this.panel1.Controls.Add(this.btnMuon);
            this.panel1.Controls.Add(this.txtMa);
            this.panel1.Controls.Add(this.btnTracuu);
            this.panel1.Controls.Add(this.lblMa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 218);
            this.panel1.TabIndex = 2;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(127, 183);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(60, 23);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnMuon
            // 
            this.btnMuon.Location = new System.Drawing.Point(3, 183);
            this.btnMuon.Name = "btnMuon";
            this.btnMuon.Size = new System.Drawing.Size(60, 23);
            this.btnMuon.TabIndex = 4;
            this.btnMuon.Text = "Mượn";
            this.btnMuon.UseVisualStyleBackColor = true;
            this.btnMuon.Click += new System.EventHandler(this.btnMuon_ClickAsync);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(66, 15);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(100, 20);
            this.txtMa.TabIndex = 3;
            // 
            // btnTracuu
            // 
            this.btnTracuu.Location = new System.Drawing.Point(66, 183);
            this.btnTracuu.Name = "btnTracuu";
            this.btnTracuu.Size = new System.Drawing.Size(60, 23);
            this.btnTracuu.TabIndex = 2;
            this.btnTracuu.Text = "Tra cứu";
            this.btnTracuu.UseVisualStyleBackColor = true;
            this.btnTracuu.Click += new System.EventHandler(this.btnTracuu_ClickAsync);
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(12, 18);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(48, 13);
            this.lblMa.TabIndex = 1;
            this.lblMa.Text = "Mã sách";
            // 
            // KiemTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 218);
            this.Controls.Add(this.dgvKiemTraSach);
            this.Controls.Add(this.panel1);
            this.Name = "KiemTraSach";
            this.Text = "Danh sách Sách";
            this.Activated += new System.EventHandler(this.KiemTraSach_Load);
            this.Load += new System.EventHandler(this.KiemTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKiemTraSach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKiemTraSach;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTracuu;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnMuon;
    }
}