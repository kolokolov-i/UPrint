using System;
using UPrint.database;
using Npgsql;
using UPrintServer;

namespace UPrint.accessor
{
    public class PrinterDataAccessor
    {

        private static String selection = "SELECT * FROM printer";
        private static String insertion = "INSERT INTO printer (id, name, status, active) VALUES (@id, @name, @status, @active)";
        private static String updation = "UPDATE printer SET name = @name, status = @status, active = @active WHERE id = @id";
        private static String deletion = "DELETE FROM printer WHERE id = @id";

        NpgsqlDataAdapter adapter;

        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        
        public void Read(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "printer");
        }

        public void Update(AbstractConnection connection, AbstractTransaction transaction, UPrintDataSet dataSet)
        {
            adapter.SelectCommand = new NpgsqlCommand(selection, connection.GetConnection(), transaction.GetTransaction());
            adapter.Fill(dataSet, "printer");
            adapter.InsertCommand = new NpgsqlCommand(insertion, connection.GetConnection(), transaction.GetTransaction());
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "status", ParameterName = "@status" });
            adapter.InsertCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "active", ParameterName = "@active" });
            adapter.UpdateCommand = new NpgsqlCommand(updation, connection.GetConnection(), transaction.GetTransaction());
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "name", ParameterName = "@name" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "status", ParameterName = "@status" });
            adapter.UpdateCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "active", ParameterName = "@active" });
            adapter.DeleteCommand = new NpgsqlCommand(deletion, connection.GetConnection(), transaction.GetTransaction());
            adapter.DeleteCommand.Parameters.Add(new NpgsqlParameter() { SourceColumn = "id", ParameterName = "@id" });
            NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(adapter);
            adapter.Update(dataSet, "printer");
        }
    }
}
