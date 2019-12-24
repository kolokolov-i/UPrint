using System;
using UPrint.database;
using Npgsql;
using UPrintServer;

namespace UPrint.accessor
{
    class TaskDataAccessor
    {
        private static String selection = "SELECT * FROM task";
        private static String insertion = "INSERT INTO task (id, name, person, job, date_add, time_start, time_end, status, printer) VALUES (@id, @name, @person, @job, @date_add, @time_start, @time_end, @status, @printer)";
        private static String updation = "UPDATE task SET name = @name, person = @person, job = @job, date_add = @date_add, time_start = @time_start, time_end = @time_end, status = @status, printer = @printer WHERE id = @id";
        private static String deletion = "DELETE FROM task WHERE id = @id";

        NpgsqlDataAdapter adapter;

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "task");
        }

        public void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "task");
            adapter.InsertCommand = new NpgsqlCommand(insertion, connection.GetConnection(), transaction.GetTransaction());
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "person", ParameterName = "@person" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "job", ParameterName = "@job" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "date_add", ParameterName = "@date_add" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "time_start", ParameterName = "@time_start" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "time_end", ParameterName = "@time_end" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "status", ParameterName = "@status" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "printer", ParameterName = "@printer" });
            adapter.UpdateCommand = new NpgsqlCommand(updation, connection.GetConnection(), transaction.GetTransaction());
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "person", ParameterName = "@person" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "job", ParameterName = "@job" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "date_add", ParameterName = "@date_add" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "time_start", ParameterName = "@time_start" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "time_end", ParameterName = "@time_end" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "status", ParameterName = "@status" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "printer", ParameterName = "@printer" });
            adapter.DeleteCommand = new NpgsqlCommand(deletion, connection.GetConnection(), transaction.GetTransaction());
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataSet, "task");
        }
    }
}
