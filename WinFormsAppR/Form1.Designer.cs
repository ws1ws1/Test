
namespace WinFormsAppR
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TextDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxDataSource = new System.Windows.Forms.TextBox();
            this.textBoxInitialCatalog = new System.Windows.Forms.TextBox();
            this.labelServerName = new System.Windows.Forms.Label();
            this.labelDBName = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 463);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(125, 35);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Flag,
            this.TextDB});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(343, 385);
            this.dataGridView1.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Flag
            // 
            this.Flag.HeaderText = "Flag";
            this.Flag.Name = "Flag";
            // 
            // TextDB
            // 
            this.TextDB.HeaderText = "Text";
            this.TextDB.Name = "TextDB";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(271, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxDataSource
            // 
            this.textBoxDataSource.Location = new System.Drawing.Point(76, 400);
            this.textBoxDataSource.Name = "textBoxDataSource";
            this.textBoxDataSource.Size = new System.Drawing.Size(139, 23);
            this.textBoxDataSource.TabIndex = 5;
            // 
            // textBoxInitialCatalog
            // 
            this.textBoxInitialCatalog.Location = new System.Drawing.Point(76, 429);
            this.textBoxInitialCatalog.Name = "textBoxInitialCatalog";
            this.textBoxInitialCatalog.Size = new System.Drawing.Size(100, 23);
            this.textBoxInitialCatalog.TabIndex = 6;
            // 
            // labelServerName
            // 
            this.labelServerName.AutoSize = true;
            this.labelServerName.Location = new System.Drawing.Point(12, 406);
            this.labelServerName.Name = "labelServerName";
            this.labelServerName.Size = new System.Drawing.Size(42, 15);
            this.labelServerName.TabIndex = 7;
            this.labelServerName.Text = "Server:";
            // 
            // labelDBName
            // 
            this.labelDBName.AutoSize = true;
            this.labelDBName.Location = new System.Drawing.Point(12, 432);
            this.labelDBName.Name = "labelDBName";
            this.labelDBName.Size = new System.Drawing.Size(58, 15);
            this.labelDBName.TabIndex = 8;
            this.labelDBName.Text = "DataBase:";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(230, 463);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(125, 35);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 510);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.labelDBName);
            this.Controls.Add(this.labelServerName);
            this.Controls.Add(this.textBoxInitialCatalog);
            this.Controls.Add(this.textBoxDataSource);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn TextDB;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxDataSource;
        private System.Windows.Forms.TextBox textBoxInitialCatalog;
        private System.Windows.Forms.Label labelServerName;
        private System.Windows.Forms.Label labelDBName;
        private System.Windows.Forms.Button buttonStop;
    }
}

