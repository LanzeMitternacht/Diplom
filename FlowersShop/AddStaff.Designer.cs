namespace FlowersShop
{
    partial class AddStaff
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
            this.BClose = new System.Windows.Forms.Button();
            this.TBSName = new System.Windows.Forms.TextBox();
            this.TBFName = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.TBPost = new System.Windows.Forms.TextBox();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LPassword = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MaskTBPhone = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // BEnter
            // 
            this.BEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEnter.Location = new System.Drawing.Point(63, 285);
            this.BEnter.Name = "BEnter";
            this.BEnter.Size = new System.Drawing.Size(93, 43);
            this.BEnter.TabIndex = 0;
            this.BEnter.Text = "Принять";
            this.BEnter.UseVisualStyleBackColor = true;
            this.BEnter.Click += new System.EventHandler(this.BEnter_Click);
            // 
            // BClose
            // 
            this.BClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BClose.Location = new System.Drawing.Point(191, 285);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(93, 43);
            this.BClose.TabIndex = 1;
            this.BClose.Text = "Выход";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // TBSName
            // 
            this.TBSName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBSName.Location = new System.Drawing.Point(138, 39);
            this.TBSName.Name = "TBSName";
            this.TBSName.Size = new System.Drawing.Size(219, 26);
            this.TBSName.TabIndex = 2;
            // 
            // TBFName
            // 
            this.TBFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBFName.Location = new System.Drawing.Point(138, 78);
            this.TBFName.Name = "TBFName";
            this.TBFName.Size = new System.Drawing.Size(219, 26);
            this.TBFName.TabIndex = 3;
            // 
            // TBPassword
            // 
            this.TBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBPassword.Location = new System.Drawing.Point(138, 119);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '*';
            this.TBPassword.Size = new System.Drawing.Size(219, 26);
            this.TBPassword.TabIndex = 4;
            // 
            // TBPost
            // 
            this.TBPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBPost.Location = new System.Drawing.Point(138, 155);
            this.TBPost.Name = "TBPost";
            this.TBPost.Size = new System.Drawing.Size(219, 26);
            this.TBPost.TabIndex = 5;
            // 
            // TBEmail
            // 
            this.TBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBEmail.Location = new System.Drawing.Point(138, 226);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(219, 26);
            this.TBEmail.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Фамилия";
            // 
            // LPassword
            // 
            this.LPassword.AutoSize = true;
            this.LPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LPassword.Location = new System.Drawing.Point(38, 122);
            this.LPassword.Name = "LPassword";
            this.LPassword.Size = new System.Drawing.Size(67, 20);
            this.LPassword.TabIndex = 10;
            this.LPassword.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(38, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Должность";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(38, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Телефон";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(38, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Почта";
            // 
            // MaskTBPhone
            // 
            this.MaskTBPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaskTBPhone.Location = new System.Drawing.Point(138, 191);
            this.MaskTBPhone.Mask = "+7(000) 000 00-00";
            this.MaskTBPhone.Name = "MaskTBPhone";
            this.MaskTBPhone.Size = new System.Drawing.Size(134, 26);
            this.MaskTBPhone.TabIndex = 14;
            // 
            // AddStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 348);
            this.Controls.Add(this.MaskTBPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.TBPost);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBFName);
            this.Controls.Add(this.TBSName);
            this.Controls.Add(this.BClose);
            this.Controls.Add(this.BEnter);
            this.Name = "AddStaff";
            this.Text = "NewGuy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BEnter;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.TextBox TBSName;
        private System.Windows.Forms.TextBox TBFName;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.TextBox TBPost;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox MaskTBPhone;
    }
}