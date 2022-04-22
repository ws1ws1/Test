using System;

using System.Windows.Forms;

namespace WinFormsAppR
{
    public partial class Form1 : Form
    {
        DBConnection dbConnection = new DBConnection();
        DBOperation dbOperation = new DBOperation();
        public Form1()
        {
            InitializeComponent();
            dbOperation.ChangeTable += OnChangeTable;
            if (dbConnection.GetConnectionInfo().Count == 2)
            {
                textBoxDataSource.Text = dbConnection.GetConnectionInfo()[0];
                textBoxInitialCatalog.Text = dbConnection.GetConnectionInfo()[1];
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            dbConnection.SetSqlConnection(textBoxDataSource.Text, textBoxInitialCatalog.Text);
            dbConnection.Open();
            dbOperation.SetSqlConnection(dbConnection.GetConnection());
            dbOperation.StartTableDependency();

            dbOperation.StartOperations();
        }

        public void OnChangeTable(object sender, TableChangedEventArgs args)
        {
            if (args.ChangeType == "Insert")
            {
                
/*
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = args.Id;
                row.Cells[1].Value = args.Flag;
                row.Cells[2].Value = args.Text;
*/
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Rows.Add(args.Id, args.Flag, args.Text); }));
                    //                    dataGridView1.Invoke(new MethodInvoker(delegate { dataGridView1.Rows.Add(row); }));
                }
            }

            if (args.ChangeType == "Update")
            {
                for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == args.Id.ToString())
                    {
                        dataGridView1.Rows[i].Cells[1].Value = args.Flag;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxDataSource.Text) && !string.IsNullOrEmpty(textBoxInitialCatalog.Text))
            {
                dbConnection.SetSqlConnection(textBoxDataSource.Text, textBoxInitialCatalog.Text);
                dbConnection.Open();
                dbOperation.SetSqlConnection(dbConnection.GetConnection());
                dbOperation.GetRows(dataGridView1);
            }
            
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            dbOperation.StopTableDependency();
            dbConnection.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbOperation.StopTableDependency();
            dbConnection.Close();
        }
    }
}
