using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace WinFormsAppR
{
    public class DBOperation
    {
        private Task _task;
        public event EventHandler<TableChangedEventArgs> ChangeTable;

        private SqlConnection _connection;
        private SqlTableDependency<Table_1> _tableDependency;

        public void SetSqlConnection(SqlConnection connection)
        {
            _connection = connection;
        }

        public void StartOperations()
        {

            _task = Task.Run(() => _doOperarions());
        }

        public void StartTableDependency()
        {
            _tableDependency = new SqlTableDependency<Table_1>(_connection.ConnectionString);
            _tableDependency.OnChanged += _changeTable;
            _tableDependency.Start();
        }

        public void StopTableDependency()
        {
            if (_tableDependency != null)
            {
                _tableDependency.Stop();
            }
        }

        private void _doOperarions()
        {

            if (!_checkBase())
            {
                _addRows();
            }
            else
            {
                _updateRows();
            }
        }

        private bool _checkBase()
        {
            string queryString = "SELECT TOP(1) * from dbo.Table_1";
            SqlCommand command = new SqlCommand(queryString, _connection);
            SqlDataReader reader = command.ExecuteReader();
            var r = reader.HasRows;
            reader.Close();
            _connection.Close();
            return r;
        }
        private void _addRows()
        {
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();

            SqlCommand command = _connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    // выполняем команду
                    command.CommandText = $"INSERT INTO dbo.Table_1 (flag, text) VALUES(1, 'Hello {i}')";
                    command.ExecuteNonQuery();
                }

                // подтверждаем транзакцию
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // если ошибка, откатываем назад все изменения
                transaction.Rollback();
            }


        }

        private void _updateRows()
        {
            _connection.Open();
            SqlTransaction transaction = _connection.BeginTransaction();

            SqlCommand command = _connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                // выполняем команду
                command.CommandText = $"UPDATE dbo.Table_1 SET flag=0";
                command.ExecuteNonQuery();

                // подтверждаем транзакцию
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // если ошибка, откатываем назад все изменения
                transaction.Rollback();
            }
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetBoolean(1), record.GetString(2));
        }

        public void GetRows(DataGridView dgw)
        {
            string queryString = "SELECT * from dbo.Table_1";
            SqlCommand command = new SqlCommand(queryString, _connection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
            command.Dispose();
        }

        private void _changeTable(object sender, RecordChangedEventArgs<Table_1> rc)
        {
            var changedEntity = rc.Entity;

            TableChangedEventArgs row = new TableChangedEventArgs();
            row.Id = changedEntity.Id;
            row.Flag = changedEntity.Flag;
            row.Text = changedEntity.Text;
            row.ChangeType = rc.ChangeType.ToString();

            ChangeTable(this, row);
        }

        private void _errorTable(object sender, ErrorEventArgs er)
        {
            MessageBox.Show(er.Error.ToString());
        }
    }
}
