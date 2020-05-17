namespace CarRent.Forms
{
    partial class All_orders
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.numEnd = new System.Windows.Forms.NumericUpDown();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearchDateNum = new System.Windows.Forms.Button();
            this.gbNameS = new System.Windows.Forms.GroupBox();
            this.gbSNum = new System.Windows.Forms.GroupBox();
            this.btnSviewNum = new System.Windows.Forms.Button();
            this.btnSviewName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            this.gbNameS.SuspendLayout();
            this.gbSNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvOrders.Location = new System.Drawing.Point(12, 115);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.Size = new System.Drawing.Size(777, 386);
            this.dgvOrders.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.Width = 21;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Customer";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Car";
            this.Column3.Name = "Column3";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Plate";
            this.Column9.Name = "Column9";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Out date";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Returned Date";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Total price";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Activate";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Added date";
            this.Column8.Name = "Column8";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(9, 25);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(427, 27);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(458, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(6, 37);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(133, 20);
            this.dtpStart.TabIndex = 3;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(145, 38);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(133, 20);
            this.dtpEnd.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(650, 14);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(139, 28);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Download to Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // numEnd
            // 
            this.numEnd.Location = new System.Drawing.Point(389, 36);
            this.numEnd.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numEnd.Name = "numEnd";
            this.numEnd.Size = new System.Drawing.Size(88, 20);
            this.numEnd.TabIndex = 6;
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(295, 37);
            this.numStart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(88, 20);
            this.numStart.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "End date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "End price";
            // 
            // btnSearchDateNum
            // 
            this.btnSearchDateNum.Location = new System.Drawing.Point(506, 29);
            this.btnSearchDateNum.Name = "btnSearchDateNum";
            this.btnSearchDateNum.Size = new System.Drawing.Size(117, 28);
            this.btnSearchDateNum.TabIndex = 12;
            this.btnSearchDateNum.Text = "Search ";
            this.btnSearchDateNum.UseVisualStyleBackColor = true;
            this.btnSearchDateNum.Click += new System.EventHandler(this.btnSearchDateNum_Click);
            // 
            // gbNameS
            // 
            this.gbNameS.Controls.Add(this.txtSearch);
            this.gbNameS.Controls.Add(this.btnSearch);
            this.gbNameS.Location = new System.Drawing.Point(12, 19);
            this.gbNameS.Name = "gbNameS";
            this.gbNameS.Size = new System.Drawing.Size(595, 72);
            this.gbNameS.TabIndex = 13;
            this.gbNameS.TabStop = false;
            this.gbNameS.Text = "Search for Name";
            this.gbNameS.Visible = false;
            // 
            // gbSNum
            // 
            this.gbSNum.Controls.Add(this.dtpStart);
            this.gbSNum.Controls.Add(this.btnSearchDateNum);
            this.gbSNum.Controls.Add(this.dtpEnd);
            this.gbSNum.Controls.Add(this.numEnd);
            this.gbSNum.Controls.Add(this.label4);
            this.gbSNum.Controls.Add(this.numStart);
            this.gbSNum.Controls.Add(this.label3);
            this.gbSNum.Controls.Add(this.label1);
            this.gbSNum.Controls.Add(this.label2);
            this.gbSNum.Location = new System.Drawing.Point(12, 19);
            this.gbSNum.Name = "gbSNum";
            this.gbSNum.Size = new System.Drawing.Size(632, 72);
            this.gbSNum.TabIndex = 14;
            this.gbSNum.TabStop = false;
            this.gbSNum.Text = "Search for date and price";
            this.gbSNum.Visible = false;
            // 
            // btnSviewNum
            // 
            this.btnSviewNum.Location = new System.Drawing.Point(650, 79);
            this.btnSviewNum.Name = "btnSviewNum";
            this.btnSviewNum.Size = new System.Drawing.Size(138, 28);
            this.btnSviewNum.TabIndex = 16;
            this.btnSviewNum.Text = "Search for date and price";
            this.btnSviewNum.UseVisualStyleBackColor = true;
            this.btnSviewNum.Click += new System.EventHandler(this.btnSviewNum_Click);
            // 
            // btnSviewName
            // 
            this.btnSviewName.Location = new System.Drawing.Point(650, 45);
            this.btnSviewName.Name = "btnSviewName";
            this.btnSviewName.Size = new System.Drawing.Size(138, 28);
            this.btnSviewName.TabIndex = 15;
            this.btnSviewName.Text = "Search for name";
            this.btnSviewName.UseVisualStyleBackColor = true;
            this.btnSviewName.Click += new System.EventHandler(this.btnSviewName_Click);
            // 
            // All_orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.btnSviewName);
            this.Controls.Add(this.btnSviewNum);
            this.Controls.Add(this.gbSNum);
            this.Controls.Add(this.gbNameS);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.dgvOrders);
            this.Name = "All_orders";
            this.Text = "All_orders";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            this.gbNameS.ResumeLayout(false);
            this.gbNameS.PerformLayout();
            this.gbSNum.ResumeLayout(false);
            this.gbSNum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearchDateNum;
        private System.Windows.Forms.GroupBox gbNameS;
        private System.Windows.Forms.GroupBox gbSNum;
        private System.Windows.Forms.Button btnSviewNum;
        private System.Windows.Forms.Button btnSviewName;
    }
}