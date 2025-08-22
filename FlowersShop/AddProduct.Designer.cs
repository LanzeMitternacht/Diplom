namespace FlowersShop
{
    partial class AddProduct
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
            this.TBName = new System.Windows.Forms.TextBox();
            this.BClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TBPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BEnter
            // 
            this.BEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEnter.Location = new System.Drawing.Point(28, 294);
            this.BEnter.Name = "BEnter";
            this.BEnter.Size = new System.Drawing.Size(104, 40);
            this.BEnter.TabIndex = 0;
            this.BEnter.Text = "Принять";
            this.BEnter.UseVisualStyleBackColor = true;
            this.BEnter.Click += new System.EventHandler(this.BEnter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBName.Location = new System.Drawing.Point(167, 41);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(166, 26);
            this.TBName.TabIndex = 2;
            // 
            // BClose
            // 
            this.BClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BClose.Location = new System.Drawing.Point(208, 294);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(104, 40);
            this.BClose.TabIndex = 3;
            this.BClose.Text = "Закрыть";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Тип";
            // 
            // TBPrice
            // 
            this.TBPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBPrice.Location = new System.Drawing.Point(167, 153);
            this.TBPrice.Name = "TBPrice";
            this.TBPrice.Size = new System.Drawing.Size(166, 26);
            this.TBPrice.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(44, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Количество";
            // 
            // TBCount
            // 
            this.TBCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBCount.Location = new System.Drawing.Point(167, 208);
            this.TBCount.Name = "TBCount";
            this.TBCount.Size = new System.Drawing.Size(166, 26);
            this.TBCount.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(44, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Цена";
            // 
            // CBType
            // 
            this.CBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBType.FormattingEnabled = true;
            this.CBType.Location = new System.Drawing.Point(167, 98);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(165, 28);
            this.CBType.TabIndex = 10;
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 358);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.TBCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BClose);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BEnter);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BEnter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CBType;
    }
}