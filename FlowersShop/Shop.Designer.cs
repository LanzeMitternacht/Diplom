namespace FlowersShop
{
    partial class Shop
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
            this.TabCMain = new System.Windows.Forms.TabControl();
            this.Products = new System.Windows.Forms.TabPage();
            this.BEditProd = new System.Windows.Forms.Button();
            this.BSell = new System.Windows.Forms.Button();
            this.BAddProd = new System.Windows.Forms.Button();
            this.DataGridVShop = new System.Windows.Forms.DataGridView();
            this.Archive = new System.Windows.Forms.TabPage();
            this.DataGridArch = new System.Windows.Forms.DataGridView();
            this.Staff = new System.Windows.Forms.TabPage();
            this.BEditStaff = new System.Windows.Forms.Button();
            this.BAddStaff = new System.Windows.Forms.Button();
            this.DataGridVStaff = new System.Windows.Forms.DataGridView();
            this.Visitors = new System.Windows.Forms.TabPage();
            this.BEditVisitor = new System.Windows.Forms.Button();
            this.BAddVisitor = new System.Windows.Forms.Button();
            this.DataGirdVVisitor = new System.Windows.Forms.DataGridView();
            this.BClose = new System.Windows.Forms.Button();
            this.BDelete = new System.Windows.Forms.Button();
            this.BPrint = new System.Windows.Forms.Button();
            this.CBSearch = new System.Windows.Forms.ComboBox();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.BSearch = new System.Windows.Forms.Button();
            this.TabCMain.SuspendLayout();
            this.Products.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVShop)).BeginInit();
            this.Archive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridArch)).BeginInit();
            this.Staff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVStaff)).BeginInit();
            this.Visitors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdVVisitor)).BeginInit();
            this.SuspendLayout();
            // 
            // TabCMain
            // 
            this.TabCMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCMain.Controls.Add(this.Products);
            this.TabCMain.Controls.Add(this.Archive);
            this.TabCMain.Controls.Add(this.Staff);
            this.TabCMain.Controls.Add(this.Visitors);
            this.TabCMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabCMain.Location = new System.Drawing.Point(12, 12);
            this.TabCMain.Name = "TabCMain";
            this.TabCMain.SelectedIndex = 0;
            this.TabCMain.Size = new System.Drawing.Size(919, 467);
            this.TabCMain.TabIndex = 0;
            this.TabCMain.SelectedIndexChanged += new System.EventHandler(this.TabCMain_SelectedIndexChanged);
            // 
            // Products
            // 
            this.Products.Controls.Add(this.BEditProd);
            this.Products.Controls.Add(this.BSell);
            this.Products.Controls.Add(this.BAddProd);
            this.Products.Controls.Add(this.DataGridVShop);
            this.Products.Location = new System.Drawing.Point(4, 29);
            this.Products.Name = "Products";
            this.Products.Padding = new System.Windows.Forms.Padding(3);
            this.Products.Size = new System.Drawing.Size(911, 434);
            this.Products.TabIndex = 0;
            this.Products.Text = "Товар";
            this.Products.UseVisualStyleBackColor = true;
            // 
            // BEditProd
            // 
            this.BEditProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEditProd.Location = new System.Drawing.Point(6, 351);
            this.BEditProd.Name = "BEditProd";
            this.BEditProd.Size = new System.Drawing.Size(95, 77);
            this.BEditProd.TabIndex = 2;
            this.BEditProd.Text = "Редактировать";
            this.BEditProd.UseVisualStyleBackColor = true;
            this.BEditProd.Click += new System.EventHandler(this.BEditProd_Click);
            // 
            // BSell
            // 
            this.BSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BSell.Location = new System.Drawing.Point(802, 351);
            this.BSell.Name = "BSell";
            this.BSell.Size = new System.Drawing.Size(95, 77);
            this.BSell.TabIndex = 2;
            this.BSell.Text = "Продать";
            this.BSell.UseVisualStyleBackColor = true;
            this.BSell.Click += new System.EventHandler(this.BSell_Click);
            // 
            // BAddProd
            // 
            this.BAddProd.Location = new System.Drawing.Point(371, 364);
            this.BAddProd.Name = "BAddProd";
            this.BAddProd.Size = new System.Drawing.Size(158, 44);
            this.BAddProd.TabIndex = 1;
            this.BAddProd.Text = "Добавить";
            this.BAddProd.UseVisualStyleBackColor = true;
            this.BAddProd.Click += new System.EventHandler(this.BAddProd_Click);
            // 
            // DataGridVShop
            // 
            this.DataGridVShop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridVShop.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataGridVShop.Location = new System.Drawing.Point(3, 3);
            this.DataGridVShop.Name = "DataGridVShop";
            this.DataGridVShop.Size = new System.Drawing.Size(905, 342);
            this.DataGridVShop.TabIndex = 0;
            // 
            // Archive
            // 
            this.Archive.Controls.Add(this.DataGridArch);
            this.Archive.Location = new System.Drawing.Point(4, 29);
            this.Archive.Name = "Archive";
            this.Archive.Padding = new System.Windows.Forms.Padding(3);
            this.Archive.Size = new System.Drawing.Size(911, 434);
            this.Archive.TabIndex = 1;
            this.Archive.Text = "Архив";
            this.Archive.UseVisualStyleBackColor = true;
            // 
            // DataGridArch
            // 
            this.DataGridArch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridArch.Location = new System.Drawing.Point(3, 3);
            this.DataGridArch.Name = "DataGridArch";
            this.DataGridArch.Size = new System.Drawing.Size(894, 360);
            this.DataGridArch.TabIndex = 0;
            // 
            // Staff
            // 
            this.Staff.Controls.Add(this.BEditStaff);
            this.Staff.Controls.Add(this.BAddStaff);
            this.Staff.Controls.Add(this.DataGridVStaff);
            this.Staff.Location = new System.Drawing.Point(4, 29);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(911, 434);
            this.Staff.TabIndex = 2;
            this.Staff.Text = "Сотрудники";
            this.Staff.UseVisualStyleBackColor = true;
            // 
            // BEditStaff
            // 
            this.BEditStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEditStaff.Location = new System.Drawing.Point(735, 375);
            this.BEditStaff.Name = "BEditStaff";
            this.BEditStaff.Size = new System.Drawing.Size(149, 45);
            this.BEditStaff.TabIndex = 11;
            this.BEditStaff.Text = "Редактировать";
            this.BEditStaff.UseVisualStyleBackColor = true;
            this.BEditStaff.Click += new System.EventHandler(this.BEditStaff_Click);
            // 
            // BAddStaff
            // 
            this.BAddStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BAddStaff.Location = new System.Drawing.Point(22, 375);
            this.BAddStaff.Name = "BAddStaff";
            this.BAddStaff.Size = new System.Drawing.Size(155, 45);
            this.BAddStaff.TabIndex = 9;
            this.BAddStaff.Text = "Добавить";
            this.BAddStaff.UseVisualStyleBackColor = true;
            this.BAddStaff.Click += new System.EventHandler(this.BAddStaff_Click);
            // 
            // DataGridVStaff
            // 
            this.DataGridVStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridVStaff.Location = new System.Drawing.Point(3, 3);
            this.DataGridVStaff.Name = "DataGridVStaff";
            this.DataGridVStaff.Size = new System.Drawing.Size(897, 352);
            this.DataGridVStaff.TabIndex = 0;
            // 
            // Visitors
            // 
            this.Visitors.Controls.Add(this.BEditVisitor);
            this.Visitors.Controls.Add(this.BAddVisitor);
            this.Visitors.Controls.Add(this.DataGirdVVisitor);
            this.Visitors.Location = new System.Drawing.Point(4, 29);
            this.Visitors.Name = "Visitors";
            this.Visitors.Size = new System.Drawing.Size(911, 434);
            this.Visitors.TabIndex = 3;
            this.Visitors.Text = "Покупатели";
            this.Visitors.UseVisualStyleBackColor = true;
            // 
            // BEditVisitor
            // 
            this.BEditVisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BEditVisitor.Location = new System.Drawing.Point(748, 375);
            this.BEditVisitor.Name = "BEditVisitor";
            this.BEditVisitor.Size = new System.Drawing.Size(138, 42);
            this.BEditVisitor.TabIndex = 17;
            this.BEditVisitor.Text = "Редактировать";
            this.BEditVisitor.UseVisualStyleBackColor = true;
            this.BEditVisitor.Click += new System.EventHandler(this.BEditVisitor_Click);
            // 
            // BAddVisitor
            // 
            this.BAddVisitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BAddVisitor.Location = new System.Drawing.Point(17, 375);
            this.BAddVisitor.Name = "BAddVisitor";
            this.BAddVisitor.Size = new System.Drawing.Size(138, 42);
            this.BAddVisitor.TabIndex = 14;
            this.BAddVisitor.Text = "Добавить";
            this.BAddVisitor.UseVisualStyleBackColor = true;
            this.BAddVisitor.Click += new System.EventHandler(this.BAddVisitor_Click);
            // 
            // DataGirdVVisitor
            // 
            this.DataGirdVVisitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGirdVVisitor.Location = new System.Drawing.Point(3, 3);
            this.DataGirdVVisitor.Name = "DataGirdVVisitor";
            this.DataGirdVVisitor.Size = new System.Drawing.Size(897, 352);
            this.DataGirdVVisitor.TabIndex = 12;
            // 
            // BClose
            // 
            this.BClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BClose.Location = new System.Drawing.Point(152, 485);
            this.BClose.Name = "BClose";
            this.BClose.Size = new System.Drawing.Size(110, 43);
            this.BClose.TabIndex = 1;
            this.BClose.Text = "Выход";
            this.BClose.UseVisualStyleBackColor = true;
            this.BClose.Click += new System.EventHandler(this.BClose_Click);
            // 
            // BDelete
            // 
            this.BDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDelete.Location = new System.Drawing.Point(19, 485);
            this.BDelete.Name = "BDelete";
            this.BDelete.Size = new System.Drawing.Size(127, 43);
            this.BDelete.TabIndex = 2;
            this.BDelete.Text = "Удалить";
            this.BDelete.UseVisualStyleBackColor = true;
            this.BDelete.Click += new System.EventHandler(this.BDelete_Click);
            // 
            // BPrint
            // 
            this.BPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BPrint.Location = new System.Drawing.Point(824, 485);
            this.BPrint.Name = "BPrint";
            this.BPrint.Size = new System.Drawing.Size(103, 48);
            this.BPrint.TabIndex = 8;
            this.BPrint.Text = "Печать";
            this.BPrint.UseVisualStyleBackColor = true;
            this.BPrint.Click += new System.EventHandler(this.BPrint_Click);
            // 
            // CBSearch
            // 
            this.CBSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CBSearch.FormattingEnabled = true;
            this.CBSearch.Location = new System.Drawing.Point(387, 493);
            this.CBSearch.Name = "CBSearch";
            this.CBSearch.Size = new System.Drawing.Size(158, 28);
            this.CBSearch.TabIndex = 6;
            // 
            // TBSearch
            // 
            this.TBSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TBSearch.Location = new System.Drawing.Point(551, 493);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(265, 26);
            this.TBSearch.TabIndex = 5;
            // 
            // BSearch
            // 
            this.BSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BSearch.Location = new System.Drawing.Point(281, 485);
            this.BSearch.Name = "BSearch";
            this.BSearch.Size = new System.Drawing.Size(85, 48);
            this.BSearch.TabIndex = 9;
            this.BSearch.Text = "Поиск";
            this.BSearch.UseVisualStyleBackColor = true;
            this.BSearch.Click += new System.EventHandler(this.BTest_Click);
            // 
            // Shop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 545);
            this.Controls.Add(this.BSearch);
            this.Controls.Add(this.BPrint);
            this.Controls.Add(this.CBSearch);
            this.Controls.Add(this.TBSearch);
            this.Controls.Add(this.BClose);
            this.Controls.Add(this.TabCMain);
            this.Controls.Add(this.BDelete);
            this.Name = "Shop";
            this.Text = "Shop";
            this.TabCMain.ResumeLayout(false);
            this.Products.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVShop)).EndInit();
            this.Archive.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridArch)).EndInit();
            this.Staff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridVStaff)).EndInit();
            this.Visitors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGirdVVisitor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabCMain;
        private System.Windows.Forms.TabPage Products;
        private System.Windows.Forms.TabPage Archive;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.TabPage Staff;
        private System.Windows.Forms.TabPage Visitors;
        private System.Windows.Forms.DataGridView DataGridVShop;
        private System.Windows.Forms.Button BAddProd;
        private System.Windows.Forms.Button BEditProd;
        private System.Windows.Forms.Button BSell;
        private System.Windows.Forms.Button BDelete;
        private System.Windows.Forms.DataGridView DataGridArch;
        private System.Windows.Forms.Button BPrint;
        private System.Windows.Forms.Button BEditStaff;
        private System.Windows.Forms.Button BAddStaff;
        private System.Windows.Forms.DataGridView DataGridVStaff;
        private System.Windows.Forms.Button BEditVisitor;
        private System.Windows.Forms.Button BAddVisitor;
        private System.Windows.Forms.DataGridView DataGirdVVisitor;
        private System.Windows.Forms.ComboBox CBSearch;
        private System.Windows.Forms.TextBox TBSearch;
        private System.Windows.Forms.Button BSearch;
    }
}