namespace FlowersShop
{
    partial class Authentication
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.BEnter = new System.Windows.Forms.Button();
            this.BExit = new System.Windows.Forms.Button();
            this.BQrCode = new System.Windows.Forms.Button();
            this.TBLogin = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BEnter
            // 
            this.BEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEnter.Location = new System.Drawing.Point(50, 189);
            this.BEnter.Name = "BEnter";
            this.BEnter.Size = new System.Drawing.Size(97, 39);
            this.BEnter.TabIndex = 0;
            this.BEnter.Text = "Вход";
            this.BEnter.UseVisualStyleBackColor = true;
            this.BEnter.Click += new System.EventHandler(this.BEnter_Click);
            // 
            // BExit
            // 
            this.BExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BExit.Location = new System.Drawing.Point(191, 189);
            this.BExit.Name = "BExit";
            this.BExit.Size = new System.Drawing.Size(97, 39);
            this.BExit.TabIndex = 1;
            this.BExit.Text = "Выйти";
            this.BExit.UseVisualStyleBackColor = true;
            this.BExit.Click += new System.EventHandler(this.BExit_Click);
            // 
            // BQrCode
            // 
            this.BQrCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BQrCode.Location = new System.Drawing.Point(302, 12);
            this.BQrCode.Name = "BQrCode";
            this.BQrCode.Size = new System.Drawing.Size(37, 34);
            this.BQrCode.TabIndex = 2;
            this.BQrCode.UseVisualStyleBackColor = true;
            this.BQrCode.Click += new System.EventHandler(this.BQrCode_Click);
            // 
            // TBLogin
            // 
            this.TBLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBLogin.Location = new System.Drawing.Point(112, 75);
            this.TBLogin.Name = "TBLogin";
            this.TBLogin.Size = new System.Drawing.Size(176, 26);
            this.TBLogin.TabIndex = 3;
            // 
            // TBPassword
            // 
            this.TBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBPassword.Location = new System.Drawing.Point(112, 117);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '*';
            this.TBPassword.Size = new System.Drawing.Size(176, 26);
            this.TBPassword.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // Authentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 261);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBLogin);
            this.Controls.Add(this.BQrCode);
            this.Controls.Add(this.BExit);
            this.Controls.Add(this.BEnter);
            this.Name = "Authentication";
            this.Text = "Аунтефикация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BEnter;
        private System.Windows.Forms.Button BExit;
        private System.Windows.Forms.Button BQrCode;
        private System.Windows.Forms.TextBox TBLogin;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

