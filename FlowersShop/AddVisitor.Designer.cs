namespace FlowersShop
{
    partial class AddVisitor
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
            this.BEnter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBFName = new System.Windows.Forms.TextBox();
            this.BClose = new System.Windows.Forms.Button();
            this.TBSName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBCount = new System.Windows.Forms.TextBox();
            this.LCount = new System.Windows.Forms.Label();
            this.CheckDiscount = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BEnter
            // 
            this.BEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEnter.Location = new System.Drawing.Point(40, 233);
            this.BEnter.Name = "BEnter";
            this.BEnter.Size = new System.Drawing.Size(107, 45);
            this.BEnter.TabIndex = 0;
            this.BEnter.Text = "Принять";
            this.BEnter.UseVisualStyleBackColor = true;
            this.BEnter.Click += new System.EventHandler(this.BEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фамилия";
            // 
            // TBFName
            // 
            this.TBFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBFName.Location = new System.Drawing.Point(152, 29);
            this.TBFName.Name = "TBFName";
            this.TBFName.Size = new System.Drawing.Size(158, 26);
            this.TBFName.TabIndex = 2;
            // 
            // BClose
            // 
            this.BClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BClose.Location = new System.Drawing.Point(182, 233);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(107, 45);
            this.BClose.TabIndex = 3;
            this.BClose.Text = "Отменить";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // TBSName
            // 
            this.TBSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBSName.Location = new System.Drawing.Point(152, 89);
            this.TBSName.Name = "TBSName";
            this.TBSName.Size = new System.Drawing.Size(158, 26);
            this.TBSName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Имя";
            // 
            // TBCount
            // 
            this.TBCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBCount.Location = new System.Drawing.Point(152, 135);
            this.TBCount.Name = "TBCount";
            this.TBCount.Size = new System.Drawing.Size(158, 26);
            this.TBCount.TabIndex = 7;
            this.TBCount.Visible = false;
            // 
            // LCount
            // 
            this.LCount.AutoSize = true;
            this.LCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LCount.Location = new System.Drawing.Point(21, 138);
            this.LCount.Name = "LCount";
            this.LCount.Size = new System.Drawing.Size(126, 20);
            this.LCount.TabIndex = 6;
            this.LCount.Text = "Кол посещений";
            this.LCount.Visible = false;
            // 
            // CheckDiscount
            // 
            this.CheckDiscount.AutoSize = true;
            this.CheckDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckDiscount.Location = new System.Drawing.Point(124, 186);
            this.CheckDiscount.Name = "CheckDiscount";
            this.CheckDiscount.Size = new System.Drawing.Size(84, 24);
            this.CheckDiscount.TabIndex = 8;
            this.CheckDiscount.Text = "Скидка";
            this.CheckDiscount.UseVisualStyleBackColor = true;
            this.CheckDiscount.Visible = false;
            // 
            // AddVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 290);
            this.Controls.Add(this.CheckDiscount);
            this.Controls.Add(this.TBCount);
            this.Controls.Add(this.LCount);
            this.Controls.Add(this.TBSName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BClose);
            this.Controls.Add(this.TBFName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BEnter);
            this.Name = "AddVisitor";
            this.Text = "AddVisitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBFName;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.TextBox TBSName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBCount;
        private System.Windows.Forms.Label LCount;
        private System.Windows.Forms.CheckBox CheckDiscount;
    }
}