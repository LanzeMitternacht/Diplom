namespace FlowersShop
{
    partial class SellProduct
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
            this.BSell = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBCount = new System.Windows.Forms.TextBox();
            this.BClose = new System.Windows.Forms.Button();
            this.TBStaff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBVisitor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BSell
            // 
            this.BSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BSell.Location = new System.Drawing.Point(38, 195);
            this.BSell.Name = "BSell";
            this.BSell.Size = new System.Drawing.Size(99, 43);
            this.BSell.TabIndex = 0;
            this.BSell.Text = "Принять";
            this.BSell.UseVisualStyleBackColor = true;
            this.BSell.Click += new System.EventHandler(this.BSell_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(42, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество";
            // 
            // TBCount
            // 
            this.TBCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBCount.Location = new System.Drawing.Point(141, 43);
            this.TBCount.Name = "TBCount";
            this.TBCount.Size = new System.Drawing.Size(166, 26);
            this.TBCount.TabIndex = 2;
            // 
            // BClose
            // 
            this.BClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BClose.Location = new System.Drawing.Point(175, 195);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(99, 43);
            this.BClose.TabIndex = 3;
            this.BClose.Text = "Отменить";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // TBStaff
            // 
            this.TBStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBStaff.Location = new System.Drawing.Point(141, 92);
            this.TBStaff.Name = "TBStaff";
            this.TBStaff.Size = new System.Drawing.Size(166, 26);
            this.TBStaff.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(42, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Продавец";
            // 
            // TBVisitor
            // 
            this.TBVisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBVisitor.Location = new System.Drawing.Point(141, 141);
            this.TBVisitor.Name = "TBVisitor";
            this.TBVisitor.Size = new System.Drawing.Size(166, 26);
            this.TBVisitor.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(42, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Покупатель";
            // 
            // SellProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 261);
            this.Controls.Add(this.TBVisitor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBStaff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BClose);
            this.Controls.Add(this.TBCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BSell);
            this.Name = "SellProduct";
            this.Text = "SellProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BSell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBCount;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.TextBox TBStaff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBVisitor;
        private System.Windows.Forms.Label label3;
    }
}